using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //AI Stuff:
    #region Singleton
        public static Player instance;

        void Awake()
        {
            instance = this;
        }
    #endregion
    public GameObject player;
    // Settables


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
