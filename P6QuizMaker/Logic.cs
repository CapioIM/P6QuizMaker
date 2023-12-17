namespace P6QuizMaker
{
    internal class Logic
    {

        /// <summary>
        /// Initialized random
        /// </summary>
        public static readonly Random random = new Random();


        /// <summary>
        /// user entered integer is compared to values in CorrectAnswers... list and returns score
        /// </summary>
        /// <param name="QuestionAtPlay"> Variable name for List of objects </param>
        /// <param name="score"> updates score </param>
        /// <param name="randomQuestionPick"> same variable used to interract with qustions and answers </param>
        /// <returns> updated score </returns>
        private static int UserAnswerCheckWithScore(QuestionsAndAnswers QuestionAtPlay, QuestionsAndAnswers testQuestion)
        {
            int score = 0;
            int userAnswer = UIMethods.GetUserInputNum(QuestionAtPlay.AnswersListCount) - 1;
            foreach (int correctAnswer in testQuestion.CorrectAnswersList)
            {
                if (QuestionAtPlay.AnswerListValueAtIndex(userAnswer) == testQuestion.AnswerListValueAtIndex(correctAnswer))
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
                QuestionsAndAnswers questionPlaying = new QuestionsAndAnswers();
                QuestionsAndAnswers originalQuestionToCheckAgains = questionsList[randomQuestionIndex];

                CopyAnswerList(originalQuestionToCheckAgains, questionPlaying);
                CopyQuestionText(originalQuestionToCheckAgains, questionPlaying);
                UIMethods.DisplayPlayAnswerNumber();
                Console.WriteLine($"Please answer this Question: {questionPlaying.QuestionText}");
                ShuffleAnswersInList(questionPlaying);
                questionPlaying.DisplayAnswers();
                score.ScoreCount += UserAnswerCheckWithScore(questionPlaying, originalQuestionToCheckAgains);
                Console.WriteLine($"Your score: {score.ScoreCount}");
                UIMethods.DisplayPlayAnotherQuestionText();
                playingQuizMaker = UIMethods.MakeDecisionYorN();
            }
        }


        private static void ShuffleAnswersInList(QuestionsAndAnswers questionObject)
        {
            int j;
            string k;
            for (int i = 0; i < questionObject.AnswersListCount; i++)
            {
                j = GetRandomIndexNumber(i);
                k = questionObject.AnswersList[j];
                questionObject.AnswersList[j] = questionObject.AnswersList[i];
                questionObject.AnswersList[i] = k;
            }
        }
        private static void CopyAnswerList(QuestionsAndAnswers originalAnswerList, QuestionsAndAnswers copyOfList)
        {
            foreach (string answer in originalAnswerList.AnswersList)
            {
                copyOfList.AnswersList.Add(answer);
            }
        }
        private static void CopyQuestionText(QuestionsAndAnswers originalQuestion, QuestionsAndAnswers copyOfQuesiton)
        {
            copyOfQuesiton.QuestionText = originalQuestion.QuestionText;
        }

    }
}
