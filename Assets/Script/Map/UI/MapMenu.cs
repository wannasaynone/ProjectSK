using ProjectSK.Data;
using UnityEngine;
using ProjectSK.Data.Mission;

namespace ProjectSK.Map.UI
{
    public class MapMenu : InitialableObject
    {
        [SerializeField] private MapButton[] mapButtons;

        public override void Initial(SaveData saveData)
        {
            base.Initial(saveData);
            RefreshMapButtonWithSave();
            MissionStats.OnMissionStatsUpdated += OnMissionStatsUpdated;
        }

        private void OnMissionStatsUpdated(MissionStats missionStats)
        {
            RefreshMapButtonWithSave();
        }

        private void RefreshMapButtonWithSave()
        {
            for (int i = 0; i < mapButtons.Length; i++)
            {
                mapButtons[i].SetUp(Save);
            }
        }
    } 
}