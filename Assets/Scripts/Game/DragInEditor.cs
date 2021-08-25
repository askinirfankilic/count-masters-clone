using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInEditor : MonoBehaviour
{
    [DraggablePoint] public Vector3 spawnPosition;
    [SerializeField] private new GameObject gameObject;

    #region Public Methods

    public void Spawn()
    {
        Instantiate(gameObject, spawnPosition, Quaternion.identity);
    }

    #endregion
}
