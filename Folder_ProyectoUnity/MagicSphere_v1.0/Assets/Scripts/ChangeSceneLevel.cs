using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneLevel : MonoBehaviour
{
    [SerializeField] private NodeLevelData levelData;

    private Renderer _renderer;
    private bool isMouse = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        if (_renderer == null) return;

        if (!isMouse)
        {
            if (levelData.isUnlocked)//Si el nivel esta desbloqueado
            {
                _renderer.material = levelData.Unlocked;
            }
            else
            {
                _renderer.material = levelData.Blocked;
            }
        }
    }
    #region OnMouse
    private void OnMouseDown()
    {
        if (levelData.isUnlocked)
        {
            Invoke("ChangeLevel", 1.5f);
        }
        else
        {
            Debug.Log("Nivel bloqueado: " + levelData.levelName);
        }
    }
    private void OnMouseEnter()
    {
        isMouse = true;
        if (levelData.isUnlocked)
        {
            _renderer.material = levelData.Select;
        }
    }
    private void OnMouseExit()
    {
        isMouse= false;
    }
    #endregion

    private void ChangeLevel()
    {
        SceneManager.LoadScene(levelData.levelName);
    }
}
