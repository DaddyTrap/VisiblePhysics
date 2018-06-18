﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectInstrPanel : MonoBehaviour {

    public GameObject selectInstr;

    public void OnSelectJiTaButtonClick() {
        Texture2D _tex = Resources.Load("Image/乐器icon/jita", typeof(Texture2D)) as Texture2D;
        selectInstr.GetComponent<Image>().sprite = Sprite.Create(_tex, new Rect(0, 0, _tex.width, _tex.height), new Vector2(0, 0));
        this.gameObject.SetActive(false);
    }

    public void OnSelectDianJiTaButtonClick() {
        Texture2D _tex = Resources.Load("Image/乐器icon/dianjita", typeof(Texture2D)) as Texture2D;
        selectInstr.GetComponent<Image>().sprite = Sprite.Create(_tex, new Rect(0, 0, _tex.width, _tex.height), new Vector2(0, 0));
        this.gameObject.SetActive(false);
    }

    public void OnSelectGangQingButtonClick() {
        Texture2D _tex = Resources.Load("Image/乐器icon/gangqing", typeof(Texture2D)) as Texture2D;
        selectInstr.GetComponent<Image>().sprite = Sprite.Create(_tex, new Rect(0, 0, _tex.width, _tex.height), new Vector2(0, 0));
        this.gameObject.SetActive(false);
    }
}
