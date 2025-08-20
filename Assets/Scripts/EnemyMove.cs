using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 1.0f;

    public Transform a;
    public Transform b;
    private Transform c;
    private bool check = true;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (check)
        {
            c = a.transform;
            spriteRenderer.flipX = false;
        }
        else
        {
            c = b.transform;
            spriteRenderer.flipX = true;
        }
        plapla(c);
    }

    void plapla(Transform current)
    {
        transform.position = Vector3.MoveTowards(transform.position, current.position, speed * Time.deltaTime);

        var distanceToTarget = Vector3.Distance(transform.position, current.position);


        if (distanceToTarget < 0.01f)
            check = !check;

    }
}
