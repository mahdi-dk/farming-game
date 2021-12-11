using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class plant : MonoBehaviour
{
    public float timeDuration = 300;
    public Text textBox;

    public string plantMode = "growing";
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "time left" + " " + timeDuration.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeDuration >= 0)
        {
            timeDuration -= Time.deltaTime;
        }//stops timer from after 0

        if (timeDuration < 0)
        {
            timeDuration = 0;
        }//makes sure time duration doesnt become negative

        if (timeDuration != 0)
        {
            textBox.text = "time left" + " " + Mathf.Round(timeDuration /60).ToString();
        }
        else if (timeDuration == 0)
        {
            textBox.text = "DONE!";
            plantMode = "grown";
        }//changes text depending on time duration and makes plant grown
        

    }
    public void Destroy()
    {

        Destroy(gameObject);
    }
}
