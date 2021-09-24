using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{

	public class XRedpointExMgr : XRedpointMgr, IXRedpointExMgr, IXRedpointMgr, IXRedpointRelationMgr, IXRedpointForbidMgr
	{

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

		public void InitCurrentLevel(uint level)
		{
			this.mCurrentLevel = level;
		}

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

		protected uint mCurrentLevel;

		protected Dictionary<int, HashSet<uint>> mSysForbidLevelsDic = new Dictionary<int, HashSet<uint>>();
	}
}
