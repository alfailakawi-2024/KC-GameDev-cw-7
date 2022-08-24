using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float inc;
    public int minpos;
    public int maxpos;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - inc, minpos, maxpos), transform.position.y, transform.position.z);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + inc, minpos, maxpos), transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Restart 
            //Invoke("Restart", 1f);
            StartCoroutine(restartDelay());
            //play audio 
        }   playAudio();
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

    void playAudio()
    {
        audioSource.Play();
    }

    IEnumerator restartDelay()
    {
        yield return new WaitForSeconds(1f);
        Restart();
        yield return new WaitForSeconds(2f);
        //play anothor sound 

    }
}
