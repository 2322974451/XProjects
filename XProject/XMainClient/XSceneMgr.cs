using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	public sealed class XSceneMgr : XSingleton<XSceneMgr>
	{

		public PreloadAnimationList AnimReader
		{
			get
			{
				return this._animReader;
			}
		}

		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/ChapterList", this._chapterReader, false);
				this._async_loader.AddTask("Table/SceneList", this._reader, false);
				this._async_loader.AddTask("Table/PreloadAnimationList", this._animReader, false);
				this._async_loader.Execute(null);
			}
			return this._async_loader.IsDone;
		}

		public override void Uninit()
		{
			this._async_loader = null;
		}

		public SceneTable.RowData GetSceneData(uint sceneID)
		{
			return this._reader.GetBySceneID((int)sceneID);
		}

		public string GetScenePath(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			string result;
			if (flag)
			{
				result = bySceneID.ScenePath;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public uint GetDriveID(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				result = bySceneID.StoryDriver;
			}
			return result;
		}

		public void GetSceneList(SceneType type, List<int> lst)
		{
			for (int i = 0; i < this._reader.Table.Length; i++)
			{
				bool flag = (SceneType)this._reader.Table[i].type == type;
				if (flag)
				{
					lst.Add(this._reader.Table[i].id);
				}
			}
		}

		public SceneTable.RowData GetSceneData(int sceneID)
		{
			return this._reader.GetBySceneID(sceneID);
		}

		public bool SceneCanNavi(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			return bySceneID.SceneCanNavi;
		}

		public SceneType GetSceneType(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			SceneType result;
			if (flag)
			{
				result = (SceneType)bySceneID.type;
			}
			else
			{
				result = SceneType.SCENE_HALL;
			}
			return result;
		}

		public bool CanAutoPlay(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			return bySceneID.ShowAutoFight;
		}

		public float SpecifiedTargetLocatedRange(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			return bySceneID.SpecifiedTargetLocatedRange;
		}

		public string GetSceneBGM(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			string result;
			if (flag)
			{
				result = bySceneID.BGM;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public string GetSceneLoadingTips(bool forward, uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null && bySceneID.LoadingTips != null;
			if (flag)
			{
				bool flag2 = forward && bySceneID.LoadingTips.Length != 0;
				if (flag2)
				{
					return bySceneID.LoadingTips[0];
				}
				bool flag3 = bySceneID.LoadingTips.Length > 1;
				if (flag3)
				{
					return bySceneID.LoadingTips[1];
				}
			}
			return null;
		}

		public string GetSceneLoadingPic(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID.LoadingPic != null && bySceneID.LoadingPic.Length != 0;
			string result;
			if (flag)
			{
				result = bySceneID.LoadingPic[XSingleton<XCommon>.singleton.RandomInt(0, bySceneID.LoadingPic.Length)];
			}
			else
			{
				result = "";
			}
			return result;
		}

		public bool IsPVPScene()
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			return sceneType == SceneType.SCENE_ARENA || sceneType == SceneType.SCENE_PK || sceneType == SceneType.SCENE_INVFIGHT || sceneType == SceneType.SCENE_PVP || sceneType == SceneType.SKYCITY_FIGHTING || sceneType == SceneType.SCENE_RESWAR_PVP || sceneType == SceneType.SCENE_BIGMELEE_FIGHT || sceneType == SceneType.SCENE_BATTLEFIELD_FIGHT || sceneType == SceneType.SCENE_SURVIVE || sceneType == SceneType.SCENE_GMF || sceneType == SceneType.SCENE_GPR || sceneType == SceneType.SCENE_GCF || sceneType == SceneType.SCENE_LEAGUE_BATTLE || sceneType == SceneType.SCENE_HORSE_RACE || sceneType == SceneType.SCENE_CASTLE_FIGHT || sceneType == SceneType.SCENE_CASTLE_WAIT || sceneType == SceneType.SCENE_HEROBATTLE || sceneType == SceneType.SCENE_CUSTOMPK || sceneType == SceneType.SCENE_CUSTOMPKTWO || sceneType == SceneType.SCENE_PKTWO || sceneType == SceneType.SCENE_MOBA || sceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || sceneType == SceneType.SCENE_WEEKEND4V4_GHOSTACTION || sceneType == SceneType.SCENE_WEEKEND4V4_HORSERACING || sceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE || sceneType == SceneType.SCENE_WEEKEND4V4_DUCK || sceneType == SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT;
		}

		public bool IsPVEScene()
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			return sceneType == SceneType.SCENE_BATTLE || sceneType == SceneType.SCENE_BOSSRUSH || sceneType == SceneType.SCENE_CALLBACK || sceneType == SceneType.SCENE_NEST || sceneType == SceneType.SCENE_ABYSSS || sceneType == SceneType.SCENE_WORLDBOSS || sceneType == SceneType.SCENE_GUILD_BOSS || sceneType == SceneType.SCENE_TOWER || sceneType == SceneType.SCENE_DRAGON || sceneType == SceneType.SCENE_GODDESS || sceneType == SceneType.SCENE_ENDLESSABYSS || sceneType == SceneType.SCENE_DRAGON_EXP || sceneType == SceneType.SCENE_GUILD_CAMP || sceneType == SceneType.SCENE_RISK || sceneType == SceneType.SCENE_PROF_TRIALS || sceneType == SceneType.SCENE_RESWAR_PVE || sceneType == SceneType.SCENE_AIRSHIP || sceneType == SceneType.SCENE_WEEK_NEST || sceneType == SceneType.SCENE_ACTIVITY_ONE || sceneType == SceneType.SCENE_ACTIVITY_TWO || sceneType == SceneType.SCENE_ACTIVITY_THREE || sceneType == SceneType.SCENE_ABYSS_PARTY || sceneType == SceneType.SCENE_CALLBACK || sceneType == SceneType.SCENE_RIFT || sceneType == SceneType.SCENE_GUILD_WILD_HUNT || sceneType == SceneType.SCENE_BIOHELL || sceneType == SceneType.SCENE_DUCK || sceneType == SceneType.SCENE_COUPLE || sceneType == SceneType.SCENE_COMPETEDRAGON || sceneType == SceneType.SCENE_AWAKE;
		}

		public bool Is1V1Scene()
		{
			bool flag = this._PVPOne == null;
			if (flag)
			{
				this._PVPOne = XSingleton<XGlobalConfig>.singleton.GetIntList("PVPOne");
			}
			int sceneID = (int)XSingleton<XScene>.singleton.SceneID;
			return this._PVPOne.Contains(sceneID);
		}

		public bool GetSceneSwitchToSelf(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			return flag && bySceneID.SwitchToSelf;
		}

		public float GetSceneDelayTransfer(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			float result;
			if (flag)
			{
				result = Mathf.Min(0.5f, bySceneID.DelayTransfer);
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		public string GetUnitySceneFile(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			string result;
			if (flag)
			{
				result = bySceneID.sceneFile;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public string GetSceneConfigFile(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			string result;
			if (flag)
			{
				result = bySceneID.configFile;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public int GetSceneSyncMode(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			int result;
			if (flag)
			{
				result = (int)bySceneID.syncMode;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public bool GetSceneDraw(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			return flag && bySceneID.CanDrawBox;
		}

		public bool GetSceneFlyOut(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			return flag && bySceneID.HasFlyOut;
		}

		public Vector3 GetSceneStartPos(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			Vector3 result;
			if (flag)
			{
				result = new Vector3(bySceneID.StartPos[0, 0], bySceneID.StartPos[0, 1], bySceneID.StartPos[0, 2]);
			}
			else
			{
				result = Vector3.zero;
			}
			return result;
		}

		public Quaternion GetSceneStartRot(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			Quaternion result;
			if (flag)
			{
				result = Quaternion.Euler(bySceneID.StartRot[0], bySceneID.StartRot[1], bySceneID.StartRot[2]);
			}
			else
			{
				result = Quaternion.identity;
			}
			return result;
		}

		public uint GetGroupByScene(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null && bySceneID.DayLimitGroupID > 0U;
			uint result;
			if (flag)
			{
				result = bySceneID.DayLimitGroupID;
			}
			else
			{
				result = sceneID;
			}
			return result;
		}

		public void GetSceneListByChapter(int chapter, List<uint> sceneList)
		{
			int i = 0;
			int num = this._reader.Table.Length;
			while (i < num)
			{
				SceneTable.RowData rowData = this._reader.Table[i];
				bool flag = (int)rowData.Chapter == chapter;
				if (flag)
				{
					sceneList.Add((uint)rowData.id);
				}
				i++;
			}
		}

		public void GetSceneListByType(XChapterType t, List<uint> ret)
		{
			int i = 0;
			int num = this._reader.Table.Length;
			while (i < num)
			{
				SceneTable.RowData rowData = this._reader.Table[i];
				bool flag = (XChapterType)rowData.type == t;
				if (flag)
				{
					ret.Add((uint)rowData.id);
				}
				i++;
			}
		}

		public AsyncSceneAnimationRequest ShowSceneLoadAnim(SceneType sceneType)
		{
			bool flag = SceneType.SCENE_PK == sceneType || SceneType.SCENE_INVFIGHT == sceneType;
			AsyncSceneAnimationRequest result;
			if (flag)
			{
				DlgBase<XPkLoadingView, XPkLoadingBehaviour>.singleton.ShowPkLoading(sceneType);
				result = new AsyncSceneAnimationRequest();
			}
			else
			{
				bool flag2 = SceneType.SCENE_PKTWO == sceneType;
				if (flag2)
				{
					DlgBase<XMultiPkLoadingView, XMultiPkLoadingBehaviour>.singleton.ShowPkLoading();
					result = new AsyncSceneAnimationRequest();
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		public void UpdateSceneLoadAnim(AsyncSceneAnimationRequest asar, SceneType sceneType)
		{
			bool flag = sceneType == SceneType.SCENE_LEAGUE_BATTLE;
			if (flag)
			{
				asar.IsDone = DlgBase<XTeamLeagueLoadingView, XTeamLeagueLoadingBehaviour>.singleton.IsLoadingOver;
			}
			else
			{
				bool flag2 = sceneType == SceneType.SCENE_PKTWO;
				if (flag2)
				{
					asar.IsDone = DlgBase<XMultiPkLoadingView, XMultiPkLoadingBehaviour>.singleton.IsLoadingOver;
				}
				else
				{
					asar.IsDone = DlgBase<XPkLoadingView, XPkLoadingBehaviour>.singleton.IsLoadingOver;
				}
			}
		}

		public int GetScenePreDifficultScene(int sceneID, int index)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID(sceneID);
			XChapter.RowData byChapterID = this._chapterReader.GetByChapterID((int)bySceneID.Chapter);
			bool flag = byChapterID.Difficult[1] == 0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = byChapterID.Difficult[0];
				XChapter.RowData[] table = this._chapterReader.Table;
				for (int i = 0; i < table.Length; i++)
				{
					bool flag2 = table[i].Difficult[0] == num && table[i].Difficult[1] == byChapterID.Difficult[1] - 1;
					if (flag2)
					{
						List<uint> list = ListPool<uint>.Get();
						this.GetSceneListByChapter(table[i].ChapterID, list);
						list.Sort();
						int result2 = (int)list[index];
						ListPool<uint>.Release(list);
						return result2;
					}
				}
				result = 0;
			}
			return result;
		}

		public int GetSceneChapter(int sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID(sceneID);
			bool flag = bySceneID != null;
			int result;
			if (flag)
			{
				result = (int)bySceneID.Chapter;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public int GetSceneDifficult(int sceneID)
		{
			int sceneChapter = this.GetSceneChapter(sceneID);
			bool flag = sceneChapter > 0;
			if (flag)
			{
				XChapter.RowData chapter = this.GetChapter(sceneChapter);
				bool flag2 = chapter != null;
				if (flag2)
				{
					return chapter.Difficult[1];
				}
			}
			return -1;
		}

		public void GetChapterList(XChapterType t, List<int> lst)
		{
			XChapter.RowData[] table = this._chapterReader.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].Type == (int)t;
				if (flag)
				{
					lst.Add(table[i].ChapterID);
				}
			}
		}

		public XChapter.RowData GetChapter(int chapter)
		{
			return this._chapterReader.GetByChapterID(chapter);
		}

		public int GetChapterID(int chapter, uint difficult)
		{
			int num = this._chapterReader.GetByChapterID(chapter).Difficult[0];
			XChapter.RowData[] table = this._chapterReader.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].Difficult[0] == num && (long)table[i].Difficult[1] == (long)((ulong)difficult);
				if (flag)
				{
					return table[i].ChapterID;
				}
			}
			return 0;
		}

		private static int SortChapterCompare(XChapter.RowData data1, XChapter.RowData data2)
		{
			bool flag = data1.ChapterID > data2.ChapterID;
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public int GetNextChapter(int chapter)
		{
			XChapter.RowData[] table = this._chapterReader.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].PreChapter == chapter;
				if (flag)
				{
					return table[i].ChapterID;
				}
			}
			return chapter;
		}

		public int GetPreviousChapter(int chapter)
		{
			XChapter.RowData[] table = this._chapterReader.Table;
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].ChapterID == chapter;
				if (flag)
				{
					return table[i].PreChapter;
				}
			}
			return 0;
		}

		public void PlaceDynamicScene(uint sceneID)
		{
			GameObject gameObject = GameObject.Find("DynamicScene");
			bool flag = gameObject != null;
			if (flag)
			{
				for (int i = 0; i < gameObject.transform.childCount; i++)
				{
					gameObject.transform.GetChild(i).gameObject.SetActive(false);
				}
				SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
				bool flag2 = bySceneID != null;
				if (flag2)
				{
					bool flag3 = bySceneID.DynamicScene != null && bySceneID.DynamicScene.Length > 0;
					if (flag3)
					{
						Transform transform = gameObject.transform.FindChild(bySceneID.DynamicScene);
						bool flag4 = transform != null;
						if (flag4)
						{
							transform.gameObject.SetActive(true);
							Component component = transform.GetComponent("XSceneOperation");
							bool flag5 = component != null;
							if (flag5)
							{
								IXSceneOperation ixsceneOperation = component as IXSceneOperation;
								ixsceneOperation.SetLightMap();
							}
						}
					}
				}
			}
		}

		public void PlaceDynamicScene(string name)
		{
			GameObject gameObject = GameObject.Find("DynamicScene");
			bool flag = gameObject != null;
			if (flag)
			{
				for (int i = 0; i < gameObject.transform.childCount; i++)
				{
					gameObject.transform.GetChild(i).gameObject.SetActive(false);
				}
				Transform transform = gameObject.transform.FindChild(name);
				bool flag2 = transform != null;
				if (flag2)
				{
					transform.gameObject.SetActive(true);
				}
			}
		}

		public string GetSceneDynamicPrefix(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null && bySceneID.DynamicScene != null;
			string result;
			if (flag)
			{
				result = "DynamicScene/" + bySceneID.DynamicScene + "/";
			}
			else
			{
				result = "";
			}
			return result;
		}

		public int GetFirstStarRewardCount(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			if (flag)
			{
				bool flag2 = bySceneID.FirstSSS.Count >= 1;
				if (flag2)
				{
					return (int)bySceneID.FirstSSS[0, 1];
				}
			}
			return -1;
		}

		public short[] GetSceneMiniMapSize(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			if (flag)
			{
				bool flag2 = bySceneID.MiniMapSize != null && bySceneID.MiniMapSize.Length >= 2;
				if (flag2)
				{
					return bySceneID.MiniMapSize;
				}
			}
			return null;
		}

		public string GetSceneMiniMap(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			string result;
			if (flag)
			{
				result = bySceneID.MiniMap;
			}
			else
			{
				result = "";
			}
			return result;
		}

		public int GetSceneMiniMapRotation(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			int result;
			if (flag)
			{
				result = (int)bySceneID.MiniMapRotation;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public bool GetSceneStaticMiniMapCenter(uint sceneID, out Vector3 pos)
		{
			pos = Vector3.zero;
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID == null || bySceneID.StaticMiniMapCenter == null || bySceneID.StaticMiniMapCenter.Length != 3;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				pos = new Vector3(bySceneID.StaticMiniMapCenter[0], bySceneID.StaticMiniMapCenter[1], bySceneID.StaticMiniMapCenter[2]);
				result = true;
			}
			return result;
		}

		public Vector2 GetSceneMiniMapOutSize(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID == null || bySceneID.MiniMapOutSize == null || bySceneID.MiniMapOutSize.Length != 2;
			Vector2 result;
			if (flag)
			{
				result = Vector2.one;
			}
			else
			{
				result = new Vector2(bySceneID.MiniMapOutSize[0], bySceneID.MiniMapOutSize[1]);
			}
			return result;
		}

		public int GetSceneAutoLeaveTime(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			int result;
			if (flag)
			{
				result = (int)bySceneID.AutoReturn;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		private XTableAsyncLoader _async_loader = null;

		private SceneTable _reader = new SceneTable();

		private PreloadAnimationList _animReader = new PreloadAnimationList();

		private XChapter _chapterReader = new XChapter();

		private List<int> _PVPOne = null;
	}
}
