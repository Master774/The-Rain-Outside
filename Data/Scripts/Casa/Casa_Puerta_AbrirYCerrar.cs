using UnityEngine;

public class Casa_Puerta_AbrirYCerrar : MonoBehaviour {
    public float AnguloDePuertaY = 90f; // �ngulo m�ximo de apertura en el eje Y
    public bool suavidadDePuerta = true; // Si la puerta debe abrirse/cerrarse suavemente
    public float velocidadDePuerta = 2f; // Velocidad de apertura/cierre

    private bool puertaAbierta = false; // Estado de la puerta
    private Quaternion rotacionCerrada; // Rotaci�n de la puerta cuando est� cerrada
    private Quaternion rotacionAbierta; // Rotaci�n de la puerta cuando est� abierta
    public bool MoviendoPuerta { get; private set; } = false; // Indica si la puerta est� en movimiento

    void Start() {
        // Rotaci�n inicial cerrada en 0 grados en el eje Y
        rotacionCerrada = Quaternion.Euler(0, 0, 0);

        // Rotaci�n objetivo cuando la puerta est� abierta
        rotacionAbierta = Quaternion.Euler(0, AnguloDePuertaY, 0);
    }

    void Update() {
        if(suavidadDePuerta) {
            if(MoviendoPuerta) {
                GetComponent<MeshCollider>().isTrigger = true;
                // Rotar suavemente la puerta hacia la rotaci�n objetivo
                transform.localRotation = Quaternion.Lerp(transform.localRotation, puertaAbierta ? rotacionAbierta : rotacionCerrada, Time.deltaTime * velocidadDePuerta);

                // Verifica si la puerta ha terminado de moverse
                if(Quaternion.Angle(transform.localRotation, puertaAbierta ? rotacionAbierta : rotacionCerrada) < 0.1f) {
                    transform.localRotation = puertaAbierta ? rotacionAbierta : rotacionCerrada;
                    MoviendoPuerta = false; // Detener el movimiento
                    GetComponent<MeshCollider>().isTrigger = false;
                }
            }
        }
        else {
            // Rotar instant�neamente la puerta a la rotaci�n objetivo
            transform.localRotation = puertaAbierta ? rotacionAbierta : rotacionCerrada;
            MoviendoPuerta = false; // No se est� moviendo
            GetComponent<MeshCollider>().isTrigger = false;
        }
    }

    public void CambiarEstadoDePuerta() {
        if(!MoviendoPuerta) {
            puertaAbierta = !puertaAbierta; // Cambiar el estado de la puerta
            MoviendoPuerta = true; // Iniciar el movimiento
        }
    }
}