using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairStatus : MonoBehaviour
{
    public int chairNumber;
    public bool isOccupied = false;
    public bool platePositionIsOccupied = false;

    public Transform SittingPosition;
    public Transform PlatePosition;
}

