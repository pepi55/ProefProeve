using UnityEngine;
using System.Collections;
namespace StateMachine
{
    public class StateControler : MonoBehaviour
    {

        GameStates _currentState = GameStates.state1;
        public GameStates currentState { get { return _currentState; } }

        public void SwitchState(GameStates newState)
        {
            if (_currentState == newState)
                return;
            
            //run code
        }
    }
}