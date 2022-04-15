using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject domaine;
    public Animator animator;

    public Transform enemySpawnObject;
    public GameObject bulletPrefab;

    private void Start()
    {
        StartCoroutine(EnemyFire());
    }

    IEnumerator EnemyFire()
    {
        float time = Random.Range(1, 5);
        yield return new WaitForSeconds(time);
        var bullet = Instantiate(bulletPrefab, enemySpawnObject.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Fire(Vector2.left);
    }


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
        domaine.GetComponent<EnemyDomaine>().RandomSpeed();
        domaine.transform.position = new Vector2(
            Random.Range(GameManager.Instance.enemySpawnX1, GameManager.Instance.enemySpawnX2), 
            Random.Range(GameManager.Instance.enemySpawnY2, GameManager.Instance.enemySpawnY1));
        animator.SetTrigger("Start");
    }

    private void Update()
    {
        if (gameObject.transform.position.x < GameManager.Instance.player.transform.position.x)
        {
            Respawn();
            GameManager.Instance.GameOver();
        }        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Respawn();
            GameManager.Instance.GameOver();
        }
    }
}
