using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dying : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.Equals("Player"))
            PlayerDying();
        if (collision.collider.tag.Equals("Enemy"))
            EnemyDying();
    }

    void EnemyDying()
    {
        Enemy.SetActive(false);
    }
    void PlayerDying()
    {
        Cursor.visible = true;
        Player.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
