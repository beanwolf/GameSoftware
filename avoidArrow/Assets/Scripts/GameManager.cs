using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    GameObject player;
    public float heart = 3;
    public Text heartScore;
    public static GameManager instance;
    public bool isPlayerAlive = true;

    private void Awake()
    {
        if (GameManager.instance == null)
            GameManager.instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("startGame", 2f);
    }

    void startGame()
    {
        ArrowSpawn.instance.isSpawn = true;
    }

    public void KillPlayer()
    {
        isPlayerAlive = false;
        ArrowSpawn.instance.isSpawn = false;
        TextController.instance.ShowGameOver();
    }

    public void deleteHeart()
    {
        heart = heart - 0.5f ;
        heartScore.text = "남은 목숨 : " + heart;
        Debug.Log("delete Heart");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
