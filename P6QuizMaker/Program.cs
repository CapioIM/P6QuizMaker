namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.WelcomeText();

            List<QuizQuestionAndAnswers> QuizList = new List<QuizQuestionAndAnswers>(); 

            bool addQuestions = true;
            while (addQuestions)
            {
                UIMethods.DisplayAskToTypeQuestionText();
                QuizQuestionAndAnswers quiz = new QuizQuestionAndAnswers();
                QuizList.Add(quiz);
                quiz.QuestionText = UIMethods.GetUserInput();

                bool addMoreAnswers = true;
                while (addMoreAnswers)
                {
                    UIMethods.DisplayTypeAnswerText();
                    UIMethods.AddTextToAnswerList(quiz.AnswersList);
                    UIMethods.DisplayIsCorrectAnswerText();
                    Logic.SetCorrectAnswerIndex(quiz.CorrectAnswersIndexList, quiz.AnswersList);
                    UIMethods.DisplayAddAnswerText();
                    addMoreAnswers = UIMethods.MakeDecision();
                }

                UIMethods.DisplayAddQuestionText();
                addQuestions = UIMethods.MakeDecision();
            }

            ReadWriteFile.writeXMLfile(QuizList);

            ReadWriteFile.readXmlFile();
            Console.ReadLine();
        }
    }
}