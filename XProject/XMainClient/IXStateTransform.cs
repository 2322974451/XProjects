using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal interface IXStateTransform : IXInterface
	{

		bool IsPermitted(XStateDefine state);

		void OnRejected(XStateDefine current);

		void OnGetPermission();

		void Stop(XStateDefine next);

		void StateUpdate(float deltaTime);

		string TriggerAnim(string pre);

		bool SyncPredicted { get; }

		bool IsUsingCurve { get; }

		float Speed { get; }

		XStateDefine SelfState { get; }

		bool ShouldBePresent { get; }

		string PresentCommand { get; }

		string PresentName { get; }

		bool IsFinished { get; }

		long Token { get; }

		int CollisionLayer { get; }
	}
}
