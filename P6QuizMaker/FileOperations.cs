using System.Xml.Serialization;

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
            CreateQuestionsFolder(DoesFolderExist(QUESTIONS_FOLDER_PATH));
            XmlSerializer writer = new XmlSerializer(typeof(List<Question>));
            using (FileStream file = File.Create(QUESTIONS_FILE_PATH))
            {
                writer.Serialize(file, QuizmakerList);
            }
        }

        private static void CreateQuestionsFolder(bool itDoesnt)
        {
            if (itDoesnt)
            {
                Directory.CreateDirectory(QUESTIONS_FILE_PATH);
            }
        }
        private static bool DoesFolderExist(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Question> Deserialize()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
            List<Question> quesitonListName;
            using (FileStream file = File.OpenRead(QUESTIONS_FILE_PATH))
            {
                quesitonListName = serializer.Deserialize(file) as List<Question>;
            }
            return quesitonListName;
        }
    }
}
