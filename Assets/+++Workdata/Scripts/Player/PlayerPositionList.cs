using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerPositionList : MonoBehaviour
{
    #region Variables

    [FormerlySerializedAs("_positionTime")] public float positionTime;
    private float _positionTimer;
    private Vector2 _position;
    public List<Tuple<Vector2,Time>>playerPositionList;
    
    #endregion
    #region Unity event functions

    private void Awake()
    {
        _positionTimer = 0;
    }

    private void Start()
    {
        playerPositionList = new List<Tuple<Vector2,Time>>();
    }

    private void FixedUpdate()
    {
        _position = gameObject.transform.position;
        _positionTimer += Time.fixedDeltaTime;
        if (_positionTimer >= positionTime)
            {
            _positionTimer = 0;
            playerPositionList.Add(new Tuple<Vector2, Time>(_position, new Time()));
            }
    }

    public Vector2 GetNextPosition()
    {
        return Vector2.down;
    }

    [ContextMenu("Print PlayerPositionList")]
    public void ShowList()
    {
        foreach (Tuple<Vector2, Time> playerPosition in playerPositionList)
        {
            print(playerPosition.Item1);
            print(playerPosition.Item2);
        }
    }

    #endregion
    
}
