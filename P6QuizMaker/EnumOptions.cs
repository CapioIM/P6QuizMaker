namespace P6QuizMaker
{

    public enum GameMode
    {
        Manage,
        Play,
        Invalid
    }
    public enum ModificationOptions
    {
        Add,
        Remove,
        Amend,
        Invalid,
        Exit
    }

    public enum ModificationTarget
    {
        Questions,
        AnswerList,
        CorrectAnswerList,
        Invalid,
        Exit
    }

    public enum EnumChoice
    {
        ModificationOptions,
        ModificationTarget,
        Invalid,
        Exit
    }
}
