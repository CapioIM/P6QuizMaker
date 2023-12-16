namespace P6QuizMaker
{
    internal class Logic
    {
        /// <summary>
        /// Initialized random
        /// </summary>
        public static readonly Random random = new Random();

/*
        /// <summary>
        /// user entered integer is compared to values in CorrectAnswers... list and returns score
        /// </summary>
        /// <param name="QuestionAtPlay"> Variable name for List of objects </param>
        /// <param name="score"> updates score </param>
        /// <param name="randomQuestionPick"> same variable used to interract with qustions and answers </param>
        /// <returns> updated score </returns>
        private static int UserAnswerCheckWithScore(QuestionsAndAnswers QuestionAtPlay,QuestionsAndAnswers testQuestion)
        {
            int score = 0;
            int userAnswer = UIMethods.GetUserInputNum() - 1;
            foreach (int correctAnswer in testQuestion.CorrectAnswersList)
            {
                if (QuestionAtPlay.AnswersList[userAnswer] == testQuestion.AnswersList[correctAnswer])
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
*/


        /// <summary>
        /// Returns random number between 0 and max value to use as parametre
        /// </summary>
        /// <param name="maxRandomValue"> Int of max value for random to return </param>
        /// <returns> random number between 0 and (int)variable </returns>
        private static int GetRandomIndexNumber(int maxRandomValue)
        {
            return random.Next(0, maxRandomValue + 1);
        }

        public static void PlayGame()
        {
            Score score = new Score();
            List<QuestionsAndAnswers> questionsList = FileOperations.DeserializeTest();

            bool playingQuizMaker = true;
            while (playingQuizMaker)
            {
                UIMethods.ClearConcole();
                UIMethods.DisplayGameDiscription();

                int randomQuestionIndex = GetRandomIndexNumber(questionsList.Count - 1);
                QuestionsAndAnswers questionPicked = new QuestionsAndAnswers(questionsList[randomQuestionIndex]);
                UIMethods.DisplayPlayAnswerNumber();
                Console.WriteLine($"Please answer this Question: {questionPicked.QuestionText}");
                Shuffler(questionPicked);
                UIMethods.ShowListOfAnswers(questionPicked,false);



 //     score.ScoreCount += UserAnswerCheckWithScore(questionPicked, questionsList[randomQuestionIndex]);
                Console.WriteLine($"Your score: {score.ScoreCount}");
                UIMethods.DisplayPlayAnotherQuestionText();
                playingQuizMaker = UIMethods.MakeDecisionYorN();
            }
        }


        //time to shuffle
        private static void Shuffler(QuestionsAndAnswers questionObject)
        {
            int j;
            string k;
            for (int i = 0; i < questionObject.AnswersList.Count; i++)
            {
                j = GetRandomIndexNumber(i);
                k = questionObject.AnswersList[j];
                questionObject.AnswersList[j] = questionObject.AnswersList[i];
                questionObject.AnswersList[i] = k;
            }
        }



    }
}
