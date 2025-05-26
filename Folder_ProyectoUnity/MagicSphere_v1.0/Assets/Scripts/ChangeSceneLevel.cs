using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneLevel : MonoBehaviour
{
    [SerializeField] private NodeLevelData levelData;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
