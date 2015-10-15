using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer DayBackground;
    public SpriteRenderer NightBackground;

    // Use this for initialization
    void Start()
    {
        // Listen to the time changed event
        TimeController.Instance.TimeChanged += TimeChanged;

        // Set the intial state of the object based on what time the
        // level is starting off as

        TimeChanged(TimeController.Instance.CurrentTime);
    }

    // Handle switching for the time of day
    void TimeChanged(TimeOfDay newTime)
    {
        DayBackground.enabled = (newTime == TimeOfDay.DAY);
        NightBackground.enabled = (newTime == TimeOfDay.NIGHT);
    }

    void OnDestroy()
    {
    	TimeController.Instance.TimeChanged -= TimeChanged;
    }
    
}
