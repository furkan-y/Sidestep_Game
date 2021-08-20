using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Level level;

    Camera mainCamera;

    private Vector3 playerPosition;

    private Vector3 mousePosition;
    private Vector2 fingerPosition;

    Vector3 targetPosition;
    Vector3 PCtargetPosition;
    private Vector2 direction;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        TouchInput();
        MouseInput();
    }

    private void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            targetPosition = mainCamera.ScreenToWorldPoint(touch.position);
            targetPosition.z = 0;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, level.playerSpeed * Time.deltaTime);
        }
    }

    private void MouseInput()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        Vector3 playerPosition = mainCamera.WorldToScreenPoint(transform.position);

        mousePosition.x = mousePosition.x - playerPosition.x;
        mousePosition.y = mousePosition.y - playerPosition.y;

        Vector3 PCtargetPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        PCtargetPosition.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, PCtargetPosition, level.playerSpeed * Time.deltaTime);
    }

}
