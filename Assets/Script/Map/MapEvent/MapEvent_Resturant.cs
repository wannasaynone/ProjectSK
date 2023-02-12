using UnityEngine;
using System;

namespace ProjectSK.Map.MapEvent
{
    [CreateAssetMenu(menuName = "Map Event/Resturant")]
    public class MapEvent_Resturant : MapEventBase
    {
        public static event Action<string> OnConditionCheckFailed;
        public static event Action OnBeforeDateStart;
        public static event Action<int> OnGoldCost;
        public static event Action<int> OnStaminaCost;

        [Tooltip("-1 means doesn't need suit")]
        [SerializeField] private int requireSuitID = -1;
        [SerializeField] private int costGold;
        [SerializeField] private int costStamina;

        protected override void DoMapEvent()
        {
            if (requireSuitID != -1 && Save.Player.Stuits.Contains(requireSuitID))
            {
                OnConditionCheckFailed?.Invoke("沒有對應的服裝，約會失敗");
                return;
            }

            if (Save.Player.Gold < costGold)
            {
                OnConditionCheckFailed?.Invoke("金錢不足，需求" + costGold + "，現在擁有" + Save.Player.Gold);
                return;
            }

            if (Save.Player.Stamina < costStamina)
            {
                OnConditionCheckFailed?.Invoke("體力不足，需求" + costStamina + "，現在擁有" + Save.Player.Stamina);
                return;
            }

            OnBeforeDateStart?.Invoke();

            Save.Player.AddGold(-costGold);
            OnGoldCost?.Invoke(-costGold);

            Save.Player.AddStamina(-costStamina);
            OnStaminaCost?.Invoke(-costStamina);

            EndEvent();
        }
    }
}