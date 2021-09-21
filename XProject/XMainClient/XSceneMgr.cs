using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EDB RID: 3803
	public sealed class XSceneMgr : XSingleton<XSceneMgr>
	{
		// Token: 0x1700351B RID: 13595
		// (get) Token: 0x0600C94A RID: 51530 RVA: 0x002D26B8 File Offset: 0x002D08B8
		public PreloadAnimationList AnimReader
		{
			get
			{
				return this._animReader;
			}
		}

		// Token: 0x0600C94B RID: 51531 RVA: 0x002D26D0 File Offset: 0x002D08D0
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

		// Token: 0x0600C94C RID: 51532 RVA: 0x002D275C File Offset: 0x002D095C
		public override void Uninit()
		{
			this._async_loader = null;
		}

		// Token: 0x0600C94D RID: 51533 RVA: 0x002D2768 File Offset: 0x002D0968
		public SceneTable.RowData GetSceneData(uint sceneID)
		{
			return this._reader.GetBySceneID((int)sceneID);
		}

		// Token: 0x0600C94E RID: 51534 RVA: 0x002D2788 File Offset: 0x002D0988
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

		// Token: 0x0600C94F RID: 51535 RVA: 0x002D27C0 File Offset: 0x002D09C0
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

		// Token: 0x0600C950 RID: 51536 RVA: 0x002D27F4 File Offset: 0x002D09F4
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

		// Token: 0x0600C951 RID: 51537 RVA: 0x002D2854 File Offset: 0x002D0A54
		public SceneTable.RowData GetSceneData(int sceneID)
		{
			return this._reader.GetBySceneID(sceneID);
		}

		// Token: 0x0600C952 RID: 51538 RVA: 0x002D2874 File Offset: 0x002D0A74
		public bool SceneCanNavi(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			return bySceneID.SceneCanNavi;
		}

		// Token: 0x0600C953 RID: 51539 RVA: 0x002D289C File Offset: 0x002D0A9C
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

		// Token: 0x0600C954 RID: 51540 RVA: 0x002D28D0 File Offset: 0x002D0AD0
		public bool CanAutoPlay(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			return bySceneID.ShowAutoFight;
		}

		// Token: 0x0600C955 RID: 51541 RVA: 0x002D28F8 File Offset: 0x002D0AF8
		public float SpecifiedTargetLocatedRange(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			return bySceneID.SpecifiedTargetLocatedRange;
		}

		// Token: 0x0600C956 RID: 51542 RVA: 0x002D2920 File Offset: 0x002D0B20
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

		// Token: 0x0600C957 RID: 51543 RVA: 0x002D2958 File Offset: 0x002D0B58
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

		// Token: 0x0600C958 RID: 51544 RVA: 0x002D29C8 File Offset: 0x002D0BC8
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

		// Token: 0x0600C959 RID: 51545 RVA: 0x002D2A24 File Offset: 0x002D0C24
		public bool IsPVPScene()
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			return sceneType == SceneType.SCENE_ARENA || sceneType == SceneType.SCENE_PK || sceneType == SceneType.SCENE_INVFIGHT || sceneType == SceneType.SCENE_PVP || sceneType == SceneType.SKYCITY_FIGHTING || sceneType == SceneType.SCENE_RESWAR_PVP || sceneType == SceneType.SCENE_BIGMELEE_FIGHT || sceneType == SceneType.SCENE_BATTLEFIELD_FIGHT || sceneType == SceneType.SCENE_SURVIVE || sceneType == SceneType.SCENE_GMF || sceneType == SceneType.SCENE_GPR || sceneType == SceneType.SCENE_GCF || sceneType == SceneType.SCENE_LEAGUE_BATTLE || sceneType == SceneType.SCENE_HORSE_RACE || sceneType == SceneType.SCENE_CASTLE_FIGHT || sceneType == SceneType.SCENE_CASTLE_WAIT || sceneType == SceneType.SCENE_HEROBATTLE || sceneType == SceneType.SCENE_CUSTOMPK || sceneType == SceneType.SCENE_CUSTOMPKTWO || sceneType == SceneType.SCENE_PKTWO || sceneType == SceneType.SCENE_MOBA || sceneType == SceneType.SCENE_WEEKEND4V4_CRAZYBOMB || sceneType == SceneType.SCENE_WEEKEND4V4_GHOSTACTION || sceneType == SceneType.SCENE_WEEKEND4V4_HORSERACING || sceneType == SceneType.SCENE_WEEKEND4V4_LIVECHALLENGE || sceneType == SceneType.SCENE_WEEKEND4V4_DUCK || sceneType == SceneType.SCENE_WEEKEND4V4_MONSTERFIGHT;
		}

		// Token: 0x0600C95A RID: 51546 RVA: 0x002D2AD0 File Offset: 0x002D0CD0
		public bool IsPVEScene()
		{
			SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
			return sceneType == SceneType.SCENE_BATTLE || sceneType == SceneType.SCENE_BOSSRUSH || sceneType == SceneType.SCENE_CALLBACK || sceneType == SceneType.SCENE_NEST || sceneType == SceneType.SCENE_ABYSSS || sceneType == SceneType.SCENE_WORLDBOSS || sceneType == SceneType.SCENE_GUILD_BOSS || sceneType == SceneType.SCENE_TOWER || sceneType == SceneType.SCENE_DRAGON || sceneType == SceneType.SCENE_GODDESS || sceneType == SceneType.SCENE_ENDLESSABYSS || sceneType == SceneType.SCENE_DRAGON_EXP || sceneType == SceneType.SCENE_GUILD_CAMP || sceneType == SceneType.SCENE_RISK || sceneType == SceneType.SCENE_PROF_TRIALS || sceneType == SceneType.SCENE_RESWAR_PVE || sceneType == SceneType.SCENE_AIRSHIP || sceneType == SceneType.SCENE_WEEK_NEST || sceneType == SceneType.SCENE_ACTIVITY_ONE || sceneType == SceneType.SCENE_ACTIVITY_TWO || sceneType == SceneType.SCENE_ACTIVITY_THREE || sceneType == SceneType.SCENE_ABYSS_PARTY || sceneType == SceneType.SCENE_CALLBACK || sceneType == SceneType.SCENE_RIFT || sceneType == SceneType.SCENE_GUILD_WILD_HUNT || sceneType == SceneType.SCENE_BIOHELL || sceneType == SceneType.SCENE_DUCK || sceneType == SceneType.SCENE_COUPLE || sceneType == SceneType.SCENE_COMPETEDRAGON || sceneType == SceneType.SCENE_AWAKE;
		}

		// Token: 0x0600C95B RID: 51547 RVA: 0x002D2B90 File Offset: 0x002D0D90
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

		// Token: 0x0600C95C RID: 51548 RVA: 0x002D2BE0 File Offset: 0x002D0DE0
		public bool GetSceneSwitchToSelf(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			return flag && bySceneID.SwitchToSelf;
		}

		// Token: 0x0600C95D RID: 51549 RVA: 0x002D2C14 File Offset: 0x002D0E14
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

		// Token: 0x0600C95E RID: 51550 RVA: 0x002D2C54 File Offset: 0x002D0E54
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

		// Token: 0x0600C95F RID: 51551 RVA: 0x002D2C8C File Offset: 0x002D0E8C
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

		// Token: 0x0600C960 RID: 51552 RVA: 0x002D2CC4 File Offset: 0x002D0EC4
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

		// Token: 0x0600C961 RID: 51553 RVA: 0x002D2CF8 File Offset: 0x002D0EF8
		public bool GetSceneDraw(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			return flag && bySceneID.CanDrawBox;
		}

		// Token: 0x0600C962 RID: 51554 RVA: 0x002D2D2C File Offset: 0x002D0F2C
		public bool GetSceneFlyOut(uint sceneID)
		{
			SceneTable.RowData bySceneID = this._reader.GetBySceneID((int)sceneID);
			bool flag = bySceneID != null;
			return flag && bySceneID.HasFlyOut;
		}

		// Token: 0x0600C963 RID: 51555 RVA: 0x002D2D60 File Offset: 0x002D0F60
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

		// Token: 0x0600C964 RID: 51556 RVA: 0x002D2DBC File Offset: 0x002D0FBC
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

		// Token: 0x0600C965 RID: 51557 RVA: 0x002D2E0C File Offset: 0x002D100C
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

		// Token: 0x0600C966 RID: 51558 RVA: 0x002D2E4C File Offset: 0x002D104C
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

		// Token: 0x0600C967 RID: 51559 RVA: 0x002D2EA8 File Offset: 0x002D10A8
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

		// Token: 0x0600C968 RID: 51560 RVA: 0x002D2F04 File Offset: 0x002D1104
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

		// Token: 0x0600C969 RID: 51561 RVA: 0x002D2F5C File Offset: 0x002D115C
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

		// Token: 0x0600C96A RID: 51562 RVA: 0x002D2FB0 File Offset: 0x002D11B0
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

		// Token: 0x0600C96B RID: 51563 RVA: 0x002D30AC File Offset: 0x002D12AC
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

		// Token: 0x0600C96C RID: 51564 RVA: 0x002D30E0 File Offset: 0x002D12E0
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

		// Token: 0x0600C96D RID: 51565 RVA: 0x002D3128 File Offset: 0x002D1328
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

		// Token: 0x0600C96E RID: 51566 RVA: 0x002D3178 File Offset: 0x002D1378
		public XChapter.RowData GetChapter(int chapter)
		{
			return this._chapterReader.GetByChapterID(chapter);
		}

		// Token: 0x0600C96F RID: 51567 RVA: 0x002D3198 File Offset: 0x002D1398
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

		// Token: 0x0600C970 RID: 51568 RVA: 0x002D3220 File Offset: 0x002D1420
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

		// Token: 0x0600C971 RID: 51569 RVA: 0x002D324C File Offset: 0x002D144C
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

		// Token: 0x0600C972 RID: 51570 RVA: 0x002D329C File Offset: 0x002D149C
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

		// Token: 0x0600C973 RID: 51571 RVA: 0x002D32EC File Offset: 0x002D14EC
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

		// Token: 0x0600C974 RID: 51572 RVA: 0x002D33F0 File Offset: 0x002D15F0
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

		// Token: 0x0600C975 RID: 51573 RVA: 0x002D3478 File Offset: 0x002D1678
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

		// Token: 0x0600C976 RID: 51574 RVA: 0x002D34C8 File Offset: 0x002D16C8
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

		// Token: 0x0600C977 RID: 51575 RVA: 0x002D3518 File Offset: 0x002D1718
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

		// Token: 0x0600C978 RID: 51576 RVA: 0x002D3568 File Offset: 0x002D1768
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

		// Token: 0x0600C979 RID: 51577 RVA: 0x002D35A0 File Offset: 0x002D17A0
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

		// Token: 0x0600C97A RID: 51578 RVA: 0x002D35D4 File Offset: 0x002D17D4
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

		// Token: 0x0600C97B RID: 51579 RVA: 0x002D3648 File Offset: 0x002D1848
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

		// Token: 0x0600C97C RID: 51580 RVA: 0x002D36A4 File Offset: 0x002D18A4
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

		// Token: 0x0400590A RID: 22794
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x0400590B RID: 22795
		private SceneTable _reader = new SceneTable();

		// Token: 0x0400590C RID: 22796
		private PreloadAnimationList _animReader = new PreloadAnimationList();

		// Token: 0x0400590D RID: 22797
		private XChapter _chapterReader = new XChapter();

		// Token: 0x0400590E RID: 22798
		private List<int> _PVPOne = null;
	}
}
