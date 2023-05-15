using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFx : MonoBehaviour
{
    private static bool activateEffect = false;
    private Material material;

    void Awake()
    {
        material = new Material(Shader.Find("Huse360/Sweep"));
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (activateEffect)
        {
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    public static void ActivateEffect()
    {
        activateEffect = true;
    }
}
