using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{

    [SerializeField] private CharacterData Data;
    [SerializeField] private GameObject[] CharacterModel;
    [SerializeField] private Character[] Characters;


    [Header("UI Name Character")]
    [SerializeField] private TMP_Text NameCharacter;

    [Header("UI Buy Button")]
    [SerializeField] private Button BuyButton;

    [Header("UI PlayButton")]
    [SerializeField] private Button PlayButton;


    private int CurrentCharacter;

   
    private void Start()
    {
        foreach (Character chars in Characters)
        {
            if (chars.Price == 0)
            {
                chars.isUnlocked = true;
            }
            else
            {
                chars.isUnlocked = PlayerPrefs.GetInt(chars.name, 0) == 0 ? false : true;
            }
        }




        CurrentCharacter = Data.IdData;
        foreach (var c in CharacterModel)
        {
            c.gameObject.SetActive(false);


        }
        CharacterModel[CurrentCharacter].SetActive(true);

    }



    private void Update()
    {
        Data.IdData = CurrentCharacter;

        if (Input.GetMouseButtonUp(0))
        {
            if(Input.mousePosition.x > Screen.width -100 )
            {
                NextCharacter();
            }
            if(Input.mousePosition.x < Screen.width /4)
            {
                BackCharacter();
            }

        }

        ChangeStatusCharacter();
        ShowNameCharacter();

    }

    private void ShowNameCharacter()
    {
        Character chars = Characters[CurrentCharacter];
        NameCharacter.text = chars.Name;
    }

    private void NextCharacter()
    {
        CharacterModel[CurrentCharacter].SetActive(false);
        CurrentCharacter++;

        if(CurrentCharacter == CharacterModel.Length)
        {
            CurrentCharacter = 0;
        }
        
        
        CharacterModel[CurrentCharacter].SetActive(true);
        
    }

    private void BackCharacter()
    {
        CharacterModel[CurrentCharacter].SetActive(false);
        CurrentCharacter--;
        if (CurrentCharacter == -1)
        {
            CurrentCharacter = CharacterModel.Length-1;
        }
        
       

        CharacterModel[CurrentCharacter].SetActive(true);
       
    }

    private void ChangeStatusCharacter()
    {
        Character chars = Characters[CurrentCharacter];
        if(chars.isUnlocked)
        {
            SetActiveBuyButton(false);
            SetActivePlayButton(true);
            
        }
        else
        {
            SetActivePlayButton(false);
            SetActiveBuyButton(true);
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = chars.Price.ToString();
            if(UI_ShopManager.CurrentStar >= chars.Price)
            {
                BuyButton.interactable = true;
            }
            else
            {
                BuyButton.interactable = false;
            }
        }

    }






    private void SetActiveBuyButton(bool Active)
    {
        BuyButton.gameObject.SetActive(Active);
    }

    private void SetActivePlayButton(bool Active)
    {
        PlayButton.gameObject.SetActive(Active);

    }



    public void UnLock()
    {
        Character chars = Characters[CurrentCharacter];
        PlayerPrefs.SetInt(chars.name, 1);
        Data.IdData = CurrentCharacter;
    
        chars.isUnlocked = true;
        gameObject.GetComponent<UI_ShopManager>().BuyCharacter(chars.Price);
    

    }

   
   
   
}
