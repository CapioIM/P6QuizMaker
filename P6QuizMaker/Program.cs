namespace P6QuizMaker
{                                                   // comented code is to speed up testing :)
    internal class Program
    {
        static void Main(string[] args)
        {

            UIMethods.WelcomeText();


            List<Question> QuizmakerList = new List<Question>();

            /*
            bool addQuestions = true;
            while (addQuestions)
            {
                UIMethods.WelcomeAddQuestionsChoice();
                
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
            */
            /*
                        for (int i = 0; i <3; i++)
                        {
                            Question quizmaker = new Question();
                            QuizmakerList.Add(quizmaker);
                            quizmaker.QuestionText = $"{i}";
                            for (int j = 0; j < 3; j++)
                            {
                                quizmaker.AnswersList.Add($"{i}");
                            }
                        }

                        FileOperations.CreateXMLSerializeFile(QuizmakerList);
            */
            QuizmakerList = FileOperations.Deserialize();
            foreach (Question question in QuizmakerList)
            {
                Console.WriteLine(question.QuestionText);
            }
            Console.ReadLine();
        }
    }
}