using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Node", menuName = "Level Graph/Level Node")]
public class NodeLevelData : ScriptableObject
{
    public string levelName;
    public List<NodeLevelData> nextLevels;
    public bool isUnlocked = false;

    [Header("Materials")]
    public Material Blocked;
    public Material Unlocked;
    public Material Select;
}
