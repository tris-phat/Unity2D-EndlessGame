using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;


public class MonkeyController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator anim;

    [Header("Change Lanes")]
    [SerializeField] private Transform Lane0;
    [SerializeField] private Transform Lane1;
    [SerializeField] private Transform Lane2;
    [SerializeField] private Transform Lane3;

    
    public int _currentLane = 1;

    private Vector3 targetDir;

    public static bool CharacterLife;

    private float OffsetGameOver= -5.8f;

    private void Start()
    {
        CharacterLife = true;
    }
    private void Update()
    {
        if(UIManager._isGameStarted==true)
        {
            // Control touch 
            if (Input.GetMouseButtonUp(0))
            {

                if (Input.mousePosition.x > Screen.width * 2 / 4)
                {

                    _currentLane++;
                    if (_currentLane == 4)
                    {
                        _currentLane = 3;


                    }
                    anim.SetTrigger("Jump");


                }

                if (Input.mousePosition.x < Screen.width / 2)
                {

                    _currentLane--;
                    if (_currentLane == -1)
                    {
                        _currentLane = 0;


                    }
                    anim.SetTrigger("Jump");


                }



            }
            
            // Control KeyBoard
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                _currentLane++;
                if (_currentLane == 4)
                {
                    _currentLane = 3;


                }
                anim.SetTrigger("Jump");

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _currentLane--;
                if (_currentLane == -1)
                {
                    _currentLane = 0;


                }
                anim.SetTrigger("Jump");
            }
        }

        

        


        if (_currentLane == 0)
        {
            targetDir = Lane0.transform.position;
            SetFlip(true);


        }
        else if (_currentLane == 1)
        {
            targetDir = Lane1.transform.position;
            SetFlip (false);


        }
        else if (_currentLane == 2)
        {
            targetDir = Lane2.transform.position;
            SetFlip(true);

        }
        else if (_currentLane == 3)
        {
            targetDir = Lane3.transform.position;
            SetFlip(false);


        }

        
    
    }
    //set Flip Character 
    private void SetFlip(bool Flip)
    {

        gameObject.GetComponent<SpriteRenderer>().flipX = Flip;

    }


    private void FixedUpdate()
    {
        if(CharacterLife )
        {
            transform.position = Vector3.Lerp(transform.position,
            targetDir, 10 * Time.fixedDeltaTime);

        }
    
        else if (!CharacterLife)
        {
            transform.Translate(Vector3.down * 15 * Time.fixedDeltaTime);
            if(transform.position.y<=OffsetGameOver)
            {
                EventManager.GameOver();
            }
        }
        

    }

    

    private void OnCollisionEnter2D(Collision2D colli)
    {
        if(colli.gameObject.CompareTag("Trap"))
        {
        
            anim.SetTrigger("Death");
            StartCoroutine(AfterDeath());
            
        }
        

    }
    IEnumerator AfterDeath()
    {
        
        yield return new WaitForSeconds(1f);
        CharacterLife = false;
  
    }

    

}



