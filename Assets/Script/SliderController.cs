using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public GameObject panel;

    void Start()
    {
        slider.value = 0f;
    }

    void Update()
    {
        if (slider.value == 1f)
        {
            panel.SetActive(true);
            SceneManager.LoadScene("NombreDeLaSiguienteEscena");
        }
    }
}
