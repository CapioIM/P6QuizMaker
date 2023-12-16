namespace P6QuizMaker
{
    internal class Logic
    {

        /// <summary>
        /// user entered integer is compared to values in CorrectAnswers... list and returns score
        /// </summary>
        /// <param name="Question"> Variable name for List of objects </param>
        /// <param name="score"> updates score </param>
        /// <param name="randomQuestionPick"> same variable used to interract with qustions and answers </param>
        /// <returns> updated score </returns>
        private static int UserAnswerCheckWithScore(QuestionsAndAnswers Question)
        {
            int score = 0;
            int userAnswer = UIMethods.GetUserInputNum() - 1;
            foreach (int correctAnswer in Question.CorrectAnswersList)
            {
                if (correctAnswer == Question.AnswersList.IndexOf(Question.AnswersList[userAnswer]))
                {
                    score++;
                    Console.WriteLine("You are smartest!");
                }
            }
            if (score == 0)
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
            List<QuestionsAndAnswers> questionsList = FileOperations.DeserializeTest();

            bool playingQuizMaker = true;
            while (playingQuizMaker)
            {
                UIMethods.ClearConcole();
                UIMethods.DisplayGameDiscription();

                int randomQuestionIndex = GetRandomQuestionIndex(questionsList.Count - 1);
                QuestionsAndAnswers questionPicked = questionsList[randomQuestionIndex];
                UIMethods.DisplayPlayAnswerNumber();
                UIMethods.DisplayQuestionAndAnswersToPlayer(questionPicked);

                score.ScoreCount += UserAnswerCheckWithScore(questionPicked);
                Console.WriteLine($"Your score: {score.ScoreCount}");
                UIMethods.DisplayPlayAnotherQuestionText();
                playingQuizMaker = UIMethods.MakeDecisionYorN();
            }
        }
    }
}
