using System.Xml.Serialization;

namespace P6QuizMaker
{
    internal class FileOperations
    {
        private const string _QUESTIONS_FOLDER_PATH = @"..\..\..\..\QuestionsAndAnswers";
        private const string _QUESTIONS_FILE_NAME = @"\QuestionsAndAnswers.xml";
        private const string _QUESTIONS_FILE_PATH = _QUESTIONS_FOLDER_PATH + _QUESTIONS_FILE_NAME;

        /// <summary>
        /// creates file in text format with values of object ....
        /// </summary>
        /// <param name="QuizmakerList"> List of objects </param>
        public static void CreateXMLSerializeFile(List<QuestionsAndAnswers> QuizmakerList)
        {
            CreateQuestionsFolder(DoesFolderExist(_QUESTIONS_FOLDER_PATH));
            XmlSerializer writer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
            using (FileStream file = File.Create(_QUESTIONS_FILE_PATH))
            {
                writer.Serialize(file, QuizmakerList);
            }
        }

        private static void CreateQuestionsFolder(bool doesExist)
        {
            if (!doesExist)
            {
                Directory.CreateDirectory(_QUESTIONS_FILE_PATH);
            }
        }
        private static bool DoesFolderExist(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<QuestionsAndAnswers> DeserializeFiles()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
            List<QuestionsAndAnswers> questionListName;
            using (FileStream file = File.OpenRead(_QUESTIONS_FILE_PATH))
            {
                questionListName = serializer.Deserialize(file) as List<QuestionsAndAnswers>;
            }
            return questionListName;
        }
    }
}
