///////////////////////////////
///  Ramón Guardia López
///  Curso 2017-2018
///  CustomPointerTimer.cs
///////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomPointerTimer : MonoBehaviour
{
    // Objeto compartido por todos los scripts
    public static CustomPointerTimer CPT;

    // Tiempo por defecto que vamos a tener que esperar para que el contador se rellene
    private float timeToWait = 3f;

    // Temporizador
    private float timer = 0f;

    // Componente Image de la imagen de relleno
    private Image image;

    // Indica cuándo está contando
    [HideInInspector] public bool counting = false;

    // Indica si ha llegado al final
    [HideInInspector] public bool ended = false;

    // Awake se invoca antes de Start
    private void Awake()
        // Se comprueba si el objeto está inicializado
    {
        if (CPT == null)
        {
            // Se obtiene el objeto temporizador
            CPT = GetComponent<CustomPointerTimer>();
        }

        // Se obtiene la imagen del reloj
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counting)
        {
            // Se incrementa el  temporizador 
            // la porción del tiempo que ha tardado en renderizar el último
            // update. De esta manera se tiene un control de tiempo real 
            // independientemente de las características de la máquina
            timer += Time.deltaTime;
            // Se rellena la imagen la cantidad proporcional al temporizador
            image.fillAmount = timer / timeToWait;
        }
        else
        {
            // Se reinicia el temporizador 
            timer = 0f;
            // Se reinicia el relleno de la imagen
            image.fillAmount = timer;
        }

        if (timer >= timeToWait)
        {
            // Se indica que el contador ha finalizado
            ended = true;
        }
       
    }
    /// <summary>
    ///  Inicial el temporizador, utilizando el tiempo indicando
    ///  como parámetro
    /// </summary>
    /// <param name="time"></param>
    public void StartCounting(float time)
    {
        counting = true;
        ended = false;
        timeToWait = time;
    }
    
    /// <summary>
    ///  Para el temporizador.
    /// </summary>
    public void StopCounting()
    {
        counting = false;
        ended = true;
    }
}