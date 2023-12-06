using UnityEngine;
using UnityEngine.Events;

public class rhythmnote : MonoBehaviour
{
    [SerializeField] private float _bmp;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Intervals[] _intervals;
    
    private void Update() {
        foreach (Intervals interval in _intervals)
        {
            float sampledTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetIntervalLength(_bmp)));
            interval.CheckForNewIntervals(sampledTime);
        }
    }    
}

[System.Serializable]
public class Intervals {
    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastinterval;

    public float GetIntervalLength(float bpm) {
        return 6f / (bpm * _steps);

    }

    public void CheckForNewIntervals (float interval) {
        if (Mathf.FloorToInt(interval)!= _lastinterval){
            _lastinterval = Mathf.FloorToInt(interval);
            _trigger.Invoke();
        }
    }
}
