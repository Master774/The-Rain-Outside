using UnityEngine;

public class Jugador_Vision : MonoBehaviour {
    public float distanciaRayCast = 3.5f;
    public Camera camara;

    private RaycastHit hit;

    void Start() {
        // Obtén la cámara principal si no has asignado una
        if(camara == null) {
            camara = Camera.main;
        }
    }

    void Update() {
        // Lanza un rayo desde el centro de la cámara
        Ray rayo = camara.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        // Inicializa el hit para asegurar que quede vacío si no hay colisión
        hit = new RaycastHit();

        if(Physics.Raycast(rayo, out hit, distanciaRayCast)) {
            switch(hit.collider.tag) {
                case "Interruptor":
                // Acción para objetos con la etiqueta "Enemigo"
                Debug.Log("Interruptor");
                // Aquí puedes agregar más lógica para interactuar con el enemigo
                break;
                case "Item":
                // Acción para objetos con la etiqueta "Item"
                Debug.Log("Chocó con un Item");
                // Aquí puedes agregar más lógica para recoger el ítem
                break;
                default:
                
                break;
            }
        }

        // Dibujar la línea del rayo en el Editor
        Debug.DrawLine(rayo.origin, rayo.origin + rayo.direction * distanciaRayCast, Color.red);
    }
}