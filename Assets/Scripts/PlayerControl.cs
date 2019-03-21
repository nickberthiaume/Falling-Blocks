using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float speed = 7f;
    public event System.Action OnPlayerDeath;

    float screenHalfWidthInWolrdUnits;

	// Use this for initialization
	void Start () {
        float halfPlayerWidth = transform.localScale.x / 2;
        screenHalfWidthInWolrdUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
	}
	
	// Update is called once per frame
	void Update () {
      float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;

        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        if(transform.position.x < -screenHalfWidthInWolrdUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWolrdUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWolrdUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWolrdUnits, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.tag == "Falling Block")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
