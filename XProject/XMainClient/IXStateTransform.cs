using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EEE RID: 3822
	internal interface IXStateTransform : IXInterface
	{
		// Token: 0x0600CAE5 RID: 51941
		bool IsPermitted(XStateDefine state);

		// Token: 0x0600CAE6 RID: 51942
		void OnRejected(XStateDefine current);

		// Token: 0x0600CAE7 RID: 51943
		void OnGetPermission();

		// Token: 0x0600CAE8 RID: 51944
		void Stop(XStateDefine next);

		// Token: 0x0600CAE9 RID: 51945
		void StateUpdate(float deltaTime);

		// Token: 0x0600CAEA RID: 51946
		string TriggerAnim(string pre);

		// Token: 0x17003562 RID: 13666
		// (get) Token: 0x0600CAEB RID: 51947
		bool SyncPredicted { get; }

		// Token: 0x17003563 RID: 13667
		// (get) Token: 0x0600CAEC RID: 51948
		bool IsUsingCurve { get; }

		// Token: 0x17003564 RID: 13668
		// (get) Token: 0x0600CAED RID: 51949
		float Speed { get; }

		// Token: 0x17003565 RID: 13669
		// (get) Token: 0x0600CAEE RID: 51950
		XStateDefine SelfState { get; }

		// Token: 0x17003566 RID: 13670
		// (get) Token: 0x0600CAEF RID: 51951
		bool ShouldBePresent { get; }

		// Token: 0x17003567 RID: 13671
		// (get) Token: 0x0600CAF0 RID: 51952
		string PresentCommand { get; }

		// Token: 0x17003568 RID: 13672
		// (get) Token: 0x0600CAF1 RID: 51953
		string PresentName { get; }

		// Token: 0x17003569 RID: 13673
		// (get) Token: 0x0600CAF2 RID: 51954
		bool IsFinished { get; }

		// Token: 0x1700356A RID: 13674
		// (get) Token: 0x0600CAF3 RID: 51955
		long Token { get; }

		// Token: 0x1700356B RID: 13675
		// (get) Token: 0x0600CAF4 RID: 51956
		int CollisionLayer { get; }
	}
}
