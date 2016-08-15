using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Attributes {

    [AttributeUsage(AttributeTargets.Property)]
    public class SearchableAttribute : Attribute {
    }
}
