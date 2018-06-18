using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectTypePanel : MonoBehaviour {

    public GameObject selectType;
    private int option = 0;

    public void OnSelectSoundButtonClick() {
        if (option != 0) {
            Texture2D _tex = Resources.Load("Image/icon/sound", typeof(Texture2D)) as Texture2D;
            selectType.GetComponent<Image>().sprite = Sprite.Create(_tex, new Rect(0, 0, _tex.width, _tex.height), new Vector2(0, 0));
        }
        this.gameObject.SetActive(false);
    }
}
