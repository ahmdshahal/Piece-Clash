using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] 
    private GridManager gridManager;
    [SerializeField] 
    private Image timerBar;

    [HideInInspector]
    public float time;

    public float duration;

    private void Start()
    {
        time = duration;
    }

    private void Update()
    {
        //Mengurangi nilai time/detik
        time -= Time.deltaTime;

        //Menghitung nilai fill amount sesuai dengan hitungan waktu
        timerBar.fillAmount = time / duration;

        //Jika waktu habis maka kalah
        if (time <= 0)
        {
            gridManager.LoseCondition();
        }
    }
}
