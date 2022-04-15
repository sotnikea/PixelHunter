using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDomaine : MonoBehaviour
{
    [SerializeField] private float speedMin;
    [SerializeField] private float speedMax;

    void Update()
    {
        transform.Translate(Vector2.left * Random.Range(speedMin, speedMax) * Time.deltaTime);
    }
}
