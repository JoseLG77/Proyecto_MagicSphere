using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneLevel : MonoBehaviour
{
    [SerializeField] private NodeLevelData levelData;

    private Renderer _renderer;
    Material[] mats;
    private bool isMouse = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        mats = _renderer.materials;
    }
    private void Update()
    {
        if (_renderer == null) return;

        if (!isMouse)
        {
            if (levelData.isUnlocked)//Si el nivel esta desbloqueado
            {
                mats[1] = levelData.Unlocked;
                _renderer.materials = mats;
            }
            else
            {
                mats[1] = levelData.Blocked;
                _renderer.materials = mats;
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
            mats[1] = levelData.Select;
            _renderer.materials = mats;
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
