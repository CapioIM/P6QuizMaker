namespace P6QuizMaker
{
    internal class QuizQuestions
    {
        public static List<String> Questions = new List<string>();

        public static void StoreQuestions(string questionText)
        {
            Questions.Add(questionText);
        }
    }
}
