using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamCategoryMgr
	{

		public int LastestNoRankAbyssSceneID { get; set; }

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

		public List<XTeamCategory> m_Categories = new List<XTeamCategory>();

		private Dictionary<int, XTeamCategory> m_DicCate = new Dictionary<int, XTeamCategory>();

		private Dictionary<int, XTeamCategory> m_DicExpCate = new Dictionary<int, XTeamCategory>();
	}
}
