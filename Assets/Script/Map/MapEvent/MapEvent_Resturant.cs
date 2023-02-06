using UnityEngine;

namespace ProjectSK.Map.MapEvent
{
    [CreateAssetMenu(menuName = "Map Event/Resturant")]
    public class MapEvent_Resturant : MapEventBase
    {
        [Tooltip("-1 means doesn't need suit")]
        [SerializeField] private int requireSuitID = -1;
        [SerializeField] private int costGold;
        [SerializeField] private int costStamina;

        protected override void DoMapEvent()
        {
            if (requireSuitID != -1 && Save.Player.Stuits.Contains(requireSuitID))
            {
                Debug.Log("沒有對應的服裝，約會失敗");
                return;
            }

            Debug.Log("開始約會");

            Debug.Log("消耗金錢: " + costGold);
            Save.Player.AddGold(-costGold);

            Debug.Log("消耗體力: " + costStamina);
            Save.Player.AddStamina(-costStamina);

            EndEvent();
        }
    }
}