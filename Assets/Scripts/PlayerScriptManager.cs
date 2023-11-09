using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Hide _hide;
    
    public PlayerMovement PlayerMovement { get { return _playerMovement; } }

    public Hide Hide { get { return _hide; } }
}
