using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float horizSpeed = 5f; // velocidad horizontal del jugador

    public void Move(int value)
    {
        if (GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            // Mueve al jugador horizontalmente según el valor pasado a la función
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(horizSpeed, 0f, 0f) * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-horizSpeed, 0f, 0f) * Time.deltaTime;
            }
        }
    }
    void Update()
    {
        Move(0); // Llama a la función Move para mover el jugador horizontalmente
    }
}
