namespace P6QuizMaker
{

    public enum GameMode
    {
        Manage,
        Play,
    }
    public enum ModificationOptions
    {
        Add,
        Remove,
        Amend,
        Exit
    }

    public enum ModificationTarget
    {
        Questions,
        AnswerList,
        CorrectAnswerList,
        Exit
    }

    public enum EnumChoice
    {
        ModificationOptions,
        ModificationTarget,
        Exit
    }
}
