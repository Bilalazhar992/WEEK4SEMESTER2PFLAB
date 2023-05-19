using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2022_CS_196
{
    public class MUser
    {
        public string username;
        public string password;
        public string role;
        public MUser(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public bool isValidname(List<MUser> users)
        {
            foreach (MUser variable in users)
            {
                if (variable.username == username)
                {
                    return false;
                }
            }
            return true;
        }
        public void StoreInList(MUser user, List<MUser> users)
        {
            users.Add(user);
        }
        public void StoreInFile(string path)
        {

            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(username + "," + password + "," + role);
            file.Flush();
            file.Close();

        }
        public MUser(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public bool SignIn(List<MUser> objects)
        {
            foreach (MUser users in objects)
            {
                if (users.username == username && users.password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public MUser ReturnObject(List<MUser> objects)
        {
            foreach (MUser users in objects)
            {
                if (users.username == username && users.password == password)
                {
                    return users;
                }
            }
            return null;
        }

        public string CheckRole()
        {
            return role;
        }
    }
}
