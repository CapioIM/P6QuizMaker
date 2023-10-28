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
            string path = @"C:\QuizXml\QuestionsAndAnswers.xml";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, QuizList);
            }
        }

        public static void readXmlFile()
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<QuizQuestionAndAnswers>));
            var path = @"C:\QuizXML\QuestionsAndAnswers.xml";
            using (XmlReader file = XmlReader.Create(path)) 
            {
                reader.Deserialize(file);
            }
        }
    }
}
