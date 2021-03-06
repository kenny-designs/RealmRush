﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {
  Waypoint waypoint;

  private void Awake() {
    waypoint = GetComponent<Waypoint>();
  }

  void Update() {
    if (Application.IsPlaying(gameObject)) { return; }

    SnapToGrid();
    UpdateLabel();
  }

  private void SnapToGrid() {
    transform.position = new Vector3(
      waypoint.GetGridPos().x,
      0f,
      waypoint.GetGridPos().y
    );
  }

  private void UpdateLabel() {
    TextMesh textMesh = GetComponentInChildren<TextMesh>();
    int gridSize = waypoint.GetGridSize();
    string labelText = waypoint.GetGridPos().x / gridSize + "," + waypoint.GetGridPos().y / gridSize;
    textMesh.text = labelText;
    gameObject.name = labelText;
  }
}
