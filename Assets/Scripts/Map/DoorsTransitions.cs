using Assets.Scripts.LabyrinthGenerator;
using System.Collections.Generic;
using UnityEngine;

public class DoorsTransitions : MonoBehaviour
{
    [SerializeField] private List<PlayerTransition> transitions;
    public Direction Direction;

    public List<PlayerTransition> GetTransitions() => transitions;
}
