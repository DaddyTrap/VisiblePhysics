using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisButton : MonoBehaviour {

    public GameObject[] Axises;

    bool hidden = false;

    public void OnSelectAxisButtonClick() {
        hidden = !hidden;
        foreach (var axis in Axises) {
            axis.SetActive(!hidden);
        }
    }
}
