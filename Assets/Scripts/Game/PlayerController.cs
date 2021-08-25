using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private int automatedCharacterCount = 1;
    [SerializeField] private GameObject automatedCharacterPrefab;
    [SerializeField] private int maxAutomatedCharacterCount = 149;
    [SerializeField] private InputField automatedCharCountField;

    private Queue<GameObject> automatedCharacterPool;
    private Stack<GameObject> activeAutomatedCharacters;

    #endregion

    #region Properties

    public int AutomatedCharacterCount
    {
        get => automatedCharacterCount;
        set => automatedCharacterCount = value;
    }

    public GameObject AutomatedCharacterPrefab => automatedCharacterPrefab;

    #endregion


    #region Unity Methods

    private void Awake()
    {
        automatedCharacterPool = new Queue<GameObject>(maxAutomatedCharacterCount);
        for (int i = 0; i < maxAutomatedCharacterCount; i++)
        {
            GameObject obj = Instantiate(automatedCharacterPrefab,
                AddNoiseToObjectPosition(AutomatedCharacterPrefab.transform),
                Quaternion.identity, this.transform);

            obj.SetActive(false);

            automatedCharacterPool.Enqueue(obj);
        }

        activeAutomatedCharacters = new Stack<GameObject>(maxAutomatedCharacterCount);
    }

    private void Start()
    {
        if (automatedCharacterCount > 1)
        {
            //starting object spawn routine
        }
    }

    private void Update()
    {
        automatedCharCountField.text = AutomatedCharacterCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
    }

    #endregion

    #region Private Methods

    public void SpawnAutomatedCharacter(int spawnAmount)
    {
        //spawn block
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject obj = automatedCharacterPool.Dequeue();
            obj.SetActive(true);
            activeAutomatedCharacters.Push(obj);
        }


        AutomatedCharacterCount += spawnAmount;
    }

    public void DismissAutomatedCharacter(int dismissAmount)
    {
        //dismiss block
        for (int i = 0; i < dismissAmount; i++)
        {
            GameObject obj = activeAutomatedCharacters.Pop();
            obj.SetActive(false);
            automatedCharacterPool.Enqueue(obj);
        }

        AutomatedCharacterCount -= dismissAmount;
    }

    private Vector3 AddNoiseToObjectPosition(Transform objTrans)
    {
        Vector3 noisedPosition = new Vector3(objTrans.position.x + Random.Range(-0.5f, 0.5f), objTrans.position.y,
            objTrans.position.z + Random.Range(-0.5f, 0.5f));
        return noisedPosition;
    }

    #endregion
}