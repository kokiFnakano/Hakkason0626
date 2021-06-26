using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    private AudioManager _AudioManager;

    [SerializeField] AudioSource[] _Source;

    [Header("音量")]
    [SerializeField] private float _SeVolume;
    [SerializeField] private float _BgVolume;

    [Header("フェードアウトまでに何秒かかるか"), SerializeField]
    private float _FadeOutTime;

    private float _PassedTime = 0.0f;
    private bool _IsFadeOut = false;

    private float _StartSEVolume;
    private float _StartBGMVolume;


    public static AudioManager Instance
    {
        get; private set;
    }

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        _AudioManager = GetComponent<AudioManager>();
    }

    public void Start()
    {
        _Source = GetComponents<AudioSource>();

        _Source[0].volume = _SeVolume;
        _Source[0].loop = false;

        _Source[1].volume = _BgVolume;
        _Source[1].loop = true;

        _StartBGMVolume = _BgVolume;
        _StartSEVolume = _SeVolume;
    }

    public void Update()
    {
        if (_IsFadeOut)
        {
            float time = Time.deltaTime;
            if ((_PassedTime += time) > _FadeOutTime)
            {
                _Source[1].Stop();
                _Source[1].volume = _StartBGMVolume;

                _IsFadeOut = false;
                _PassedTime = 0.0f;
                Debug.Log("フェード終わり");
            }
            _Source[1].volume = _BgVolume * (1 - _PassedTime / _FadeOutTime);
        }
    }

    public void PlayBGM(AudioClip clip)
    {
        _Source[1].clip = clip;
        _Source[1].Play();
    }

    public void PlaySE(AudioClip audioClip)
    {
        _Source[0].PlayOneShot(audioClip, _SeVolume);
    }

    public void SetBGMVol(float vol)
    {
        _Source[1].volume = vol;

        _BgVolume = vol;
    }

    public void ResetBGMVol()
    {
        _Source[1].volume = _StartBGMVolume;

        _BgVolume = _StartBGMVolume;
    }

    public void SetSEVol(float vol) { _SeVolume = vol; }

    public void ResetSEVol() { _SeVolume = _StartSEVolume; }

    public void StopBGM()
    {
        _IsFadeOut = true;
    }

    public void StopNowBGM()
    {
        _Source[1].Stop();
    }

}
