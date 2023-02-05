using UnityEngine;

namespace ProjectSK.Map
{
    [CreateAssetMenu(menuName = "Setting/Map Setting")]
    public class MapSetting : ScriptableObject
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
}