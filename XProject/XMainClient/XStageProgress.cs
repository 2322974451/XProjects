using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DD0 RID: 3536
	internal class XStageProgress : XSingleton<XStageProgress>
	{
		// Token: 0x170033D3 RID: 13267
		// (get) Token: 0x0600C09E RID: 49310 RVA: 0x0028C900 File Offset: 0x0028AB00
		public int BaseRank
		{
			get
			{
				return this._base_rank;
			}
		}

		// Token: 0x170033D4 RID: 13268
		// (get) Token: 0x0600C09F RID: 49311 RVA: 0x0028C918 File Offset: 0x0028AB18
		// (set) Token: 0x0600C0A0 RID: 49312 RVA: 0x0028C920 File Offset: 0x0028AB20
		public int LastNormalChapter { get; set; }

		// Token: 0x170033D5 RID: 13269
		// (get) Token: 0x0600C0A1 RID: 49313 RVA: 0x0028C929 File Offset: 0x0028AB29
		// (set) Token: 0x0600C0A2 RID: 49314 RVA: 0x0028C931 File Offset: 0x0028AB31
		public int LastHardChapter { get; set; }

		// Token: 0x0600C0A3 RID: 49315 RVA: 0x0028C93C File Offset: 0x0028AB3C
		public void Init(StageInfo stageInfo)
		{
			this.StageRanks.Clear();
			this.StageBox.Clear();
			for (int i = 0; i < stageInfo.sceneID.Count; i++)
			{
				StageRankInfo stageRankInfo = new StageRankInfo();
				stageRankInfo.RankValue = stageInfo.rank[i];
				this.StageRanks.Add(stageInfo.sceneID[i], stageRankInfo);
			}
			for (int i = 0; i < stageInfo.chapterchest.Count; i++)
			{
				int key = (int)(stageInfo.chapterchest[i] >> 8);
				List<int> list = new List<int>();
				list.Add((int)(stageInfo.chapterchest[i] & 1U));
				list.Add((int)(stageInfo.chapterchest[i] & 2U));
				list.Add((int)(stageInfo.chapterchest[i] & 4U));
				this.StageBox.Add(key, list);
			}
			this.ReCalculateLastChapter();
		}

		// Token: 0x0600C0A4 RID: 49316 RVA: 0x0028CA40 File Offset: 0x0028AC40
		public bool HasChapterBoxFetched(int chapterID, int index)
		{
			bool flag = this.StageBox.ContainsKey(chapterID);
			if (flag)
			{
				bool flag2 = this.StageBox[chapterID][index] > 0;
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C0A5 RID: 49317 RVA: 0x0028CA84 File Offset: 0x0028AC84
		public void OnFetchChapterBoxSucc(int chapterID, int chestID)
		{
			bool flag = this.StageBox.ContainsKey(chapterID);
			if (flag)
			{
				this.StageBox[chapterID][chestID] = 1;
			}
			else
			{
				List<int> list = new List<int>();
				list.Add(0);
				list.Add(0);
				list.Add(0);
				this.StageBox.Add(chapterID, list);
				this.StageBox[chapterID][chestID] = 1;
			}
			bool flag2 = DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.OnFetchChapterBoxSucc();
			}
		}

		// Token: 0x0600C0A6 RID: 49318 RVA: 0x0028CB15 File Offset: 0x0028AD15
		public void OnEnterScene()
		{
			this._base_rank = this.GetRank((int)XSingleton<XScene>.singleton.SceneID);
		}

		// Token: 0x0600C0A7 RID: 49319 RVA: 0x0028CB2E File Offset: 0x0028AD2E
		protected void ReCalculateLastChapter()
		{
			this.LastNormalChapter = this._CalPlayerLastChapter(0U, ref this.LastNormalLocationChapter);
			this.LastHardChapter = this._CalPlayerLastChapter(1U, ref this.LastHardLocationChapter);
		}

		// Token: 0x0600C0A8 RID: 49320 RVA: 0x0028CB5C File Offset: 0x0028AD5C
		protected int _CalPlayerLastChapter(uint difficult, ref int lastLocationChapter)
		{
			lastLocationChapter = 0;
			int num = XSingleton<XSceneMgr>.singleton.GetChapterID(1, difficult);
			bool flag2;
			bool flag4;
			do
			{
				List<uint> list = ListPool<uint>.Get();
				XSingleton<XSceneMgr>.singleton.GetSceneListByChapter(num, list);
				bool flag = true;
				flag2 = true;
				for (int i = 0; i < list.Count; i++)
				{
					int rank = this.GetRank((int)list[i]);
					flag &= (rank > 0);
					flag2 &= (rank == -1);
				}
				ListPool<uint>.Release(list);
				bool flag3 = flag;
				if (!flag3)
				{
					goto IL_9A;
				}
				int num2 = num;
				num = XSingleton<XSceneMgr>.singleton.GetNextChapter(num2);
				flag4 = (num2 == num);
			}
			while (!flag4);
			goto IL_E1;
			IL_9A:
			bool flag5 = flag2;
			if (flag5)
			{
				XChapter.RowData chapter = XSingleton<XSceneMgr>.singleton.GetChapter(num);
				bool flag6 = chapter != null;
				if (flag6)
				{
					int preChapter = chapter.PreChapter;
					bool flag7 = preChapter != 0;
					if (flag7)
					{
						lastLocationChapter = preChapter;
					}
				}
			}
			IL_E1:
			bool flag8 = lastLocationChapter == 0;
			if (flag8)
			{
				lastLocationChapter = num;
			}
			return num;
		}

		// Token: 0x0600C0A9 RID: 49321 RVA: 0x0028CC60 File Offset: 0x0028AE60
		public int GetPlayerLastChapter(uint difficult)
		{
			bool flag = difficult == 0U;
			int result;
			if (flag)
			{
				result = this.LastNormalChapter;
			}
			else
			{
				result = this.LastHardChapter;
			}
			return result;
		}

		// Token: 0x0600C0AA RID: 49322 RVA: 0x0028CC8C File Offset: 0x0028AE8C
		public int GetPlayerLocationChapter(uint difficult)
		{
			bool flag = difficult == 0U;
			int result;
			if (flag)
			{
				result = this.LastNormalLocationChapter;
			}
			else
			{
				result = this.LastHardLocationChapter;
			}
			return result;
		}

		// Token: 0x0600C0AB RID: 49323 RVA: 0x0028CCB8 File Offset: 0x0028AEB8
		public uint GetPlayerLastSceneInChapter(int chapter)
		{
			List<uint> list = ListPool<uint>.Get();
			XSingleton<XSceneMgr>.singleton.GetSceneListByChapter(chapter, list);
			uint result = 0U;
			for (int i = 0; i < list.Count; i++)
			{
				int rank = this.GetRank((int)list[i]);
				bool flag = rank > 0;
				if (flag)
				{
					result = list[i];
				}
			}
			ListPool<uint>.Release(list);
			return result;
		}

		// Token: 0x0600C0AC RID: 49324 RVA: 0x0028CD24 File Offset: 0x0028AF24
		internal int GetRank(int sceneID)
		{
			StageRankInfo stageRankInfo = null;
			bool flag = this.StageRanks != null && this.StageRanks.TryGetValue(sceneID, out stageRankInfo);
			int result;
			if (flag)
			{
				result = stageRankInfo.Rank;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x0600C0AD RID: 49325 RVA: 0x0028CD60 File Offset: 0x0028AF60
		internal bool GetRankDetail(int sceneID, int index)
		{
			StageRankInfo stageRankInfo = null;
			bool flag = this.StageRanks != null && this.StageRanks.TryGetValue(sceneID, out stageRankInfo);
			if (flag)
			{
				switch (index)
				{
				case 0:
					return (stageRankInfo.RankValue & 1) > 0;
				case 1:
					return (stageRankInfo.RankValue & 2) > 0;
				case 2:
					return (stageRankInfo.RankValue & 4) > 0;
				}
			}
			return false;
		}

		// Token: 0x0600C0AE RID: 49326 RVA: 0x0028CDD4 File Offset: 0x0028AFD4
		internal void SetRank(int sceneID, int rank)
		{
			StageRankInfo stageRankInfo;
			bool flag = this.StageRanks.TryGetValue(sceneID, out stageRankInfo);
			if (flag)
			{
				stageRankInfo.RankValue = Math.Max(stageRankInfo.RankValue, rank);
			}
			else
			{
				stageRankInfo = new StageRankInfo();
				stageRankInfo.RankValue = rank;
				this.StageRanks.Add(sceneID, stageRankInfo);
			}
			this.ReCalculateLastChapter();
		}

		// Token: 0x0400506E RID: 20590
		public Dictionary<int, StageRankInfo> StageRanks = new Dictionary<int, StageRankInfo>();

		// Token: 0x0400506F RID: 20591
		public Dictionary<int, List<int>> StageBox = new Dictionary<int, List<int>>();

		// Token: 0x04005070 RID: 20592
		private int _base_rank = -1;

		// Token: 0x04005073 RID: 20595
		public int LastNormalLocationChapter = 0;

		// Token: 0x04005074 RID: 20596
		public int LastHardLocationChapter = 0;
	}
}
