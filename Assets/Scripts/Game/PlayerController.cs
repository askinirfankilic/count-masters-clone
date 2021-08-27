using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        #region Private Fields

        [SerializeField] private int automatedCharacterCount = 1;
        [SerializeField] private GameObject automatedCharacterPrefab;
        [SerializeField] private int maxAutomatedCharacterCount = 149;
        [SerializeField] private InputField automatedCharCountField;
        [SerializeField] private GameObject firstAutomatedCharacter;
        
        private LinkedList<GameObject> activeAutomatedCharacters;

        private Queue<GameObject> automatedCharacterPool;
    
        private bool isLost = false;
        private bool isWin = false;

        #endregion

        #region Properties

        public int AutomatedCharacterCount
        {
            get => automatedCharacterCount;
            set => automatedCharacterCount = value;
        }

        public GameObject AutomatedCharacterPrefab => automatedCharacterPrefab;

        public bool IsLost
        {
            get => isLost;
            set => isLost = value;
        }

        public bool IsWin
        {
            get => isWin;
            set => isWin = value;
        }

        public LinkedList<GameObject> ActiveAutomatedCharacters
        {
            get => activeAutomatedCharacters;
            set => activeAutomatedCharacters = value;
        }
        #endregion


        #region Unity Methods

        private void Awake()
        {
            activeAutomatedCharacters = new LinkedList<GameObject>();
            activeAutomatedCharacters.AddLast(firstAutomatedCharacter);
            
            automatedCharacterPool = new Queue<GameObject>(maxAutomatedCharacterCount);
            
            for (int i = 0; i < maxAutomatedCharacterCount; i++)
            {
                GameObject obj = Instantiate(automatedCharacterPrefab,
                    AddNoiseToObjectPosition(AutomatedCharacterPrefab.transform),
                    Quaternion.identity, this.transform);

                obj.SetActive(false);

                automatedCharacterPool.Enqueue(obj);
            }
        }

        private void Start()
        {
        }

        private void Update()
        {
            automatedCharCountField.text = AutomatedCharacterCount.ToString();
            if (AutomatedCharacterCount <= 0)
            {
                isLost = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
        }

        #endregion


        #region Public Methods

        public void SpawnAutomatedCharacter(int spawnAmount)
        {
            //spawn block
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject obj = automatedCharacterPool.Dequeue();
                activeAutomatedCharacters.AddLast(obj);
                obj.SetActive(true);
                obj.GetComponent<Animator>().SetTrigger("IsMoving");
            }


            AutomatedCharacterCount += spawnAmount;
        }

        public void DismissAutomatedCharacter(GameObject automatedCharacter)
        {
            automatedCharacterPool.Enqueue(automatedCharacter);
            if (AutomatedCharacterCount > 0)
            {
                activeAutomatedCharacters.Remove(automatedCharacter);
                AutomatedCharacterCount -= 1;
            }
        }

        public void SetActiveAutomatedCharactersForDancing()
        {
            foreach (var character in activeAutomatedCharacters)
            {
                character.GetComponent<Animator>().SetTrigger("IsDancing");
            }
        }
        #endregion

        #region Private Methods
        
        private Vector3 AddNoiseToObjectPosition(Transform objTrans)
        {
            Vector3 noisedPosition = new Vector3(objTrans.position.x + Random.Range(-0.5f, 0.5f), objTrans.position.y,
                objTrans.position.z + Random.Range(-0.5f, 0.5f));
            return noisedPosition;
        }

        #endregion
    }
}