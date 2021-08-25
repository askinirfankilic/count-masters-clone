using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region Public Fields

    public float speed = 1f;
    public float horizontalMultiplier = 1f;
    
    #endregion

    #region Private Fields

    private float horizontal = 0f;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
    }

    #endregion

    #region Private Methods

    void Move()
    {
#if UNITY_EDITOR
        var standaloneHorizontal = Input.GetAxisRaw("Horizontal");
        if (standaloneHorizontal != 0)
        {
            this.horizontal = standaloneHorizontal;
        }
        this.transform.Translate(this.horizontal * horizontalMultiplier, 0, speed * Time.deltaTime);

        ResetHorizontal();

#endif
    }

    private void ResetHorizontal()
    {
        horizontal = 0f;
    }

    #endregion
}
