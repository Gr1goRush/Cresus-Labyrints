using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Sockets;
using System.IO;

public class CheckScript : MonoBehaviour
{
    [SerializeField]
    private SampleWebView sampleWeb;
    public IEnumerator GetDataCoroutine()
    {
        //   yield return new WaitForSeconds(0.5f);
        /*   if(PlayerPrefs.HasKey("Url"))
           {
               sampleWeb.Url = PlayerPrefs.GetString("Url");
               sampleWeb.enabled = true;
               //sampleWeb.SetVisibility(true);
               // sampleWeb.Open(sampleWeb.Url);
               Screen.autorotateToLandscapeLeft = true;
               Screen.autorotateToPortrait = true;

           }
           else
        */
        {
            print("start");
            string url = "https://plusqwerty.site";
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {

                yield return request.SendWebRequest();
                if (request.isNetworkError || request.isHttpError || request.downloadHandler.text == "")
                {
                    print(request.error);
                    print("error");
                    
                }
                else
                {
                
                    print(request.downloadHandler.text);

                    print(request.url);
                    
                    sampleWeb.Url = request.url;
                   
                    sampleWeb.enabled = true;
                   
                   

                }
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetDataCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
