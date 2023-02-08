using ProjectSK.Data;
using ProjectSK.Data.Mission;
using ProjectSK.Map.MapEvent;
using UnityEngine;

namespace ProjectSK.Map.UI
{
    public class MapButton : MonoBehaviour
    {
        [SerializeField] private MapEventBase mapEvent;

        private SaveData saveData;

        private UnityEngine.UI.Button button;

        public void SetUp(SaveData saveData)
        {
            if (button == null)
            {
                button = GetComponent<UnityEngine.UI.Button>();
            }

            this.saveData = saveData;
            if (this.saveData == null)
            {
                button.interactable = false;
                return;
            }

            if (mapEvent == null)
            {
                button.interactable = false;
                return;
            }

            if (mapEvent.Setting == null)
            {
                Debug.Log("mapEvent " + mapEvent.name + " missing map setting");
                button.interactable = false;
                return;
            }

            MissionStats.MapNameContainer mapName = new MissionStats.MapNameContainer(mapEvent.Setting.MapName);
            if (mapEvent.Setting.IsRequireMission && !saveData.MissionStats.IsHavingMission(mapName))
            {
                button.interactable = false;
                return;
            }

            int[] openTimeIndex = mapEvent.Setting.OpenTimeIndex;
            if (openTimeIndex != null && openTimeIndex.Length > 0)
            {
                bool open = false;
                for (int i = 0; i < openTimeIndex.Length; i++)
                {
                    if (saveData.Player.TimeIndex == openTimeIndex[i])
                    {
                        open = true;
                        break;
                    }
                }

                if (!open)
                {
                    button.interactable = false;
                    return;
                }
            }

            button.interactable = true;
        }

        public void Button_OnPressed()
        {
            if (saveData == null)
            {
                Debug.Log("[MapButton] saveData == null");
                return;
            }

            if (mapEvent == null)
            {
                Debug.Log("[MapButton] mapEvent == null");
                return;
            }

            mapEvent.StartEvent(saveData);
        }
    }
}