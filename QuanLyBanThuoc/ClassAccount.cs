using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanThuoc
{
    class ClassAccount
    {
        private static ClassAccount instance;

        public static ClassAccount Instance
        {
            get { if (instance == null) instance = new ClassAccount(); return instance; }
            private set { instance = value; }
        }

        private ClassAccount()
        {

        }

        public bool Login(string username, string password)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = N'K9' AND Password = N'1'";
            return false;
        }
    }
}
