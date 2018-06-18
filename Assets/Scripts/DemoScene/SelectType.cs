using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectType : MonoBehaviour {

    public GameObject selectTypePanel;

	public void OnSelectButtonClick() {
        if (selectTypePanel.activeSelf == false)
            selectTypePanel.SetActive(true);
        else
            selectTypePanel.SetActive(false);
    }

}
