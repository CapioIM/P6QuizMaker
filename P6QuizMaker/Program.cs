namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UIMethods.WelcomeText();

            List<Question> QuizmakerList = new List<Question>();

            bool addQuestions = true;
            while (addQuestions)
            {
                
                Question quizmaker = new Question();
                QuizmakerList.Add(quizmaker);
                quizmaker.QuestionText = UIMethods.DisplayAskToTypeQuestionText();

                bool addMoreAnswers = true;
                while (addMoreAnswers)
                {
                    string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                    quizmaker.AnswersList.Add(answerText);

                    if (UIMethods.IsCorrectAnswer())
                    {
                        quizmaker.CorrectAnswersIndexList.Add(quizmaker.AnswersList.IndexOf(answerText));
                    }

                    addMoreAnswers = UIMethods.GetAdditionalAnswer();
                }
                addQuestions = UIMethods.GetAdditionalQuestions();
                Console.Clear();
                UIMethods.WelcomeText();
            }

            FileOperations.CreateXMLfile(QuizmakerList);

            Console.ReadLine();
        }
    }
}