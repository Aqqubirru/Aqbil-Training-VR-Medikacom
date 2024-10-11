using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Module4
{
    public class TimeManager : MonoBehaviour
    {
        [SerializeField] private float initialTime = 60f;
        private float timer = 60;
        [SerializeField] private TextMeshProUGUI timerText;

        bool isTracking = false;
        public UnityEvent onTimerFinish;
        private bool isTimerFinished = false;

        private void Update()
        {
            if (isTracking)
            {
                timer -= Time.deltaTime;
                if (timer <= 0 && !isTimerFinished)
                {
                    isTimerFinished = true;
                    onTimerFinish.Invoke();
                    isTracking = false;
                }
            }

            // Menghitung menit dan detik
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);

            // Menampilkan timer dalam format MM:SS
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        public void StartTimer()
        {
            timer = initialTime;
            isTracking = true;
            isTimerFinished = false;
        }
    }
}
