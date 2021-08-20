using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalWall : MonoBehaviour
{
    Level level;

    public bool hitTheFloor = false;
    private float newHorWallSpeed = 0;

    // Horizontal Wall x -1 , 2.3 arasýnda

    private void Start()
    {
        level = FindObjectOfType<Level>();

        StartCoroutine(ThreeSecondCountdown());
    }

    void Update()
    {
        if (hitTheFloor == true)
        {
            gameObject.transform.Translate(0, newHorWallSpeed * Time.deltaTime, 0);
        }
        else if (hitTheFloor != true)
        {
            gameObject.transform.Translate(0, -newHorWallSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            hitTheFloor = true;

            float xPos = Random.Range(-1.4f, 1.2f);
            gameObject.transform.position = new Vector2(xPos, transform.position.y);

            newHorWallSpeed = level.horWallSpeed;
        }
        else if (collision.gameObject.tag == "roof")
        {
            hitTheFloor = false;
            
            float xPos = Random.Range(-1.4f, 1.2f);
            gameObject.transform.position = new Vector2(xPos, transform.position.y);
        }
    }

    IEnumerator ThreeSecondCountdown()
    {
        yield return new WaitForSeconds(3);
        newHorWallSpeed = level.horWallSpeed;
    }


    public void buttonClick()
    {
        float xPos = Random.Range(-1.4f, 1.2f);
        gameObject.transform.position = new Vector2(xPos, transform.position.y);
    }

}
