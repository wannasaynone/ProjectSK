using UnityEngine;
using KahaGameCore.GameData.Implemented;

namespace ProjectSK.Map.MapEvent
{
    [CreateAssetMenu(menuName = "Map Event/Home")]
    public class MapEvent_Home : MapEventBase
    {
        [SerializeField] private float increaseStaminaPersent;

        protected override void DoMapEvent()
        {
            Debug.Log("在家休息");

            GameStaticDataManager gameStaticDataManager = GameService.Get<GameStaticDataManager>();
            int currentMaxStamina = gameStaticDataManager.GetGameData<Data.StaminaExpData>(Save.Player.StaminaLevel).Stamina;
            float addStamina = (float)currentMaxStamina * increaseStaminaPersent;
            int addStaminaInt = System.Convert.ToInt32(addStamina);

            Debug.Log("增加體力 " + increaseStaminaPersent * 100f + "%");

            if (Save.Player.Stamina + addStaminaInt > currentMaxStamina)
            {
                Save.Player.SetStamina(currentMaxStamina);
            }
            else
            {
                Save.Player.AddStamina(addStaminaInt);
            }

            Debug.Log("現在體力是 " + Save.Player.Stamina);

            EndEvent();
        }
    }
}