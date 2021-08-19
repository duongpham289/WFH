using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.MISAAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISANotMap : Attribute
    {

    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        public string _fieldName = string.Empty;
        public string _message = string.Empty;

        public MISARequired(string fieldName)
        {
            _message = $"Thông tin {fieldName} không được để trống!";
            _fieldName = fieldName;

        }
    }
}
