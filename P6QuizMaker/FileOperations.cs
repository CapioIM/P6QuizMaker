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
        /// <param name="QuizList"> List of objects </param>
        public static void  writeXMLfile(List<QuizQuestionAndAnswers> QuizList)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestionAndAnswers>));
            string path = @"QuestionsAndAnswers.xml";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, QuizList);
            }
            Console.WriteLine(Path.GetFullPath(path));
        }

    }
}
