using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;

    [Header("Save Coin Data after play round")]
    [SerializeField] private CountStarManager CoinData;
    // Count Star
    private int CountStar;
    //
    private int _getStar;

    [Header("UI Count Star")]
    [SerializeField] private TMP_Text CountStar_Text;



    [Header("Save High Score after play round")]
    [SerializeField] private CountScore HighScoreData;
    // count Score
    private float _score;
    // Hight Score
    private int _hightScore;


    [Header("UI Count Score")]
    [SerializeField] private TMP_Text Score_Text;

    [Header("UI High Score")]
    [SerializeField] private TMP_Text HighScore_Text;



    [Header("Level Game")]
    [SerializeField] private float Level;
    // Bounus Speed
    public static float BonusSpeed;

    

    private void Awake()
    {
        
        Instance = this;
        _getStar = CoinData.CoinValue;
        _hightScore = HighScoreData.HightScoreValue;

       
        
    
        

    }
    private void OnEnable()
    {
        EventManager.CountStarEvent += Countstar;
       
    }
    private void OnDisable()
    {
        
        EventManager.CountStarEvent -= Countstar;
        
    }
    


    private void Start()
    {
        

        // Set Count Score = 0 khi mới bắt đầu chơi
        _score = 0;
        Score_Text.text = _score.ToString("Điểm:"+ " " + _score);

        // Set Count Star = 0 khi mới bắt đầu chơi
        CountStar = 0;
        CountStar_Text.text = CountStar.ToString();

   
        BonusSpeed = 1f;
    }

    private void Update()
    {
       


        CountScore();
        _hightScore = HighScoreData.HightScoreValue;

    }


    public void Countstar()
    {
        if (MonkeyController.CharacterLife == true)
        {
            CountStar++;
            CountStar_Text.text = CountStar.ToString();
            _getStar++;
            CoinData.CoinValue = _getStar;
        
        }
        
    }

    public void CountScore()
    {
        if (MonkeyController.CharacterLife == true && UIManager._isGameStarted == true)
        {
            _score += Time.deltaTime;

            if (_score >= Level)
            {
                BonusSpeed += 0.040f * Time.deltaTime;

            }

        }
        else return;
     
        Score_Text.text = _score.ToString("Điểm:" + " " + (int)_score);
     
        if(_score > _hightScore)
        {
            HighScoreData.HightScoreValue = (int)_score;
        }
        HighScore_Text.text = _hightScore.ToString();
    }
    

   
}

