using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class ItemButtonManager : MonoBehaviour //Asociar la informacion del boton por cada item que exista
{
  private string itemName;
  private string itemDescription;
  private Sprite itemImage;
  private GameObject item3DModel;
  private ARInteractionManager interactionsManager;
  private string urlBundleModel;
  private RawImage imageBundle;
 
  public string ItemName { set => itemName = value;}
  public string ItemDescription { set => itemDescription = value;}
  public Sprite ItemImage{ set =>  itemImage = value;}
  public GameObject Item3DModel{ set => item3DModel = value; }
  public string  URLBundleModel{ set => urlBundleModel = value; }
  public RawImage ImageBundle{ get => imageBundle; set => imageBundle = value; }

  void Start()
   {  
     
      transform.GetChild(0).GetComponent<TMP_Text>().text = itemName;
      transform.GetChild(1).GetComponent<RawImage>().texture = itemImage.texture;
      //imageBundle = transform.GetChild(1).GetComponent<RawImage>();
      transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = itemDescription;
     
     var button = GetComponent<Button>();
     button.onClick.AddListener(GameManager.instance.ARPosition); //Cuando seleccione un item llame al evento ARPosition
     button.onClick.AddListener(Create3DModel);

     interactionsManager  = FindObjectOfType<ARInteractionManager>();

    }

    private void Create3DModel()//Crear modelo 3D que se elige
    {
       interactionsManager.Item3DModel = Instantiate(item3DModel);
       //Instantiate(item3DModel);
       //StartCoroutine(DownLoadAssetBundle(urlBundleModel)); 
    }
   
   IEnumerator DownLoadAssetBundle(string urlAssetBundle)
   {
      UnityWebRequest serverRequest = UnityWebRequestAssetBundle.GetAssetBundle(urlAssetBundle);
      yield return serverRequest.SendWebRequest();
      if(serverRequest.result == UnityWebRequest.Result.Success)
      {
         AssetBundle model3D = DownloadHandlerAssetBundle.GetContent(serverRequest);
         if(model3D != null )
         {
            interactionsManager.Item3DModel = Instantiate(model3D.LoadAsset(model3D.GetAllAssetNames()[0]) as GameObject); 
         } 
         else
         {
            Debug.Log("Asset Bundle no valido");
         } 
      }
      else
      {
         Debug.Log("Error de descarga");
      }
   }

}