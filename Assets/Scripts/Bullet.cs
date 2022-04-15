using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb2d;

    public void Fire(Vector2 direction)
    {
        rb2d.AddForce(direction * speed, ForceMode2D.Impulse);
        StartCoroutine(BulletDestroy());
    }

    private IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
