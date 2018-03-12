using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static UI ui;
    [SerializeField]
    UI m_ui;

	// Use this for initialization
	void Awake() {
        ui = m_ui;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
