using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public void UnlockLevel(NodeLevelData nodeLevelData)
    {
        foreach (var next in nodeLevelData.nextLevels)
        {
            next.isUnlocked = true;

            string keyLevel = "Desbloqueado " + next.name;
            PlayerPrefs.SetInt(keyLevel, 1);
        }
        PlayerPrefs.Save(); //Save lo que hace es guardar todos los cambios
    }
}
