using System.Security.Cryptography;
using System.Text;

namespace WebApp1.Utilities
{
    public class Functions
    {
        public static int _AccountID = 0;
        public static string _UserName = string.Empty;
        public static string _FullName = string.Empty;
        public static string _Email = string.Empty;
        public static string _Image = string.Empty;
        public static string _Phone = string.Empty;
        public static string _Class = string.Empty;
        public static string _StudentCode = string.Empty;
        public static string _Gender = string.Empty;
        public static DateTime _Birth = DateTime.MinValue;

        public static int _RoleID = 0;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;

        public static string TitleSlugGeneration(string type, string title, long id)
        {
            string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
            return sTitle;
        }

        public static string getCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Functions._UserName) || string.IsNullOrEmpty(Functions._Email) || (Functions._AccountID <= 0))
                return false;
            return true;
        }
    }
}
