using System;
using System.Collections.Generic;
using System.Linq;
using ESAPI = VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace LevelUpEsapi.DoseMetrics.esapi
{
    public class EsapiService : ITpsService
    {
        private const double DVH_BIN_WIDTH = 0.01;

        private readonly ESAPI.ScriptContext _context;

        public EsapiService(ESAPI.ScriptContext context)
        {
            _context = context;
        }

        public Structure[] GetStructures()
        {
            return _context.StructureSet.Structures.Select(Convert).ToArray();
        }

        public DvhData CreateDvh(string structureId)
        {
            ESAPI.Structure structure = FindEsapiStructure(structureId);
            ESAPI.DVHData dvhData = CreateEsapiDvh(structure);
            return Convert(dvhData);
        }

        private ESAPI.Structure FindEsapiStructure(string structureId)
        {
            IEnumerable<ESAPI.Structure> structures = _context.StructureSet.Structures;
            return structures.FirstOrDefault(s => s.Id == structureId);
        }

        private ESAPI.DVHData CreateEsapiDvh(ESAPI.Structure structure)
        {
            return _context.PlanSetup.GetDVHCumulativeData(
                structure, DoseValuePresentation.Absolute, VolumePresentation.AbsoluteCm3, DVH_BIN_WIDTH);
        }

        private static Structure Convert(ESAPI.Structure s)
        {
            return new Structure
            {
                Id = s.Id,
                VolumeCc = s.Volume,
                IsEmpty = s.IsEmpty,
                Color = s.Color,
            };
        }

        private DvhData Convert(ESAPI.DVHData dvhData)
        {
            return new DvhData
            {
                Points = dvhData.CurveData.Select(Convert).ToArray(),
                MeanDoseGy = ConvertToGy(dvhData.MeanDose),
                MinDoseGy = ConvertToGy(dvhData.MinDose),
                MaxDoseGy = ConvertToGy(dvhData.MaxDose),
                RxDoseGy = ConvertToGy(_context.PlanSetup.TotalPrescribedDose),
                VolumeCc = dvhData.Volume,
            };
        }

        private static DvhPoint Convert(DVHPoint point)
        {
            return new DvhPoint(ConvertToGy(point.DoseValue), point.Volume);
        }

        private static double ConvertToGy(DoseValue dose)
        {
            switch (dose.Unit)
            {
                case DoseValue.DoseUnit.Gy: return dose.Dose;
                case DoseValue.DoseUnit.cGy: return dose.Dose / 100.0;

                // dose is expected to be in Absolute units
                case DoseValue.DoseUnit.Percent:
                case DoseValue.DoseUnit.Unknown:
                default: throw new Exception($"Unexpected dose unit {dose.Unit}");
            }
        }
    }
}