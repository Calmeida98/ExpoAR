using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButtonManager : MonoBehaviour //Asociar la informacion del boton por cada item que exista
{
  private string itemName;
  private string itemDescription;
  private Sprite itemImage;
  private GameObject item3DModel;

  public string ItemName
    { 
     set
      {
            itemName = value;
      }
    }

  public string ItemDescription
    { 
        set  => itemDescription = value; 
    }
  public Sprite ItemImage
    {
        set  => itemImage = value; 
    }
  public GameObject Item3DModel
    { 
        set  => item3DModel = value; 
}

  void Start()
   {
     transform.GetChild(0).GetComponent<Text>().text = itemName;
     transform.GetChild(1).GetComponent<RawImage>().texture = itemImage.texture; 
     transform.GetChild(2).GetComponent<Text>().text = itemDescription;

     var button = GetComponent<Button>();
     button.onClick.AddListener(GameManager.instance.ARPosition); //Cunado seleccione un item llame al evento ARPosition
     button.onClick.AddListener(Create3DModel); 

    }

    private void Create3DModel()//Crear modelo 3D que se elige
    {
        Instantiate(item3DModel);
    }



}