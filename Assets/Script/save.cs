using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour
{
    //public int LifeValue = int.Parse(GameSystemInfo.Instance.LifeText.text);
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
    
        GameSystemInfo.Instance.UpdateLife(1);
        Destroy(gameObject);
          
    }
}
