using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exibicion : MonoBehaviour
{
    public Image flagPlayer;
    public Text txtValuePlayer, namePlayer;
    public Image flagAi;
    public Text txtValueAi, nameAi;
    // Start is called before the first frame update
    void Start()
    {
        // ValueAi= PlayerPrefs.GetInt("valueAi, 1");
    }

    // Update is called once per frame
    void Update()
    {
        flagPlayer.sprite = Uiteam.instance.FlagTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        namePlayer.text = Uiteam.instance.NameTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        txtValuePlayer.text = PlayerPrefs.GetInt("valuePlayer", 1) + "/4";



        flagAi.sprite = Uiteam.instance.FlagTeam[PlayerPrefs.GetInt("valueAi", 1) - 1];
        nameAi.text = Uiteam.instance.NameTeam[PlayerPrefs.GetInt("valueAi", 1) - 1];
        txtValueAi.text = PlayerPrefs.GetInt("valueAi", 1) + "/4";


    }
    public void regresar()
    {

        SceneManager.LoadScene("MENU");
    }
    public void jugar()
    {
        SceneManager.LoadScene("JUEGO");

    }
    public void Playerleft()
    {
        if (PlayerPrefs.GetInt("valuePlayer", 1) <= 1)
        {
            PlayerPrefs.SetInt("valuePlayer", 4);
        }
        else
        {
            int valuePlayer = PlayerPrefs.GetInt("valuePlayer", 1);
            valuePlayer--;
            PlayerPrefs.SetInt("valuePlayer", valuePlayer);
        }
    }

   

    public void PlayerRight()
    {
        if (PlayerPrefs.GetInt("valuePlayer", 1) >= 4)
        {
            PlayerPrefs.SetInt("valuePlayer", 1);
        }
        else
        {
            int valuePlayer = PlayerPrefs.GetInt("valuePlayer", 1);
            valuePlayer++;
            PlayerPrefs.SetInt("valuePlayer", valuePlayer);
        }
    }
    public void AiRight()
    {
        if (PlayerPrefs.GetInt("valueAi", 1) >= 4)
        {
            PlayerPrefs.SetInt("valueAi", 1);
        }
        else
        {
            int valueAi = PlayerPrefs.GetInt("valueAi", 1);
            valueAi++;
            PlayerPrefs.SetInt("valueAi", valueAi);
        }
    }

    public void AiLeft()
    {
        if (PlayerPrefs.GetInt("valueAi", 1) <= 1)
        {
            PlayerPrefs.SetInt("valueAi", 4);
        }
        else
        {
            int valueAi = PlayerPrefs.GetInt("valueAi", 1);
            valueAi--;
            PlayerPrefs.SetInt("valueAi", valueAi);
        }
    }
}
