using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb2d;
    Vector2 direction;

    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject bulletPrefab;

    private void Update()
    {
        #region MovePlayer
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down * speed;
        }

        rb2d.velocity = direction;
        #endregion
        #region Fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateBullet();
        }
        #endregion
    }

    public void CreateBullet()
    {
        if (GameManager.Instance.ammo == 0)
        {
            return;
        }
        GameManager.Instance.ammo--;

        var bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Fire();
    }

}
