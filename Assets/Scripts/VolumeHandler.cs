using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeHandler : MonoBehaviour
{
    public Sprite hardSprite;
    public Sprite mediumSprite;
    public Sprite softSprite;
    public Sprite offSprite;

    public AudioSource gameAudio;
    [SerializeField] private AudioSource Sound;
    [SerializeField] private Button soundButton;

    private enum SoundSetting { Hard, Medium, Soft, Off }
    private SoundSetting currentSetting = SoundSetting.Hard;

    void Start()
    {
        UpdateButtonUI();
    }

    public void ChangeSoundSetting()
    {
        currentSetting = (SoundSetting)(((int)currentSetting + 1) % 4);

        switch (currentSetting)
        {
            case SoundSetting.Hard:
                gameAudio.volume = 1.0f;
                break;
            case SoundSetting.Medium:
                gameAudio.volume = 0.6f;
                break;
            case SoundSetting.Soft:
                gameAudio.volume = 0.3f;
                break;
            case SoundSetting.Off:
                gameAudio.volume = 0.0f;
                break;
        }

        UpdateButtonUI();
    }

    void UpdateButtonUI()
    {
        switch (currentSetting)
        {
            case SoundSetting.Hard:
                soundButton.image.sprite = hardSprite;
                break;
            case SoundSetting.Medium:
                soundButton.image.sprite = mediumSprite;
                break;
            case SoundSetting.Soft:
                soundButton.image.sprite = softSprite;
                break;
            case SoundSetting.Off:
                soundButton.image.sprite = offSprite;
                break;
        }
    }

    public void Pirate()
    {
        gameAudio.clip = Sound.clip;


        gameAudio.Play();
    }
}

