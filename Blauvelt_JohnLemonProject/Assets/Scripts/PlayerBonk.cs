using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonk : MonoBehaviour
{

    public GameObject enemyToBonk; //saves reference to stun ability

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && enemyToBonk != null)
        {
            Destroy(enemyToBonk);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            enemyToBonk = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            if (enemyToBonk == other.gameObject)
            {
                enemyToBonk = null;
            }
        }
    }
}
