using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniJam
{
    public class AudioManager : MonoBehaviour
    {
	    private static AudioManager instance = null;

	    public static AudioManager Instance => instance;

	    private void Awake()
	    {
		    if (instance != null && instance != this)
		    {
			    Destroy(this.gameObject);
			    return;
		    }
		    else
		    {
			    instance = this;
		    }
		    
		    DontDestroyOnLoad(this.gameObject);
	    }
    }
}
