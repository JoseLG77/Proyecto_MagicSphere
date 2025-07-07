using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;

    #region Methods
    public void ButtonChangeScene(string nameScene)
    {
        if (UIManager.Instance.IsGameplay)
        {
            UIManager.Instance.panelResult.SetActive(false);
        }
        FadeManager.Instance.fadePanel.gameObject.SetActive(true);
        UIManager.Instance.PanelSettings.gameObject.SetActive(false);
        UIManager.Instance.IsGameplay = false;
        FadeManager.Instance.ChangeSceneFade(nameScene);
        Time.timeScale = 1.0f;
    }
    public void ButtonActivePanel(GameObject activePanel)
    {
        MenuPanel.SetActive(false);
        activePanel.SetActive(true);
    }
    public void ButtonBack(GameObject currentPanel)
    {
        if (UIManager.Instance.IsGameplay)
        {
            currentPanel.SetActive(false);
            UIManager.Instance.IsSettings = true;
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            return;
        }
        currentPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
    public void ButtonRetry()
    {
        Time.timeScale = 1f; //Para que ya no este en pause
        UIManager.Instance.panelResult.SetActive(false);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void ExitButton()
    {
        Application.Quit();//Sirve para mandar a cerrar la aplicacion. 
        //SceneManager.GetSceneByName(SceneManager.GetActiveScene().name);
    }
    #endregion
}
