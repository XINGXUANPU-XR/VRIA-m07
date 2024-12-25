using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalOperator : MonoBehaviour
{

    public bool conditionTrue = true;
    public bool conditionFalse = false;

    [SerializeField] //型と同じ行に書いてもいいが、改行することが多い
    private bool checkAndOperator, checkOrOperator,
                 checkNotOperator, checkXorOperator;
    // Start is called before the first frame update
    void Start()
    {
        CheckCondition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckCondition()
    {
        if(checkAndOperator)
        Debug.Log(conditionTrue &&  conditionFalse);

        if(checkOrOperator)
        Debug.Log(conditionTrue ||  conditionFalse);
        
        if(checkNotOperator)
        Debug.Log(!conditionTrue);

        if(checkXorOperator)
        Debug.Log(conditionTrue ^  conditionFalse);

    }
}
