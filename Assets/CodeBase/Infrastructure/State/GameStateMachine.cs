using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Service.PersistentProgress;
using CodeBase.Service.SaveLoad;
using CodeBase.Service.StaticData;

namespace CodeBase.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader loader, IPersistentProgressService progressService, ISaveLoadService saveLoadService, IGameFactory factory, IStaticDataService staticData)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(LoadProgressState)] = new LoadProgressState(this, progressService, saveLoadService),
                [typeof(LoadLevelState)] = new LoadLevelState(this, loader, factory, staticData),
                [typeof(GameLoopState)] = new GameLoopState()
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state?.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state?.Enter(payload);
        }


        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}