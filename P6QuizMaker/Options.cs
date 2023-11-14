namespace P6QuizMaker
{
    internal class Options
    {
        public enum OptionChoice
        {
            Add = 1,
            Remove = 2,
            Amend = 3
        }

        public enum ListForOptions
        {
            QuestionsText = 1,
            AnswerList = 2,
            CorrectAnswerList = 3
        }

        public static ListForOptions TestMethod(int someint)
        {
            switch (someint)
            {
                case 1:
                    return ListForOptions.QuestionsText;
                case 2:
                    return ListForOptions.AnswerList;
                case 3:
                    return ListForOptions.CorrectAnswerList;
                default:
                    {
                        Console.WriteLine("Invalid number");
                    }
                    break;
            }
            return 0;
        }



        public static void Option(ListForOptions list, List<Question> QuizmakerList, int questionToAmend)
        {
            switch (list)
            {
                case ListForOptions.QuestionsText:
                    Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
                    QuizmakerList[questionToAmend].QuestionText = UIMethods.DisplayAskToTypeQuestionText();
                    break;
            }
        }


    }
}
