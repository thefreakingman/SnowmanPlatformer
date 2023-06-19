using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballThrowing : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement _playerMovement;
    public GameObject myPrefab;
    bool throwSnowball;
    float throwSpeed = 5f;
    Vector3 currentPos;
    GameObject snowball;

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
        throwSnowball = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (_playerMovement.melt == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                snowball = Instantiate(myPrefab, currentPos, Quaternion.identity);

                throwSnowball = true;
            }
        }
        if (throwSnowball)
        {
            MoveSnowball(snowball);
        }
    }

    private void MoveSnowball(GameObject ball)
    {
        ball.transform.position += new Vector3(throwSpeed * Time.deltaTime, 0, 0);
    }
}
