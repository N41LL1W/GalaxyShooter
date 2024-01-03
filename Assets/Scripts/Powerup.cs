using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int powerupID;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Access the player
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (powerupID == 0)
                {
                    //Enable triple shot
                    player.TripleShotPowerupOn();
                }
                else if (powerupID == 1)
                {
                    //Enable spped boost
                    player.SpeedPowerupOn();
                }
                else if (powerupID == 2)
                {
                    //Enable shield
                    player.EnableShields();
                }

            }

            //Destroy ourself
            Destroy(this.gameObject);


        }
    }
}
