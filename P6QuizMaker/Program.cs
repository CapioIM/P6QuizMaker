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
                    string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                    quiz.AnswersList.Add(answerText);

                    if (UIMethods.IsCorrectAnswer())
                    {
                        quiz.CorrectAnswersIndexList.Add(quiz.AnswersList.IndexOf(answerText));
                    }

                    addMoreAnswers = UIMethods.GetAdditionalAnswer();
                }

                addQuestions = UIMethods.GetAdditionalQuestions();
            }

        // in progress    FileOperations.writeXMLfile(QuizList);


            Console.ReadLine();
        }
    }
}