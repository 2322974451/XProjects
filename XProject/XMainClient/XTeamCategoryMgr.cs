using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D3B RID: 3387
	internal class XTeamCategoryMgr
	{
		// Token: 0x17003306 RID: 13062
		// (get) Token: 0x0600BB94 RID: 48020 RVA: 0x00268F08 File Offset: 0x00267108
		// (set) Token: 0x0600BB95 RID: 48021 RVA: 0x00268F10 File Offset: 0x00267110
		public int LastestNoRankAbyssSceneID { get; set; }

		// Token: 0x0600BB96 RID: 48022 RVA: 0x00268F1C File Offset: 0x0026711C
		public void Init()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this.m_DicExpCate.Clear();
			this.m_DicCate.Clear();
			this.m_Categories.Clear();
			XTeamCategory xteamCategory = null;
			for (int i = 0; i < XExpeditionDocument.ExpTable.Table.Length; i++)
			{
				ExpeditionTable.RowData rowData = XExpeditionDocument.ExpTable.Table[i];
				bool flag = rowData.Category == 0;
				if (!flag)
				{
					bool flag2 = xteamCategory == null || xteamCategory.category != rowData.Category;
					if (flag2)
					{
						xteamCategory = null;
						for (int j = 0; j < this.m_Categories.Count; j++)
						{
							bool flag3 = this.m_Categories[j].category == rowData.Category;
							if (flag3)
							{
								xteamCategory = this.m_Categories[j];
								break;
							}
						}
						bool flag4 = xteamCategory == null;
						if (flag4)
						{
							xteamCategory = new XTeamCategory(this);
							xteamCategory.category = rowData.Category;
							this.m_Categories.Add(xteamCategory);
							this.m_DicCate[xteamCategory.category] = xteamCategory;
						}
					}
					xteamCategory.expList.Add(rowData);
					this.m_DicExpCate[rowData.DNExpeditionID] = xteamCategory;
				}
			}
			this.m_Categories.Sort();
			for (int k = 0; k < this.m_Categories.Count; k++)
			{
				this.m_Categories[k].expList.Sort(new Comparison<ExpeditionTable.RowData>(XTeamCategory.SortExp));
			}
		}

		// Token: 0x0600BB97 RID: 48023 RVA: 0x002690CC File Offset: 0x002672CC
		public void RefreshAbyssStates()
		{
			this.LastestNoRankAbyssSceneID = 1073741824;
			List<int> list = ListPool<int>.Get();
			XSingleton<XSceneMgr>.singleton.GetSceneList(SceneType.SCENE_ABYSSS, list);
			for (int i = 0; i < list.Count; i++)
			{
				int num = list[i];
				bool flag = num < this.LastestNoRankAbyssSceneID && XSingleton<XStageProgress>.singleton.GetRank(num) <= 0;
				if (flag)
				{
					this.LastestNoRankAbyssSceneID = num;
				}
			}
			ListPool<int>.Release(list);
		}

		// Token: 0x0600BB98 RID: 48024 RVA: 0x00269150 File Offset: 0x00267350
		public XTeamCategory GetCategoryByExpID(int expID)
		{
			XTeamCategory xteamCategory;
			bool flag = this.m_DicExpCate.TryGetValue(expID, out xteamCategory);
			XTeamCategory result;
			if (flag)
			{
				result = xteamCategory;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600BB99 RID: 48025 RVA: 0x0026917C File Offset: 0x0026737C
		public XTeamCategory FindCategory(int category)
		{
			XTeamCategory xteamCategory;
			bool flag = this.m_DicCate.TryGetValue(category, out xteamCategory);
			XTeamCategory result;
			if (flag)
			{
				result = xteamCategory;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600BB9A RID: 48026 RVA: 0x002691A8 File Offset: 0x002673A8
		public bool IsExpOpened(ExpeditionTable.RowData rowData)
		{
			bool flag = rowData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XTeamCategory xteamCategory = this.FindCategory(rowData.Category);
				bool flag2 = xteamCategory == null;
				result = (!flag2 && xteamCategory.IsExpOpened(rowData));
			}
			return result;
		}

		// Token: 0x0600BB9B RID: 48027 RVA: 0x002691E8 File Offset: 0x002673E8
		public bool IsExpOpening(ExpeditionTable.RowData rowData)
		{
			bool flag = rowData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XTeamCategory xteamCategory = this.FindCategory(rowData.Category);
				result = (xteamCategory != null && xteamCategory.HasOpened());
			}
			return result;
		}

		// Token: 0x04004C22 RID: 19490
		public List<XTeamCategory> m_Categories = new List<XTeamCategory>();

		// Token: 0x04004C23 RID: 19491
		private Dictionary<int, XTeamCategory> m_DicCate = new Dictionary<int, XTeamCategory>();

		// Token: 0x04004C24 RID: 19492
		private Dictionary<int, XTeamCategory> m_DicExpCate = new Dictionary<int, XTeamCategory>();
	}
}
