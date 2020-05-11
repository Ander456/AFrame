using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour {

    void Awake () {
        DontDestroyOnLoad(gameObject);
    }
}
