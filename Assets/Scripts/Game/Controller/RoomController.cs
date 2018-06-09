﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using ForestGuard;

public class RoomController : MonoBehaviour {



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ReturnLobby()
    {
        var info = new RoomSeat { RoomId = User.RoomId, SeatId = User.SeatId };
        Client.Instance.Send(RequestType.LeaveRoom, Proto.Serialize(info));
        SceneManager.LoadSceneAsync(1);
    }
}
