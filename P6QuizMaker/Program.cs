namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UIMethods.WelcomeText();

            bool addQuestions = true;
            while (addQuestions)
            {
                UIMethods.DisplayAskToTypeQuestionText();
                QuizQuestionAndAnswers quiz = new QuizQuestionAndAnswers();
                Logic.AddQuestionInput(quiz.QuestionText);

                bool addMoreAnswers = true;
                while (addMoreAnswers)
                {
                    UIMethods.DisplayTypeAnswerText();
                    Logic.AddTextToAnswerList(quiz.AnswersList);
                    UIMethods.DisplayIsCorrectAnswerText();
                    Logic.SetCorrectAnswerIndex(quiz.CorrectAnswersIndexList,quiz.AnswersList);
                    UIMethods.DisplayAddAnswerText();
                    addMoreAnswers = UIMethods.MakeDecision();
                }

                UIMethods.DisplayAddQuestionText();
                addQuestions = UIMethods.MakeDecision();
            }
        }
    }
}