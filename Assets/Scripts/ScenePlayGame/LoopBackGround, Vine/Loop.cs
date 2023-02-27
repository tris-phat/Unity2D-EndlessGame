using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    public float speed;
    public float Offset;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime * GameManager.BonusSpeed);
        if (transform.position.y <= Offset)
        {
            transform.position = startPosition;
        }
        
    }
}
