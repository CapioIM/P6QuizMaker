namespace P6QuizMaker
{
    internal class ManageQuestions
    {

        public static bool IsQuestionListEmpty(List<Question> list)
        {
            if (list.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsAnswerListEmpty(List<string> list)
        {
            if (list.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
