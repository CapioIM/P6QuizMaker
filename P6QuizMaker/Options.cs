namespace P6QuizMaker
{
    internal class Options
    {
        public enum ModificationOptions
        {
            Add,
            Remove,
            Amend
        }

        public enum ModificationTarget
        {
            QuestionsText,
            AnswerList,
            CorrectAnswerList
        }

        public enum EnumChoice
        {
            ModificationOptions,
            ModificationTarget
        }

        public static ModificationTarget ModificationTargetChoice(int modificationTargetChoice)
        {
            switch (modificationTargetChoice)
            {
                case 0:
                    return ModificationTarget.QuestionsText;
                case 1:
                    return ModificationTarget.AnswerList;
                case 2:
                    return ModificationTarget.CorrectAnswerList;
                default:
                    {
                        Console.WriteLine("Invalid number");
                    }
                    break;
            }
            return 0;
        }

        public static ModificationOptions ModificationOptionChoice(int modificationOptionChoice)
        {
            switch (modificationOptionChoice)
            {
                case 1:
                    return ModificationOptions.Amend;
                case 2:
                    return ModificationOptions.Remove;
                case 3:
                    return ModificationOptions.Add;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
            return 0;
        }



        public static void ModifyQuestionText(List<Question> QuizmakerList, int questionToAmend)
        {
            Console.WriteLine($"Question you are changing is : {QuizmakerList[questionToAmend].QuestionText}");
            QuizmakerList[questionToAmend].QuestionText = UIMethods.DisplayAskToTypeQuestionText();
        }

    }
}
