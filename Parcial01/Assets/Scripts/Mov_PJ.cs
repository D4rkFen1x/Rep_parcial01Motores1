using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_PJ : MonoBehaviour
{
    public float rapidezDesplazamiento = 10.0f;
    public float fuerzaSalto = 5.0f;
    private bool enSuelo = true;

    public int maxSaltos = 2;
    private int saltosRestantes;

    private Rigidbody rb;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        saltosRestantes = maxSaltos;
    }
    void Update()
    {
        float movimientoAdelanteAtras = Input.GetAxis("Vertical") * rapidezDesplazamiento;
        float movimientoCostados = Input.GetAxis("Horizontal") * rapidezDesplazamiento;

        movimientoAdelanteAtras *= Time.deltaTime;
        movimientoCostados *= Time.deltaTime;

        transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            saltosRestantes--;
        }

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            saltosRestantes = maxSaltos;
        }
    }
}
