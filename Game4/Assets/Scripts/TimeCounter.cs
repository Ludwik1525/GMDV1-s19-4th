using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{

    public Text counterValue;
    private bool firstCall = true;

	void Start ()
    {
        counterValue.text = "0";
        StartCoroutine(Counter(counterValue));
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
