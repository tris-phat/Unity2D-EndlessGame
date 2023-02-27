using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddCharacterData : MonoBehaviour
{
    

    [SerializeField] private Character Data;
    [SerializeField] private TMP_Text NameText;
    [SerializeField] private Image image;



    private Sprite Avatar;
    private string Name;
    public int ID;
    public int Price;
    public bool IsUnlock;


    private void Awake()
    {
        Avatar = Data.imageCharacter;
        Name = Data.Name;
        ID = Data.ID;
        Price = Data.Price;
        IsUnlock = Data.isUnlocked;
    }

    private void Start()
    {
        ShowData();
        

    }
    private void Update()
    {
       
        Data.isUnlocked = IsUnlock;
        
    }

    private void ShowData()
    {
        NameText.text = Name;
        image.sprite = Avatar;

    }

         



}
