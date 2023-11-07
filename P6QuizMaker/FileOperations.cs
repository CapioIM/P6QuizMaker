using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace P6QuizMaker
{
    internal class FileOperations
    {
        private const string QUESTIONS_FOLDER_PATH = @"..\..\..\..\Questions";
        private const string QUESTIONS_FILE_NAME = @"\QuestionsAndAnswers.xml";
        private const string QUESTIONS_FILE_PATH = QUESTIONS_FOLDER_PATH + QUESTIONS_FILE_NAME;

        /// <summary>
        /// creates file in text format with values of object ....
        /// </summary>
        /// <param name="QuizmakerList"> List of objects </param>
        public static void CreateXMLSerializeFile(List<Question> QuizmakerList)
        {
            CreateQuestionsFolder(QUESTIONS_FOLDER_PATH);
            XmlSerializer writer = new XmlSerializer(typeof(List<Question>));
            using (FileStream file = File.Create(QUESTIONS_FILE_PATH))
            {
                writer.Serialize(file, QuizmakerList);
            }
        }
        private static void CreateQuestionsFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public static void Deserialized()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream file = File.OpenRead(QUESTIONS_FILE_PATH))
            {
                List<Question> quesitonListName = serializer.Deserialize(file) as List<Question>;
            }
        }
    }
}
