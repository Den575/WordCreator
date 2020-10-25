

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WordCreator.Models
{
    public class CreateTextDocument
    {

        public void AddToDataBase(User user)
        {
            using (StreamWriter sw = new StreamWriter("Files/data.json", true, System.Text.Encoding.Default))
            {
                string jsonObject = JsonConvert.SerializeObject(user);
                sw.WriteLine(jsonObject);
            }
        }
        public List<User> GetUser()
        {
            using (StreamReader sr = new StreamReader(@"Files/data.json"))
            {
                List<User> users = new List<User>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    User user = JsonConvert.DeserializeObject<User>(line);
                    users.Add(user);
                }
                sr.Close();
                return users;
            }
        }

       
       
    }
}
