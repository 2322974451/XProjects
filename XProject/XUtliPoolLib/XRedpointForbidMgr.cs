using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{

	public abstract class XRedpointForbidMgr : XRedpointRelationMgr, IXRedpointForbidMgr
	{

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

		protected HashSet<int> mForbidHashSet = new HashSet<int>();
	}
}
