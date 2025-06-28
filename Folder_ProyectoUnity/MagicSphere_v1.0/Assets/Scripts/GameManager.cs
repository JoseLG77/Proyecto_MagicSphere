using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    private bool isPauseGame;
    private bool isFinishLevel;

    public static GameManager Instance { get; private set; }
    public static event Action FinishLevel;// Evento para cuando el jugador termina el nivel
    public static event Action StartLevel;// Evento para cuando el jugador termina el nivel

    public bool IsPauseGame
    {
        get { return isPauseGame; }
        set { IsPauseGame = value; }
    }

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
}
