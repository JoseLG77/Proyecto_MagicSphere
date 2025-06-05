using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneLevel : MonoBehaviour
{
    [SerializeField] private NodeLevelData levelData;
    private void OnMouseDown()
    {
        if (levelData.isUnlocked)
        {
            SceneManager.LoadScene(levelData.levelName);
        }
        else
        {
            Debug.Log("Nivel bloqueado: " + levelData.levelName);
        }
    }
}
