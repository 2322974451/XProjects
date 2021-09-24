using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XNestDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XNestDocument.uuID;
			}
		}

		public static NestListTable NestListData
		{
			get
			{
				return XNestDocument._NestListTable;
			}
		}

		public static NestTypeTable NestTypeData
		{
			get
			{
				return XNestDocument._NestTypeTable;
			}
		}

		public static NestStarReward NestStarRewardTab
		{
			get
			{
				return XNestDocument._nestStarRewardTab;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XNestDocument.AsyncLoader.AddTask("Table/NestList", XNestDocument._NestListTable, false);
			XNestDocument.AsyncLoader.AddTask("Table/NestType", XNestDocument._NestTypeTable, false);
			XNestDocument.AsyncLoader.AddTask("Table/NestStarReward", XNestDocument._nestStarRewardTab, false);
			XNestDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("NestDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static NestListTable _NestListTable = new NestListTable();

		private static NestTypeTable _NestTypeTable = new NestTypeTable();

		private static NestStarReward _nestStarRewardTab = new NestStarReward();

		public uint NestType = 0U;
	}
}
