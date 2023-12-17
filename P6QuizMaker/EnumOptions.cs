namespace P6QuizMaker
{

    public enum GameMode
    {
        Manage,
        Play,
        Exit
    }
    public enum ModificationOptions
    {
        Add,
        Remove,
        Amend,
        Exit,
    }

    public enum ModificationTarget
    {
        Questions,
        AnswerList,
        CorrectAnswerList,
        Exit,
        SaveChanges
    }

    public enum EnumChoice
    {
        ModificationOptions,
        ModificationTarget,
        Exit
    }
}
