using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SING.Data.Data;

namespace SING.Data.BaseTools
{
    public class FACEIdentity : IIdentity
    {
        public static FACEIdentity CurrentUser;
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserCfgData UserInfo { get; set; }
        public FACEIdentity() : this("testUser", "", false)
        {


        }
        public FACEIdentity(string userName, string password, bool isAuth)
        {
            _IsAuthenticated = isAuth;
            UserName = userName;
            Password = password;


            //_IsAuthenticated = IsAuth();
        }

        #region Implementation of IIdentity

        public string Name { get; set; }

        public string AuthenticationType
        {
            get; set;
        }

        private bool _IsAuthenticated = false;
        public bool IsAuthenticated
        {

            get { return _IsAuthenticated; }
        }

        #endregion
    }
}
