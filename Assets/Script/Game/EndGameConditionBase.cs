using ProjectSK.Data;
using UnityEngine;

namespace ProjectSK.Game
{
    public abstract class EndGameConditionBase : ScriptableObject
    {
        public abstract bool IsEnd(SaveData saveData);
    }
}