using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SimonDice : MonoBehaviour
{
    public GameObject Texto;
    Jugador player;
    Animator anim;
    public bool abierto;
    public bool cerca;
    public InputAction Interaccion;

    void Start()
    {
        player = FindObjectOfType<Jugador>();
        anim = gameObject.GetComponent<Animator>();
        Interaccion.Enable();
        abierto = false;
        cerca = false;
        Texto.SetActive(false);

        if (Datos.SimonDice == true)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (abierto == true && other.CompareTag("Player"))
        {
            Texto.SetActive(false);
            cerca = false;
        }
        if (abierto == false && other.CompareTag("Player"))
        {
            Texto.SetActive(true);
            cerca = true;
        }

    }


    public void Update()
    {
        if (Interaccion.triggered && cerca)
        {
            SceneManager.LoadScene("SimonDice");
            abierto = true;
            Texto.SetActive(false);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Texto.SetActive(false);
        cerca = false;
    }
}
