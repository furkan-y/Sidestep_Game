using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    Level level;

    bool isEnable;

    private void Start()
    {
        level = FindObjectOfType<Level>();
    }


    void Update()
    {
        if(isEnable == true)
        {
            gameObject.transform.Translate(level.normalEnemySpeed * Time.deltaTime, 0, 0);
        }
    }

    private void OnEnable()
    {
        isEnable = true;
    }

    private void OnDisable()
    {
        isEnable = false;
    }
}
