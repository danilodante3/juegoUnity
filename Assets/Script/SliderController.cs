using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public GameObject panel;

    void Start()
    {
        // Inicializa el valor del slider a 0
        slider.value = 0f;
    }

    void Update()
    {
        // Si el valor del slider llega a 1, carga la siguiente escena y muestra el panel
        if (slider.value == 1f)
        {
            panel.SetActive(true);
            SceneManager.LoadScene("NombreDeLaSiguienteEscena");
        }
    }
}
