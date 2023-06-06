using UnityEngine;
using UnityEngine.UI;

public class Comprar : MonoBehaviour
{
    public Text coinText;
    private int totalCoins = 0;

    public void AddCoins(int coins)
    {
        totalCoins += coins;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + totalCoins.ToString();
    }
}