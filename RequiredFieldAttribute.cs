using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistrationForm
{
    public class RequiredFieldAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                ExistUser userName = value as ExistUser;
                if (userName.Login!="" && userName.Age!= 0)
                    return true;
                else
                    this.ErrorMessage = "Поля не заполнены";
            }
            return false;
        }
    }
}
