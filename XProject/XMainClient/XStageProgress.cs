using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XStageProgress : XSingleton<XStageProgress>
	{

		public int BaseRank
		{
			get
			{
				return this._base_rank;
			}
		}

		public int LastNormalChapter { get; set; }

		public int LastHardChapter { get; set; }

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

		public void OnEnterScene()
		{
			this._base_rank = this.GetRank((int)XSingleton<XScene>.singleton.SceneID);
		}

		protected void ReCalculateLastChapter()
		{
			this.LastNormalChapter = this._CalPlayerLastChapter(0U, ref this.LastNormalLocationChapter);
			this.LastHardChapter = this._CalPlayerLastChapter(1U, ref this.LastHardLocationChapter);
		}

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

		public Dictionary<int, StageRankInfo> StageRanks = new Dictionary<int, StageRankInfo>();

		public Dictionary<int, List<int>> StageBox = new Dictionary<int, List<int>>();

		private int _base_rank = -1;

		public int LastNormalLocationChapter = 0;

		public int LastHardLocationChapter = 0;
	}
}
