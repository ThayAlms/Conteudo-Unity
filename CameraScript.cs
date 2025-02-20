using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform player;
    public Vector3 offset;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        }
    }
}
