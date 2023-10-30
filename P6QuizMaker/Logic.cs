namespace P6QuizMaker
{
    internal class Logic
    {
        /// <summary>
        /// ask if answer is correct and add List index number to another CorrectAnswersIndex list
        /// </summary>
        /// <param name="correctAnswersIndexList"> Correct answers list of indexes </param>
        /// <param name="AnswerList"> list of answers </param>
        public static void SetCorrectAnswerIndex(List<int> correctAnswersIndexList, List<string> AnswerList)
        {
            if (UIMethods.MakeDecision())
            {
                correctAnswersIndexList.Add(AnswerList.LastIndexOf(AnswerList.Last()));
            }
        }
        /// <summary>
        /// type text which is added to Answers List
        /// </summary>
        /// <param name="answersList"> List name where to add text </param>
        public static void AddTextToAnswerList(List<string> answersList)
        {
            answersList.Add(Console.ReadLine());
        }
    }
}
