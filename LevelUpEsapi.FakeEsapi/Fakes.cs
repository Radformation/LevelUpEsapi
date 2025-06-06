﻿// <auto-generated>
//     This code was generated by a tool. Do not change this code directly.
// </auto-generated>

using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public partial class SerializableObject
    {
    }

    public partial class ApiDataObject : SerializableObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string HistoryUserName { get; set; }
        public DateTime HistoryDateTime { get; set; }
    }

    public partial class AddOn : ApiDataObject
    {
        public DateTime? CreationDateTime { get; set; }
    }

    public partial class AddOnMaterial : ApiDataObject
    {
    }

    public partial class Applicator : AddOn
    {
    }

    public partial class Dose : ApiDataObject
    {
        public DoseValue DoseMax3D { get; set; }
        public VVector DoseMax3DLocation { get; set; }
        public IEnumerable<Isodose> Isodoses { get; set; }
        public VVector Origin { get; set; }
        public Series Series { get; set; }
        public string SeriesUID { get; set; }
        public string UID { get; set; }
        public VVector XDirection { get; set; }
        public double XRes { get; set; }
        public int XSize { get; set; }
        public VVector YDirection { get; set; }
        public double YRes { get; set; }
        public int YSize { get; set; }
        public VVector ZDirection { get; set; }
        public double ZRes { get; set; }
        public int ZSize { get; set; }
    }

    public partial class BeamDose : Dose
    {
    }

    public partial class BeamParameters
    {
        public IEnumerable<ControlPointParameters> ControlPoints { get; set; }
        public GantryDirection GantryDirection { get; set; }
        public VVector Isocenter { get; set; }
        public double WeightFactor { get; set; }
    }

    public partial class BeamUncertainty : ApiDataObject
    {
        public Beam Beam { get; set; }
        public BeamNumber BeamNumber { get; set; }
        public Dose Dose { get; set; }
    }

    public partial class PlanningItem : ApiDataObject
    {
        public DateTime? CreationDateTime { get; set; }
        public PlanningItemDose Dose { get; set; }
        public DoseValuePresentation DoseValuePresentation { get; set; }
    }

    public partial class PlanSetup : PlanningItem
    {
        public string Id { get; set; }
        public double PlanNormalizationValue { get; set; }
        public IEnumerable<PlanUncertainty> PlanUncertainties { get; set; }
        public PlanSetupApprovalStatus ApprovalStatus { get; set; }
        public IEnumerable<Beam> Beams { get; set; }
        public Course Course { get; set; }
        public string CreationUserName { get; set; }
        public IEnumerable<EstimatedDVH> DVHEstimates { get; set; }
        public string ElectronCalculationModel { get; set; }
        public Dictionary<string, string> ElectronCalculationOptions { get; set; }
        public bool IsDoseValid { get; set; }
        public bool IsTreated { get; set; }
        public OptimizationSetup OptimizationSetup { get; set; }
        public string PhotonCalculationModel { get; set; }
        public Dictionary<string, string> PhotonCalculationOptions { get; set; }
        public string PlanIntent { get; set; }
        public string PlanningApprovalDate { get; set; }
        public string PlanningApprover { get; set; }
        public string PlanNormalizationMethod { get; set; }
        public VVector PlanNormalizationPoint { get; set; }
        public PlanType PlanType { get; set; }
        public double PrescribedPercentage { get; set; }
        public ReferencePoint PrimaryReferencePoint { get; set; }
        public string ProtocolID { get; set; }
        public string ProtocolPhaseID { get; set; }
        public string ProtonCalculationModel { get; set; }
        public Dictionary<string, string> ProtonCalculationOptions { get; set; }
        public Series Series { get; set; }
        public string SeriesUID { get; set; }
        public StructureSet StructureSet { get; set; }
        public string TargetVolumeID { get; set; }
        public DoseValue TotalPrescribedDose { get; set; }
        public string TreatmentApprovalDate { get; set; }
        public string TreatmentApprover { get; set; }
        public PatientOrientation TreatmentOrientation { get; set; }
        public string UID { get; set; }
        public Fractionation UniqueFractionation { get; set; }
        public PlanSetup VerifiedPlan { get; set; }
    }

    public partial class BrachyPlanSetup : PlanSetup
    {
        public string ApplicationSetupType { get; set; }
        public IEnumerable<Catheter> Catheters { get; set; }
        public Int32? NumberOfPdrPulses { get; set; }
        public Double? PdrPulseInterval { get; set; }
        public IEnumerable<SeedCollection> SeedCollections { get; set; }
        public IEnumerable<BrachySolidApplicator> SolidApplicators { get; set; }
        public DateTime? TreatmentDateTime { get; set; }
        public string TreatmentTechnique { get; set; }
    }

    public partial class BrachySolidApplicator : ApiDataObject
    {
        public string ApplicatorSetName { get; set; }
        public string ApplicatorSetType { get; set; }
        public string Category { get; set; }
        public IEnumerable<Catheter> Catheters { get; set; }
        public string Note { get; set; }
        public string PartName { get; set; }
        public string PartNumber { get; set; }
        public string Summary { get; set; }
        public string UID { get; set; }
        public string Vendor { get; set; }
        public string Version { get; set; }
    }

    public partial class BrachyTreatmentUnit : ApiDataObject
    {
        public string DoseRateMode { get; set; }
        public double DwellTimeResolution { get; set; }
        public string MachineInterface { get; set; }
        public string MachineModel { get; set; }
        public double MaxDwellTimePerChannel { get; set; }
        public double MaxDwellTimePerPos { get; set; }
        public double MaxDwellTimePerTreatment { get; set; }
        public double MaximumChannelLength { get; set; }
        public int MaximumDwellPositionsPerChannel { get; set; }
        public double MaximumStepSize { get; set; }
        public double MinimumChannelLength { get; set; }
        public double MinimumStepSize { get; set; }
        public int NumberOfChannels { get; set; }
        public double SourceCenterOffsetFromTip { get; set; }
        public string SourceMovementType { get; set; }
        public double StepSizeResolution { get; set; }
    }

    public partial class Catheter : ApiDataObject
    {
        public double ApplicatorLength { get; set; }
        public int BrachySolidApplicatorPartID { get; set; }
        public int ChannelNumber { get; set; }
        public Color Color { get; set; }
        public VVector[] Shape { get; set; }
        public IEnumerable<SourcePosition> SourcePositions { get; set; }
        public double StepSize { get; set; }
        public BrachyTreatmentUnit TreatmentUnit { get; set; }
    }

    public partial class ControlPointParameters
    {
        public double CollimatorAngle { get; set; }
        public double GantryAngle { get; set; }
        public int Index { get; set; }
        public VRect<double> JawPositions { get; set; }
        public Single[,] LeafPositions { get; set; }
        public double MetersetWeight { get; set; }
        public double PatientSupportAngle { get; set; }
        public double TableTopLateralPosition { get; set; }
        public double TableTopLongitudinalPosition { get; set; }
        public double TableTopVerticalPosition { get; set; }
    }

    public partial class Beam : ApiDataObject
    {
        public string Id { get; set; }
        public MetersetValue Meterset { get; set; }
        public ExternalBeam ExternalBeam { get; set; }
        public int BeamNumber { get; set; }
        public Applicator Applicator { get; set; }
        public double ArcLength { get; set; }
        public double AverageSSD { get; set; }
        public IEnumerable<Block> Blocks { get; set; }
        public IEnumerable<Bolus> Boluses { get; set; }
        public IEnumerable<BeamCalculationLog> CalculationLogs { get; set; }
        public Compensator Compensator { get; set; }
        public ControlPointCollection ControlPoints { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public BeamDose Dose { get; set; }
        public int DoseRate { get; set; }
        public double DosimetricLeafGap { get; set; }
        public string EnergyModeDisplayName { get; set; }
        public IEnumerable<FieldReferencePoint> FieldReferencePoints { get; set; }
        public GantryDirection GantryDirection { get; set; }
        public VVector IsocenterPosition { get; set; }
        public bool IsSetupField { get; set; }
        public double MetersetPerGy { get; set; }
        public MLC MLC { get; set; }
        public MLCPlanType MLCPlanType { get; set; }
        public double MLCTransmissionFactor { get; set; }
        public double NormalizationFactor { get; set; }
        public string NormalizationMethod { get; set; }
        public double PlannedSSD { get; set; }
        public Image ReferenceImage { get; set; }
        public SetupTechnique SetupTechnique { get; set; }
        public double SSD { get; set; }
        public double SSDAtStopAngle { get; set; }
        public Technique Technique { get; set; }
        public string ToleranceTableLabel { get; set; }
        public IEnumerable<Tray> Trays { get; set; }
        public ExternalBeamTreatmentUnit TreatmentUnit { get; set; }
        public IEnumerable<Wedge> Wedges { get; set; }
        public double WeightFactor { get; set; }
    }

    public partial class Course : ApiDataObject
    {
        public string Id { get; set; }
        public IEnumerable<PlanSetup> PlanSetups { get; set; }
        public IEnumerable<ExternalPlanSetup> ExternalPlanSetups { get; set; }
        public IEnumerable<BrachyPlanSetup> BrachyPlanSetups { get; set; }
        public IEnumerable<IonPlanSetup> IonPlanSetups { get; set; }
        public DateTime? CompletedDateTime { get; set; }
        public IEnumerable<Diagnosis> Diagnoses { get; set; }
        public string Intent { get; set; }
        public Patient Patient { get; set; }
        public IEnumerable<PlanSum> PlanSums { get; set; }
        public DateTime? StartDateTime { get; set; }
    }

    public partial class OptimizerDVH
    {
        public DVHPoint[] CurveData { get; set; }
        public Structure Structure { get; set; }
    }

    public partial class OptimizerObjectiveValue
    {
        public Structure Structure { get; set; }
        public double Value { get; set; }
    }

    public partial class ExternalPlanSetup : PlanSetup
    {
        public EvaluationDose DoseAsEvaluationDose { get; set; }
    }

    public partial class ExternalBeam : ApiDataObject
    {
        public double SourceAxisDistance { get; set; }
        public string MachineModel { get; set; }
        public string MachineModelName { get; set; }
        public string MachineScaleDisplayName { get; set; }
    }

    public partial class IonBeamParameters : BeamParameters
    {
        public IEnumerable<IonControlPointParameters> ControlPoints { get; set; }
        public IonControlPointPairCollection IonControlPointPairs { get; set; }
    }

    public partial class IonPlanSetup : PlanSetup
    {
        public bool IsPostProcessingNeeded { get; set; }
        public EvaluationDose DoseAsEvaluationDose { get; set; }
        public IEnumerable<IonBeam> IonBeams { get; set; }
    }

    public partial class OptimizationSetup : SerializableObject
    {
        public bool UseJawTracking { get; set; }
        public IEnumerable<OptimizationObjective> Objectives { get; set; }
        public IEnumerable<OptimizationParameter> Parameters { get; set; }
    }

    public partial class CalculationResult
    {
        public bool Success { get; set; }
    }

    public partial class OptimizerResult : CalculationResult
    {
        public IEnumerable<OptimizerDVH> StructureDVHs { get; set; }
        public IEnumerable<OptimizerObjectiveValue> StructureObjectiveValues { get; set; }
        public double TotalObjectiveFunctionValue { get; set; }
        public int NumberOfIMRTOptimizerIterations { get; set; }
    }

    public partial class Structure : ApiDataObject
    {
        public string Id { get; set; }
        public VVector CenterPoint { get; set; }
        public Color Color { get; set; }
        public string DicomType { get; set; }
        public bool HasSegment { get; set; }
        public bool IsEmpty { get; set; }
        public bool IsHighResolution { get; set; }
        public MeshGeometry3D MeshGeometry { get; set; }
        public int ROINumber { get; set; }
        public SegmentVolume SegmentVolume { get; set; }
        public IEnumerable<StructureCodeInfo> StructureCodeInfos { get; set; }
        public double Volume { get; set; }
    }

    public partial class StructureSet : ApiDataObject
    {
        public IEnumerable<Structure> Structures { get; set; }
        public Image Image { get; set; }
        public string UID { get; set; }
    }

    public partial class TypeBasedIdValidator
    {
    }

    public partial class Diagnosis : ApiDataObject
    {
        public string ClinicalDescription { get; set; }
        public string Code { get; set; }
        public string CodeTable { get; set; }
    }

    public partial class EstimatedDVH : ApiDataObject
    {
        public DVHPoint[] CurveData { get; set; }
        public PlanSetup PlanSetup { get; set; }
        public string PlanSetupId { get; set; }
        public Structure Structure { get; set; }
        public string StructureId { get; set; }
        public DoseValue TargetDoseLevel { get; set; }
        public DVHEstimateType Type { get; set; }
    }

    public partial class EvaluationDose : Dose
    {
    }

    public partial class ExternalBeamTreatmentUnit : ApiDataObject
    {
        public string MachineModel { get; set; }
        public string MachineModelName { get; set; }
        public string MachineScaleDisplayName { get; set; }
        public double SourceAxisDistance { get; set; }
    }

    public partial class IonBeam : Beam
    {
        public double AirGap { get; set; }
        public double DistalTargetMargin { get; set; }
        public VRect<double> LateralMargins { get; set; }
        public IEnumerable<LateralSpreadingDevice> LateralSpreadingDevices { get; set; }
        public double NominalRange { get; set; }
        public double NominalSOBPWidth { get; set; }
        public string OptionId { get; set; }
        public string PatientSupportId { get; set; }
        public PatientSupportType PatientSupportType { get; set; }
        public IonControlPointCollection IonControlPoints { get; set; }
        public double ProximalTargetMargin { get; set; }
        public IEnumerable<RangeModulator> RangeModulators { get; set; }
        public IEnumerable<RangeShifter> RangeShifters { get; set; }
        public IonBeamScanMode ScanMode { get; set; }
        public string SnoutId { get; set; }
        public Structure TargetStructure { get; set; }
        public double VirtualSADX { get; set; }
        public double VirtualSADY { get; set; }
    }

    public partial class ControlPoint : SerializableObject
    {
        public double CollimatorAngle { get; set; }
        public double GantryAngle { get; set; }
        public int Index { get; set; }
        public VRect<double> JawPositions { get; set; }
        public Single[,] LeafPositions { get; set; }
        public double MetersetWeight { get; set; }
        public double PatientSupportAngle { get; set; }
        public double TableTopLateralPosition { get; set; }
        public double TableTopLongitudinalPosition { get; set; }
        public double TableTopVerticalPosition { get; set; }
    }

    public partial class IonControlPoint : ControlPoint
    {
        public IonSpotCollection FinalSpotList { get; set; }
        public IEnumerable<LateralSpreadingDeviceSettings> LateralSpreadingDeviceSettings { get; set; }
        public double NominalBeamEnergy { get; set; }
        public int NumberOfPaintings { get; set; }
        public IEnumerable<RangeModulatorSettings> RangeModulatorSettings { get; set; }
        public IEnumerable<RangeShifterSettings> RangeShifterSettings { get; set; }
        public IonSpotCollection RawSpotList { get; set; }
        public double ScanningSpotSizeX { get; set; }
        public double ScanningSpotSizeY { get; set; }
        public string ScanSpotTuneId { get; set; }
        public double SnoutPosition { get; set; }
    }

    public partial class IonControlPointCollection : SerializableObject
    {
        public int Count { get; set; }
    }

    public partial class IonControlPointPair
    {
        public IonControlPointParameters EndControlPoint { get; set; }
        public IonSpotParametersCollection FinalSpotList { get; set; }
        public double NominalBeamEnergy { get; set; }
        public IonSpotParametersCollection RawSpotList { get; set; }
        public IonControlPointParameters StartControlPoint { get; set; }
        public int StartIndex { get; set; }
    }

    public partial class IonControlPointPairCollection
    {
        public int Count { get; set; }
    }

    public partial class IonControlPointParameters : ControlPointParameters
    {
        public IonSpotParametersCollection FinalSpotList { get; set; }
        public IonSpotParametersCollection RawSpotList { get; set; }
    }

    public partial class IonSpot : SerializableObject
    {
        public VVector Position { get; set; }
        public float Weight { get; set; }
    }

    public partial class IonSpotCollection : SerializableObject
    {
        public int Count { get; set; }
    }

    public partial class IonSpotParameters : SerializableObject
    {
        public float Weight { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }

    public partial class IonSpotParametersCollection : SerializableObject
    {
        public int Count { get; set; }
    }

    public partial class LateralSpreadingDevice : AddOn
    {
        public LateralSpreadingDeviceType Type { get; set; }
    }

    public partial class LateralSpreadingDeviceSettings : SerializableObject
    {
        public double IsocenterToLateralSpreadingDeviceDistance { get; set; }
        public string LateralSpreadingDeviceSetting { get; set; }
        public double LateralSpreadingDeviceWaterEquivalentThickness { get; set; }
        public LateralSpreadingDevice ReferencedLateralSpreadingDevice { get; set; }
    }

    public partial class OptimizationObjective : SerializableObject
    {
        public Structure Structure { get; set; }
        public string StructureId { get; set; }
    }

    public partial class OptimizationEUDObjective : OptimizationObjective
    {
        public DoseValue Dose { get; set; }
        public OptimizationObjectiveOperator Operator { get; set; }
        public double ParameterA { get; set; }
        public double Priority { get; set; }
    }

    public partial class OptimizationParameter : SerializableObject
    {
    }

    public partial class OptimizationExcludeStructureParameter : OptimizationParameter
    {
        public Structure Structure { get; set; }
    }

    public partial class OptimizationIMRTBeamParameter : OptimizationParameter
    {
        public Beam Beam { get; set; }
        public string BeamId { get; set; }
        public bool Excluded { get; set; }
        public bool FixedJaws { get; set; }
        public double SmoothX { get; set; }
        public double SmoothY { get; set; }
    }

    public partial class OptimizationJawTrackingUsedParameter : OptimizationParameter
    {
    }

    public partial class OptimizationLineObjective : OptimizationObjective
    {
        public DVHPoint[] CurveData { get; set; }
        public OptimizationObjectiveOperator Operator { get; set; }
        public double Priority { get; set; }
    }

    public partial class OptimizationMeanDoseObjective : OptimizationObjective
    {
        public DoseValue Dose { get; set; }
        public double Priority { get; set; }
    }

    public partial class OptimizationNormalTissueParameter : OptimizationParameter
    {
        public double DistanceFromTargetBorderInMM { get; set; }
        public double EndDosePercentage { get; set; }
        public double FallOff { get; set; }
        public bool IsAutomatic { get; set; }
        public double Priority { get; set; }
        public double StartDosePercentage { get; set; }
    }

    public partial class OptimizationPointCloudParameter : OptimizationParameter
    {
        public double PointResolutionInMM { get; set; }
        public Structure Structure { get; set; }
    }

    public partial class OptimizationPointObjective : OptimizationObjective
    {
        public DoseValue Dose { get; set; }
        public OptimizationObjectiveOperator Operator { get; set; }
        public double Priority { get; set; }
        public double Volume { get; set; }
    }

    public partial class PlanningItemDose : Dose
    {
    }

    public partial class PlanSumComponent : ApiDataObject
    {
        public string PlanSetupId { get; set; }
        public PlanSumOperation PlanSumOperation { get; set; }
        public double PlanWeight { get; set; }
    }

    public partial class PlanUncertainty : ApiDataObject
    {
        public IEnumerable<BeamUncertainty> BeamUncertainties { get; set; }
        public double CalibrationCurveError { get; set; }
        public string DisplayName { get; set; }
        public Dose Dose { get; set; }
        public VVector IsocenterShift { get; set; }
        public PlanUncertaintyType UncertaintyType { get; set; }
    }

    public partial class RadioactiveSource : ApiDataObject
    {
        public DateTime? CalibrationDate { get; set; }
        public bool NominalActivity { get; set; }
        public RadioactiveSourceModel RadioactiveSourceModel { get; set; }
        public string SerialNumber { get; set; }
        public double Strength { get; set; }
    }

    public partial class RadioactiveSourceModel : ApiDataObject
    {
        public VVector ActiveSize { get; set; }
        public double ActivityConversionFactor { get; set; }
        public string CalculationModel { get; set; }
        public double DoseRateConstant { get; set; }
        public double HalfLife { get; set; }
        public string LiteratureReference { get; set; }
        public string Manufacturer { get; set; }
        public string SourceType { get; set; }
        public string Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public string StatusUserName { get; set; }
    }

    public partial class RangeModulator : AddOn
    {
        public RangeModulatorType Type { get; set; }
    }

    public partial class RangeModulatorSettings : SerializableObject
    {
        public double IsocenterToRangeModulatorDistance { get; set; }
        public double RangeModulatorGatingStartValue { get; set; }
        public double RangeModulatorGatingStarWaterEquivalentThickness { get; set; }
        public double RangeModulatorGatingStopValue { get; set; }
        public double RangeModulatorGatingStopWaterEquivalentThickness { get; set; }
        public RangeModulator ReferencedRangeModulator { get; set; }
    }

    public partial class RangeShifter : AddOn
    {
        public RangeShifterType Type { get; set; }
    }

    public partial class RangeShifterSettings : SerializableObject
    {
        public double IsocenterToRangeShifterDistance { get; set; }
        public string RangeShifterSetting { get; set; }
        public double RangeShifterWaterEquivalentThickness { get; set; }
        public RangeShifter ReferencedRangeShifter { get; set; }
    }

    public partial class SeedCollection : ApiDataObject
    {
        public Color Color { get; set; }
        public IEnumerable<SourcePosition> SourcePositions { get; set; }
    }

    public partial class SegmentVolume : SerializableObject
    {
    }

    public partial class SourcePosition : ApiDataObject
    {
        public double DwellTime { get; set; }
        public RadioactiveSource RadioactiveSource { get; set; }
        public Double[,] Transform { get; set; }
        public VVector Translation { get; set; }
    }

    public partial class Wedge : AddOn
    {
        public double Direction { get; set; }
        public double WedgeAngle { get; set; }
    }

    public partial class StandardWedge : Wedge
    {
    }

    public partial class BeamCalculationLog : SerializableObject
    {
        public string Category { get; set; }
        public IEnumerable<string> MessageLines { get; set; }
    }

    public partial class Block : ApiDataObject
    {
        public AddOnMaterial AddOnMaterial { get; set; }
        public bool IsDiverging { get; set; }
        public double TransmissionFactor { get; set; }
        public Tray Tray { get; set; }
        public double TrayTransmissionFactor { get; set; }
        public BlockType Type { get; set; }
    }

    public partial class Bolus : SerializableObject
    {
        public string Id { get; set; }
        public double MaterialCTValue { get; set; }
        public string Name { get; set; }
    }

    public partial class Compensator : ApiDataObject
    {
        public AddOnMaterial Material { get; set; }
        public Slot Slot { get; set; }
        public Tray Tray { get; set; }
    }

    public partial class ControlPointCollection : SerializableObject
    {
        public int Count { get; set; }
    }

    public partial class Application : SerializableObject
    {
        public User CurrentUser { get; set; }
        public IEnumerable<PatientSummary> PatientSummaries { get; set; }
    }

    public partial class Globals
    {
    }

    public partial class DVHData : SerializableObject
    {
        public double Coverage { get; set; }
        public DVHPoint[] CurveData { get; set; }
        public DoseValue MaxDose { get; set; }
        public DoseValue MeanDose { get; set; }
        public DoseValue MedianDose { get; set; }
        public DoseValue MinDose { get; set; }
        public double SamplingCoverage { get; set; }
        public double StdDev { get; set; }
        public double Volume { get; set; }
    }

    public partial class DynamicWedge : Wedge
    {
    }

    public partial class EnhancedDynamicWedge : DynamicWedge
    {
    }

    public partial class FieldReferencePoint : ApiDataObject
    {
        public double EffectiveDepth { get; set; }
        public DoseValue FieldDose { get; set; }
        public bool IsFieldDoseNominal { get; set; }
        public bool IsPrimaryReferencePoint { get; set; }
        public ReferencePoint ReferencePoint { get; set; }
        public VVector RefPointLocation { get; set; }
        public double SSD { get; set; }
    }

    public partial class Fractionation : ApiDataObject
    {
        public DateTime? CreationDateTime { get; set; }
        public DoseValue DosePerFractionInPrimaryRefPoint { get; set; }
        public Int32? NumberOfFractions { get; set; }
        public DoseValue PrescribedDosePerFraction { get; set; }
    }

    public partial class Hospital : ApiDataObject
    {
        public DateTime? CreationDateTime { get; set; }
        public string Location { get; set; }
    }

    public partial class Image : ApiDataObject
    {
        public string ContrastBolusAgentIngredientName { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public string DisplayUnit { get; set; }
        public string FOR { get; set; }
        public bool HasUserOrigin { get; set; }
        public PatientOrientation ImagingOrientation { get; set; }
        public bool IsProcessed { get; set; }
        public int Level { get; set; }
        public VVector Origin { get; set; }
        public Series Series { get; set; }
        public VVector UserOrigin { get; set; }
        public string UserOriginComments { get; set; }
        public int Window { get; set; }
        public VVector XDirection { get; set; }
        public double XRes { get; set; }
        public int XSize { get; set; }
        public VVector YDirection { get; set; }
        public double YRes { get; set; }
        public int YSize { get; set; }
        public VVector ZDirection { get; set; }
        public double ZRes { get; set; }
        public int ZSize { get; set; }
    }

    public partial class ScriptContext
    {
        public User CurrentUser { get; set; }
        public Course Course { get; set; }
        public Image Image { get; set; }
        public StructureSet StructureSet { get; set; }
        public Patient Patient { get; set; }
        public PlanSetup PlanSetup { get; set; }
        public ExternalPlanSetup ExternalPlanSetup { get; set; }
        public BrachyPlanSetup BrachyPlanSetup { get; set; }
        public IonPlanSetup IonPlanSetup { get; set; }
        public IEnumerable<PlanSetup> PlansInScope { get; set; }
        public IEnumerable<ExternalPlanSetup> ExternalPlansInScope { get; set; }
        public IEnumerable<BrachyPlanSetup> BrachyPlansInScope { get; set; }
        public IEnumerable<IonPlanSetup> IonPlansInScope { get; set; }
        public IEnumerable<PlanSum> PlanSumsInScope { get; set; }
        public string ApplicationName { get; set; }
        public string VersionInfo { get; set; }
    }

    public partial class Isodose : SerializableObject
    {
        public Color Color { get; set; }
        public DoseValue Level { get; set; }
        public MeshGeometry3D MeshGeometry { get; set; }
    }

    public partial class MLC : AddOn
    {
        public string ManufacturerName { get; set; }
        public double MinDoseDynamicLeafGap { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
    }

    public partial class MotorizedWedge : Wedge
    {
    }

    public partial class OmniWedge : Wedge
    {
    }

    public partial class Patient : ApiDataObject
    {
        public IEnumerable<Course> Courses { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public bool HasModifiedData { get; set; }
        public Hospital Hospital { get; set; }
        public string Id2 { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PrimaryOncologistId { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }
        public string Sex { get; set; }
        public string SSN { get; set; }
        public IEnumerable<StructureSet> StructureSets { get; set; }
        public IEnumerable<Study> Studies { get; set; }
    }

    public partial class PatientSummary : SerializableObject
    {
        public DateTime? CreationDateTime { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string Id { get; set; }
        public string Id2 { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Sex { get; set; }
        public string SSN { get; set; }
    }

    public partial class PlanSum : PlanningItem
    {
        public Course Course { get; set; }
        public IEnumerable<PlanSumComponent> PlanSumComponents { get; set; }
        public StructureSet StructureSet { get; set; }
        public IEnumerable<PlanSetup> PlanSetups { get; set; }
    }

    public partial class ReferencePoint : ApiDataObject
    {
    }

    public partial class Registration : ApiDataObject
    {
        public DateTime? CreationDateTime { get; set; }
        public string RegisteredFOR { get; set; }
        public string SourceFOR { get; set; }
        public Double[,] TransformationMatrix { get; set; }
    }

    public partial class Series : ApiDataObject
    {
        public string FOR { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public string ImagingDeviceId { get; set; }
        public string ImagingDeviceManufacturer { get; set; }
        public string ImagingDeviceModel { get; set; }
        public string ImagingDeviceSerialNo { get; set; }
        public SeriesModality Modality { get; set; }
        public Study Study { get; set; }
        public string UID { get; set; }
    }

    public partial class Slot : ApiDataObject
    {
        public int Number { get; set; }
    }

    public partial class Study : ApiDataObject
    {
        public DateTime? CreationDateTime { get; set; }
        public IEnumerable<Series> Series { get; set; }
        public string UID { get; set; }
    }

    public partial class Technique : ApiDataObject
    {
    }

    public partial class Tray : AddOn
    {
    }

    public partial class User : ApiDataObject
    {
        public string Language { get; set; }
    }

}

