using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class MusicCrossfade : MonoBehaviour
{
    public PlayableDirector director;

    public AudioSource cutsceneSource;
    public AudioSource gameplaySource;

    public AudioClip gameplayClip;

    public AudioClip cutsceneClip;

    // This function is what starts the music.
    void Start()
    {
        cutsceneSource.clip = cutsceneClip;
        cutsceneSource.Play();

        director.stopped += OnCutsceneEnd;
    }

    // This function helps the music move on to the next song when the cutscene ends.
    void OnCutsceneEnd(PlayableDirector pd)
    {
        StartCoroutine(Crossfade());
    }

    // This function makes the music overlap with each other nicely when cutscenes end so it isnt so abrupt.
    IEnumerator Crossfade()
    {
        gameplaySource.clip = gameplayClip;
        gameplaySource.Play();

        float t = 0f;
        float duration = 2f;

        float startCutsceneVol = cutsceneSource.volume;

        while (t < duration)
        {
            t += Time.deltaTime;
            float normalized = t / duration;

            cutsceneSource.volume = Mathf.Lerp(startCutsceneVol, 0f, normalized);
            gameplaySource.volume = Mathf.Lerp(0f, 1f, normalized);

            yield return null;
        }

        cutsceneSource.Stop();
    }
}