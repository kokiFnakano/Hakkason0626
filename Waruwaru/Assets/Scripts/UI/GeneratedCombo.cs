using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GeneratedCombo : MonoBehaviour
{
    [SerializeField] Text comboText;


    // Start is called before the first frame update
    void Start()
    {
        ComboManager cm = GameObject.Find("ComboManager").GetComponent<ComboManager>();
        comboText.text  = cm.GetCombo().ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
