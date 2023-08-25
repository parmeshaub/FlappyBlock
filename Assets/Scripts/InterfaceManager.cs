using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager instance;
    public TextMeshProUGUI score;

    public GameObject scoreObject;

    public GameObject deathMenu;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        score.text = "0";
        scoreObject.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
