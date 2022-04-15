using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject domaine;
    public Animator animator;
        
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        animator.SetTrigger("Respawn");

        if (gameObject.CompareTag("Square"))
        {
            GameManager.Instance.score += 3;
        }
        else if (gameObject.CompareTag("Circle"))
        {
            GameManager.Instance.score += 1;
        }
        else if (gameObject.CompareTag("Hexagon"))
        {
            GameManager.Instance.score += 2;
        }
    }

    public void Respawn()
    {
        animator.SetTrigger("Start");
        domaine.GetComponent<EnemyDomaine>().RandomSpeed();
        domaine.transform.position = new Vector2(
            Random.Range(GameManager.Instance.enemySpawnX1, GameManager.Instance.enemySpawnX2), 
            Random.Range(GameManager.Instance.enemySpawnY2, GameManager.Instance.enemySpawnY1));        
    }

    private void Update()
    {
        if (gameObject.transform.position.x < GameManager.Instance.player.transform.position.x)
        {
            GameManager.Instance.GameOver();
        }        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
