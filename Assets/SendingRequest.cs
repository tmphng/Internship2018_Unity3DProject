using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SendingRequest : MonoBehaviour
{
    public string url;

    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        /*
         * PUT
        //byte[] myData = System.Text.Encoding.UTF8.GetBytes("Hello World");
        string myData = "HelloWorld";
        UnityWebRequest www = UnityWebRequest.Put("http://192.168.29.133:8379/set/test/1234", myData);
        /* POST
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("field1=foo&field2=bar"));
        formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));
        UnityWebRequest www = UnityWebRequest.Post("http://192.168.29.133:8379/set/test/1234", formData);
        */

        //url = "http://192.168.29.133:8379/set/test/1234";
        url = "http://192.168.0.17:8379/set/test/1234";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.Send();

        if (www.isError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Upload complete!");
            // Show results as text
            Debug.Log(www.downloadHandler.text);
        }
    }
}