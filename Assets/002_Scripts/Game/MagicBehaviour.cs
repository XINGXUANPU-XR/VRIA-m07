using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //‚Ô‚Â‚©‚Á‚½‘Šè‚ªƒvƒŒƒCƒ„[‚Ìê‡
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
            player.Hp -= 3;

            return;
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();
            enemy.Hp -= 3;
            return;
        }
    }
}
