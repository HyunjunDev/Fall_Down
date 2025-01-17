using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax; 
    float speed;
    float visibleHeightThreshold;
    private void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }
    public void FalingBlock()
    {
        Invoke("DestroyFallingBlock", 2f);
    }
    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
    }
    private void DestroyFallingBlock()
    {
        ObjectPool.ReturnObject(this);
    }
}
