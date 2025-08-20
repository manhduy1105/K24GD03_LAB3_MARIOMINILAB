using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    
    {
        if(collision.gameObject.CompareTag("Player")) {
            Destroy(enemy);
        }
    }
}
