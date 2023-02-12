using ProjectSK.Map.MapEvent;
using UnityEngine;

namespace ProjectSK.Game.UI
{
    public class TempGameUI : InitialableObject
    {
        private void Awake()
        {
            MapEvent_Resturant.OnConditionCheckFailed += MapEvent_Resturant_OnConditionCheckFailed;
            MapEvent_Resturant.OnBeforeDateStart += MapEvent_Resturant_OnBeforeDateStart;
            MapEvent_Resturant.OnGoldCost += MapEvent_Resturant_OnGoldCost;
            MapEvent_Resturant.OnStaminaCost += MapEvent_Resturant_OnStaminaCost;
        }

        private void MapEvent_Resturant_OnBeforeDateStart()
        {
            Debug.Log("開始約會");
        }

        private void MapEvent_Resturant_OnConditionCheckFailed(string message)
        {
            Debug.Log(message);
        }

        private void MapEvent_Resturant_OnGoldCost(int costGold)
        {
            Debug.Log("消耗金錢: " + costGold);
        }

        private void MapEvent_Resturant_OnStaminaCost(int costStamina)
        {
            Debug.Log("消耗體力: " + costStamina);
        }

        public void Button_GetMission()
        {
            Save.MissionStats.AddMission(new Data.Mission.Mission
            {
                targetMapName = "Resturant",
                targetCharacterName = "Rocker",
                missionType = Data.Mission.Mission.missionTypeCollection.NormalDate
            });
        }

        public void Button_GetGold()
        {
            Save.Player.AddGold(1000);
        }
    }
}
