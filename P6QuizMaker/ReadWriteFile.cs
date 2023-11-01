using System.Xml;
using System.Xml.Serialization;

namespace P6QuizMaker
{
    internal class ReadWriteFile
    {
        /// <summary>
        /// creates file in text format with values of object ....
        /// </summary>
        /// <param name="QuizList"> List of objects </param>
        public static void  writeXMLfile(List<QuizQuestionAndAnswers> QuizList)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestionAndAnswers>));
            string path = @".\QuizXml\QuestionsAndAnswers.xml";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, QuizList);
            }
        }

    }
}
