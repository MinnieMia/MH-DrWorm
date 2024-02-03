using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject popUp;
    public float seconds = 5;
    public string scene = "Level2";
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        popUp.SetActive(true);
        var dieScript = GetComponent<GameOver>();
        dieScript.StopAllAudio();
        StartCoroutine(NextScene(scene));
    }

    IEnumerator NextScene(string sceneName)
    {
        player.GetComponent<Character>().canMove = false;
        player.GetComponent<Animator>().SetBool("isRunning", false);
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneName);
    }
}
