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
        Exit,
        SaveChanges
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
