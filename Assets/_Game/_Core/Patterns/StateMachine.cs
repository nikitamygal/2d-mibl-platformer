using System;
using System.Collections.Generic;

namespace SoloGames.Tools
{
	public interface IStateMachine
	{
		bool TriggerEvents { get; set; }
	}

	public class StateMachine<T> : IStateMachine where T : struct, IComparable, IConvertible, IFormattable
	{

		public virtual bool TriggerEvents { get; set; }
		public virtual T CurrentState { get; protected set; }
		public virtual T PreviousState { get; protected set; }

		public delegate void OnStateChangeDelegate();
		public OnStateChangeDelegate OnStateChange;


		public virtual void ChangeState(T newState)
		{
			if (EqualityComparer<T>.Default.Equals(newState, CurrentState))
			{
				return;
			}

			PreviousState = CurrentState;
			CurrentState = newState;

			OnStateChange?.Invoke();
		}

		public virtual void RestorePreviousState()
		{
			CurrentState = PreviousState;

			OnStateChange?.Invoke();
		}	
	}
}