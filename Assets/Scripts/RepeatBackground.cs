using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPostion;
    private float repeatWidth;    
    void Start()
    {
        startPostion = transform.position;
        var b = GetComponent<BoxCollider>();
        repeatWidth = b.size.x / 2;
    }
        
    void Update()
    {
        if (transform.position.x < startPostion.x - repeatWidth)
        { transform.position = startPostion; }
    }
}
