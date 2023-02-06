using ProjectSK.Data;
using System;
using ProjectSK.Map.MapEvent;

namespace ProjectSK.Game
{
    public class GameManager 
    {
        public static event Action OnGameStarted;
        public static event Action OnDayStarted;
        public static event Action<int> OnTimeIndexStarted;
        public static event Action<int> OnTimdIndexEnded;
        public static event Action OnDayEnded;
        public static event Action OnGameEnded;

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
            EndTimeIndex();
        }

        public void StartGame(GameSetting gameSetting)
        {
            currentGame = gameSetting;
            OnGameStarted?.Invoke();

            StartNewDay();
        }

        private void StartNewDay()
        {
            saveData.Player.AddDay(1);
            OnDayStarted?.Invoke();

            saveData.Player.SetTimeIndex(0);
            AddTimeIndex();
        }

        private void AddTimeIndex()
        {
            saveData.Player.AddTimeIndex(1);
            OnTimeIndexStarted?.Invoke(saveData.Player.TimeIndex);
        }

        private void EndTimeIndex()
        {
            OnTimdIndexEnded?.Invoke(saveData.Player.TimeIndex);

            if (saveData.Player.TimeIndex >= currentGame.TotalTimePerDay)
            {
                EndDay();
            }
            else
            {
                AddTimeIndex();
            }
        }

        private void EndDay()
        {
            OnDayEnded?.Invoke();
            StartNewDay();
        }
    }
}