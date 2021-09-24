using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTargetRewardDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XTargetRewardDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XTargetRewardDocument.AsyncLoader.AddTask("Table/GoalAwards", XTargetRewardDocument._reader, false);
			XTargetRewardDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
			XTargetRewardDocument.m_GoalAwardsDic.Clear();
			int num = XTargetRewardDocument._reader.Table.Length;
			for (int i = 0; i < XTargetRewardDocument._reader.Table.Length; i++)
			{
				uint goalAwardsID = XTargetRewardDocument._reader.Table[i].GoalAwardsID;
				bool flag = !XTargetRewardDocument.m_GoalAwardsDic.ContainsKey(goalAwardsID);
				if (flag)
				{
					XTargetRewardDocument.m_GoalAwardsDic[goalAwardsID] = new List<GoalAwards.RowData>();
					XTargetRewardDocument.m_GoalAwardsDic[goalAwardsID].Clear();
					XTargetRewardDocument.m_sortDic[goalAwardsID] = num - i;
				}
				XTargetRewardDocument.m_GoalAwardsDic[goalAwardsID].Add(XTargetRewardDocument._reader.Table[i]);
				uint type = XTargetRewardDocument._reader.Table[i].Type;
				XTargetRewardDocument.m_goalLevel[(int)type] = Math.Min(XTargetRewardDocument.m_goalLevel[(int)type], XTargetRewardDocument._reader.Table[i].ShowLevel);
			}
			foreach (KeyValuePair<uint, List<GoalAwards.RowData>> keyValuePair in XTargetRewardDocument.m_GoalAwardsDic)
			{
				keyValuePair.Value.Sort((GoalAwards.RowData x, GoalAwards.RowData y) => x.AwardsIndex.CompareTo(y.AwardsIndex));
			}
		}

		public void FetchTargetRewardType(TargetRewardType type)
		{
			RpcC2M_GoalAwardsGetList rpcC2M_GoalAwardsGetList = new RpcC2M_GoalAwardsGetList();
			rpcC2M_GoalAwardsGetList.oArg.type = (uint)type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GoalAwardsGetList);
		}

		public uint GetMinRewardLevel(List<GoalAwards.RowData> subItems)
		{
			uint num = 500U;
			for (int i = 0; i < subItems.Count; i++)
			{
				num = Math.Min(num, subItems[i].ShowLevel);
			}
			return num;
		}

		public void OnResTargetRewardType(GoalAwardsGetList_C2M oArg, GoalAwardsGetList_M2C oRes)
		{
			this.targetAwardDetails.Clear();
			bool flag = this.rwdView != null && this.rwdView.IsVisible();
			if (flag)
			{
				foreach (GoalAwardsInfo goalAwardsInfo in oRes.goalAwardsList)
				{
					TargetItemInfo targetItemInfo = new TargetItemInfo();
					targetItemInfo.subItems = this.FindTarget(goalAwardsInfo.goalAwardsID);
					bool flag2 = targetItemInfo.subItems != null;
					if (flag2)
					{
						targetItemInfo.minLevel = this.GetMinRewardLevel(targetItemInfo.subItems);
						targetItemInfo.goalAwardsID = goalAwardsInfo.goalAwardsID;
						targetItemInfo.doneIndex = Math.Min(goalAwardsInfo.doneIndex, (uint)targetItemInfo.subItems.Count);
						targetItemInfo.gottenAwardsIndex = Math.Min(goalAwardsInfo.gottenAwardsIndex, (uint)targetItemInfo.subItems.Count);
						targetItemInfo.totalvalue = goalAwardsInfo.totalvalue;
						this.targetAwardDetails.Add(targetItemInfo);
					}
				}
				foreach (KeyValuePair<uint, List<GoalAwards.RowData>> keyValuePair in XTargetRewardDocument.m_GoalAwardsDic)
				{
					bool flag3 = keyValuePair.Value.Count > 0 && !this.FindTargetInDetailList(keyValuePair.Value[0].GoalAwardsID);
					if (flag3)
					{
						bool flag4 = (ulong)keyValuePair.Value[0].Type == (ulong)((long)this.rwdView.m_targetRewardType);
						if (flag4)
						{
							TargetItemInfo targetItemInfo2 = new TargetItemInfo();
							targetItemInfo2.subItems = keyValuePair.Value;
							targetItemInfo2.goalAwardsID = keyValuePair.Value[0].GoalAwardsID;
							targetItemInfo2.doneIndex = 0U;
							targetItemInfo2.gottenAwardsIndex = 0U;
							targetItemInfo2.totalvalue = 0.0;
							targetItemInfo2.minLevel = this.GetMinRewardLevel(targetItemInfo2.subItems);
							this.targetAwardDetails.Add(targetItemInfo2);
						}
					}
				}
				for (int i = this.targetAwardDetails.Count - 1; i >= 0; i--)
				{
					bool flag5 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < this.targetAwardDetails[i].minLevel;
					if (flag5)
					{
						this.targetAwardDetails.RemoveAt(i);
					}
				}
				this.RecalulateRedPoint(this.targetAwardDetails, oArg.type);
				this.targetAwardDetails.Sort(new Comparison<TargetItemInfo>(this.Sort));
				this.rwdView.RefreshDetails();
			}
		}

		private int Sort(TargetItemInfo x, TargetItemInfo y)
		{
			int num = XTargetRewardDocument.m_sortDic.ContainsKey(x.goalAwardsID) ? XTargetRewardDocument.m_sortDic[x.goalAwardsID] : 0;
			int num2 = XTargetRewardDocument.m_sortDic.ContainsKey(y.goalAwardsID) ? XTargetRewardDocument.m_sortDic[y.goalAwardsID] : 0;
			int num3 = 10000 + num;
			int num4 = 10000 + num2;
			bool flag = x.gottenAwardsIndex < x.doneIndex;
			if (flag)
			{
				num3 += 10000000;
			}
			else
			{
				bool flag2 = x.subItems != null && (ulong)x.gottenAwardsIndex == (ulong)((long)x.subItems.Count);
				if (flag2)
				{
					num3 = num;
				}
			}
			bool flag3 = y.gottenAwardsIndex < y.doneIndex;
			if (flag3)
			{
				num4 += 10000000;
			}
			else
			{
				bool flag4 = y.subItems != null && (ulong)y.gottenAwardsIndex == (ulong)((long)y.subItems.Count);
				if (flag4)
				{
					num4 = num2;
				}
			}
			return num4 - num3;
		}

		public bool FindTargetInDetailList(uint goalAwardsID)
		{
			foreach (TargetItemInfo targetItemInfo in this.targetAwardDetails)
			{
				bool flag = targetItemInfo.goalAwardsID == goalAwardsID;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public List<GoalAwards.RowData> FindTarget(uint goalAwardsID)
		{
			bool flag = XTargetRewardDocument.m_GoalAwardsDic.ContainsKey(goalAwardsID);
			List<GoalAwards.RowData> result;
			if (flag)
			{
				result = XTargetRewardDocument.m_GoalAwardsDic[goalAwardsID];
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("not find info in goalAward table id: ", goalAwardsID.ToString(), null, null, null, null);
				result = null;
			}
			return result;
		}

		public void ClaimAchieve(int id)
		{
			XSingleton<XDebug>.singleton.AddLog("ClaimTarget ", id.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_GoalAwardsGetAwards rpcC2M_GoalAwardsGetAwards = new RpcC2M_GoalAwardsGetAwards();
			rpcC2M_GoalAwardsGetAwards.oArg.goalAwardsID = (uint)id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GoalAwardsGetAwards);
		}

		public void OnClaimedAchieve(uint id, uint index)
		{
			List<GoalAwards.RowData> list = this.FindTarget(id);
			bool flag = list != null;
			if (flag)
			{
				this.FetchTargetRewardType((TargetRewardType)list[0].Type);
			}
		}

		public void SetRedPointList(List<uint> redList)
		{
			this.InitOpenGoalAward();
			this.m_redList.Clear();
			for (int i = 0; i < redList.Count; i++)
			{
				bool flag = (ulong)redList[i] < (ulong)((long)this.m_isGoalOpen.Length) && this.m_isGoalOpen[(int)redList[i]];
				if (flag)
				{
					this.m_redList.Add(redList[i]);
				}
			}
			bool flag2 = this.rwdView != null && this.rwdView.IsVisible();
			if (flag2)
			{
				this.rwdView.RefreshRedPoint();
			}
			this.UpdateAllRedPoint();
		}

		public void RecalulateRedPoint(List<TargetItemInfo> itemInfo, uint type)
		{
			this.m_redList.Remove(type);
			bool flag = false;
			foreach (TargetItemInfo targetItemInfo in itemInfo)
			{
				bool flag2 = targetItemInfo.subItems == null;
				if (!flag2)
				{
					bool flag3 = targetItemInfo.doneIndex > targetItemInfo.gottenAwardsIndex;
					if (flag3)
					{
						flag = true;
						break;
					}
				}
			}
			bool flag4 = flag && (ulong)type < (ulong)((long)this.m_isGoalOpen.Length) && this.m_isGoalOpen[(int)type];
			if (flag4)
			{
				this.m_redList.Add(type);
			}
			bool flag5 = this.rwdView != null && this.rwdView.IsVisible();
			if (flag5)
			{
				this.rwdView.RefreshRedPoint();
			}
			this.UpdateAllRedPoint();
		}

		public void UpdateAllRedPoint()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward_Target, true);
		}

		public bool HasNewRed()
		{
			return this.m_redList.Count > 0;
		}

		public void InitOpenGoalAward()
		{
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("OpenGoalAwards").Split(XGlobalConfig.ListSeparator);
			this.m_designationId = XSingleton<XGlobalConfig>.singleton.GetInt("GoalDesignationId");
			for (int i = 0; i < array.Length; i++)
			{
				int num = int.Parse(array[i]);
				bool flag = num < this.m_isGoalOpen.Length && XSingleton<XAttributeMgr>.singleton.XPlayerData.Level >= XTargetRewardDocument.m_goalLevel[num];
				if (flag)
				{
					this.m_isGoalOpen[num] = true;
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TargetRewardDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static GoalAwards _reader = new GoalAwards();

		public List<TargetItemInfo> targetAwardDetails = new List<TargetItemInfo>();

		private static Dictionary<uint, List<GoalAwards.RowData>> m_GoalAwardsDic = new Dictionary<uint, List<GoalAwards.RowData>>();

		private static Dictionary<uint, int> m_sortDic = new Dictionary<uint, int>();

		public List<uint> m_redList = new List<uint>();

		public XTargetRewardView rwdView;

		public bool[] m_isGoalOpen = new bool[5];

		public static uint[] m_goalLevel = new uint[]
		{
			500U,
			500U,
			500U,
			500U,
			500U
		};

		public int m_designationId = 40;
	}
}
