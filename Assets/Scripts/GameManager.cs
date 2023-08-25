using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;

    public BlockScript blockScript;

    public static GameManager instance;

    public GameObject[] pipes;

    private InterfaceManager ui;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ui = InterfaceManager.instance;
        block = GameObject.FindGameObjectWithTag("Player");
        blockScript = block.GetComponent<BlockScript>();
        block.SetActive(false);
        pipes = GameObject.FindGameObjectsWithTag("Pipe");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PipeScript.hasGameStarted = true;
        block.SetActive(true);
        blockScript.ResetGame();
        foreach(GameObject pipe in pipes)
        {
            Debug.Log("ran");
            PipeScript pipeScript = pipe.GetComponent<PipeScript>();
            pipeScript.ResetGame();
        }

    }
    public void OnPlayerDeath()
    {
        PipeScript.hasGameStarted = false;
        ui.deathMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
