using ProjectSK.Data;
using System;
using ProjectSK.Map;

namespace ProjectSK.Game
{
    public class GameManager 
    {
        public static event Action OnDayStarted;
        public static event Action<int> OnTimeIndexStarted;
        public static event Action<int> OnTimdIndexEnded;
        public static event Action OnDayEnded;

        private readonly SaveData saveData;
        private GameSetting currentGame;

        public GameManager(SaveData saveData)
        {
            this.saveData = saveData;
            MapEventBase.OnMapEventStartToStart += OnMapEventStartToStart;
            MapEventBase.OnMapEventEnded += OnMapEventEnded;
        }

        private void OnMapEventStartToStart(MapEventBase obj)
        {
        }

        private void OnMapEventEnded(MapEventBase obj)
        {
        }

        public void StartGame(GameSetting gameSetting)
        {
            currentGame = gameSetting;
        }
    }
}