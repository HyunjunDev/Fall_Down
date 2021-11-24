using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    private Queue<FallingBlock> poolingObjectQueue = new Queue<FallingBlock>();

    private void Awake()
    {
        Instance = this;
        Initialize(10);
    }

    private FallingBlock CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab, transform).GetComponent<FallingBlock>();                                          
        newObj.gameObject.SetActive(false);
        return newObj;
    }
    private void Initialize(int count)
    {
        for(int i=0;i<count;i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    public static FallingBlock GetObject()
    {
        if(Instance.poolingObjectQueue.Count>0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.transform.SetParent(null);
            newObj.gameObject.SetActive(true);
            return newObj;
        }
    }

    public static void ReturnObject(FallingBlock fallingBlock)
    {
        fallingBlock.gameObject.SetActive(false);
        fallingBlock.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(fallingBlock);
    }
}
