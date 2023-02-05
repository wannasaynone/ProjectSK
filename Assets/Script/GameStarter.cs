using UnityEngine;

namespace ProjectSK
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Game.GameSetting gameSetting;

        private void Awake()
        {
            Data.SaveData testSave = new Data.SaveData();

            InitialableObject[] initialableObjects = Resources.FindObjectsOfTypeAll<InitialableObject>();
            for (int i = 0; i < initialableObjects.Length; i++)
            {
                initialableObjects[i].Initial(testSave);
            }

            Game.GameManager gameManager = new Game.GameManager(testSave);
            gameManager.StartGame(gameSetting);
        }
    }
}