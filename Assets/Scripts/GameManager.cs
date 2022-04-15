using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float enemySpawnX1;
    public float enemySpawnX2;
    public float enemySpawnY1;
    public float enemySpawnY2;

    public int ammo = 10;

    public GameObject player;
    public GameObject[] enemies;

    public int score = 0;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(AddAmmo());
    }
       

    IEnumerator AddAmmo()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            if (ammo < 10)
            {
                ammo++;
            }
        }        
    }

    public void GameOver()
    {
        player.GetComponent<Animator>().SetTrigger("GameOver");
        foreach (var en in enemies)
        {
            Destroy(en);            
        }
    }
}
