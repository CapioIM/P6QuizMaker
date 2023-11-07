using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace P6QuizMaker
{
    internal class FileOperations
    {
        private const string QUESTIONS_FOLDER_PATH = @"..\..\..\..\Questions";
        private const string QUESTIONS_FILE_NAME = @"\QuestionsAndAnswers.xml";
        /// <summary>
        /// creates file in text format with values of object ....
        /// </summary>
        /// <param name="QuizmakerList"> List of objects </param>
        public static void CreateXMLSerializeFile(List<Question> QuizmakerList)
        {
            CreateQuestionsFolder(QUESTIONS_FOLDER_PATH);
            XmlSerializer writer = new XmlSerializer(typeof(List<Question>));
            string path = QUESTIONS_FOLDER_PATH + QUESTIONS_FILE_NAME;
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, QuizmakerList);
            }
        }

        private static void CreateQuestionsFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void Deserialized()
        {
            string path = QUESTIONS_FOLDER_PATH + QUESTIONS_FILE_NAME;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            using (FileStream file = File.OpenRead(path))
            {
                List<Question> quesitonListName = serializer.Deserialize(file) as List<Question>;
            }
        }


    }
}
