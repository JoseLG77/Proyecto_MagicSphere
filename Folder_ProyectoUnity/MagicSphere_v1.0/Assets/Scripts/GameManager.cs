using UnityEngine;
using TMPro;
using System;
using NUnit.Framework;
using System.Security.Cryptography;
using System.Collections.Generic;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [Header("-----List-----")]
    [SerializeField] private List time;
    [SerializeField] private List score;

    private bool isPauseGame;
    private bool isFinishLevel;

    #region Event y Singleton
    public static GameManager Instance { get; private set; }
    public static event Action FinishLevel;// Evento para cuando el jugador termina el nivel
    public static event Action StartLevel;// Evento para cuando el jugador inicia el nivel
    #endregion

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
    public void InsertionSorft(List<int> value)
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
}
