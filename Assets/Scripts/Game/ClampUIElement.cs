using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampUIElement : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private InputField automatedCharCountField;

    #endregion

    void Update()
    {
        Vector3 worldPos = Camera.main.WorldToScreenPoint(this.transform.position);
        automatedCharCountField.transform.position = worldPos;
    }
}