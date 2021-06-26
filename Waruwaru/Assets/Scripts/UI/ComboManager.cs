using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    [SerializeField] GameObject comboUI;

    int totalCombo = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AddCombo();
    }


    //�R���{�𑫂��Ɠ�����UI�𐶐�
    public void AddCombo() 
    { 
        totalCombo++;

        //�R���{UI�̐���
        GameObject ui = Instantiate(comboUI);
        ui.GetComponent<Transform>().position = GetComponent<Transform>().position;
    }




    public void ResetCombo() { totalCombo = 0; }
    public int GetCombo() { return totalCombo; }
}
