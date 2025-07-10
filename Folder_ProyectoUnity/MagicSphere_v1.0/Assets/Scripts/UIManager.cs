using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Properties
    [Header("---Panel---")]
    public GameObject panelMenu;
    [SerializeField] private GameObject panelTutorials;
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject panelCredist;
    public GameObject panelGame;
    public GameObject panelResult;
    [SerializeField] private GameObject panelSelecLevel;
    [Header("---Text---")]
    [SerializeField] private TextMeshProUGUI timeGame;
    [SerializeField] private TextMeshProUGUI scoreGame;
    [SerializeField] private TextMeshProUGUI timeResult;
    [SerializeField] private TextMeshProUGUI ScoreResutl;
    [SerializeField] private TextMeshProUGUI afterScoreResult;

    private float currentTime = 0;
    private float segU = 0;
    private float segD = 0;
    private float min = 0;
    private bool isGameplay;
    private bool isCronometre;
    private bool isSettings;
    #endregion

    public static UIManager Instance { get; private set; }//Singleton

    #region Getters y Setters
    public bool IsGameplay
    {
        get { return isGameplay; }
        set { isGameplay = value; }
    }
    public bool OnCronometro
    {
        get { return isCronometre; }
        set { isCronometre = value; }
    }
    public bool IsSettings
    {
        get { return isSettings; }
        set { isSettings = value; }
    }
    public GameObject PanelSettings
    {
        get { return panelSettings; }
        set { panelSettings = value; }
    }
    public GameObject PanelSelecLevel
    {
        get { return panelSelecLevel; }
        set { panelSelecLevel = value; }
    }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnEnable()
    {
        GameManager.StartLevel += StartGame;
        GameManager.FinishLevel += LevelFinish;
        GameManager.FinishLevel += SaveStatisticsResult;
    }
    private void OnDisable()
    {
        GameManager.StartLevel -= StartGame;
        GameManager.FinishLevel -= LevelFinish;
        GameManager.FinishLevel -= SaveStatisticsResult;
    }
    void Start()
    {
        panelMenu.SetActive(true);
        panelTutorials.SetActive(false);
        panelSettings.SetActive(false);
        panelCredist.SetActive(false);
        panelGame.SetActive(false);
        panelResult.SetActive(false);
        panelSelecLevel.SetActive(false);
        isGameplay = false;
        isSettings = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameplay)
        {
            Chronometer();
            scoreGame.text = "Score: " + GameManager.Instance.Score;
        }
    }
    #endregion

    #region Methods
    private void Chronometer()
    {
        if (isCronometre)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= 1)
            {
                segU++;
                currentTime = 0;
                if (segU == 10)
                {
                    segD++;
                    segU = 0;
                    if (segD == 6)
                    {
                        min++;
                        segD = 0;
                    }
                }
            }
            timeGame.text = min + " : " + segD + segU;
        }
        //Tiempo asintotico es O(1)
    }
    public void GameSettings(InputAction.CallbackContext context)
    {
        if (context.performed && isGameplay && isSettings)
        {
            panelSettings.SetActive(true);
            panelGame.SetActive(false);
            isSettings = false;
            Time.timeScale = 0;
        }
        else if (context.performed && isGameplay && !isSettings)
        {
            panelSettings.SetActive(false);
            panelGame.SetActive(true);
            isSettings = true;
            Time.timeScale = 1;
        }
        //Tiempo asintotico es O(1)
    }
    public void SaveStatisticsResult()
    {
        timeResult.text = timeGame.text;
        ScoreResutl.text = scoreGame.text;
    }
    public void StartGame()
    {
        panelMenu.SetActive(false);
        panelTutorials.SetActive(false);
        panelSettings.SetActive(false);
        panelCredist.SetActive(false);
        panelGame.SetActive(true);
        panelResult.SetActive(false);
        isGameplay = true;
        isCronometre = true;
        //Tiempo asintotico es O(1)
    }
    public void LevelFinish()
    {
        panelMenu.SetActive(false);
        panelTutorials.SetActive(false);
        panelSettings.SetActive(false);
        panelCredist.SetActive(false);
        panelGame.SetActive(false);
        panelResult.SetActive(true);
        isGameplay = false;
        isCronometre = false;
    }
    #endregion
}
