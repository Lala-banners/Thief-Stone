using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWin : MonoBehaviour
{
    // OnTriggerEnter is called when the Collider other enters the trigger
    private void OnCollisionEnter(Collision other)
    {
        WinLose.instance.WinGame(); //Call Win Game
    }

}
