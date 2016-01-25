using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoffingDesign.DAL.EntityModels
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public ContactType ContactType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Website { get; set; }
    }

    public enum ContactType
    {
        Undefined=0,
        Contact=1,
        Newsletter=2
    }
}
