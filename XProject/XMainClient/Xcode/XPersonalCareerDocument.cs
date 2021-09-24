using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPersonalCareerDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XPersonalCareerDocument.uuID;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XPersonalCareerDocument.AsyncLoader.AddTask("Table/Career", XPersonalCareerDocument.CareerTable, false);
			XPersonalCareerDocument.AsyncLoader.AddTask("Table/TrophyInfo", XPersonalCareerDocument.TrophyInfoTable, false);
			XPersonalCareerDocument.AsyncLoader.AddTask("Table/TrophyReward", XPersonalCareerDocument.TrophyRewardTable, false);
			XPersonalCareerDocument.AsyncLoader.Execute(callback);
		}

		public TrophyReward.RowData ProcessHonorLevelMax(TrophyReward.RowData data)
		{
			bool flag = XPersonalCareerDocument.TrophyRewardTable.Table.Length >= 2;
			if (flag)
			{
				bool flag2 = data.HonourRank == XPersonalCareerDocument.TrophyRewardTable.Table[XPersonalCareerDocument.TrophyRewardTable.Table.Length - 1].HonourRank;
				if (flag2)
				{
					data.TrophyScore = XPersonalCareerDocument.TrophyRewardTable.Table[XPersonalCareerDocument.TrophyRewardTable.Table.Length - 2].TrophyScore;
				}
			}
			return data;
		}

		public static List<TrophyReward.RowData> GetHonorRewardList()
		{
			List<TrophyReward.RowData> list = new List<TrophyReward.RowData>();
			for (int i = 0; i < XPersonalCareerDocument.TrophyRewardTable.Table.Length; i++)
			{
				bool flag = XPersonalCareerDocument.TrophyRewardTable.Table[i].Rewards.Count != 0;
				if (flag)
				{
					list.Add(XPersonalCareerDocument.TrophyRewardTable.Table[i]);
				}
			}
			return list;
		}

		public static TrophyReward.RowData GetTrophyReward(int level)
		{
			for (int i = 0; i < XPersonalCareerDocument.TrophyRewardTable.Table.Length; i++)
			{
				bool flag = level == XPersonalCareerDocument.TrophyRewardTable.Table[i].HonourRank;
				if (flag)
				{
					return XPersonalCareerDocument.TrophyRewardTable.Table[i];
				}
			}
			return XPersonalCareerDocument.TrophyRewardTable.Table[XPersonalCareerDocument.TrophyRewardTable.Table.Length - 1];
		}

		public static TrophyReward.RowData GetHonorNextReward(int curLevel)
		{
			for (int i = curLevel; i < XPersonalCareerDocument.TrophyRewardTable.Table.Length; i++)
			{
				bool flag = XPersonalCareerDocument.TrophyRewardTable.Table[i].Rewards.Count != 0;
				if (flag)
				{
					return XPersonalCareerDocument.TrophyRewardTable.Table[i];
				}
			}
			return null;
		}

		public static TrophyInfo.RowData GetTrophyTableData(uint ID)
		{
			for (int i = 0; i < XPersonalCareerDocument.TrophyInfoTable.Table.Length; i++)
			{
				bool flag = XPersonalCareerDocument.TrophyInfoTable.Table[i].ID == ID;
				if (flag)
				{
					return XPersonalCareerDocument.TrophyInfoTable.Table[i];
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("TrophyID:" + ID + " No Find", null, null, null, null, null);
			return null;
		}

		public static List<TrophyInfo.RowData> GetTrophyTableDataToSceneID(uint SceneID)
		{
			List<TrophyInfo.RowData> list = new List<TrophyInfo.RowData>();
			for (int i = 0; i < XPersonalCareerDocument.TrophyInfoTable.Table.Length; i++)
			{
				bool flag = XPersonalCareerDocument.TrophyInfoTable.Table[i].SceneID == SceneID;
				if (flag)
				{
					list.Add(XPersonalCareerDocument.TrophyInfoTable.Table[i]);
				}
			}
			return list;
		}

		public static Career.RowData GetCareer(int sortid)
		{
			for (int i = 0; i < XPersonalCareerDocument.CareerTable.Table.Length; i++)
			{
				bool flag = sortid == XPersonalCareerDocument.CareerTable.Table[i].SortId;
				if (flag)
				{
					return XPersonalCareerDocument.CareerTable.Table[i];
				}
			}
			return null;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void ReqGetCareer(PersonalCarrerReqType type, ulong roleId = 0UL)
		{
			RpcC2G_PersonalCareer rpcC2G_PersonalCareer = new RpcC2G_PersonalCareer();
			rpcC2G_PersonalCareer.oArg.quest_type = type;
			rpcC2G_PersonalCareer.oArg.role_id = roleId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PersonalCareer);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XPersonalCareerDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static Career CareerTable = new Career();

		public static TrophyInfo TrophyInfoTable = new TrophyInfo();

		public static TrophyReward TrophyRewardTable = new TrophyReward();

		public Dictionary<PersonalCarrerReqType, bool> HasData = new Dictionary<PersonalCarrerReqType, bool>();
	}
}
