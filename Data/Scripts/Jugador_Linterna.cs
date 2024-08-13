using System;
using UnityEngine;

public class Jugador_Linterna : MonoBehaviour {

    public GameObject linterna;
    public bool linternaEncendida = false;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
        ControlDeLinterna();
        if(linternaEncendida) {
            linterna.SetActive(true);
        }
        else {
            linterna.SetActive(false);
        }
    }

    private void ControlDeLinterna() {
        if(linternaEncendida && Input.GetKeyDown(KeyCode.F)) {
            linternaEncendida = false;
        }
        else if(!linternaEncendida && Input.GetKeyDown(KeyCode.F)) {
            linternaEncendida = true;
        }
    }
}
