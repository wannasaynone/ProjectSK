using ProjectSK.Data;
using UnityEngine.UI;
using UnityEngine;

namespace ProjectSK.Game.UI
{
    public class GameInfoPanel : InitialableObject
    {
        [SerializeField] private Text dayText;
        [SerializeField] private Text timeIndexText;

        private SaveData saveData;

        public override void Initial(SaveData saveData)
        {
            this.saveData = saveData;
            PlayerStats.OnValueUpdated += OnValueUpdated;
        }

        private void OnValueUpdated()
        {
            dayText.text = "Day " + saveData.Player.Day;
            timeIndexText.text = "Time Index=" + saveData.Player.TimeIndex;
        }
    }
}