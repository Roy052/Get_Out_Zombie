using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSM : MonoBehaviour
{
    public Vector2 startPos;
    public ZombieAI zombie;
    public GameObject objZombie;

    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }


    void CreateZombie()
    {
        GameObject temp = Instantiate(objZombie, startPos, Quaternion.identity, objZombie.transform.parent);
        temp.SetActive(true);
        zombie = temp.GetComponent<ZombieAI>();
    }

    public void GameOver()
    {
        CreateZombie();
        mainCamera.transform.position = new Vector3(startPos.x, startPos.y, -10f);
    }

    public void GameEnd()
    {

    }
}
