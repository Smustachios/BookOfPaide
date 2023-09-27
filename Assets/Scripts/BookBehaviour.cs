using System;
using UnityEngine;

public class BookBehaviour : MonoBehaviour
{
    [SerializeField] private float animTime = 1.0f;

    private SpriteRenderer spriteRenderer;
    private Vector3 targetPos = Vector3.zero;
    private Vector3 startPos;
    private bool isMoving = false;
    private float timer = 0.0f;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / animTime);

        if (isMoving)
        {
            Vector3 newPos = Vector3.Lerp(startPos, targetPos, t);

            transform.position = newPos;

            if (timer >= animTime)
            {
                isMoving = false;
                enabled = false;
                DisableBook();
            }
        }
    }

    private void DisableBook()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void StartBookMovement()
    {
        startPos = transform.position;
        spriteRenderer.sortingOrder = 5;

        isMoving = true;
        enabled = true;
    }
}
