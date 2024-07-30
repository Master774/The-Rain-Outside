using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class Interruptures : MonoBehaviour {
    public Light LuzObjetivo;
    public bool encendida = true;
    void Start() {

    }


    void Update() {

    }
    public void Interruptor() {
        if(encendida) {
            encendida = false;
            LuzObjetivo.enabled = false;
        }
        else {
            encendida = true;
            LuzObjetivo.enabled = true;
        }
    }
}
