using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectSK.Map.MapEvent
{
    [CreateAssetMenu(menuName = "Map Event/GYM")]
    public class MapEvent_GYM : MapEventBase
    {
        [SerializeField] private int addExp;
        [SerializeField] private int costStamina;

        protected override void DoMapEvent()
        {
            if (Save.Player.Stamina < costStamina)
            {
                Debug.Log("體力不足，無法訓練");
                return;
            }

            Debug.Log("開始訓練");

            Debug.Log("消耗體力: " + costStamina);
            Save.Player.AddStamina(-costStamina);

            int addRandom = Random.Range(addExp, addExp * 2 + 1);
            Debug.Log("增加體力經驗值: " + addRandom);
            Save.Player.AddStaminaExp(addRandom);

            EndEvent();
        }
    }
}