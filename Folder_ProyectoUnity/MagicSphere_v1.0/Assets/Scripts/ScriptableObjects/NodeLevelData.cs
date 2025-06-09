using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Node", menuName = "Level Graph/Level Node")]
public class NodeLevelData : ScriptableObject
{
    public string levelName;
    public NodeLevelData nextLevels;
    public bool isUnlocked = false;
    public Material Blocked;
    public Material Unlocked;
    public Material Select;
}
