using UnityEngine;
using System.Collections;

public class EnemyHorizontalMovementScript : MonoBehaviour {

    [Range(-1, 1)] public int direction;

    public float walkSpeed;

    public float maxRange;

    private Vector2 startPosition;

    private Vector2 walkingVector;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Walk();
	}

    void Walk()
    {
        if (Vector2.Distance(transform.position, startPosition) > maxRange / 10.0f)
        {
            direction *= -1;
            Flip();
			transform.Translate(new Vector2((direction * (walkSpeed + 1.0f)) * Time.deltaTime, 0.0f));
        }

        walkingVector = new Vector2(direction * walkSpeed, 0.0f);
        transform.Translate(walkingVector * Time.deltaTime);
    }

    void Flip()
    {
        Vector2 revScale = transform.localScale;
        revScale.x *= -1.0f;
        transform.localScale = revScale;
    }
}
