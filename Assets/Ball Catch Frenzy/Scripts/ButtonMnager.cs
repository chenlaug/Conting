using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMnager : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(play);
    }

    // Update is called once per frame
    void play()
    {
        gameManager.isGameActive = 1;
    }
}
