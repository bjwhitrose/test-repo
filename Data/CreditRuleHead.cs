﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace PlanningSystem.Data
{
    public partial class CreditRuleHead
    {
        public CreditRuleHead()
        {
            CreditRuleDetail = new HashSet<CreditRuleDetail>();
        }

        public int Ruleid { get; set; }
        public string Rulename { get; set; }
        public string RuleContent { get; set; }
        public DateTime Createdate { get; set; }
        public string Createdby { get; set; }
        public DateTime Modifieddate { get; set; }
        public string Modifiedby { get; set; }

        public virtual ICollection<CreditRuleDetail> CreditRuleDetail { get; set; }
    }
}