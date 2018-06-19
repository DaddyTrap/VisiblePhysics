using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoiceButton : MonoBehaviour {

    public GameObject audioController;

    private bool isMute = false;

	public void OnSelectVoiceButtonClick() {
        // 如果是非静音状态
        if (!isMute) {
            isMute = true;
            audioController.GetComponent<AudioController>().SetMute(isMute);

            Texture2D _tex = Resources.Load("Image/icon/SOUND MINUS", typeof(Texture2D)) as Texture2D;
            this.GetComponent<Image>().sprite = Sprite.Create(_tex, new Rect(0, 0, _tex.width, _tex.height), new Vector2(0, 0));
        }
        else {
            isMute = false;
            audioController.GetComponent<AudioController>().SetMute(isMute);

            Texture2D _tex = Resources.Load("Image/icon/SOUND PLUS", typeof(Texture2D)) as Texture2D;
            this.GetComponent<Image>().sprite = Sprite.Create(_tex, new Rect(0, 0, _tex.width, _tex.height), new Vector2(0, 0));
        }
    }
}
