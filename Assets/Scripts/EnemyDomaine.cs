using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDomaine : MonoBehaviour
{
    [SerializeField] private float speedMin;
    [SerializeField] private float speedMax;
    private float speed;

    private void Start()
    {
        RandomSpeed();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void RandomSpeed()
    {
        speed = Random.Range(speedMin, speedMax);
    }
}
