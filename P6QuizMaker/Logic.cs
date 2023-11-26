namespace P6QuizMaker
{
    internal class Logic
    {
        /// <summary>
        /// user entered integer is compared to values in CorrectAnswers... list and returns score
        /// </summary>
        /// <param name="QuizmakerList"> Variable name for List of objects </param>
        /// <param name="score"> updates score </param>
        /// <param name="randomQuestionPick"> same variable used to interract with qustions and answers </param>
        /// <returns> updated score </returns>
        public static int UserAnswerCheckWithScore(List<Question> QuizmakerList, int randomQuestionPick)
        {
            int score = 0;
            int userAnswer = UIMethods.GetUserInputNum() - 1;
            foreach (int correctAnswer in QuizmakerList[randomQuestionPick].CorrectAnswersList)
            {
                if (correctAnswer == QuizmakerList[randomQuestionPick].AnswersList.IndexOf(QuizmakerList[randomQuestionPick].AnswersList[userAnswer]))
                {
                    score++;
                    Console.WriteLine("You are smartest!");
                }
            }
            return score;
        }

        /// <summary>
        /// Returns random number between 0 and max value to use as parametre
        /// </summary>
        /// <param name="maxRandomValue"> Int of max value for random to return </param>
        /// <returns> random number between 0 and (int)variable </returns>
        public static int GetRandomNumber(int maxRandomValue)
        {
            Random random = new Random();
            return random.Next(0, maxRandomValue + 1);
        }

        public static void Play(List<Question> QuizmakerList)
        {
            int score = 0;
            QuizmakerList = FileOperations.Deserialize();

            bool playingQuizMaker = true;
            while (playingQuizMaker)
            {
                int randomQuestionIndex = Logic.GetRandomNumber(QuizmakerList.Count - 1);
                UIMethods.DisplayPlayAnswerNumber();
                UIMethods.DisplayQuestionAndAnswersToPlayer(QuizmakerList, randomQuestionIndex);

                 score += Logic.UserAnswerCheckWithScore(QuizmakerList, randomQuestionIndex);
                Console.WriteLine($"Your score: {score}");
                playingQuizMaker = UIMethods.MakeDecisionYorN();
                Console.Clear();
            }
            UIMethods.DisplayPlayAnotherQuestionText();
        }

    }


}
