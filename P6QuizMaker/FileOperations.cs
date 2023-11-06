using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace P6QuizMaker
{
    internal class FileOperations
    {
        /// <summary>
        /// creates file in text format with values of object ....
        /// </summary>
        /// <param name="QuizmakerList"> List of objects </param>
        public static void CreateXMLSerializeFile(List<Question> QuizmakerList)
        {
            string questionsFolderPath = CreateQuestionsFolder();

            XmlSerializer writer = new XmlSerializer(typeof(List<Question>));
            string path = questionsFolderPath + @"\QuestionsAndAnswers.xml";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, QuizmakerList);
            }
            Console.WriteLine(Path.GetFullPath(path));
        }

        private static string CreateQuestionsFolder()
        {
            string questionsFolderPath = @"..\..\..\..\Questions";
            if (!Directory.Exists(questionsFolderPath))
            {
                Directory.CreateDirectory(questionsFolderPath);
            }
            return questionsFolderPath;
        }
/*
        public static void Deserialized() 
        {
            string questionsFolderPath = CreateQuestionsFolder();
            string path = questionsFolderPath + @"\QuestionsAndAnswers.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream file = File.OpenRead(path))
            {
               List<Question> quesitonListName = serializer.Deserialize(file) as List<Question>;
            }
        }
*/

    }
}
