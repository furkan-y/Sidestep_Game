using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalWall : MonoBehaviour
{
    Level level;

    public TMPro.TextMeshProUGUI countDownTMP;

    public bool hitTheLeftW = false;
    private float newVerWallSpeed = 0;

    private int countDownInt = 3;

    private void Start()
    {
        level = FindObjectOfType<Level>();

        StartCoroutine(ThreeSecondCountdown());
    }

    // Vertical Wall y 0.7 , -5.2 arasýnda
    void Update()
    {
        if (hitTheLeftW == true)
        {
            transform.Translate(0, -newVerWallSpeed * Time.deltaTime, 0);
        }
        else if (hitTheLeftW != true)
        {
            transform.Translate(0, newVerWallSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "leftWall")
        {
            hitTheLeftW = true;

            float yPos = Random.Range(-2.7f, 2.5f);
            gameObject.transform.position = new Vector2(transform.position.x, yPos);

            newVerWallSpeed = level.verWallSpeed;
        }
        else if (collision.gameObject.tag == "rightWall")
        {
            hitTheLeftW = false;

            float yPos = Random.Range(-2.7f, 2.5f);
            gameObject.transform.position = new Vector2(transform.position.x, yPos);
        }
    }

    IEnumerator ThreeSecondCountdown()
    {
        while(countDownInt > 0)
        {
            countDownTMP.text = countDownInt.ToString();
            yield return new WaitForSeconds(1);
            countDownInt--;
        }
        countDownTMP.text = "";
        newVerWallSpeed = level.verWallSpeed;
    }



}
