using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorJuego : MonoBehaviour
{
    public Cube[] cubs;
    public List<int> ListaAleatoria = new List<int>();

    public bool ListaLlena;
    public bool turnoPc;
    public bool turnoUsuario;

    public int Contador;
    public int Contadorusuario;
    public int NivelActual;

    [Range(0.1f, 2f)]
    public float Velocidad;

    void Start()
    {
        LlenarListaAleatoria();
        turnoPc = true;
        Invoke("TurnoPC", 0.5f);
    }

    void LlenarListaAleatoria()
    {
        for(int i = 0; i <=1000; i++)
        {
            ListaAleatoria.Add(Random.Range(0, 4));
        }
        ListaLlena = true;
    }

    public void TurnoPC()
    {
        if (ListaLlena && turnoPc)
        {
            cubs[ListaAleatoria[Contador]].ActivarCubo();
        }
        if (Contador >= NivelActual)
        {
            NivelActual++;
            CambiarEstado();
        }
        else
        {
            Contador++;
            Invoke("TurnoPC", Velocidad);
        }

    }

    public void CambiarEstado()
    {
        if (turnoPc)
        {
            turnoPc = false;
            turnoUsuario = true;
        }
        else
        {
            if (NivelActual == 7)
            {
                Datos.SimonDice = true;
                SceneManager.LoadScene("Nivel2");
            }
            else
            {
                turnoPc = true;
                turnoUsuario = false;
                Contador = 0;
                Contadorusuario = 0;
                Invoke("TurnoPC", 1.2f);
            }
        }
    }



    public void ClickUsuario(int idCubo)
    {
        if(idCubo != ListaAleatoria [Contadorusuario])
        {
            SceneManager.LoadScene("Nivel2");
            return;
        }

        if (Contadorusuario == Contador)
        {
            CambiarEstado();
        }
        else
        {
            Contadorusuario++;
        }
    }

    void Update()
    {

    }
}
