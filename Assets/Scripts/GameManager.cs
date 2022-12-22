using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{ 
    //Eventos que representan los tres estados de la aplicacion
    public event Action OnMainMenu;
    public event Action OnItemMenu;
    public event Action OnARPosition;

    //Patron Singleton
    public static GameManager instance;

    private void Awake()
    {
        if(instance != null && instance != this)//Solo exista una instancia de GameManager
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
        }
    }
           
    // Start is called before the first frame update
    void Start()
    {
      MainMenu(); //Llamar solo al menu principal al iniciar la aplicacion 
    }

    public void MainMenu()
    {
        OnMainMenu?.Invoke(); //Que exista algo inscrito al evento
        Debug.Log("Menu Principal Activado");   
    }

    public void ItemMenu()
    {
        OnItemMenu?.Invoke();
        Debug.Log("Menu de Elementos Activado");   
    }

     public void ARPosition()
    {
        OnARPosition?.Invoke();
        Debug.Log("Posicionamiento en RA Activado");   
    }

    public void CloseApp()//Cerrar aplicacion
    {
       Application.Quit();

    } 
    
}
