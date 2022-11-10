using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pierwszySkrypt : MonoBehaviour
{
    // typ_zmiennej tekst  = "abcd";
    float liczba1 = 3.14f;
    float liczba2 = 6.0f;
    float wynik;
    

    // Start is called before the first frame update
    void Start()
    {
        wynik = liczba1 + liczba2;
        Debug.Log(wynik);
    }
    

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("sus");
    }
}
