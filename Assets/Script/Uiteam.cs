using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Uiteam : MonoBehaviour
{
    public static Uiteam instance;
    public Sprite[] FlagTeam;
    public string[] NameTeam;
    public Sprite[] head, shoe;
    // Start is called before the first frame update
    private void Awake()
    {
         if(instance == null)
        {


            instance = this;
            DontDestroyOnLoad(gameObject);
        }
         else
        {


            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
