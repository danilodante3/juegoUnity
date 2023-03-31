using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    public float dashSpeed = 50f; // La velocidad del dash
    public float dashDuration = 0.1f; // La duración del dash
    public float dashCooldown = 5f; // El tiempo de recarga del dash
    private bool isDashing = false; // Si el personaje está haciendo un dash
    private float dashTimeLeft = 0f; // El tiempo restante del dash
    private float dashCooldownLeft = 0f; // El tiempo restante de la recarga del dash
    public Button dashButton; // El botón que activará el dash

    void Start()
    {
        dashButton.onClick.AddListener(ActivateDash);
    }

    void ActivateDash()
    {
        if (dashCooldownLeft <= 0)
        {
            isDashing = true;
            dashTimeLeft = dashDuration;

            Rigidbody2D rb;
            if (TryGetComponent<Rigidbody2D>(out rb))
            {
                rb.velocity = new Vector2(dashSpeed * transform.localScale.x, 0f);
            }
        }
    }

    void Update()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                dashTimeLeft -= Time.deltaTime;
            }
            else
            {
                isDashing = false;
                Rigidbody2D rb;
                if (TryGetComponent<Rigidbody2D>(out rb))
                {
                    rb.velocity = Vector2.zero;
                }

                dashCooldownLeft = dashCooldown;
            }

            if (dashCooldownLeft > 0)
            {
                dashCooldownLeft -= Time.deltaTime;
            }
        }
    }
}