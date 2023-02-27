using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    [Header("UI GameOver")]
    [SerializeField] private GameObject GameOverUI;

    [Header("UI Tap on Play")]
    [SerializeField] private GameObject TaponPlay;
    public static bool _isGameStarted;

    [Header("UI Setting Button")]
    [SerializeField] private GameObject SettingButton;
    [SerializeField] private GameObject ControlSetting;
    private bool CheckStatusOpenSetting;

    [Header("Setting Volume")]
    [SerializeField] private VolumeSave volumesave;
    [SerializeField] private AudioSource Music;
    [SerializeField] private Slider slider;
  

    private void Awake()
    {
        GameOverUI.SetActive(false);
        slider.value = volumesave.VolumeData;
    }
    private void OnEnable()
    {
       
        EventManager.GameOverEvent += GameOver;
    }
    private void OnDisable()
    {
        
        EventManager.GameOverEvent -= GameOver;

    }

    private void Start()
    {
        Time.timeScale = 1;
        _isGameStarted = false;
        CheckStatusOpenSetting = false;

    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y < Screen.height - 282)
            {
                if (CheckStatusOpenSetting == false)
                {
                    TapOnPlay();

                }
                else return;
                
            }
        }
        if (_isGameStarted==true)
        {
            gameObject.GetComponent<SpawmTrap>().enabled = true;
        }

        Music.volume = volumesave.VolumeData;
    }
    private void TapOnPlay()
    {
        _isGameStarted = true;
        TaponPlay.SetActive(false);
        SettingButton.SetActive(false);

    }

    public void ChangeVolume()
    {
        volumesave.VolumeData = slider.value;
    }






    public void OpenSetting()
    {
        CheckStatusOpenSetting = true;
        ControlSetting.SetActive(true);
    }
    public void CloseSetting()
    {
        CheckStatusOpenSetting = false;
        ControlSetting.SetActive(false);
    }


    public void GameOver()
    {

        GameOverUI.SetActive(true);

    }


    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("ShopMenu");
    }
}
