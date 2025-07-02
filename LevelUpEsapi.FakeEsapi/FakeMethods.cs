using System;
using VMS.TPS.Common.Model.Types;

namespace VMS.TPS.Common.Model.API
{
    public partial class PlanningItem
    {
        public Func<Structure, DoseValuePresentation, VolumePresentation, double, DVHData> GetDVHCumulativeData { get; set; }
    }
}
