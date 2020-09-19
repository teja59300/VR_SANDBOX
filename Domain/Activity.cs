using System;

namespace Domain
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int NoOfAcres { get; set; }
        public int Amount  { get; set; }
        public string Status { get; set; }        

    }
}