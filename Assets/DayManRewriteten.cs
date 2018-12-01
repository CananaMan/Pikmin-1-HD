using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManRewriteten : MonoBehaviour {
    public GameObject sunSprite;
    public int timeSpeed;
    private int second;
    private int timeOfDay;

	void Start () {
        //Debug.Log("The position of the day object is:" + dayPos.ToString());
        //InvokeRepeating("secondTick", .1f, 1); // repeat this 0.1 seconds after every 1 second.
    }
	
	void Update () {
		
	}

    void secondTick()
    {
        second = timeOfDay + second;
        Vector3 sunSpritePos = sunSprite.GetComponent<RectTransform>().position;
        Vector3 dayPos = new Vector3(sunSpritePos.x + timeSpeed, sunSpritePos.y, sunSpritePos.z);
        //sunSprite = dayPos; // move the sunsprite across the screen
    }
}
