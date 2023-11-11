namespace P6QuizMaker
{                                                   
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> QuizmakerList = new List<Question>();
            int score = 0;

            while (true)
            {
                UIMethods.WelcomeText();
                UIMethods.DisplayChoiceManagePlay();
                int manageOrPlay = UIMethods.GetUserInputNum();
               
                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Manage))
                {
                    bool manageQuestions = true;
                    while (manageQuestions)
                    {
                        Question quizmaker = new Question();
                        QuizmakerList.Add(quizmaker);
                        quizmaker.QuestionText = UIMethods.DisplayAskToTypeQuestionText();

                        bool addMoreAnswers = true;
                        while (addMoreAnswers)
                        {
                            string answerText = UIMethods.GetAndDisplayTypeAnswerText();
                            quizmaker.AnswersList.Add(answerText);
                            Logic.AddCorrectAnswersToList(answerText,quizmaker);
                            addMoreAnswers = UIMethods.GetAdditionalAnswer();
                        }
                        manageQuestions = UIMethods.GetAdditionalQuestions();
                        Console.Clear();
                    }

                    FileOperations.CreateXMLSerializeFile(QuizmakerList);
                    continue;
                }

                if (manageOrPlay == Convert.ToInt32(StartMode.ManageOrPlay.Play))
                {
                    QuizmakerList = FileOperations.Deserialize();
                }
                bool playingQuizMaker = true;
                while (playingQuizMaker)
                {
                    Random random = new Random();
                    int randomQuestionIndex = random.Next(0,QuizmakerList.Count);
                    Console.WriteLine("Please type number associated with answer");
                    Console.WriteLine($"Please answer this Question: {QuizmakerList[randomQuestionIndex].QuestionText}");
                    foreach (string answer in QuizmakerList[randomQuestionIndex].AnswersList)
                    {
                        Console.Write($"{QuizmakerList[randomQuestionIndex].AnswersList.IndexOf(answer)+1}" + " ");
                        Console.WriteLine(answer);
                    }
                    int userAnswer = UIMethods.GetUserInputNum();
                    foreach (int correctAnswer in QuizmakerList[randomQuestionIndex].CorrectAnswersIndexList)
                    {
                        if (correctAnswer == userAnswer)
                        {
                            score++;
                        }
                    }



                    playingQuizMaker = false;
                }



                Console.ReadLine();
            }
        }
    }
}