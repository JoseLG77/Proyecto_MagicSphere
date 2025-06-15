
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneLevel : MonoBehaviour
{
    [SerializeField] private NodeLevelData levelData;

    private Renderer _renderer;
    private Material[] materials;
    private bool isMouse = false;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        materials = _renderer.materials;
    }
    private void Update()
    {
        if (_renderer == null) return;

        if (!isMouse)
        {
            if (levelData.isUnlocked)//Si el nivel esta desbloqueado
            {
                materials[1] = levelData.Unlocked;
                _renderer.materials = materials;
            }
            else
            {
                materials[1] = levelData.Blocked;
                _renderer.materials = materials;
            }
        }
    }
    #region OnMouse
    //Se llama al hacer click sobre el objecto
    private void OnMouseDown()
    {
        if (levelData.isUnlocked)
        {
            Invoke("ChangeLevel", 1f);
        }
        else
        {
            Debug.Log("Nivel bloqueado: " + levelData.levelName);
        }
    }
    //Se llama mientras el mouse este encima del objecto
    private void OnMouseEnter()
    {
        isMouse = true;
        if (levelData.isUnlocked)
        {
            materials[1] = levelData.Select;
            _renderer.materials = materials;
        }
    }
    //Se llama cuando el mouse sale del objecto
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
