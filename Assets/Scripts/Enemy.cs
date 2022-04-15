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
        
    }

    public void Respawn()
    {
        domaine.GetComponent<EnemyDomaine>().RandomSpeed();
        domaine.transform.position = new Vector2(
            Random.Range(GameManager.Instance.enemySpawnX1, GameManager.Instance.enemySpawnX2), 
            Random.Range(GameManager.Instance.enemySpawnY2, GameManager.Instance.enemySpawnY1));
        animator.SetTrigger("Start");
    }
}
