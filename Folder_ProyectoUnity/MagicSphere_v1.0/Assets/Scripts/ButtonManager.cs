using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEditor;

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
        SceneManager.LoadScene(nameScene);
    }
    public void ButtonSettings()
    {
        MenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void ButtonBackMenu([SerializeField] GameObject DesactivetPanel)
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
