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
                    quiz.AnswersList.Add(UIMethods.GetUserInput());

                    UIMethods.DisplayIsCorrectAnswerText();
                    if (UIMethods.MakeDecision())
                    {
                        for (int i = 0; i < quiz.AnswersList.Count; i++)
                        {
                            // if(answerText == quiz.AnswersList[i])
                            {
                                //   quiz.CorrectAnswersIndexList.Add(quiz.AnswersList.FindIndex(answerText));
                            }
                        }
                    }

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