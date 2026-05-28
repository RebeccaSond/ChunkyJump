using UnityEngine;
using UnityEngine.Playables;

public class CutsceneMusicTrigger : MonoBehaviour
{
    public PlayableDirector director;
    public AudioSource musicSource;

    void Start()
    {
        director.stopped += OnCutsceneEnd;
    }

    void OnCutsceneEnd(PlayableDirector pd)
    {
        musicSource.Play();
    }

    private void OnDestroy()
    {
        director.stopped -= OnCutsceneEnd;
    }
}