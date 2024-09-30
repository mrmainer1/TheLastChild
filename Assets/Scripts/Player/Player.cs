using System;
using System.Collections;
using Synty.AnimationBaseLocomotion.Samples;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public readonly Inventory Inventory = new Inventory();
    private SamplePlayerAnimationController _samplePlayerAnimationController;
    private void Start()
    {
        _samplePlayerAnimationController = GetComponent<SamplePlayerAnimationController>();
    }
    public void StopMovement()
    {
        _samplePlayerAnimationController.StopMove();
    }

    public void StartMovement()
    {
        _samplePlayerAnimationController.StartMove();
    }
}
