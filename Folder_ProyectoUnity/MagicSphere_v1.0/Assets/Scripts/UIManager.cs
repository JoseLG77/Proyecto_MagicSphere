using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

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
    [Header("---Text---")]
    [SerializeField] private TextMeshProUGUI timeGame;
    [SerializeField] private TextMeshProUGUI scoreGame;
    [SerializeField] private TextMeshProUGUI timeResult;
    [SerializeField] private TextMeshProUGUI ScoreResutl;
    [SerializeField] private TextMeshProUGUI beforeScoreResult;

    private float currentTime = 0;
    private float segU = 0;
    private float segD = 0;
    private float min = 0;
    private bool isGameplay;
    private bool isCronometre;
    private bool isSettings;
    private int score = 0;
    #endregion

    public static UIManager Instance { get; private set; }

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
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    public GameObject PanelSettings
    {
        get { return panelSettings; }
        set { panelSettings = value; }
    }
    #endregion

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
    void Start()
    {
        panelMenu.SetActive(true);
        panelTutorials.SetActive(false);
        panelSettings.SetActive(false);
        panelCredist.SetActive(false);
        panelGame.SetActive(false);
        panelResult.SetActive(false);
        isGameplay = false;
        isSettings = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameplay && isCronometre)
        {
            panelGame.SetActive(true);
            Chronometer();
            scoreGame.text = "Score: " + score;
        }
    }
    private void Chronometer()
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
    #region Methods
    public void GameSettings(InputAction.CallbackContext context)
    {
        if (context.performed && isGameplay && isSettings)
        {
            panelSettings.SetActive(true);
            isSettings = false;
            Time.timeScale = 0;
        }
        else if (context.performed && isGameplay && !isSettings)
        {
            panelSettings.SetActive(false);
            isSettings = true;
            Time.timeScale = 1;
        }
    }
    public void SaveStatisticsResult()
    {
        
    }
    #endregion
}
