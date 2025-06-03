using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private TextMeshProUGUI buttonPlay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPlay()
    {
        SceneManager.LoadScene("levels");
    }
    public void ExitButton()
    {
        
    }
}
