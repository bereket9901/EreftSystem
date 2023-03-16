using System;
using System.Collections.Generic;

namespace Core.DTOs
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public DateTime dateTime { get; set; }    
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public IList<RequestItems> Items { get; set; }
    }

    public class RequestItems
    {
        public string Name { get; set; }
        public float Amount { get; set; }
        public string MeasuringUnit { get; set; }
        

    }
}
