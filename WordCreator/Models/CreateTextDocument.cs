using System.IO;

namespace WordCreator.Models
{
    public class CreateTextDocument
    {

        public void CreateDocument(User user)
        {
            using(StreamWriter sw = new StreamWriter("Files/test.txt"))
            {
                sw.WriteLine($"Name: {user.Name}");
                sw.WriteLine($"Surnmae: {user.Surname}");
                sw.WriteLine($"City: {user.City}");
                sw.WriteLine($"Date: {user.Time}");
            }
        }
        
        
    }
}
