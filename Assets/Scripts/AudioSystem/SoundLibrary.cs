using UnityEngine;

[CreateAssetMenu(fileName = "SoundLibrary", menuName = "SCO/SoundLibrary")]
public class SoundLibrary : ScriptableObject
{
    public SoundClip[] soundClips;

    private void OnValidate()
    {
        foreach (SoundClip soundClip in soundClips)
        {
            if (soundClip.hasPlayTimer && soundClip.playTimer == 0)
            {
                soundClip.playTimer = soundClip.audioClip.length;
            }
        }
    }
}

/// <summary>
/// enum all the clips that you will need to enumerate in your game
/// </summary>
public enum SoundName
{
    SelectionPlayerMusic,
    PlaySceneMusic,
    CarEngine,
    CarMetalImpact,
    CarWallImpact,
    CarOut,
    Brakeing,
    RocketOut,
    RocketFlying,
    RocketImpact,
    Reactor,
    PowerUpStay,
    PowerUpGot,
    MainMenuMusic,
    Drift
}

[System.Serializable]
public class SoundClip
{
    public SoundName soundName;
    public AudioClip audioClip;
    public bool loop;
    [Range(0f, 1f)]
    public float volume = 1f;
    public bool hasPlayTimer;
    public float playTimer;
    [Range(0f, 1f)]
    public float spacialBlend;
    [Range(-3f, 3f)]
    public float pitch = 1f;

    public SoundClip()
    {
        volume = 1f;
        pitch = 1f;
    }
}