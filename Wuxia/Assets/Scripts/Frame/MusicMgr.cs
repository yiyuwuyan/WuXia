using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicMgr : BaseManager<MusicMgr> {
    AudioSource bgMusic;
    GameObject soundObj;
    List<AudioSource> soundList=new List<AudioSource>();
    float bgVolume = 1;//音量
    float soundVolume = 1;//音效音量

    public MusicMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(Update);
    }
    void Update()
    {
        for (int i = soundList.Count-1; i >=0; i--)
        {
            if (!soundList[i].isPlaying)
            {
                GameObject.Destroy(soundList[i]);
                soundList.RemoveAt(i);
            }
        }
    }
    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="name"></param>
    public void PlayBGMusic(string name)
    {
        if (bgMusic==null)
        {
            GameObject obj = new GameObject();
            obj.name = "BgMusic";
            bgMusic = obj.AddComponent<AudioSource>();
        }
        //异步加载
        ResMgr.GetInstance().LoadAsync<AudioClip>("Music/BG/"+name,(bg)=> {
            bgMusic.clip = bg;
            bgMusic.loop = true;
            bgMusic.volume = bgVolume;
            bgMusic.Play();
        });
    }
    public void StopBGMusic()
    {
        if (bgMusic==null)
        {
            return;  
        }
        bgMusic.Stop();
    }
    public void PauseBGMusic()
    {
        if (bgMusic == null)
        {
            return;
        }
        bgMusic.Pause();
    }
    public void ChangeBGVolume(float v)
    {
        if (bgMusic == null)
        {
            return;
        }
        bgMusic.volume = v;
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="name"></param>
    /// <param name="isLoop"></param>
    /// <param name="callback"></param>
    public void PlaySound(string name,bool isLoop,UnityAction<AudioSource> callback =null )
    {
        if (soundObj== null)
        {
            soundObj = new GameObject();
            soundObj.name = "Sound";
        }
        ResMgr.GetInstance().LoadAsync<AudioClip>("Music/Sound/"+name, (clip) =>
        {
            AudioSource sound = soundObj.AddComponent<AudioSource>();
            sound.clip = clip;
            sound.loop = isLoop;
            sound.volume = soundVolume;
            sound.Play();
            soundList.Add(sound);
            if (callback !=null)
            {
                callback(sound);
            }
        });
    }
    public void StopSound(AudioSource audio)
    {
        if (soundList.Contains(audio))
        {
            audio.Stop();
            soundList.Remove(audio);
            GameObject.Destroy(audio);
        }

    }
    public void ChangeSoundVolume(float v)
    {
        soundVolume = v;
        for (int i = 0; i < soundList.Count; i++)
        {
            soundList[i].volume = soundVolume;
        }
    }
}
