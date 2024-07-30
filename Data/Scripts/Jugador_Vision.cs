using UnityEngine;

public class Jugador_Vision : MonoBehaviour {
    public float distanciaRayCast = 3.5f;
    public Camera camara;

    private RaycastHit hit;

    void Start() {
        // Obt�n la c�mara principal si no has asignado una
        if(camara == null) {
            camara = Camera.main;
        }
    }

    void Update() {
        // Lanza un rayo desde el centro de la c�mara
        Ray rayo = camara.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        // Inicializa el hit para asegurar que quede vac�o si no hay colisi�n
        hit = new RaycastHit();

        if(Physics.Raycast(rayo, out hit, distanciaRayCast)) {
            switch(hit.collider.tag) {
                case "Interruptor":
                // Acci�n para objetos con la etiqueta "Enemigo"
                Debug.Log("Interruptor");
                // Aqu� puedes agregar m�s l�gica para interactuar con el enemigo
                break;
                case "Item":
                // Acci�n para objetos con la etiqueta "Item"
                Debug.Log("Choc� con un Item");
                // Aqu� puedes agregar m�s l�gica para recoger el �tem
                break;
                default:
                
                break;
            }
        }

        // Dibujar la l�nea del rayo en el Editor
        Debug.DrawLine(rayo.origin, rayo.origin + rayo.direction * distanciaRayCast, Color.red);
    }
}