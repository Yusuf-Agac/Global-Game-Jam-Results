using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinisherTimer : MonoBehaviour
{
    private BatteryUP Battery;

    
    private float T;

    // Start is called before the first frame update
    void Start()
    {
        Battery = GameObject.FindGameObjectWithTag("Battery").GetComponent<BatteryUP>();
    }

    // Update is called once per frame
    void Update()
    {
        T = Time.time - Battery.startTime;
        if (T > 2)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                Cursor.visible = true;
                SceneManager.LoadScene(3);
            }
            else
            SceneManager.LoadScene(2);
        }
    }
}
