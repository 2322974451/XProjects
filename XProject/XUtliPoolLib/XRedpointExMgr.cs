using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x020001B5 RID: 437
	public class XRedpointExMgr : XRedpointMgr, IXRedpointExMgr, IXRedpointMgr, IXRedpointRelationMgr, IXRedpointForbidMgr
	{
		// Token: 0x060009CE RID: 2510 RVA: 0x0003348C File Offset: 0x0003168C
		public void AddSysForbidLevels(int sys, uint level)
		{
			HashSet<uint> hashSet = null;
			bool flag = !this.mSysForbidLevelsDic.TryGetValue(sys, out hashSet);
			if (flag)
			{
				hashSet = new HashSet<uint>();
				this.mSysForbidLevelsDic[sys] = hashSet;
			}
			bool flag2 = hashSet.Add(level);
			if (flag2)
			{
				bool flag3 = this.mCurrentLevel == level;
				if (flag3)
				{
					this._RefreshSysRedpointUI(sys, base._GetSysRedpointState(sys));
				}
			}
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x000334F0 File Offset: 0x000316F0
		public void RemoveSysForbidLevels(int sys, uint level)
		{
			HashSet<uint> hashSet = null;
			bool flag = this.mSysForbidLevelsDic.TryGetValue(sys, out hashSet);
			if (flag)
			{
				bool flag2 = hashSet.Remove(level);
				if (flag2)
				{
					bool flag3 = hashSet.Count <= 0;
					if (flag3)
					{
						this.mSysForbidLevelsDic.Remove(sys);
					}
					bool flag4 = this.mCurrentLevel == level;
					if (flag4)
					{
						this._RefreshSysRedpointUI(sys, base._GetSysRedpointState(sys));
					}
				}
			}
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0003355C File Offset: 0x0003175C
		public void InitCurrentLevel(uint level)
		{
			this.mCurrentLevel = level;
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x00033568 File Offset: 0x00031768
		public void SetCurrentLevel(uint level)
		{
			bool flag = level != this.mCurrentLevel;
			if (flag)
			{
				this.mCurrentLevel = level;
				foreach (KeyValuePair<int, HashSet<uint>> keyValuePair in this.mSysForbidLevelsDic)
				{
					bool flag2 = keyValuePair.Value.Contains(level);
					if (flag2)
					{
						bool flag3 = base._GetSysRedpointState(keyValuePair.Key);
						if (flag3)
						{
							this._RefreshSysRedpointUI(keyValuePair.Key, false);
						}
					}
				}
			}
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0003360C File Offset: 0x0003180C
		protected override void _RefreshSysRedpointUI(int sys, bool redpoint)
		{
			bool flag = redpoint;
			if (flag)
			{
				HashSet<uint> hashSet = null;
				bool flag2 = this.mSysForbidLevelsDic.TryGetValue(sys, out hashSet);
				if (flag2)
				{
					bool flag3 = hashSet.Contains(this.mCurrentLevel);
					if (flag3)
					{
						redpoint = false;
					}
				}
			}
			base._RefreshSysRedpointUI(sys, redpoint);
		}

		// Token: 0x040004A9 RID: 1193
		protected uint mCurrentLevel;

		// Token: 0x040004AA RID: 1194
		protected Dictionary<int, HashSet<uint>> mSysForbidLevelsDic = new Dictionary<int, HashSet<uint>>();
	}
}
