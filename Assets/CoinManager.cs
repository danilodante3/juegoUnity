using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    public Text coinText;
    private int totalCoins = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadCoins();
        UpdateCoinText();
        CoinManager.Instance.coinText = coinText;

    }

    public void AddCoins(int coins)
    {
        totalCoins += coins;
        SaveCoins();
        UpdateCoinText();
    }

    public int GetTotalCoins()
    {
        return totalCoins;
    }

    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + totalCoins.ToString();
    }

    private void SaveCoins()
    {
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
    }

    private void LoadCoins()
    {
        if (PlayerPrefs.HasKey("TotalCoins"))
        {
            totalCoins = PlayerPrefs.GetInt("TotalCoins");
        }
    }
}
