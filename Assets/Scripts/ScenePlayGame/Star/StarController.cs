using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public float Speed;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * Speed * GameManager.BonusSpeed * Time.fixedDeltaTime);
    }
}
