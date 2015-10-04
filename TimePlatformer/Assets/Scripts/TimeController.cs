using UnityEngine;
using System.Collections;

public enum TimeOfDay
{
    DAY,
    NIGHT
}

public class TimeController
{
    #region Singleton_Attributes
    private static TimeController _instance;
    
    public static TimeController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new TimeController();
            }

            return _instance;
        }
    }

    private TimeController()
    {
        _time = TimeOfDay.DAY;
    }
    #endregion

    /// <summary>
    /// Delegate for a Listener Function for Time Changes
    /// </summary>
    /// <param name="newTime">The New Current Time of Day</param>
    public delegate void ChangeTime_Delegate(TimeOfDay newTime);

    /// <summary>
    /// Event that will be fired when the Time Changes
    /// </summary>
    public event ChangeTime_Delegate TimeChanged;

    /// <summary>
    /// The Time of Day (defaults to DAY)
    /// </summary>
    private TimeOfDay _time;

    /// <summary>
    /// The Current Time of Day
    /// </summary>
    public TimeOfDay CurrentTime {  get { return _time; } }

    /// <summary>
    /// Changes the Current Time
    /// </summary>
    /// <param name="newTime"></param>
    public void ChangeTime(TimeOfDay newTime)
    {
        //Debug.Log("Time Changed!!!!" + newTime);
        _time = newTime;

        // If anyone is listening to the time change event,
        // let them know that the time changed
        if(TimeChanged != null)
        {
            TimeChanged(newTime);
        }
    }

    /// <summary>
    /// Toggle the Current Time of Day
    /// </summary>
    public void ToggleTime()
    {
        if(_time == TimeOfDay.DAY)
        {
            ChangeTime(TimeOfDay.NIGHT);
        }
        else
        {
            ChangeTime(TimeOfDay.DAY);
        }
    }

}
