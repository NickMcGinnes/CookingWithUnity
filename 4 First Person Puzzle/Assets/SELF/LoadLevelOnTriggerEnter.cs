using UnityEngine;
using System.Collections;

public class LoadLevelOnTriggerEnter : MonoBehaviour
{
    public string levelname;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Application.LoadLevel(levelname);
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelname);
        }
    }
}
