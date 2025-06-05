using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private string nameScene;
    [SerializeField] private GameObject SettingsPanel;
    void Start()
    {
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
        SettingsPanel.SetActive(true);
    }
    public void ExitButton()
    {
        Application.Quit();//Sirve para mandar a cerrar la aplicacion. 
        Debug.Log("Se ha cerrado el videojuego");
    }
}
