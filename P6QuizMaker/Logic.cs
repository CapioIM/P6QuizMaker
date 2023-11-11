using static System.Formats.Asn1.AsnWriter;
using System;

namespace P6QuizMaker
{
    internal class Logic
    {
        /// <summary>
        /// if true adds index of matching string in AnswersList
        /// </summary>
        /// <param name="answerText">input string of Answer</param>
        /// <param name="quizmaker">Object variable name</param>
        public static void AddCorrectAnswersToList(string answerText, Question quizmaker)
        {
            if (UIMethods.IsCorrectAnswer())
            {
                quizmaker.CorrectAnswersIndexList.Add(quizmaker.AnswersList.IndexOf(answerText));
            }
        }
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
    }
}
