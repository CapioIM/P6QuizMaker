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
            if (UIMethods.MakeDecision() == true)
            {
                correctAnswersIndexList.Add(AnswerList.LastIndexOf(AnswerList.Last()));
            }
        }
    }
}
