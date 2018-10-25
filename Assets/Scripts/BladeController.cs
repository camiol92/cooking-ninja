using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour {

    public GameObject bladeTrailPrefab;
    bool isCutting;
    bool wasJustSpawned;

    Rigidbody2D rb;
    Camera cam;
    GameObject currentBladeTrail;
    CircleCollider2D collider;

    // Use this for initialization
    void Start () {
        isCutting = false;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        UpdateBladePosition();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateBladePosition();
        }
	}

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform, false);
        wasJustSpawned = true;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
   
    }

    void UpdateBladePosition()
    {
        if (wasJustSpawned)
        {
            wasJustSpawned = false;
            currentBladeTrail.GetComponent<TrailRenderer>().Clear();
        }
        cam = Camera.main;
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;
    }
}
