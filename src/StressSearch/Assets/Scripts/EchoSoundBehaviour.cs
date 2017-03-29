using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EchoSoundBehaviour : MonoBehaviour
{

    /// <summary>
    /// Audio sources for the echo effect
    /// </summary>
    public AudioSource EchoAudioSource1;
    public AudioSource EchoAudioSource2;
    public AudioSource EchoAudioSource3;
    public AudioSource EchoAudioSource4;

    string deviceName = null;

    /// <summary>
    /// Audio Clip Recorded
    /// </summary>
    private AudioClip _recordedClip;

    private float _startedRecordingTime = 10;
    private int recordLenght = 2000;


    // Update is called once per frame
    void Update()
    {
        return;

        if (!Microphone.IsRecording(deviceName) )
        {
                PlaySounds();
        }
        // After some time playing, stop the recording
        else if (LevelManager.GameTimer - _startedRecordingTime > recordLenght)
            StopRecording();
    }


    public void StopRecording()
    {
        Microphone.End(deviceName);
    }

    /// <summary>
    /// Record sounds for an specific amount of time
    /// </summary>
    public void StartRecording()
    {
        _recordedClip = Microphone.Start(deviceName, true, recordLenght, 44100);
    }

    /// <summary>
    /// Play recorded sounds
    /// </summary>
    public void PlaySounds()
    {
        StartRecording();
        if (EchoAudioSource1.isPlaying) return;

        EchoAudioSource1.clip = _recordedClip;
        EchoAudioSource2.clip = _recordedClip;
        EchoAudioSource3.clip = _recordedClip;
        EchoAudioSource4.clip = _recordedClip;

        _startedRecordingTime = LevelManager.GameTimer;

        PlayAudioSource(EchoAudioSource1, 0.4f, 0.8f);
        PlayAudioSource(EchoAudioSource2, 1f, 0.5f);
        PlayAudioSource(EchoAudioSource3, 1.8f, 0.3f);
        PlayAudioSource(EchoAudioSource4, 2.5f, 0.15f);

    }

    public static void PlayAudioSource( AudioSource audio , float delay, float volume)
    {
        audio.playOnAwake = false;
        audio.volume = volume;
        audio.PlayDelayed(delay);
        audio.loop = false;

    }

}
