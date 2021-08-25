using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private float automatedCharacterCount = 1;
    [SerializeField] private GameObject automatedCharacterPrefab;
    [SerializeField] private int maxAutomatedCharacterCount = 149;

    private Queue<GameObject> automatedCharacterPool;
    private Stack<GameObject> activeAutomatedCharacters;

    #endregion

    #region Properties

    public float AutomatedCharacterCount
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
            GameObject obj = Instantiate(automatedCharacterPrefab, this.transform);
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
    }

    #endregion

    #region Private Methods

    private void SpawnAutomatedCharacter(int spawnAmount)
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

    private void DismissAutomatedCharacter(int dismissAmount)
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

    #endregion
}