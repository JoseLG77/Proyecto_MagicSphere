using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private string nameScene;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject SettingsPanel;
    void Start()
    {
        MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPlay()
    {
        FadeManager.Instance.fadePanel.gameObject.SetActive(true);
        FadeManager.Instance.ChangeSceneFade(nameScene);
    }
    public void ButtonSettings()
    {
        MenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void ButtonBackMenu(GameObject DesactivetPanel)
    {
        DesactivetPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();//Sirve para mandar a cerrar la aplicacion. 
        Debug.Log("Se ha cerrado el videojuego");
    }
}
