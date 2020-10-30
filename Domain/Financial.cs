using System;

namespace Domain
{
    public class Financial
    {
        public int FinancialId { get; set; }
        public Guid ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        public string TotalActivities { get; set; }
        public string TotalAmount { get; set; }
        public string TotalAcresDone { get; set; }
        public string Expenditure { get; set; }
        public string Profit { get; set; }

    }
}