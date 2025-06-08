using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Graph", menuName = "Level Graph/Graph")]
public class LevelGraphData : MonoBehaviour
{
    public List<NodeLevelData> allLevels;
    //desbloquea el nivel
    public void UnlockLevel(NodeLevelData completedLevel)
    {
        foreach (var next in completedLevel.nextLevels)
        {
            next.isUnlocked = true;
        }
    }
}
