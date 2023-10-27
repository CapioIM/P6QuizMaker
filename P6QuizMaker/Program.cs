using System.Xml.Serialization;

namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.WelcomeText();

            List<QuizQuestionAndAnswers> QuizList = new List<QuizQuestionAndAnswers>();
            QuizQuestionAndAnswers quiz = null;

            bool addQuestions = true;
            while (addQuestions)
            {
                UIMethods.DisplayAskToTypeQuestionText();
                quiz = new QuizQuestionAndAnswers();
                QuizList.Add(quiz);
                quiz.QuestionText = UIMethods.GetUserInput();

                bool addMoreAnswers = true;
                while (addMoreAnswers)
                {
                    UIMethods.DisplayTypeAnswerText();
                    Logic.AddTextToAnswerList(quiz.AnswersList);
                    UIMethods.DisplayIsCorrectAnswerText();
                    Logic.SetCorrectAnswerIndex(quiz.CorrectAnswersIndexList, quiz.AnswersList);
                    UIMethods.DisplayAddAnswerText();
                    addMoreAnswers = UIMethods.MakeDecision();
                }

                UIMethods.DisplayAddQuestionText();
                addQuestions = UIMethods.MakeDecision();

            }

            XmlSerializer writer = new XmlSerializer(typeof(List<QuizQuestionAndAnswers>));
            var path = @"C:\\QuizXML\QuestionsAndAnswers.xml";
            using (FileStream file = File.Create(path)) 
            {   
                writer.Serialize(file, QuizList);
            }
        }
    }
}