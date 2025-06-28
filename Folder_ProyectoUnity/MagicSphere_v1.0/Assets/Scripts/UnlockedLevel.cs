using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockedLevel : MonoBehaviour
{
    [SerializeField] private LevelGraphData levelGraph;
    [SerializeField] private NodeLevelData currentLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelGraph.UnlockLevel(currentLevel);
            UIManager.Instance.panelResult.SetActive(true);
        }
    }
}
