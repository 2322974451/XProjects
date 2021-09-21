using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A93 RID: 2707
	internal class XNestDocument : XDocComponent
	{
		// Token: 0x17002FD9 RID: 12249
		// (get) Token: 0x0600A4C0 RID: 42176 RVA: 0x001C906C File Offset: 0x001C726C
		public override uint ID
		{
			get
			{
				return XNestDocument.uuID;
			}
		}

		// Token: 0x17002FDA RID: 12250
		// (get) Token: 0x0600A4C1 RID: 42177 RVA: 0x001C9084 File Offset: 0x001C7284
		public static NestListTable NestListData
		{
			get
			{
				return XNestDocument._NestListTable;
			}
		}

		// Token: 0x17002FDB RID: 12251
		// (get) Token: 0x0600A4C2 RID: 42178 RVA: 0x001C909C File Offset: 0x001C729C
		public static NestTypeTable NestTypeData
		{
			get
			{
				return XNestDocument._NestTypeTable;
			}
		}

		// Token: 0x17002FDC RID: 12252
		// (get) Token: 0x0600A4C3 RID: 42179 RVA: 0x001C90B4 File Offset: 0x001C72B4
		public static NestStarReward NestStarRewardTab
		{
			get
			{
				return XNestDocument._nestStarRewardTab;
			}
		}

		// Token: 0x0600A4C4 RID: 42180 RVA: 0x001C90CC File Offset: 0x001C72CC
		public static void Execute(OnLoadedCallback callback = null)
		{
			XNestDocument.AsyncLoader.AddTask("Table/NestList", XNestDocument._NestListTable, false);
			XNestDocument.AsyncLoader.AddTask("Table/NestType", XNestDocument._NestTypeTable, false);
			XNestDocument.AsyncLoader.AddTask("Table/NestStarReward", XNestDocument._nestStarRewardTab, false);
			XNestDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A4C5 RID: 42181 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600A4C6 RID: 42182 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600A4C7 RID: 42183 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600A4C8 RID: 42184 RVA: 0x001C9128 File Offset: 0x001C7328
		public int GetStarNestId(int type)
		{
			XExpeditionDocument xexpeditionDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XExpeditionDocument.uuID) as XExpeditionDocument;
			XLevelDocument specificDocument = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
			int num = 0;
			for (int i = 0; i < XNestDocument.NestListData.Table.Length; i++)
			{
				NestListTable.RowData rowData = XNestDocument.NestListData.Table[i];
				bool flag = rowData.Type != type;
				if (!flag)
				{
					ExpeditionTable.RowData expeditionDataByID = xexpeditionDocument.GetExpeditionDataByID(rowData.NestID);
					bool flag2 = expeditionDataByID == null || expeditionDataByID.CostCountType != 0;
					if (!flag2)
					{
						bool flag3 = num == 0 && expeditionDataByID.Stars[0] == 1U;
						if (flag3)
						{
							num = rowData.NestID;
						}
						SceneRefuseReason sceneRefuseReason = specificDocument.CanLevelOpen(xexpeditionDocument.GetSceneIDByExpID(rowData.NestID));
						bool flag4 = sceneRefuseReason == SceneRefuseReason.Admit;
						if (flag4)
						{
							num = rowData.NestID;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600A4C9 RID: 42185 RVA: 0x001C9224 File Offset: 0x001C7424
		public int GetNestType(int nestId)
		{
			for (int i = 0; i < XNestDocument.NestListData.Table.Length; i++)
			{
				bool flag = XNestDocument.NestListData.Table[i].NestID == nestId;
				if (flag)
				{
					return XNestDocument.NestListData.Table[i].Type;
				}
			}
			return 0;
		}

		// Token: 0x0600A4CA RID: 42186 RVA: 0x001C9280 File Offset: 0x001C7480
		public List<NestStarReward.RowData> GetNestStarRewards(uint nestType)
		{
			List<NestStarReward.RowData> list = new List<NestStarReward.RowData>();
			for (int i = 0; i < XNestDocument.NestStarRewardTab.Table.Length; i++)
			{
				bool flag = XNestDocument.NestStarRewardTab.Table[i].Type == nestType;
				if (flag)
				{
					list.Add(XNestDocument.NestStarRewardTab.Table[i]);
				}
			}
			return list;
		}

		// Token: 0x0600A4CB RID: 42187 RVA: 0x001C92E8 File Offset: 0x001C74E8
		public ExpeditionTable.RowData GetLastExpeditionRowData()
		{
			int num = -1;
			HashSet<int> hashSet = new HashSet<int>();
			XExpeditionDocument xexpeditionDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XExpeditionDocument.uuID) as XExpeditionDocument;
			for (int i = 0; i < XNestDocument.NestListData.Table.Length; i++)
			{
				NestListTable.RowData rowData = XNestDocument.NestListData.Table[i];
				bool flag = hashSet.Contains(rowData.Type);
				if (!flag)
				{
					ExpeditionTable.RowData rowData2 = xexpeditionDocument.GetExpeditionDataByID(rowData.NestID);
					bool flag2 = rowData2 == null;
					if (!flag2)
					{
						bool flag3 = xexpeditionDocument.TeamCategoryMgr.IsExpOpened(rowData2);
						if (!flag3)
						{
							break;
						}
						hashSet.Add(rowData.Type);
						num = rowData.Type;
					}
				}
			}
			bool flag4 = num == -1;
			ExpeditionTable.RowData result;
			if (flag4)
			{
				result = null;
			}
			else
			{
				ExpeditionTable.RowData rowData2 = null;
				XLevelDocument specificDocument = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
				int j = 0;
				while (j < XNestDocument.NestListData.Table.Length)
				{
					NestListTable.RowData rowData3 = XNestDocument.NestListData.Table[j];
					bool flag5 = rowData3.Type == num;
					if (flag5)
					{
						ExpeditionTable.RowData expeditionDataByID = xexpeditionDocument.GetExpeditionDataByID(rowData3.NestID);
						bool flag6 = expeditionDataByID == null;
						if (!flag6)
						{
							bool flag7 = expeditionDataByID.CostCountType == 0;
							if (!flag7)
							{
								SceneRefuseReason sceneRefuseReason = specificDocument.CanLevelOpen(xexpeditionDocument.GetSceneIDByExpID(rowData3.NestID));
								bool flag8 = sceneRefuseReason == SceneRefuseReason.Admit;
								if (!flag8)
								{
									break;
								}
								rowData2 = expeditionDataByID;
							}
						}
					}
					IL_15D:
					j++;
					continue;
					goto IL_15D;
				}
				bool flag9 = rowData2 != null;
				if (flag9)
				{
					XSingleton<XDebug>.singleton.AddGreenLog(rowData2.DNExpeditionName, null, null, null, null, null);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddGreenLog("expdata is null", null, null, null, null, null);
				}
				result = rowData2;
			}
			return result;
		}

		// Token: 0x04003BED RID: 15341
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("NestDocument");

		// Token: 0x04003BEE RID: 15342
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003BEF RID: 15343
		private static NestListTable _NestListTable = new NestListTable();

		// Token: 0x04003BF0 RID: 15344
		private static NestTypeTable _NestTypeTable = new NestTypeTable();

		// Token: 0x04003BF1 RID: 15345
		private static NestStarReward _nestStarRewardTab = new NestStarReward();

		// Token: 0x04003BF2 RID: 15346
		public uint NestType = 0U;
	}
}
