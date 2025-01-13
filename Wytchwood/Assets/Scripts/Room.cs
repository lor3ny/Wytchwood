using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
using static ProceduralGenerator;

public class Room : MonoBehaviour
{

    private bool isSolved;
    private int enemies;

    public DoorManager[] doors;

    [HideInInspector]
    public int x;
    [HideInInspector]
    public int y;

    public void Setup()
    {
        isSolved = true;
        doors = GetComponentsInChildren<DoorManager>();
        /*
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].CloseDoor();
        }
        */
        enemies = GetComponentsInChildren<EnemyMovement>().Length;
    }

    public enum Location
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public List<Location> locations;

    public GameObject UP;
    public GameObject DOWN;
    public GameObject LEFT;
    public GameObject RIGHT;

    public bool doneUP = false;
    public bool doneDOWN = false;
    public bool doneLEFT = false;
    public bool doneRIGHT = false;


    public List<Location> GetLocations()
    {
        return locations;
    }

    public bool CheckSolved()
    {
        enemies = GetComponentsInChildren<EnemyManager>().Length;
        if(enemies == 0)
        {
            isSolved = true;
        }
        return isSolved;
    }

    public void SetSolved(bool isSolv)
    {
        isSolved=isSolv;
    }

    public void Activate()
    {
        SetSolved(false);
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].CloseDoor(); 
        }
    }
}
