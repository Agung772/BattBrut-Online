using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModels : MonoBehaviour
{
    public PlayerModel[] playerModels;
}

[System.Serializable]
public class PlayerModel
{
    public GameObject model3D;
    public Material material;
}
