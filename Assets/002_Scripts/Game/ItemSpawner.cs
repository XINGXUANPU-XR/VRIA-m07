using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject itemPrefab;

    [SerializeField]
    List<Vector3> itemPositions;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(itemPrefab);  //原点座標に生成される
        // ()内の Oberject を生成する

        // Instantiate(GameObject,位置,向き)
        // itemPositions[0]: 位置情報のリストの0番目の位置に
        // Quaternion.identity:約等しい真っ直ぐを向き
        //Instantiate(itemPrefab, itemPositions[0], Quaternion.identity);
        
        //var:どんな型でも入るデータ型。ただし、初期化が必須
        foreach(var position in itemPositions)
        {
            Instantiate(itemPrefab, position, Quaternion.identity);
        }

        //Destroy():()内のGameObjectを破棄する
        Destroy(gameObject);
    }


    
}
