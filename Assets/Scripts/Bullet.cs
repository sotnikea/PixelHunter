using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb2d;

    public void Fire()
    {
        rb2d.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        StartCoroutine(BulletDestroy());
    }

    private IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
