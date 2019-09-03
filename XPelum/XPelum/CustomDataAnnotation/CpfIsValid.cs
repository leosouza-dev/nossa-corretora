using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Maoli;

namespace XPelum.CustomDataAnnotation
{
    public class CpfIsValid : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Cpf.Validate((string)value))
                return true;

            return false;
        }
    }
}
