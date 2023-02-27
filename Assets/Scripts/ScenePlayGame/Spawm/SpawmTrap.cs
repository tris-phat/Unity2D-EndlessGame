using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmTrap : MonoBehaviour
{
    [Header("Traps")]
    [SerializeField] private GameObject[] TrapPrefab;

    [Header("Points Trap")]
    [SerializeField] private Transform[] PointTrap;

    [Header("Time Instatiate Trap")]
    [SerializeField] private float TimeTrap;
    [SerializeField] private float RepeatRateTrap;
    [SerializeField] private float TimeDestroyTrap;

    [Header("Star")]
    [SerializeField] private GameObject[] StarPrefab;

    [Header("Point Star")]
    [SerializeField] private Transform[] PointStar;

    [Header("Time Instatiate Star")]
    [SerializeField] private float TimeStar;
    [SerializeField] private float RepeatRateStar;
    [SerializeField] private float TimeDestroyStar;

    void Start()
    {
        
        InvokeRepeating("Spawmtrap", TimeTrap, RepeatRateTrap);
        InvokeRepeating("SpawmStar", TimeStar, RepeatRateStar);

    }

    void Spawmtrap()
    {
        int IndexPointTrap = Random.Range(0, PointTrap.Length);
        GameObject gameObjectTrap = Instantiate(TrapPrefab[Random.Range(0, TrapPrefab.Length)],
        PointTrap[IndexPointTrap].transform.position  , Quaternion.identity);

        Destroy(gameObjectTrap, TimeDestroyTrap);
    }

    void SpawmStar()
    {
        int IndexPointStar = Random.Range(0, PointStar.Length);
        GameObject gameObjectStar = Instantiate(StarPrefab[Random.Range(0,StarPrefab.Length)],
        PointStar[IndexPointStar].transform.position, Quaternion.identity);

        Destroy(gameObjectStar, TimeDestroyStar);
    }
}
