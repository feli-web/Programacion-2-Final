using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public string sceneToLoad; 
    public GameObject loadingScreen; 
    public GameObject notloadingScreen;
  
    public Text advice;
    public string[] advices;

    private void Start()
    {
        loadingScreen.SetActive(false);
        Advice();
    }
    private void Update()
    {
        
    }
    public void LoadScene()
    {
                loadingScreen.SetActive(true);
                notloadingScreen.SetActive(false);
            
           
            StartCoroutine(LoadSceneAsync());    
    }

    
    private IEnumerator LoadSceneAsync()
    {
       yield return new WaitForSeconds(3f);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        
        while (!asyncOperation.isDone)
        {
            yield return null;
        }


        if (loadingScreen != null)
        {
            loadingScreen.SetActive(false);
        }
    }
    
    public void Advice()
    {
        int r = Random.Range(0, advices.Length);
        advice.text = advices[r];
    }
}
