using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantillaItemTienda : MonoBehaviour
{
    public Image imagen;
    public TextMeshProUGUI textoPrecio;
    public TextMeshProUGUI titulo;
    public Button botonComprar;
    int precio;
    int monedaTotales;
    // Start is called before the first frame update
    void Start()
    {
        precio = int.Parse(textoPrecio.text);
    }

    // Update is called once per frame
    void Update()
    {
        monedaTotales = PlayerPrefs.GetInt("monedasTotales");
        if (precio > monedaTotales)
        {
            botonComprar.interactable = false;
        }
    }
    public void Comprar()
    {
        monedaTotales -= precio;
        PlayerPrefs.SetInt("monedasTotales", monedaTotales);
    }
}