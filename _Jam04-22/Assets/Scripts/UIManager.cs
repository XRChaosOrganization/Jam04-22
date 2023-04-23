using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text timerDisplay;
    float timeCount;
    // Start is called before the first frame update
    private void Update()
    {
        timeCount += Time.deltaTime;
        int seconds = (int)(timeCount % 60);
        int minutes = seconds / 60;
       timerDisplay.text = string.Format("{0}:{1:00}",minutes, seconds);
    }
}
