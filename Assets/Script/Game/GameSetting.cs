using ProjectSK.Data;
using UnityEngine;

namespace ProjectSK.Game
{
    [CreateAssetMenu(menuName = "Setting/Game Setting")]
    public class GameSetting : ScriptableObject
    {
        [Tooltip("Set how many steps will be in 1 day")]
        [SerializeField] private int totalTimePerDay;
        public int TotalTimePerDay { get { return totalTimePerDay; } }

        [Tooltip("Set end game conditions")]
        [SerializeField] private EndGameConditionBase[] endGameConditions;

        public bool IsEndGame(SaveData saveData)
        {
            for (int i = 0; i < endGameConditions.Length; i++)
            {
                if (!endGameConditions[i].IsEnd(saveData))
                {
                    return false;
                }
            }

            return true;
        }
    }
}