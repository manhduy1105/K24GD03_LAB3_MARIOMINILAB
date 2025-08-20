using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed = 10f;
    public GameObject A;
    public GameObject B;
    private float timecount = 0;

    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timecount < 2)
        {
            MoveToA();
        }
            timecount += Time.deltaTime ;
            if(timecount >= 2)
            {
                MoveToB();
            Destroy(gameObject, 5f);
            }
        
    }

    

    public void MoveToA()
    {
        transform.position = Vector3.MoveTowards(transform.position,A.transform.position,speed*Time.deltaTime);

    }
    public void MoveToB()
    {
        transform.position = Vector3.MoveTowards(transform.position,B.transform.position,speed*Time.deltaTime);

    }
}
