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
        public static int UserAnswerCheckWithScore(List<Question> QuizmakerList, int score, int randomQuestionPick)
        {
            int userAnswer = UIMethods.GetUserInputNum();
            foreach (int correctAnswer in QuizmakerList[randomQuestionPick].CorrectAnswersIndexList)
            {
                if (correctAnswer == userAnswer - 1)
                {
                    score++;
                    Console.WriteLine("You are smartest!");
                    Console.WriteLine($"Your Score : {score}");
                }
            }
            return score;
        }


        public static int GetRandomIndex(List<Question> QuizmakerList)
        {
            Random random = new Random();
            return random.Next(0, QuizmakerList.Count);
        }
    }


}
