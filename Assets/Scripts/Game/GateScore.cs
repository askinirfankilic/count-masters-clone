using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Operation
{
    Multiply,
    Add
};

public class GateScore : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private Operation operation;
    [SerializeField] private int value;

    #endregion

    private void Start()
    {
        throw new NotImplementedException();
    }
}