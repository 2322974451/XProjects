using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009FA RID: 2554
	internal class XTargetRewardDocument : XDocComponent
	{
		// Token: 0x17002E5F RID: 11871
		// (get) Token: 0x06009C29 RID: 39977 RVA: 0x00192064 File Offset: 0x00190264
		public override uint ID
		{
			get
			{
				return XTargetRewardDocument.uuID;
			}
		}

		// Token: 0x06009C2A RID: 39978 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009C2B RID: 39979 RVA: 0x0019207B File Offset: 0x0019027B
		public static void Execute(OnLoadedCallback callback = null)
		{
			XTargetRewardDocument.AsyncLoader.AddTask("Table/GoalAwards", XTargetRewardDocument._reader, false);
			XTargetRewardDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009C2C RID: 39980 RVA: 0x001920A0 File Offset: 0x001902A0
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

		// Token: 0x06009C2D RID: 39981 RVA: 0x00192208 File Offset: 0x00190408
		public void FetchTargetRewardType(TargetRewardType type)
		{
			RpcC2M_GoalAwardsGetList rpcC2M_GoalAwardsGetList = new RpcC2M_GoalAwardsGetList();
			rpcC2M_GoalAwardsGetList.oArg.type = (uint)type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GoalAwardsGetList);
		}

		// Token: 0x06009C2E RID: 39982 RVA: 0x00192238 File Offset: 0x00190438
		public uint GetMinRewardLevel(List<GoalAwards.RowData> subItems)
		{
			uint num = 500U;
			for (int i = 0; i < subItems.Count; i++)
			{
				num = Math.Min(num, subItems[i].ShowLevel);
			}
			return num;
		}

		// Token: 0x06009C2F RID: 39983 RVA: 0x0019227C File Offset: 0x0019047C
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

		// Token: 0x06009C30 RID: 39984 RVA: 0x00192544 File Offset: 0x00190744
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

		// Token: 0x06009C31 RID: 39985 RVA: 0x0019264C File Offset: 0x0019084C
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

		// Token: 0x06009C32 RID: 39986 RVA: 0x001926B4 File Offset: 0x001908B4
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

		// Token: 0x06009C33 RID: 39987 RVA: 0x00192700 File Offset: 0x00190900
		public void ClaimAchieve(int id)
		{
			XSingleton<XDebug>.singleton.AddLog("ClaimTarget ", id.ToString(), null, null, null, null, XDebugColor.XDebug_None);
			RpcC2M_GoalAwardsGetAwards rpcC2M_GoalAwardsGetAwards = new RpcC2M_GoalAwardsGetAwards();
			rpcC2M_GoalAwardsGetAwards.oArg.goalAwardsID = (uint)id;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_GoalAwardsGetAwards);
		}

		// Token: 0x06009C34 RID: 39988 RVA: 0x0019274C File Offset: 0x0019094C
		public void OnClaimedAchieve(uint id, uint index)
		{
			List<GoalAwards.RowData> list = this.FindTarget(id);
			bool flag = list != null;
			if (flag)
			{
				this.FetchTargetRewardType((TargetRewardType)list[0].Type);
			}
		}

		// Token: 0x06009C35 RID: 39989 RVA: 0x00192780 File Offset: 0x00190980
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

		// Token: 0x06009C36 RID: 39990 RVA: 0x00192824 File Offset: 0x00190A24
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

		// Token: 0x06009C37 RID: 39991 RVA: 0x00192908 File Offset: 0x00190B08
		public void UpdateAllRedPoint()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward_Target, true);
		}

		// Token: 0x06009C38 RID: 39992 RVA: 0x0019291C File Offset: 0x00190B1C
		public bool HasNewRed()
		{
			return this.m_redList.Count > 0;
		}

		// Token: 0x06009C39 RID: 39993 RVA: 0x0019293C File Offset: 0x00190B3C
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

		// Token: 0x040036B8 RID: 14008
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("TargetRewardDocument");

		// Token: 0x040036B9 RID: 14009
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040036BA RID: 14010
		private static GoalAwards _reader = new GoalAwards();

		// Token: 0x040036BB RID: 14011
		public List<TargetItemInfo> targetAwardDetails = new List<TargetItemInfo>();

		// Token: 0x040036BC RID: 14012
		private static Dictionary<uint, List<GoalAwards.RowData>> m_GoalAwardsDic = new Dictionary<uint, List<GoalAwards.RowData>>();

		// Token: 0x040036BD RID: 14013
		private static Dictionary<uint, int> m_sortDic = new Dictionary<uint, int>();

		// Token: 0x040036BE RID: 14014
		public List<uint> m_redList = new List<uint>();

		// Token: 0x040036BF RID: 14015
		public XTargetRewardView rwdView;

		// Token: 0x040036C0 RID: 14016
		public bool[] m_isGoalOpen = new bool[5];

		// Token: 0x040036C1 RID: 14017
		public static uint[] m_goalLevel = new uint[]
		{
			500U,
			500U,
			500U,
			500U,
			500U
		};

		// Token: 0x040036C2 RID: 14018
		public int m_designationId = 40;
	}
}
