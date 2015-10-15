using UnityEngine;
using System.Collections;

public class ToggleObstacle : MonoBehaviour
{
    // References to changed objects on the gameobject
    private SpriteRenderer _renderer;
    private Collider2D _collider;

    // What TimeOfDay is this object active during?
    public TimeOfDay ActiveWhen;

    // Use this for initialization
    void Start()
    {
        this._collider = this.GetComponent<Collider2D>();
        this._renderer = this.GetComponent<SpriteRenderer>();

        // Listen to the time changed event
        TimeController.Instance.TimeChanged += TimeChanged;

        // Set the intial state of the object based on what time the
        // level is starting off as

        TimeChanged(TimeController.Instance.CurrentTime);
    }

    // Handle switching for the time of day
    void TimeChanged(TimeOfDay newTime)
    {
        this._renderer.enabled = (newTime == ActiveWhen);
        this._collider.enabled = (newTime == ActiveWhen);
    }

    void OnDestroy()
    {
        TimeController.Instance.TimeChanged -= TimeChanged;
    }
}
