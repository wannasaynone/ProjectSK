using UnityEngine;
using System;
using ProjectSK.Data;

namespace ProjectSK.Map.MapEvent
{
    public abstract class MapEventBase : ScriptableObject
    {
        [Serializable]
        public class MapSetting
        {
            [Tooltip("start from 0, will enable map button at these index")]
            [SerializeField] private int[] openTimeIndex;
            public int[] OpenTimeIndex
            {
                get
                {
                    int[] clone = new int[openTimeIndex.Length];
                    openTimeIndex.CopyTo(clone, 0);
                    return clone;
                }
            }

            [Tooltip("set map name, should be unique, but won't check duplicated name")]
            [SerializeField] private string mapName;
            public string MapName { get { return mapName; } }

            [Tooltip("set is require mission, if it is true, button will disbaled if doesn't have mission")]
            [SerializeField] private bool isRequireMission;
            public bool IsRequireMission { get { return isRequireMission; } }
        }

        public static event Action<MapEventBase> OnMapEventBeforeStart;
        public static event Action<MapEventBase> OnMapEventEnded;

        [SerializeField] private MapSetting mapSetting;
        public MapSetting Setting { get { return mapSetting; } }

        protected SaveData Save { get; private set; }

        public void StartEvent(SaveData saveData)
        {
            Save = saveData;
            OnMapEventBeforeStart?.Invoke(this);
            DoMapEvent();
        }

        protected void EndEvent()
        {
            Save = null;
            OnMapEventEnded?.Invoke(this);
        }

        protected abstract void DoMapEvent();
    }
}