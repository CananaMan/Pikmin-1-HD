using UnityEngine;
using System.Collections;

public class Whistle2 : MonoBehaviour
{
    // Settables
    public float diameterFull = 5f; // Blow me.
    public float maxDistanceFromPlayer = 9f;
    // References
    private Player player;
    // Properties
    private bool isOn; // true when we're whistling!
    private float diameter; // current diameter. 0 if we're off.
    private float distanceX; // These are my position relative to the player.
    private float distanceZ; // These are my position relative to the player.
                             // Sprites
    private SpriteRenderer reticuleSprite;
    private SpriteRenderer whistleBodySprite;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            Debug.Log(child.name);
            if (child.name == "Reticule")
            {
                reticuleSprite = child.GetComponent<SpriteRenderer>();
            }
            else if (child.name == "WhistleBody")
            {
                whistleBodySprite = child.GetComponent<SpriteRenderer>();
            }
        }

        whistleBodySprite.GetComponent<CapsuleCollider>().enabled = false;

        isOn = true; // say this so the next line will do something.
        SetIsOn(false);
        distanceX = 0;
        distanceZ = 0;
    }


    void SetIsOn(bool IsOn)
    {
        if (isOn == IsOn) { return; }
        isOn = IsOn;
        reticuleSprite.enabled = !isOn;
        whistleBodySprite.enabled = isOn;
        diameter = 0;
    }



    void Update()
    {
        MoveToGroundY();
        Rotate();
        MoveFromInput();
        UpdateBlow();
    }

    void FixedUpdate()
    {
    }

    void Rotate()
    {
        RaycastHit rcHit;
        //Make raycast direction down
        Vector3 theRay = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, theRay, out rcHit))
        {
            //this is for getting distance from object to the ground
            float GroundDis = rcHit.distance;
            //with this you rotate object to adjust with terrain
            transform.rotation = Quaternion.FromToRotation(Vector3.up, rcHit.normal);
        }
    }

    void MoveToGroundY()
    {
        RaycastHit groundHit;
        if (Physics.Raycast(player.transform.position, Vector3.down, out groundHit))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, player.transform.position.y - groundHit.distance + 0.3f, transform.localPosition.z);
        }
        if (Physics.Raycast(this.transform.position, Vector3.up, out groundHit))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, player.transform.position.y + groundHit.distance + 0.3f, transform.localPosition.z);
        }
        if (Physics.Raycast(this.transform.position, Vector3.down, out groundHit))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, this.transform.position.y - groundHit.distance + 0.3f, transform.localPosition.z);
        }
    }

    void MoveFromInput()
    {
        //Rotate the input vector into camera space so up is camera's up and right is camera's right
        Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        directionVector = Camera.main.transform.rotation * directionVector;

        distanceX += directionVector.x;
        distanceZ += directionVector.z;

        float totalDistance = Mathf.Sqrt((distanceX * distanceX) + (distanceZ * distanceZ));
        if (totalDistance > maxDistanceFromPlayer)
        {
            float angleFromPlayer = Mathf.Atan2(distanceZ, distanceX);
            distanceX = Mathf.Cos(angleFromPlayer) * maxDistanceFromPlayer;
            distanceZ = Mathf.Sin(angleFromPlayer) * maxDistanceFromPlayer;
        }

        // Go to position!
        transform.position = new Vector3(player.transform.position.x + distanceX, transform.position.y, player.transform.position.z + distanceZ);

    }


    void UpdateBlow()
    {
        SetIsOn(Input.GetButton("ButtonX"));

        if (isOn)
        {
            diameter = Mathf.Min(diameter + diameterFull * 0.05f, diameterFull);
            float bodyScale = diameter; // Note: We're loading in the sprite in a way for its scale to match its actual size in Unity units.
            whistleBodySprite.transform.localScale = new Vector3(bodyScale, bodyScale, bodyScale);
            whistleBodySprite.GetComponent<CapsuleCollider>().enabled = true;
            Debug.Log("enabled");
        }

        if (!isOn)
        {
            whistleBodySprite.GetComponent<CapsuleCollider>().enabled = false;
            Debug.Log("disabled");
        }
        //		if (isOn) {
        //			spriteRenderer.sprite = 
        //		}
    }
}




