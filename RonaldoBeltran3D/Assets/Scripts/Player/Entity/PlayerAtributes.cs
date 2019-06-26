﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtributes : MonoBehaviour {

    public int itemCount { get; private set; }

    // Start is called before the first frame update
    public void Initialize() {
        itemCount = SceneControl.persistentPlayerData.itemCount;
        transform.position = SceneControl.persistentPlayerData.PointData.position;
        transform.rotation = SceneControl.persistentPlayerData.PointData.rotation;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Item")) {
            itemCount++;
        }
        else if (other.CompareTag("Checkpoint")) {
            CheckPoint checkpoint = other.GetComponent<CheckPoint>();
            SceneControl.persistentPlayerData.SetAllData(itemCount, checkpoint.pointData);
            FindObjectOfType<CheckPointControl>().SetCurrentActive(checkpoint);
        }
    }
}