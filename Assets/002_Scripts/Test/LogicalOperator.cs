using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalOperator : MonoBehaviour
{

    public bool conditionTrue = true;
    public bool conditionFalse = false;

    [SerializeField] //å^Ç∆ìØÇ∂çsÇ…èëÇ¢ÇƒÇ‡Ç¢Ç¢Ç™ÅAâ¸çsÇ∑ÇÈÇ±Ç∆Ç™ëΩÇ¢
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
