using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kari_proyou : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Stagehe" , 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Stagehe()
    {
        SceneManager.LoadScene("Stage1");
    }
}
