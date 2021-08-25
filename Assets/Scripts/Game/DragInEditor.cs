using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragInEditor : MonoBehaviour
{
    [DraggablePoint] public Vector3 spawnPosition;
    [SerializeField] private GameObject automatedCharacterPrefab;

    #region Public Methods

    public void Spawn()
    {
        Instantiate(automatedCharacterPrefab, spawnPosition, Quaternion.identity);
    }

    #endregion
}
