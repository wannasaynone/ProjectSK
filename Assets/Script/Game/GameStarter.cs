using UnityEngine;

namespace ProjectSK.Game
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Game.GameSetting gameSetting;
        [SerializeField] private TextAsset staminaExpData;

        private void Awake()
        {
            Data.SaveData testSave = new Data.SaveData();
            testSave.SetUpWithDefaultSetting();

            InitialableObject[] initialableObjects = Resources.FindObjectsOfTypeAll<InitialableObject>();
            for (int i = 0; i < initialableObjects.Length; i++)
            {
                initialableObjects[i].Initial(testSave);
            }

            KahaGameCore.GameData.Implemented.GameStaticDataManager gameStaticDataManager = new KahaGameCore.GameData.Implemented.GameStaticDataManager();
            gameStaticDataManager.Add<Data.StaminaExpData>(JsonFx.Json.JsonReader.Deserialize<Data.StaminaExpData[]>(staminaExpData.text) as KahaGameCore.GameData.IGameData[]);

            GameService.Register(gameStaticDataManager);

            Game.GameManager gameManager = new Game.GameManager(testSave);
            gameManager.StartGame(gameSetting);
        }
    }
}