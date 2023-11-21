namespace P6QuizMaker
{

    public enum ManageOrPlay
    {
        Manage = 1,
        Play = 2
    }
    public enum ModificationOptions
    {
        Add,
        Remove,
        Amend
    }

    public enum ModificationTarget
    {
        Questions,
        AnswerList,
        CorrectAnswerList
    }

    public enum EnumChoice
    {
        ModificationOptions,
        ModificationTarget
    }
}
