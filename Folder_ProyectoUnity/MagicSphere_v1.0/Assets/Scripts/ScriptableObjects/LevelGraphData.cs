using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Graph", menuName = "Level Graph/Graph")]
public class LevelGraphData : ScriptableObject
{
    //desbloquea el nivel
    public void UnlockLevel(NodeLevelData completedLevel)
    {
        if (completedLevel.nextLevels != null)
        {
            completedLevel.nextLevels.isUnlocked = true;
        }
    }
}
