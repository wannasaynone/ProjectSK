using ProjectSK.Data;
using UnityEngine.UI;
using UnityEngine;
using KahaGameCore.GameData.Implemented;

namespace ProjectSK.Game.UI
{
    public class GameInfoPanel : InitialableObject
    {
        [SerializeField] private Text dayText;
        [SerializeField] private Text timeIndexText;
        [SerializeField] private Text staminaText;
        [SerializeField] private Text staminaLvText;
        [SerializeField] private Text staminaExpText;

        public override void Initial(SaveData saveData)
        {
            base.Initial(saveData);
            PlayerStats.OnValueUpdated += OnValueUpdated;
        }

        private void OnValueUpdated()
        {
            GameStaticDataManager gameStaticDataManager = GameService.Get<GameStaticDataManager>();
            StaminaExpData staminaExpData = gameStaticDataManager.GetGameData<StaminaExpData>(Save.Player.StaminaLevel);
            int currentMaxStamina = staminaExpData.Stamina;

            dayText.text = "Day " + Save.Player.Day;
            timeIndexText.text = "Time Index=" + Save.Player.TimeIndex;
            staminaText.text = "Stamina: " + Save.Player.Stamina + " / " + currentMaxStamina;
            staminaLvText.text = "Stamina Lv. " + Save.Player.StaminaLevel;
            staminaExpText.text = "Stamina Exp: " + Save.Player.StaminaExp + " / " + staminaExpData.RequireExp;
        }
    }
}