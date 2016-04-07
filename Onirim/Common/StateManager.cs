using Microsoft.Xna.Framework.Graphics;
using Onirim.Command;
using Onirim.ContentManagers;
using Onirim.Model;
using Onirim.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onirim.Common
{
    public class StateManager
    {
        public Stack<IGameState> States { get; set; }
        public IGameState CurrentState { get { return States.Peek(); } }

        public StateManager()
        {
            States = new Stack<IGameState>();
        }

        public void Initialize(IGameState firstState)
        {
            firstState.OnEnter();
            States.Push(firstState);
        }

        public void ChangeState(IGameState newState)
        {
            CurrentState.OnExit();
            newState.OnEnter();
            States.Push(newState);
        }

        public void GoBackToPreviousState()
        {
            CurrentState.OnExit();
            States.Pop();
            CurrentState.OnEnter();
        }
    }
}
