using UnityEngine;
using UnityEngine.UI;

public class CoinPack : MonoBehaviour
{
    public Text coinText;
    private int coinsToAdd = 1000;

    public void BuyCoins()
    {
        int currentCoins;
        if (int.TryParse(coinText.text.Replace("Coins: ", ""), out currentCoins))
        {
            int newCoins = currentCoins + coinsToAdd;
            coinText.text = "Coins: " + newCoins.ToString();

            CoinManager.Instance.AddCoins(coinsToAdd); // Agregar monedas al CoinManager
        }
        else
        {
            Debug.LogError("El valor del texto de las monedas no es un número válido.");
        }
    }
}
