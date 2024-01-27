using P6QuizMaker.Enums;

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
        /// <returns> int updated score </returns>
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
            List<QuestionsAndAnswers> questionsList = FileOperations.DeserializeFiles();
            int score = 0;
            bool playingQuizMaker = true;
            while (playingQuizMaker)
            {
                UIMethods.ClearConcole();
                UIMethods.DisplayGameDiscription();

                int randomQuestionIndex = GetRandomIndexNumber(questionsList.Count - 1);
                QuestionsAndAnswers originalQuestionToCheckAgains = questionsList[randomQuestionIndex];
                QuestionsAndAnswers questionPlaying = QuestionsAndAnswers.CopyQuestionObject(originalQuestionToCheckAgains);
                UIMethods.DisplayPlayAnswerNumber();
                UIMethods.DisplayQuestionTextToPlayer(questionPlaying);
                ShuffleAnswersInList(questionPlaying);
                UIMethods.DisplayAnswers(questionPlaying);
                score += UserAnswerCheckWithScore(questionPlaying, originalQuestionToCheckAgains);
                UIMethods.DisplayUpdatedScore(score);
                UIMethods.DisplayPlayAnotherQuestionText();
                playingQuizMaker = UIMethods.MakeDecisionYorN();
            }
        }

        /// <summary>
        /// Cnages order of specific list using Rand and swaps positions of data
        /// </summary>
        /// <param name="questionAndData"> Provide object </param>
        private static void ShuffleAnswersInList(QuestionsAndAnswers questionAndData)
        {
            int j;
            string k;
            for (int i = 0; i < questionAndData.AnswersListCount; i++)
            {
                j = GetRandomIndexNumber(i);
                k = questionAndData.AnswersList[j];
                questionAndData.AnswersList[j] = questionAndData.AnswersList[i];
                questionAndData.AnswersList[i] = k;
            }
        }

    }
}
