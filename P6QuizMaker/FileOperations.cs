﻿using System.Xml;
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
        public static void  writeXMLfile(List<Question> QuizmakerList)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Question>));
            string path = @"QuestionsAndAnswers.xml";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, QuizmakerList);
            }
            Console.WriteLine(Path.GetFullPath(path));
        }

    }
}
