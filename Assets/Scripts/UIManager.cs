using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Referenciando paquete DoTween

public class UIManager : MonoBehaviour
{
    [SerializableField] private GameObject MainMenuCanvas;
    [SerializableField] private GameObject ItemsMenuCanvas;
    [SerializableField] private GameObject ARPositionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnMainMenu += ActivateMainMenu; //Funcion inscrita al evento OnMainMenu
        GameManager.instance.OnItemMenu += ActivateItemsMenu;
        GameManager.instance.OnARPosition += ActivateARPosition;
    }

    private void ActivateMainMenu()
    {   //Se muestra MainMenu y se oculta ItemMenu y ARPosition
        MainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(1,1,1), 0.3f);
        MainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(1,1,1), 0.3f);
        MainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(1,1,1), 0.3f);

        ItemsMenuCanvas.transform.GetChild(0).transform.DoScale(new Vector3(0,0,0), 0.5f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DoScale(new Vector3(0,0,0), 0.3f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DOMoveY(180, 0.3f);

        ARPositionCanvas.transform.GetChild(0).transform.DoScale(new Vector3(0,0,0), 0.3f);
        ARPositionCanvas.transform.GetChild(1).transform.DoScale(new Vector3(0,0,0), 0.3f);
    }
  
    private void ActivateItemsMenu()
    {   //Se muestra ItemsMenu y se ocuta MainMenu, ARposition sigue oculto
        MainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0,0,0), 0.3f);
        MainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0,0,0), 0.3f);
        MainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0,0,0), 0.3f);

        ItemsMenuCanvas.transform.GetChild(0).transform.DoScale(new Vector3(1,1,1), 0.5f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DoScale(new Vector3(1,1,1), 0.3f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DOMoveY(300, 0.3f);
    }

    private void ActivateARPosition()
    {
        //Se muestra ARPosition  y se oculta MainMenu y ItemMenu
        MainMenuCanvas.transform.GetChild(0).transform.DOScale(new Vector3(0,0,0), 0.3f);
        MainMenuCanvas.transform.GetChild(1).transform.DOScale(new Vector3(0,0,0), 0.3f);
        MainMenuCanvas.transform.GetChild(2).transform.DOScale(new Vector3(0,0,0), 0.3f);

        ItemsMenuCanvas.transform.GetChild(0).transform.DoScale(new Vector3(0,0,0), 0.5f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DoScale(new Vector3(0,0,0), 0.3f);
        ItemsMenuCanvas.transform.GetChild(1).transform.DOMoveY(180, 0.3f);

        ARPositionCanvas.transform.GetChild(0).transform.DoScale(new Vector3(1,1,1), 0.3f);
        ARPositionCanvas.transform.GetChild(1).transform.DoScale(new Vector3(1,1,1), 0.3f);

    }

}
