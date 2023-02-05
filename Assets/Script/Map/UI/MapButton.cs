using ProjectSK.Data;
using UnityEngine;

namespace ProjectSK.Map.UI
{
    public class MapButton : MonoBehaviour
    {
        [SerializeField] private MapEventBase mapEvent;

        private SaveData saveData;

        public void SetUp(SaveData saveData)
        {
            this.saveData = saveData;
        }

        public void Button_OnPressed()
        {
            if (saveData == null)
            {
                Debug.Log("[MapButton] saveData == null");
                return;
            }

            mapEvent.Start(saveData);
        }
    }
}