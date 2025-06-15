using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Graph", menuName = "Level Graph / Level Graph")]
public class LevelGraphData : ScriptableObject
{
    public List<NodeLevelData> nodeLevel = new List<NodeLevelData>();
    
    //agrega un nodo si aun no esta 
    public void AddNodeVertix(NodeLevelData level)
    {
        if (!nodeLevel.Contains(level))
        {
            nodeLevel.Add(level);
        }
    }
    //Conecta los un nivel con otro.
    public void AddEdge(NodeLevelData current, NodeLevelData next)
    {
        if (!current.nextLevels.Contains(next))
        {
            current.nextLevels.Add(next);
        }

    }
    //desbloquea los siguientes niveles
    public void UnlockLevel(NodeLevelData nextLevel)
    {
        foreach (var next in nextLevel.nextLevels)
        {
            next.isUnlocked = true;
        }
    }
}
