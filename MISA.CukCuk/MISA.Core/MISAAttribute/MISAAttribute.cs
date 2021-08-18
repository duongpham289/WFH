﻿using System;
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
        public string FieldName = string.Empty;

        public MISARequired(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}