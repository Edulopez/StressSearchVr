using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Text countDownText;
    private static float _timer = 0;
    public float maxTime = 0;
    public AudioClip finalSound;

    private bool _DoorClosingClipPlayed = false;
    public static float GameTimer { get { return _timer; } private set { } }

    public GameObject Switch;
    private bool _IsSwitchUsed = false;

    public AudioClip DoorClosing;
    public GameObject Door;
    private bool _DoorAnimUsed = false;

    public GameObject OverHereObject;
    private bool _isOverHereUsed = false;

    public GameObject Human;
    private bool _HumanAnimUsed = false;
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

        if (_DoorAnimUsed == false && ((int)(maxTime - _timer)) == 75)
        {
            _DoorAnimUsed = true;
            Door.GetComponent<Animator>().SetBool("Open", true);
            //Door.GetComponent<AudioSource>().Play();
        }
        if (_IsSwitchUsed == false && ((int)(maxTime - _timer)) == 170)
        {
            var action = Switch.GetComponent<SwitchBehaviour>();
            action.DoAction();
            //Door.GetComponent<AudioSource>().Play();
        }
        if (_HumanAnimUsed == false && ((int)(maxTime - _timer)) == 65)
        {
            //Human.GetComponent<Animator>().SetBool("Translation", true);
            Human.GetComponent<Animation>().Play();
            Human.GetComponent<AudioSource>().Play();
            _HumanAnimUsed = true;
        }
        if (_HumanAnimUsed == true && ((int)(maxTime - _timer)) == 10)
        {
            Destroy(Human);
            _HumanAnimUsed = true;
        }
        if (_isOverHereUsed == false && ((int)(maxTime - _timer)) == 90)
        {
            OverHereObject.GetComponent<AudioSource>().Play();
            _isOverHereUsed = true;
        }
        if (_DoorAnimUsed == true && ((int)(maxTime - _timer)) == 40)
        {
            _DoorAnimUsed = false;
            Door.GetComponent<Animator>().SetBool("Open", false);

        }
        if (_DoorAnimUsed == false && _DoorClosingClipPlayed == false && ((int)(maxTime - _timer)) == 37)
        {
            _DoorClosingClipPlayed = true;
            this.GetComponent<AudioSource>().PlayOneShot(DoorClosing);
        }

    }

    void UpdateTime()
    {
        if (_timer < maxTime)
        {
            countDownText.text = ((int)(maxTime - _timer)).ToString();
            if (_timer >= (maxTime / 4))
                countDownText.color = new Color(255, 0, 0);

        }
        else
        {
           // StartCoroutine("EndGame");

        }
        // increment timer over time
        _timer += Time.deltaTime;
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
