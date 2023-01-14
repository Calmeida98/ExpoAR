using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerManager : MonoBehaviour
{    
    [SerializeField] private string jsonURL;
    [SerializeField] private ItemButtonManager itemButtonManager;
    [SerializeField] private GameObject buttonContainer;
        
    [Serializable]
    public struct Items
    {
        [Serializable]
        public struct Item
        {
        public string Name;
        public string Description;
        public string URLBundleModel;
        public string URLImageModel; 
        }

         public Item[] items;  
    }

    public Items ItemsCollection = new Items();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetJsonData());
        GameManager.instance.OnItemMenu += CreateButtons;
    }


    private void CreateButtons()
    {
        foreach (var item in ItemsCollection.items)
        {
            ItemButtonManager itemButton;
            itemButton = Instantiate(itemButtonManager, buttonContainer.transform);
            itemButton.name = item.Name;
            itemButton.ItemName = item.Name;
            itemButton.ItemDescription = item.Description;
            itemButton.URLBundleModel = item.URLBundleModel;
            StartCoroutine(GetBundleImage(item.URLImageModel, itemButton)); 
        }
         GameManager.instance.OnItemMenu -= CreateButtons;
    }


    IEnumerator GetJsonData()//Descargar archivo JSON y asignarlo a la estructura de Items
    {
        UnityWebRequest serverRequest = UnityWebRequest.Get(jsonURL); 
        yield return serverRequest.SendWebRequest(); //Esperar la respuesta del Request
        if(serverRequest.result == UnityWebRequest.Result.Success)//SI el resultado es exitoso
        {
            ItemsCollection = JsonUtility.FromJson<Items>(serverRequest.downloadHandler.text);//Asignar la informacion del JSON dentro de la estructura Items
        }
        else
        {
            Debug.Log("Error");
        }
    }

    IEnumerator GetBundleImage(string urlImage, ItemButtonManager button)
    {
        UnityWebRequest serverRequest = UnityWebRequest.Get(urlImage);
        serverRequest.downloadHandler = new DownloadHandlerTexture(); 
        yield return serverRequest.SendWebRequest(); //Esperar la respuesta del Request
        if(serverRequest.result == UnityWebRequest.Result.Success)//SI el resultado es exitoso
        {
            button.ImageBundle.texture = ((DownloadHandlerTexture)serverRequest.downloadHandler).texture;//Asignar la imágen 
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
