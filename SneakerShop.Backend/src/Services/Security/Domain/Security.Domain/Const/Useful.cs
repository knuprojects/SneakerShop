using System.Text.RegularExpressions;

namespace Security.Domain.Const
{
    public static class Useful
    {
        public static readonly Regex EmailTemplate = new Regex(
                       @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                       @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                       RegexOptions.Compiled);

        //Roles
        public static readonly string AdminRole = "admin";
        public static readonly string UserRole = "user";
    }
}
