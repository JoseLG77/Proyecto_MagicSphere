using UnityEngine;
using System;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [Header("-----List-----")]
    [SerializeField] private List<string> listTime;
    [SerializeField] private List<int> listScore;
    [SerializeField] private NodeCheckpoint[] checkPoint;

    private bool isPauseGame;
    private bool isFinishLevel;
    private int score = 0;

    #region Event y Singleton
    public static GameManager Instance { get; private set; }
    public static event Action FinishLevel;// Evento para cuando el jugador termina el nivel
    public static event Action StartLevel;// Evento para cuando el jugador inicia el nivel
    #endregion

    #region Getters y Setters
    public bool IsPauseGame
    {
        get { return isPauseGame; }
        set { IsPauseGame = value; }
    }
    public int Score
    {
        get { return score; }
        set { score = value; }
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
    private void OnEnable()
    {
        
    }
    void Start()
    {
        
    }
    void Update()
    {

    }
    public void InsertionSort(List<int> value)
    {
        for (int i = 0; i < value.Count; i++)
        {
            int key = value[1];
            int j = i - 1;
            while (j >= 0 && value[i] > key)
            {
                value[j + 1] = value[j];
                j--;
            }
            value[j + 1] = key;
        }
    }
    public void StartGame()
    {
        StartLevel?.Invoke();
    }
    public void LevelFinish()
    {
        FinishLevel?.Invoke();
    }
}
