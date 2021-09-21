using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200005A RID: 90
	public interface IGameSysMgr : IXInterface
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060002E0 RID: 736
		// (set) Token: 0x060002E1 RID: 737
		float OnlineRewardRemainTime { get; set; }

		// Token: 0x060002E2 RID: 738
		bool Init();

		// Token: 0x060002E3 RID: 739
		void Uninit();

		// Token: 0x060002E4 RID: 740
		void InitWhenSelectRole(uint level);

		// Token: 0x060002E5 RID: 741
		bool IsSystemOpen(int sys);

		// Token: 0x060002E6 RID: 742
		string GetSysName(int sysid);

		// Token: 0x060002E7 RID: 743
		string GetSysIcon(int sysid);

		// Token: 0x060002E8 RID: 744
		string GetSysAnnounceIcon(int sysid);

		// Token: 0x060002E9 RID: 745
		void OpenSystem(int sys);

		// Token: 0x060002EA RID: 746
		void ForceUpdateSysRedPointImmediately(int sys, bool redpoint);

		// Token: 0x060002EB RID: 747
		void AttachSysRedPointRelative(int sys, int childSys, bool bImmCalculate);

		// Token: 0x060002EC RID: 748
		void AttachSysRedPointRelativeUI(int sys, GameObject go);

		// Token: 0x060002ED RID: 749
		void DetachSysRedPointRelative(int sys);

		// Token: 0x060002EE RID: 750
		void DetachSysRedPointRelativeUI(int sys);

		// Token: 0x060002EF RID: 751
		void GamePause(bool pause);

		// Token: 0x060002F0 RID: 752
		bool GetSysRedPointState(int sys);
	}
}
