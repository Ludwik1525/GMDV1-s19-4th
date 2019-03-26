using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{

    public Text counterValue;
    private bool firstCall = true;

	void Start () {
		SetTimer();
	}
	
	void Update () {
		
	}

    public void SetTimer()
    {
        if(!firstCall)
        {
            StopCoroutine(Counter(counterValue));
        }
        else
        {
            counterValue.text = "" + 0;
            StartCoroutine(Counter(counterValue));
        }
        firstCall = false;
    }

    public IEnumerator Counter(Text i)
    {
        while (true)
        {
            i.text = "" + (int.Parse(i.text) + 1);
            yield return new WaitForSeconds(1f);
        }
    }

}
