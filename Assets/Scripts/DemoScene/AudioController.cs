using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour {

    [SerializeField]
    AudioSource[] m_MyAudioSource = new AudioSource[2];

    void Start () {
        m_MyAudioSource = GetComponents<AudioSource>();
    }
	

    public void PlayClipData(int number) {
        for (int i = 0; i < m_MyAudioSource.Length; i++) {
            if (i == number) m_MyAudioSource[i].Play();
            else m_MyAudioSource[i].Stop();
        }
    }

    public void SetMute(bool flag) {
        for (int i = 0; i < m_MyAudioSource.Length; i++) {
            m_MyAudioSource[i].mute = flag;
        }
    }
}
