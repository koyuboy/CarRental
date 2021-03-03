using Core.Entities.Concrete;
using FluentValidation;
using System.Linq;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            //RuleFor(u => u.FirstName).MinimumLength(2);
            //RuleFor(u => u.LastName).MinimumLength(2);
            //RuleFor(u => u.Email).Must(IsValidEmail).WithMessage("Email not valid!");
            
            //RuleFor(u => u.Password).Must(IsValidPassword).WithMessage("Password not valid!    Password must be contain one upper case, one lower case, no white space and at least one special character!!");

        }


        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        bool IsValidPassword(string password)
        {
            if (!password.Any(char.IsUpper))//One upper case
                return false;
            if (!password.Any(char.IsLower))//Atleast one lower case
                return false;
            if (password.Contains(" "))//No white space
                return false;
            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";//Check for one special character
            char[] specialCharArray = specialCh.ToCharArray();
            foreach (char ch in specialCharArray)
            {
                if (password.Contains(ch))
                    return true;
            }

            return false;
        }



        


    }
}
