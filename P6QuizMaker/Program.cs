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
                    string answerText = UIMethods.GetUserInput();
                    quiz.AnswersList.Add(answerText);

                    UIMethods.DisplayIsCorrectAnswerText();
                    if (UIMethods.MakeDecision())
                    {
                        quiz.CorrectAnswersIndexList.Add(quiz.AnswersList.IndexOf(answerText));
                    }

                    UIMethods.DisplayAddAnswerText();
                    addMoreAnswers = UIMethods.MakeDecision();
                }

                UIMethods.DisplayAddQuestionText();
                addQuestions = UIMethods.MakeDecision();
            }
/*
            ReadWriteFile.writeXMLfile(QuizList);

*/
            Console.ReadLine();
        }
    }
}