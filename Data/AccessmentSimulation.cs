﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace PlanningSystem.Data
{
    public partial class AccessmentSimulation
    {
        public long Simulationid { get; set; }
        public DateTime? TargetDate { get; set; }
        public string SimulationName { get; set; }
        public long? Planid { get; set; }
        public long? Tierplanid { get; set; }
        public int? StateRule { get; set; }
        public int? Confirmed { get; set; }
        public DateTime Createdate { get; set; }
        public string Createdby { get; set; }
        public DateTime Modifieddate { get; set; }
        public string Modifiedby { get; set; }
    }
}