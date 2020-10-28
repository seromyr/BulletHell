

using UnityEngine.SceneManagement;

namespace Constants
{
    public enum GameState
    {
        INIT,   // Application starts
        START,  // Application has started and now in MainMenu/Title Screen
        NEW,    // A new game is started
        RUNNING,// A gameplay is occurring
        PAUSE,  // Gameplay is paused
        WIN,    // A level is victorious, debrief is shown before proceed to the next level
        LOSE,   // A level is lost but can retry
        GAMEOVER // A level is lost but cannot retry, return to Main Menu/Title Screen
    }

    public static class SceneName
    {
        public const string PRELOAD = "Preload";
        public const string MAINMENU = "MainMenu";
        public const string GAME = "Game";
    }
    public static class Map
    {
        public const string LV0 = "Level 00";
        public const string LV1 = "Level 01";
        public const string LV2 = "Level 02";
        public const string LV3 = "Level 03";
        public const string LV4 = "Level 04";
        public const string LV5 = "Level 05";
        public const string LV6 = "Level 06";
        public const string LV7 = "Level 07";
        public const string LV8 = "Level 08";
        public const string LV9 = "Level 09";
        public const string LV10 = "Level 10";

    }

    public static class PrimeObj
    {
        //public const string GAMEMANAGER = "GameManager";
        public const string PLAYER = "Player";
        //public const string MAINMENU = "MainMenu";
        //public const string INGAMEMENU = "IngameMenu";
    }

    public static class PlayerSkin
    {
        public const string DEFAULT = "PlayerSkin_Default";
        public const string _01 = "PlayerSkin_01";
        public const string _02 = "PlayerSkin_02";
    }
}