using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEditor;
//using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RestartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
