using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Application.Activities
{
    public class ActivityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string NoOfAcres { get; set; }
        public string Amount  { get; set; }
        public string Status { get; set; }
        [JsonPropertyName("attendees")]
        public ICollection<AttendeeDto> UserActivities { get; set; }
    }
}