using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text countDownText;
    private static float timer = 0;
    public float maxTime = 0;
    public AudioClip finalSound;

    private bool DoorClosingClipPlayed = false;
    public static float GameTimer { get { return timer; } private set { } }


    public AudioClip DoorClosing;
    public GameObject Door;
    private bool DoorAnimUsed = false;

    public GameObject OverHereObject;
    private bool _isOverHereUsed = false;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTime();
        TimeEvents();

    }

    private void TimeEvents()
    {
       
        if (DoorAnimUsed == false && ((int)(maxTime - timer)) == 75)
        {
            DoorAnimUsed = true;
            Door.GetComponent<Animator>().SetBool("Open", true);
            //Door.GetComponent<AudioSource>().Play();
        }
        if (_isOverHereUsed == false && ((int)(maxTime - timer)) == 45)
        {
            OverHereObject.GetComponent<AudioSource>().Play();
            _isOverHereUsed = true;
        }
            if (DoorAnimUsed == true && ((int)(maxTime - timer)) == 40)
        {
            DoorAnimUsed = false;
            Door.GetComponent<Animator>().SetBool("Open", false);

        }
        if (DoorAnimUsed == false && DoorClosingClipPlayed == false && ((int)(maxTime - timer)) == 37)
        {
            DoorClosingClipPlayed = true;
            this.GetComponent<AudioSource>().PlayOneShot(DoorClosing);
        }

    }

    void UpdateTime()
    {
        if (timer < maxTime)
        {
            countDownText.text = ((int)(maxTime - timer)).ToString();
            if (timer >= (maxTime / 4))
                countDownText.color = new Color(255, 0, 0);

        }
        else
        {
           // StartCoroutine("EndGame");

        }
        // increment timer over time
        timer += Time.deltaTime;
    }

    IEnumerator EndGame()
    {
        //Time.timeScale = 0;
        float fadeTime = GameObject.Find("Main Camera").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
       // PlayerPrefs.SetInt("Gotas", Cubeta.Gota);

        gameObject.GetComponent<AudioSource>().PlayOneShot(finalSound);
        //Application.LoadLevel("Result");
    }
}
