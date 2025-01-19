using System.Collections.Generic;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

public class DoorsTransitions : MonoBehaviour
{
    [SerializeField] private List<PlayerTransition> transitions;
    public Direction Direction;

    public List<PlayerTransition> GetTransitions() => transitions;
}
