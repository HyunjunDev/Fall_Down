using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event System.Action OnPlayerDeath;
    public void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x, cursorPos.y);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Falling Block")
        {
            if(OnPlayerDeath!=null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
