namespace P6QuizMaker
{
    internal class Logic
    {
        /// <summary>
        /// ask if answer is correct and add List index number to another CorrectAnswersIndex list
        /// </summary>
        /// <param name="correctAnswersIndex"> Correct answers list of indexes </param>
        /// <param name="AnswerList"> list of answers </param>
        public static void SetCorrectAnswerIndex(List<int> correctAnswersIndex,List<string> AnswerList)
        {
            if (UIMethods.MakeDecision() == true)
            {
               correctAnswersIndex.Add(AnswerList.Count());
            }
        }



    }
}
