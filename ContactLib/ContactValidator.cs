using System.Text.RegularExpressions;

namespace ContactLib
{
 
    public static class ContactValidator
    {
        private static readonly Regex FullNameRegex =
            new(@"^[A-Za-zА-ЯҐЄІЇа-яґєії']+(\s[A-Za-zА-ЯҐЄІЇа-яґєії']+)+$", RegexOptions.Compiled);

        private static readonly Regex AgeRegex =
            new(@"^\d{1,3}$", RegexOptions.Compiled);

        private static readonly Regex PhoneRegex =
            new(@"^\+380\d{9}$", RegexOptions.Compiled);

        private static readonly Regex EmailRegex =
            new(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", RegexOptions.Compiled);

     
        public static bool IsValidFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return false;

            return FullNameRegex.IsMatch(fullName.Trim());
        }

        public static bool IsValidAge(string age)
        {
            if (string.IsNullOrWhiteSpace(age))
                return false;

            if (!AgeRegex.IsMatch(age.Trim()))
                return false;

            int value = int.Parse(age.Trim());
            return value >= 0 && value <= 120;
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            return PhoneRegex.IsMatch(phone.Trim());
        }

    
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email.Trim());
        }
    }
}
