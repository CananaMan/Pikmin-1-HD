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
    // Settables


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
