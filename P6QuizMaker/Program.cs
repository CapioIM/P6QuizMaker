using P6QuizMaker.Enums;

namespace P6QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool interestedToUseProgramm = true;
            while (interestedToUseProgramm)
            {
                UIMethods.WelcomeText();                                                                              //welcome text
                UIMethods.DisplayGameModeChoice();
                int manageOrPlay = UIMethods.GetUserInputNum(Enum.GetNames(typeof(GameMode)).Length) - 1;             //choice to manage questions or play or exit
                GameMode gameModeChoice = UIMethods.GameModeChoice(manageOrPlay);

                if (gameModeChoice == GameMode.Manage)
                {
                    ManageQuestions.Manage();
                }

                if (gameModeChoice == GameMode.Play)
                {
                    Logic.PlayGame();
                }
                if (gameModeChoice == GameMode.Exit)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}