using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organs : MonoBehaviour
{
    int addScore = 10;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.UpdateScore(addScore);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Sonner"))
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }
}
