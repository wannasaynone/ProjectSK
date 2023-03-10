using System.Collections.Generic;

namespace ProjectSK.Data
{
    public class PlayerStats 
    {
        public static event System.Action OnValueUpdated;

        public List<int> Knoledge { get; private set; } = new List<int>();
        public List<int> Stuits { get; private set; } = new List<int>();
        public int Stamina { get; private set; } = 100;
        public int StaminaLevel { get; private set; } = 1;
        public int StaminaExp { get; private set; }
        public int Gold { get; private set; } 
        public int Day { get; private set; }
        public int TimeIndex { get; private set; }

        public void AddGold(int value)
        {
            int cur = Gold;
            Add(ref cur, value);
            Gold = cur;
            OnValueUpdated?.Invoke();
        }

        public void AddStamina(int value)
        {
            int cur = Stamina;
            Add(ref cur, value);
            Stamina = cur;
            OnValueUpdated?.Invoke();
        }

        public void AddStaminaLevel(int value)
        {
            int cur = StaminaLevel;
            Add(ref cur, value);
            StaminaLevel = cur;
            OnValueUpdated?.Invoke();
        }

        public void AddStaminaExp(int value)
        {
            int cur = StaminaExp;
            Add(ref cur, value);
            StaminaExp = cur;

            KahaGameCore.GameData.Implemented.GameStaticDataManager gameStaticDataManager = GameService.Get<KahaGameCore.GameData.Implemented.GameStaticDataManager>();

            if (gameStaticDataManager == null)
            {
                UnityEngine.Debug.Log("[PlayerStats][AddStaminaExp] gameStaticDataManager == null");
                return;
            }

            while(true)
            {
                StaminaExpData staminaExpData = gameStaticDataManager.GetGameData<StaminaExpData>(StaminaLevel);
                int require = staminaExpData.RequireExp;
                if (StaminaExp >= require)
                {
                    StaminaExp -= require;
                    StaminaLevel++;

                    staminaExpData = gameStaticDataManager.GetGameData<StaminaExpData>(StaminaLevel);
                    require = staminaExpData.RequireExp;

                    if (StaminaExp < require)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            OnValueUpdated?.Invoke();
        }

        public void AddDay(int value)
        {
            int cur = Day;
            Add(ref cur, value);
            Day = cur;
            OnValueUpdated?.Invoke();
        }

        public void AddTimeIndex(int value)
        {
            int cur = TimeIndex;
            Add(ref cur, value);
            TimeIndex = cur;
            OnValueUpdated?.Invoke();
        }

        public void SetTimeIndex(int value)
        {
            TimeIndex = value;
            if (TimeIndex < 0)
            {
                TimeIndex = 0;
            }

            OnValueUpdated?.Invoke();
        }

        public void SetStamina(int value)
        {
            Stamina = value;
            if (Stamina < 0)
            {
                Stamina = 0;
            }

            OnValueUpdated?.Invoke();
        }

        private void Add(ref int value, int add)
        {
            if (value + add > int.MaxValue)
            {
                value = int.MaxValue;
            }
            else if (value + add < 0)
            {
                value = 0;
            }
            else
            {
                value += add;
            }
        }
    }
}