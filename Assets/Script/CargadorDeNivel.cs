using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CargadorDeNivel : MonoBehaviour
{
    [SerializeField]
    private Slider Slider;
    [SerializeField]
    private GameObject PantallaDeCarga;
    public float porcentaje;
    private AsyncOperation Operacion;
   public void CargadorNivel (int NumeroDeEscenas)
   {
        PantallaDeCarga.SetActive(true);
        
        StartCoroutine(this.CargarAsync(NumeroDeEscenas));
   }

    IEnumerator  CargarAsync(int NumeroDeEscenas)
    {
        Operacion = SceneManager.LoadSceneAsync(NumeroDeEscenas);
        Operacion.allowSceneActivation= false;
        while (!Operacion.isDone ) {
            porcentaje = Operacion.progress *100 /0.9f;
            yield return null;
        }

    }
    private void Update()
    {
        Slider.value = Mathf.MoveTowards(Slider.value, porcentaje,10*Time.deltaTime);
        if (Operacion != null && porcentaje >= 100) { 
        Operacion.allowSceneActivation = true;
        }
    }


}