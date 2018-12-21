using UnityEngine;
using System.Collections;

public class playerSingleton : MonoBehaviour {
    //AI Stuff:
    #region Singleton
    public static playerSingleton instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject player;

    // Use this for initialization
    void Start () {
        player = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
