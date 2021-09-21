using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x020001B6 RID: 438
	public abstract class XRedpointForbidMgr : XRedpointRelationMgr, IXRedpointForbidMgr
	{
		// Token: 0x060009D4 RID: 2516 RVA: 0x0003366C File Offset: 0x0003186C
		public void AddForbid(int sys, bool bImmUpdateUI = true)
		{
			bool flag = this.mForbidHashSet.Add(sys);
			if (flag)
			{
				if (bImmUpdateUI)
				{
					this._RefreshSysRedpointUI(sys, base._GetSysRedpointState(sys));
				}
				else
				{
					this.mDirtySysList.Add(sys);
				}
			}
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x000336B0 File Offset: 0x000318B0
		public void AddForbids(int[] systems, bool bImmUpdateUI = true)
		{
			bool flag = systems == null || systems.Length == 0;
			if (!flag)
			{
				for (int i = 0; i < systems.Length; i++)
				{
					bool flag2 = this.mForbidHashSet.Add(systems[i]);
					if (flag2)
					{
						if (bImmUpdateUI)
						{
							this._RefreshSysRedpointUI(systems[i], base._GetSysRedpointState(systems[i]));
						}
						else
						{
							this.mDirtySysList.Add(systems[i]);
						}
					}
				}
			}
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x00033724 File Offset: 0x00031924
		public void RemoveForbid(int sys, bool bImmUpdateUI = true)
		{
			bool flag = this.mForbidHashSet.Remove(sys);
			if (flag)
			{
				if (bImmUpdateUI)
				{
					this._RefreshSysRedpointUI(sys, base._GetSysRedpointState(sys));
				}
				else
				{
					this.mDirtySysList.Add(sys);
				}
			}
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x00033768 File Offset: 0x00031968
		public void RemoveForbids(int[] systems, bool bImmUpdateUI = true)
		{
			bool flag = systems == null || systems.Length == 0;
			if (!flag)
			{
				for (int i = 0; i < systems.Length; i++)
				{
					bool flag2 = this.mForbidHashSet.Remove(systems[i]);
					if (flag2)
					{
						if (bImmUpdateUI)
						{
							this._RefreshSysRedpointUI(systems[i], base._GetSysRedpointState(systems[i]));
						}
						else
						{
							this.mDirtySysList.Add(systems[i]);
						}
					}
				}
			}
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x000337DC File Offset: 0x000319DC
		public void ClearForbids(bool bImmUpdateUI = true)
		{
			foreach (int num in this.mForbidHashSet)
			{
				if (bImmUpdateUI)
				{
					this._RefreshSysRedpointUI(num, base._GetSysRedpointState(num));
				}
				else
				{
					this.mDirtySysList.Add(num);
				}
			}
			this.mForbidHashSet.Clear();
		}

		// Token: 0x040004AB RID: 1195
		protected HashSet<int> mForbidHashSet = new HashSet<int>();
	}
}
