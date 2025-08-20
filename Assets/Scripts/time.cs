using UnityEngine;
using TMPro;
public class time : MonoBehaviour
{
    private float timegame;
    [SerializeField] private TextMeshProUGUI texttime;
    void Start()
    {
        timegame = 0f;
    }

    
    void Update()
    {
        timegame += Time.deltaTime;
        int minute = Mathf.FloorToInt(timegame / 60);
        int second = Mathf.FloorToInt(timegame % 60);
        texttime.text = $"{minute:00} : {second:00}";
    }
}
