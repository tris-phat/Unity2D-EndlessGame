using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UI_ShopManager : MonoBehaviour
{
    [Header("UI Star")]
    [SerializeField] private TMP_Text ShowCurrentStar;
    [SerializeField] private CountStarManager CoinData;
    public static int CurrentStar;


    [Header("Setting Volume")]
    [SerializeField] private VolumeSave volumeSave;
    [SerializeField] private AudioSource Music;

    private void Awake()
    {
    
        CurrentStar = CoinData.CoinValue;
        Music.volume = volumeSave.VolumeData;
    }

    private void Start()
    {

        

    }
    private void Update()
    {
        CurrentStar = CoinData.CoinValue;
        ShowCurrentStar.text = CurrentStar.ToString();
    }
    public void  BuyCharacter(int CharacterPrice)
    {
        CoinData.CoinValue -= CharacterPrice;
    }





    public void StartGame()
    {
        
        SceneManager.LoadScene("SampleScene");
    }


}
