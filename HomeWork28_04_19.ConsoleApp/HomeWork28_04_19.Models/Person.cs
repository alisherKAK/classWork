using HomeWork28_04_19.AbstractModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork28_04_19.Models
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public string CertificateNumber { get; set; }
    }
}
