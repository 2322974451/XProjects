using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000965 RID: 2405
	internal class XPersonalCareerDocument : XDocComponent
	{
		// Token: 0x17002C54 RID: 11348
		// (get) Token: 0x060090E3 RID: 37091 RVA: 0x0014ABA8 File Offset: 0x00148DA8
		public override uint ID
		{
			get
			{
				return XPersonalCareerDocument.uuID;
			}
		}

		// Token: 0x060090E4 RID: 37092 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x060090E5 RID: 37093 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnEnterSceneFinally()
		{
		}

		// Token: 0x060090E6 RID: 37094 RVA: 0x0014ABC0 File Offset: 0x00148DC0
		public static void Execute(OnLoadedCallback callback = null)
		{
			XPersonalCareerDocument.AsyncLoader.AddTask("Table/Career", XPersonalCareerDocument.CareerTable, false);
			XPersonalCareerDocument.AsyncLoader.AddTask("Table/TrophyInfo", XPersonalCareerDocument.TrophyInfoTable, false);
			XPersonalCareerDocument.AsyncLoader.AddTask("Table/TrophyReward", XPersonalCareerDocument.TrophyRewardTable, false);
			XPersonalCareerDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060090E7 RID: 37095 RVA: 0x0014AC1C File Offset: 0x00148E1C
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

		// Token: 0x060090E8 RID: 37096 RVA: 0x0014AC98 File Offset: 0x00148E98
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

		// Token: 0x060090E9 RID: 37097 RVA: 0x0014AD00 File Offset: 0x00148F00
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

		// Token: 0x060090EA RID: 37098 RVA: 0x0014AD70 File Offset: 0x00148F70
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

		// Token: 0x060090EB RID: 37099 RVA: 0x0014ADCC File Offset: 0x00148FCC
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

		// Token: 0x060090EC RID: 37100 RVA: 0x0014AE48 File Offset: 0x00149048
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

		// Token: 0x060090ED RID: 37101 RVA: 0x0014AEAC File Offset: 0x001490AC
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

		// Token: 0x060090EE RID: 37102 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x060090EF RID: 37103 RVA: 0x0014AF04 File Offset: 0x00149104
		public void ReqGetCareer(PersonalCarrerReqType type, ulong roleId = 0UL)
		{
			RpcC2G_PersonalCareer rpcC2G_PersonalCareer = new RpcC2G_PersonalCareer();
			rpcC2G_PersonalCareer.oArg.quest_type = type;
			rpcC2G_PersonalCareer.oArg.role_id = roleId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PersonalCareer);
		}

		// Token: 0x04003006 RID: 12294
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XPersonalCareerDocument");

		// Token: 0x04003007 RID: 12295
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003008 RID: 12296
		public static Career CareerTable = new Career();

		// Token: 0x04003009 RID: 12297
		public static TrophyInfo TrophyInfoTable = new TrophyInfo();

		// Token: 0x0400300A RID: 12298
		public static TrophyReward TrophyRewardTable = new TrophyReward();

		// Token: 0x0400300B RID: 12299
		public Dictionary<PersonalCarrerReqType, bool> HasData = new Dictionary<PersonalCarrerReqType, bool>();
	}
}
