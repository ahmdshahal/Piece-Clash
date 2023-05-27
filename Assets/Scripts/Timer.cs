using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image timerBar;
    public float duration;
    public float time;
    public GameObject popUpLose;

    private bool isCount;

    private void Start()
    {
        time = duration;
        isCount = true;
    }

    private void Update()
    {
        if (isCount)
            time -= Time.deltaTime;

        timerBar.fillAmount = time / duration;
        if (time <= 0)
        {
            popUpLose.SetActive(true);
        }
    }
}
