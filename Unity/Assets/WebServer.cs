using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class WebServer : MonoBehaviour {

    private string m_url = "http://localhost:3000";
    public Data m_myData = new Data();

    // Use this for initialization
    void Start ()
    {
        m_myData.message = "Hello Express Server";

        string jsonData = JsonUtility.ToJson(m_myData);

        StartCoroutine(Post(m_url,jsonData));
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    IEnumerator Post(string url, string bodyJsonString)
    {
        WWWForm form = new WWWForm();
        form.AddField("message", m_myData.message);

        UnityWebRequest request = UnityWebRequest.Post(m_url, form);

        yield return request.Send();

        if (request.isError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }


        /*var request = new UnityWebRequest(url, "PUT");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        print(Convert.ToBase64String(bodyRaw));
        yield return request.Send();

        Debug.Log("Status Code: " + request.responseCode);*/
    }
}

public class Data
{
    public string message;
}