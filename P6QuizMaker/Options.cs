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

        public enum ModificaitonTarget
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

        public static ModificaitonTarget ModificationTargetChoice(int modificationTargetChoice)
        {
            switch (modificationTargetChoice)
            {
                case 0:
                    return ModificaitonTarget.QuestionsText;
                case 1:
                    return ModificaitonTarget.AnswerList;
                case 2:
                    return ModificaitonTarget.CorrectAnswerList;
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
                case 0:
                    return ModificationOptions.Add;
                case 1:
                    return ModificationOptions.Remove;
                case 2:
                    return ModificationOptions.Amend;
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
