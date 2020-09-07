using System.IO;

namespace WordCreator.Models
{
    public class CreateTextDocument
    {

        public void CreateDocument(User user)
        {
            using(StreamWriter sw = new StreamWriter("Files/test.txt"))
            {
                sw.WriteLine(user.Name);
                sw.WriteLine(user.Surname);
                sw.WriteLine(user.Time);
            }
        }
        
        
    }
}
