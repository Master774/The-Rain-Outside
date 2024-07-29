using System;
using UnityEngine;

public class Jugador_Movimiento : MonoBehaviour {
    public float velocidadMovimiento = 5.0f;
    public float velocidadCarrera = 10.0f;
    public float sensibilidadMouse = 2.0f;
    public float gravedad = 9.8f;
    public float tiempoAceleracion = 0.5f;

    private CharacterController controlador;
    private Vector3 velocidad;
    private float rotacionX = 0;
    private float velocidadActual = 0.0f;
    private float velocidadObjetivo = 0.0f;
    private float tiempoCambioVelocidad = 0.0f;


    void Start() {
        controlador = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        Movimiento();
    }

    private void Movimiento() {
        // Movimiento del mouse para rotar la cámara
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90, 90);

        transform.Rotate(0, mouseX, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);

        // Determinar la velocidad objetivo
        float velocidadMaxima = Input.GetKey(KeyCode.LeftShift) ? velocidadCarrera : velocidadMovimiento;

        if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) {
            velocidadObjetivo = velocidadMaxima;
        }
        else {
            velocidadObjetivo = 0;
        }

        // Interpolación lineal para la aceleración y frenado
        velocidadActual = Mathf.SmoothDamp(velocidadActual, velocidadObjetivo, ref tiempoCambioVelocidad, tiempoAceleracion);

        // Movimiento del personaje con WASD
        float movimientoAdelanteAtras = Input.GetAxis("Vertical");
        float movimientoLateral = Input.GetAxis("Horizontal");

        Vector3 movimiento = transform.forward * movimientoAdelanteAtras + transform.right * movimientoLateral;
        movimiento.Normalize();
        movimiento *= velocidadActual;

        if(controlador.isGrounded) {
            velocidad.y = 0;
        }
        else {
            velocidad.y -= gravedad * Time.deltaTime;
        }

        controlador.Move((movimiento + velocidad) * Time.deltaTime);
    }
}