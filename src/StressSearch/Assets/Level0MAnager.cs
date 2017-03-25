using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Level0MAnager : MonoBehaviour {

    public AudioClip background;
    public AudioClip clip1;
    public AudioClip clip2;

    private AudioSource audio;

    bool done = false;
    // Use this for initialization
    void Start () {
        audio = this.GetComponent<AudioSource>();
        StartCoroutine(playEngineSound());
    }
	
	// Update is called once per frame
	void Update () {
	    if(done)
        {
            SceneManager.LoadScene("HouseScene");
        }
	}

    IEnumerator playEngineSound()
    {
        audio.clip = clip1;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        yield return new WaitForSeconds(2f);
        audio.clip = clip2;
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        done = true;
    }
}
