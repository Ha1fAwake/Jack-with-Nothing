﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ContactWithGoddess : MonoBehaviour
{
    public Flowchart flow;

    private void OnTriggerEnter2D(Collider2D other) {
        flow.ExecuteBlock("Go");
    }
}