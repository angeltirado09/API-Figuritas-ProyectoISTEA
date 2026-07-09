using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuritas.Abstractions.DTO
{
    public class FiguritaDTO
    {
        public DateTime createdAt { get; set; }
        public string country { get; set; }
        public string playerLastName { get; set; }
        public string playerFirstName { get; set; }
        public int CardNumber { get; set; }
        public bool isDeleted { get; set; }
        public bool isSpecial { get; set; }
        public int totalCount { get; set; }
        public string id { get; set; }
    }
}
