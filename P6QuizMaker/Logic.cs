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
        private static int UserAnswerCheckWithScore(List<Question> QuizmakerList, int randomQuestionPick)
        {
            int score = 0;
            int incorrectAnswerCheckCount = 0;
            int userAnswer = UIMethods.GetUserInputNum() - 1;
            foreach (int correctAnswer in QuizmakerList[randomQuestionPick].CorrectAnswersList)
            {
                if (correctAnswer == QuizmakerList[randomQuestionPick].AnswersList.IndexOf(QuizmakerList[randomQuestionPick].AnswersList[userAnswer]))
                {
                    score++;
                    Console.WriteLine("You are smartest!");
                }
                else
                {
                    incorrectAnswerCheckCount++;
                }
            }
            if (incorrectAnswerCheckCount == QuizmakerList[randomQuestionPick].CorrectAnswersList.Count)
            {
                Console.WriteLine("Maybe you will know answer to next question !");

            }
            return score;
        }

        /// <summary>
        /// Returns random number between 0 and max value to use as parametre
        /// </summary>
        /// <param name="maxRandomValue"> Int of max value for random to return </param>
        /// <returns> random number between 0 and (int)variable </returns>
        private static int GetRandomQuestionIndex(int maxRandomValue)
        {
            return random.Next(0, maxRandomValue + 1);
        }

        /// <summary>
        /// Initialized random
        /// </summary>
        public static readonly Random random = new Random();

        public static void PlayGame()
        {
            Score score = new Score();
            List<Question> QuizmakerList = FileOperations.Deserialize();

            bool playingQuizMaker = true;
            while (playingQuizMaker)
            {
                Console.Clear();
                UIMethods.DisplayGameDiscription();

                int randomQuestionIndex = Logic.GetRandomQuestionIndex(QuizmakerList.Count - 1);
                UIMethods.DisplayPlayAnswerNumber();
                UIMethods.DisplayQuestionAndAnswersToPlayer(QuizmakerList, randomQuestionIndex);

                score.ScoreCount += Logic.UserAnswerCheckWithScore(QuizmakerList, randomQuestionIndex);
                Console.WriteLine($"Your score: {score.ScoreCount}");
                UIMethods.DisplayPlayAnotherQuestionText();
                playingQuizMaker = UIMethods.MakeDecisionYorN();
                Console.Clear();
            }
        }
    }
}
