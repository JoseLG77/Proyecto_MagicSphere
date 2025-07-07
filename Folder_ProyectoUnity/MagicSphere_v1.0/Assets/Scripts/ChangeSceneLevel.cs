using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneLevel : MonoBehaviour
{
    #region Properties
    [SerializeField] private NodeLevelData levelData;

    [SerializeField]private Renderer _renderer;
    [SerializeField]private Material[] materials;
    private bool isMouse = false;
    #endregion

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        materials = _renderer.materials;
        UIManager.Instance.panelMenu.gameObject.SetActive(false);
        FadeManager.Instance.fadePanel.gameObject.SetActive(true);
        FadeManager.Instance.FadeIn();
        PlayerPrefs.SetInt("IsState", levelData.isUnlocked ? 1 : 0);
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
            FadeManager.Instance.FadeOut();
            GameManager.Instance.StartGame();
            FadeManager.Instance.ChangeSceneFade(levelData.levelName);
            //GameManager.Instance.StartGame();
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
}
