using UnityEngine;

public class Casa_Puerta_AbrirYCerrar : MonoBehaviour {
    public float AnguloDePuertaY = 90f; // Ángulo máximo de apertura en el eje Y
    public bool suavidadDePuerta = true; // Si la puerta debe abrirse/cerrarse suavemente
    public float velocidadDePuerta = 2f; // Velocidad de apertura/cierre

    private bool puertaAbierta = false; // Estado de la puerta
    private Quaternion rotacionCerrada; // Rotación de la puerta cuando está cerrada
    private Quaternion rotacionAbierta; // Rotación de la puerta cuando está abierta
    public bool MoviendoPuerta { get; private set; } = false; // Indica si la puerta está en movimiento

    void Start() {
        // Rotación inicial cerrada en 0 grados en el eje Y
        rotacionCerrada = Quaternion.Euler(0, 0, 0);

        // Rotación objetivo cuando la puerta está abierta
        rotacionAbierta = Quaternion.Euler(0, AnguloDePuertaY, 0);
    }

    void Update() {
        if(suavidadDePuerta) {
            if(MoviendoPuerta) {
                GetComponent<MeshCollider>().isTrigger = true;
                // Rotar suavemente la puerta hacia la rotación objetivo
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
            // Rotar instantáneamente la puerta a la rotación objetivo
            transform.localRotation = puertaAbierta ? rotacionAbierta : rotacionCerrada;
            MoviendoPuerta = false; // No se está moviendo
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