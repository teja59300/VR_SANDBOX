using System;

namespace Domain
{
    public class Financial
    {
        public int Id { get; set; }
        public int TotalAmount { get; set; }
        public int TotalAcres { get; set; }
        public int TotalExpenses { get; set; }
        public int NetProfit { get; set; }
        public Activity Activity { get; set; }
        
    }
}