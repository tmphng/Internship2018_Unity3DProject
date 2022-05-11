using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SendingScript : MonoBehaviour {

    public static GameObject[] MobileObjects;

    private string ObjectName;
    //private string KeyNameX;
    private float posX;
    private float posY, posZ;
    //public string url;

    void Awake()
    {
        if (MobileObjects == null)
        {
            MobileObjects = GameObject.FindGameObjectsWithTag("Mobile Object");
        }
        if (MobileObjects.Length == 0)
        {
            Debug.Log("No game objects are tagged with Mobile Object");
        }

        StartCoroutine(Upload());
    }


    void OnEnable()
    {
        //EventRequest.Movement += Upload;
        //EventRequest.Movement += Sending;
        EventManager.OnClicked += Sending;
    }

    void OnDisable()
    {
        //EventRequest.Movement -= Upload;
        //EventRequest.Movement -= Sending;
        EventManager.OnClicked -= Sending;
    }


    public void Sending()
    {
        StartCoroutine(Upload());
    }

    public IEnumerator Upload()
    {
        List<string> url = new List<string>();

        //Debug.Log("start");

        foreach (GameObject MobileObject in MobileObjects)
        {
            ObjectName = MobileObject.name;

            posX = MobileObject.transform.position.x;
            posY = MobileObject.transform.position.y;
            posZ = MobileObject.transform.position.z;

            //KeyNameX = ObjectName + "_x";
            //url.Add("http://192.168.29.133:8379/set/" + KeyNameX + "/" + posX);

            url.Add("http://192.168.29.133:8379/hset/" + ObjectName + "/x/" + posX);
            url.Add("http://192.168.29.133:8379/hset/" + ObjectName + "/y/" + posY);
            url.Add("http://192.168.29.133:8379/hset/" + ObjectName + "/z/" + posZ);
        }

        //Debug.Log(url.Count);

        for (int i = 0; i < url.Count; i++)
        {
            /*
            Debug.Log(url[i]);
            Debug.Log(i);
            */
            UnityWebRequest myRequest = UnityWebRequest.Get(url[i]); //WWW request = new WWW(url);
            yield return myRequest.Send();

            if (myRequest.isError)
            {
                Debug.Log(myRequest.error);
            }
            else
            {
                Debug.Log("Upload complete!");
                //Debug.Log(myRequest.downloadHandler.text); // Show results as text
            }

            //Step 1 : list all the known movable objects in the scene and ID/tags : check
            //Step 2 : for each mobile object
            //step 2.1 : get coordinates of objects
            //step 2.2 : send coordinates to redis through simple http request like 
            // http://ip:8379/hset/<objecttag>/x/<xvalue>
            // y and z
            // or hmset

            /*
             * send a request : done
             * send x position : done
             * send all coordinates : done
             * send every object coordinates : done
             * send request when the position changes : done
             * */
        }
    }
}
