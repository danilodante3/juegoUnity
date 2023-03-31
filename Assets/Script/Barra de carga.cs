using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barradecarga : MonoBehaviour
{
    public GameObject panelLoading, panelTransit;
    public Image img_loading;
    public static bool isLoading;
    void Start()
    {
        if (isLoading == false)
        {
            StartCoroutine(waitLoaddingMenu());
        }
        else
        {
            panelLoading.SetActive(false);
        }
    }
    void Update()
    {
        if (img_loading.fillAmount < 1)
        {
            img_loading.fillAmount += 0.1f;
        }
        if (img_loading.fillAmount >= 1)
        {
            isLoading= true;
        }
    }
    IEnumerator waitLoaddingMenu()
    {
        yield return new WaitForSeconds(3f);
        panelLoading.SetActive(false);
        yield return new WaitForSeconds(3f);
        panelLoading.SetActive(true);
        yield return new WaitForSeconds(3f);
        panelLoading.SetActive(false);
    }
}
