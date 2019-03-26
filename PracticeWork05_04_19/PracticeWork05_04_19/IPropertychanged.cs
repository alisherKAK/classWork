using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork05_04_19
{
    public delegate void PropertyeventHandler (object sender, PropertyeventArgs e);
    public interface IPropertychanged
    {
        event PropertyeventHandler Propertychanged;
    }
}
