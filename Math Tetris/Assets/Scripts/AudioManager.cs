using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("BackgroundTrack");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, element => element.name.Equals(name));

        if (s == null)
        {
            Debug.Log("Audio '" + name + "' nao encontrado.");
            return;
        }
        if (!s.source.isPlaying)
            s.source.Play();
    }

    public IEnumerator PlayAndWait(string name)
    {
        Sound s = Array.Find(sounds, element => element.name.Equals(name));

        if (s == null)
        {
            Debug.Log("Audio '" + name + "' nao encontrado.");
            yield return null;
        }
        if (!s.source.isPlaying)
            s.source.Play();
        else
        {
            s.source.Stop();
            s.source.Play();
        }
       
        yield return new WaitWhile(() => s.source.isPlaying);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, element => element.name.Equals(name));

        if (s == null)
        {
            Debug.Log("Audio '" + name + "' nao encontrado.");
            return;
        }
        if (s.source.isPlaying)
            s.source.Stop();
    }
}
