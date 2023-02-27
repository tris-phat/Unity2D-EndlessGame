using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelecter : MonoBehaviour
{

    [SerializeField] private CharacterData Data;
    [SerializeField] private Character[] Chars;

    [SerializeField] private GameObject[] Characters;



    private void Start()
    {
        Character chars = Chars[Data.IdData];
        foreach (GameObject Chars in Characters)
        {
            Chars.SetActive(false);
            if (chars.isUnlocked == true)
            {
                Characters[Data.IdData].SetActive(true);

            }
            else
            {
                Characters[0].SetActive(true);
            }
           
        }
       

    }
}
