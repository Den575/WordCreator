using Aspose.Words;
using Aspose.Words.Replacing;

namespace WordCreator.Models
{
    public class CreateWord
    {

        public void Create(User user)
        {
            // Load a Word docx document
            Document doc = new Document("Files/WZOR.docx");
            // Set options 
            FindReplaceOptions options = new FindReplaceOptions
            {
                MatchCase = false,
                FindWholeWordsOnly = false
            };
            // Replace text with paragraph break

            doc.Range.Replace("<name>", Changer.NarzednikImie(user.Name), options);
            doc.Range.Replace("<stanowisko>", user.Position, options);
            doc.Range.Replace("<surname>", Changer.NarzednikNazwisko(user.Name, user.Surname), options);
            doc.Range.Replace("<computer>", user.Computer, options);
            doc.Range.Replace("<date>", user.Time.ToShortDateString(), options);
            doc.Range.Replace("<date1>", user.Time.ToShortDateString(), options);
            doc.Range.Replace("<date2>", user.Time.ToShortDateString(), options);
            doc.Range.Replace("<date3>", user.Time.ToShortDateString(), options);
            doc.Range.Replace("<name&surname>", $"{user.Name} {user.Surname}", options);
            doc.Range.Replace("<name&surname1>", $"{user.Name} {user.Surname}", options);
            doc.Range.Replace("<stag>", user.ServiceTag, options);
            doc.Range.Replace("<endofword> ", Changer.EndOfWord(user.Name), options);
            doc.Range.Replace("<anotherinfo>", "Info", options);
            doc.Range.Replace("<city>", user.City, options);
            doc.Range.Replace("<city2>", user.City, options);


            // Save the Word document
            doc.Save($"files/{user.Name} {user.Surname}.docx");
        }
    }
}
