using UnityEngine;

public class Casa_Control_Luz_Individual : MonoBehaviour {
    public Casa_Control_Energia CentralDeLuz;
    public GameObject LuzActual;
    public bool LuzEncendida;

    void Start() {
        LuzActual = gameObject.transform.gameObject;
        ActualizarEstadoLuz();
    }

    void Update() {
        if((LuzEncendida && CentralDeLuz.hayEnergia && !LuzActual.activeSelf) ||
            (!LuzEncendida || !CentralDeLuz.hayEnergia) && LuzActual.activeSelf) {
            ActualizarEstadoLuz();
        }
    }

    void ActualizarEstadoLuz() {
        LuzActual.SetActive(LuzEncendida && CentralDeLuz.hayEnergia);
    }
}