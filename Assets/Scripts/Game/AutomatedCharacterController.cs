﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutomatedCharacterController : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(destination.position);
    }
}
