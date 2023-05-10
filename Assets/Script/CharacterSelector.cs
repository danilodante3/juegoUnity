using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public Image characterImage; // Referencia al componente Image que mostrará el sprite del personaje
    public Sprite[] characterSprites; // Array de sprites de personajes seleccionables

    private int currentIndex = 0; // Índice actual del sprite seleccionado

    private void Start()
    {
        // Mostrar el primer sprite al iniciar el juego
        characterImage.sprite = characterSprites[currentIndex];
    }

    public void NextCharacter()
    {
        // Incrementar el índice para cambiar al siguiente sprite
        currentIndex++;

        // Si alcanzamos el final del array, volvemos al principio
        if (currentIndex >= characterSprites.Length)
        {
            currentIndex = 0;
        }

        // Mostrar el sprite correspondiente al índice actual
        characterImage.sprite = characterSprites[currentIndex];
    }

    public void PreviousCharacter()
    {
        // Decrementar el índice para retroceder al personaje anterior
        currentIndex--;

        // Si estamos en el inicio del array, retrocedemos al final
        if (currentIndex < 0)
        {
            currentIndex = characterSprites.Length - 1;
        }

        // Mostrar el sprite correspondiente al índice actual
        characterImage.sprite = characterSprites[currentIndex];
    }
}
