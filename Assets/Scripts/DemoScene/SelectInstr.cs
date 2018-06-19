using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectInstr : MonoBehaviour {

    public GameObject selectInstrPanel;
    public void OnSelectInstrButtonClick() {
        if (selectInstrPanel.activeSelf == false)
            selectInstrPanel.SetActive(true);
        else
            selectInstrPanel.SetActive(false);
    }
}
