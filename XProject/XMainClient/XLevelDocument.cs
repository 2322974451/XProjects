using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.Battle;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009AF RID: 2479
	internal class XLevelDocument : XDocComponent
	{
		// Token: 0x17002D44 RID: 11588
		// (get) Token: 0x0600961E RID: 38430 RVA: 0x00169B60 File Offset: 0x00167D60
		public override uint ID
		{
			get
			{
				return XLevelDocument.uuID;
			}
		}

		// Token: 0x0600961F RID: 38431 RVA: 0x00169B78 File Offset: 0x00167D78
		public XLevelDocument()
		{
			this._showRandomTaskCb = new XTimerMgr.ElapsedEventHandler(this.ShowRandomTask);
		}

		// Token: 0x06009620 RID: 38432 RVA: 0x00169BE7 File Offset: 0x00167DE7
		public static void Execute(OnLoadedCallback callback = null)
		{
			XLevelDocument.AsyncLoader.AddTask("Table/randomtask", XLevelDocument._randomtask, false);
			XLevelDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009621 RID: 38433 RVA: 0x00169C0C File Offset: 0x00167E0C
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.SceneDayEnter.Clear();
			for (int i = 0; i < XBagDocument.DropTable.Table.Length; i++)
			{
				int dropID = XBagDocument.DropTable.Table[i].DropID;
				int itemID = XBagDocument.DropTable.Table[i].ItemID;
				int itemCount = XBagDocument.DropTable.Table[i].ItemCount;
				XDropData item = default(XDropData);
				item.itemID = itemID;
				item.count = itemCount;
				bool flag = this.DropData.ContainsKey(dropID);
				if (flag)
				{
					this.DropData[dropID].Add(item);
				}
				else
				{
					List<XDropData> value = new List<XDropData>();
					this.DropData.Add(dropID, value);
					this.DropData[dropID].Add(item);
				}
			}
		}

		// Token: 0x06009622 RID: 38434 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06009623 RID: 38435 RVA: 0x00169CF8 File Offset: 0x00167EF8
		public void UpdateSceneDayTime(QuerySceneDayCountRes data)
		{
			for (int i = 0; i < data.sceneid.Count; i++)
			{
				bool flag = this.SceneDayEnter.ContainsKey(data.sceneid[i]);
				if (flag)
				{
					this.SceneDayEnter[data.sceneid[i]] = data.scenecout[i];
				}
				else
				{
					this.SceneDayEnter.Add(data.sceneid[i], data.scenecout[i]);
				}
				bool flag2 = this.SceneBuyCount.ContainsKey(data.sceneid[i]);
				if (flag2)
				{
					this.SceneBuyCount[data.sceneid[i]] = data.scenebuycount[i];
				}
				else
				{
					this.SceneBuyCount.Add(data.sceneid[i], data.scenebuycount[i]);
				}
			}
			this.SceneBox.Clear();
			this.SceneBox.AddRange(data.chestOpenedScene);
			bool flag3 = DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.UpdateSceneEnterTime();
				DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.UpdateSceneBox();
			}
			this.RefreshRedPoint();
		}

		// Token: 0x06009624 RID: 38436 RVA: 0x00169E48 File Offset: 0x00168048
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = SceneType.SCENE_HALL == XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID);
			if (flag)
			{
				RpcC2G_QuerySceneDayCount rpcC2G_QuerySceneDayCount = new RpcC2G_QuerySceneDayCount();
				List<int> list = ListPool<int>.Get();
				XSingleton<XSceneMgr>.singleton.GetChapterList(XChapterType.SCENE_BATTLE, list);
				for (int i = 0; i < list.Count; i++)
				{
					XChapter.RowData chapter = XSingleton<XSceneMgr>.singleton.GetChapter(list[i]);
					List<uint> list2 = ListPool<uint>.Get();
					XSingleton<XSceneMgr>.singleton.GetSceneListByChapter(list[i], list2);
					rpcC2G_QuerySceneDayCount.oArg.type = 1U;
					for (int j = 0; j < list2.Count; j++)
					{
						rpcC2G_QuerySceneDayCount.oArg.groupid.Add(list2[j]);
					}
					ListPool<uint>.Release(list2);
				}
				ListPool<int>.Release(list);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_QuerySceneDayCount);
			}
		}

		// Token: 0x06009625 RID: 38437 RVA: 0x00169F40 File Offset: 0x00168140
		public static string GetDifficulty(int _PlayerPPT, int _RecommendPower)
		{
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("SceneDifficult").Split(XGlobalConfig.ListSeparator);
			float num = (float)_PlayerPPT / (float)_RecommendPower;
			float[] array2 = new float[]
			{
				float.Parse(array[0]),
				float.Parse(array[1]),
				float.Parse(array[2])
			};
			bool flag = num >= array2[0];
			string @string;
			if (flag)
			{
				@string = XStringDefineProxy.GetString("EASY");
			}
			else
			{
				bool flag2 = num >= array2[1] && num < array2[0];
				if (flag2)
				{
					@string = XStringDefineProxy.GetString("NORMAL");
				}
				else
				{
					bool flag3 = num >= array2[2] && num < array2[1];
					if (flag3)
					{
						@string = XStringDefineProxy.GetString("HARD");
					}
					else
					{
						@string = XStringDefineProxy.GetString("VERYHARD");
					}
				}
			}
			return @string;
		}

		// Token: 0x06009626 RID: 38438 RVA: 0x0016A020 File Offset: 0x00168220
		public double GetExpAddition(int level)
		{
			PlayerLevelTable.RowData byLevel = XSingleton<XEntityMgr>.singleton.LevelTable.GetByLevel(level);
			bool flag = byLevel != null;
			double result;
			if (flag)
			{
				result = byLevel.ExpAddition;
			}
			else
			{
				result = 1.0;
			}
			return result;
		}

		// Token: 0x06009627 RID: 38439 RVA: 0x0016A05D File Offset: 0x0016825D
		public void RefreshRedPoint()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Level_Normal, false);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Level_Elite, true);
		}

		// Token: 0x06009628 RID: 38440 RVA: 0x0016A07C File Offset: 0x0016827C
		public void OnFetchSceneChestSucc(uint sceneID)
		{
			this.SceneBox.Add(sceneID);
			bool flag = DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.OnFetchSceneChestSucc();
			}
			this.RefreshRedPoint();
		}

		// Token: 0x06009629 RID: 38441 RVA: 0x0016A0BC File Offset: 0x001682BC
		public List<XDropData> GetDropData(int dropID)
		{
			bool flag = this.DropData.ContainsKey(dropID);
			List<XDropData> result;
			if (flag)
			{
				result = this.DropData[dropID];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600962A RID: 38442 RVA: 0x0016A0EF File Offset: 0x001682EF
		public void AutoGoBattle(int sceneid, int chapterid, uint diff)
		{
			DlgBase<ItemAccessDlg, ItemAccessDlgBehaviour>.singleton.SetVisible(false, true);
			DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.SetAutoSelectScene(sceneid, chapterid, diff);
			DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.FadeShow();
		}

		// Token: 0x0600962B RID: 38443 RVA: 0x0016A118 File Offset: 0x00168318
		public void ResetScene(int sceneid)
		{
			this.m_reqSceneId = sceneid;
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)sceneid);
			RpcC2G_StageCountReset rpcC2G_StageCountReset = new RpcC2G_StageCountReset();
			rpcC2G_StageCountReset.oArg.groupid = ((sceneData.DayLimitGroupID > 0U) ? sceneData.DayLimitGroupID : ((uint)sceneid));
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_StageCountReset);
			this.m_bIsResetSceneMesBack = false;
		}

		// Token: 0x0600962C RID: 38444 RVA: 0x0016A170 File Offset: 0x00168370
		public void OnResetSceneSucc(uint sceneid, StageCountResetRes oRes)
		{
			this.m_bIsResetSceneMesBack = true;
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					bool flag3 = this.SceneDayEnter.ContainsKey(sceneid);
					if (flag3)
					{
						this.SceneDayEnter[sceneid] = 0U;
					}
					bool flag4 = this.SceneBuyCount.ContainsKey(sceneid);
					if (flag4)
					{
						Dictionary<uint, uint> sceneBuyCount = this.SceneBuyCount;
						sceneBuyCount[sceneid] += 1U;
					}
					bool flag5 = DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsVisible();
					if (flag5)
					{
						DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.OnResetSucc();
					}
				}
			}
		}

		// Token: 0x0600962D RID: 38445 RVA: 0x0016A250 File Offset: 0x00168450
		public bool HasChapterRedpoint(int chapterid)
		{
			XChapter.RowData chapter = XSingleton<XSceneMgr>.singleton.GetChapter(chapterid);
			List<uint> list = ListPool<uint>.Get();
			XSingleton<XSceneMgr>.singleton.GetSceneListByChapter(chapterid, list);
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				uint num2 = list[i];
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(list[i]);
				int num3 = XSingleton<XStageProgress>.singleton.GetRank((int)num2);
				bool flag = num3 == -1;
				if (flag)
				{
					num3 = 0;
				}
				num += num3;
				bool flag2 = sceneData.SceneChest != 0;
				if (flag2)
				{
					bool flag3 = num3 > 0 && !this.SceneBox.Contains(num2);
					if (flag3)
					{
						ListPool<uint>.Release(list);
						return true;
					}
				}
			}
			ListPool<uint>.Release(list);
			for (int j = 0; j < chapter.Drop.Count; j++)
			{
				int num4 = chapter.Drop[j, 0];
				bool flag4 = num >= num4;
				if (flag4)
				{
					bool flag5 = !XSingleton<XStageProgress>.singleton.HasChapterBoxFetched(chapterid, j);
					if (flag5)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600962E RID: 38446 RVA: 0x0016A388 File Offset: 0x00168588
		public bool HasDifficultAllChapterRedpoint(int difficult)
		{
			List<int> list = ListPool<int>.Get();
			XSingleton<XSceneMgr>.singleton.GetChapterList(XChapterType.SCENE_BATTLE, list);
			for (int i = 0; i < list.Count; i++)
			{
				XChapter.RowData chapter = XSingleton<XSceneMgr>.singleton.GetChapter(list[i]);
				bool flag = chapter.Difficult[1] == difficult;
				if (flag)
				{
					bool flag2 = this.HasChapterRedpoint(list[i]);
					bool flag3 = flag2;
					if (flag3)
					{
						ListPool<int>.Release(list);
						return true;
					}
				}
			}
			ListPool<int>.Release(list);
			return false;
		}

		// Token: 0x0600962F RID: 38447 RVA: 0x0016A41C File Offset: 0x0016861C
		public int GetUnFinishedPreSceneID(SceneTable.RowData data)
		{
			bool flag = data != null && data.PreScene != null;
			if (flag)
			{
				for (int i = 0; i < data.PreScene.Length; i++)
				{
					bool flag2 = data.PreScene[i] != 0;
					if (flag2)
					{
						int rank = XSingleton<XStageProgress>.singleton.GetRank(data.PreScene[i]);
						bool flag3 = rank <= 0;
						if (flag3)
						{
							return data.PreScene[i];
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x06009630 RID: 38448 RVA: 0x0016A4A0 File Offset: 0x001686A0
		public SceneRefuseReason CanLevelOpen(uint sceneID)
		{
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneID);
			bool flag = sceneData == null;
			SceneRefuseReason result;
			if (flag)
			{
				result = SceneRefuseReason.Admit;
			}
			else
			{
				int preTask = (int)sceneData.PreTask;
				bool flag2 = preTask != 0;
				if (flag2)
				{
					XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
					bool flag3 = !specificDocument.TaskRecord.IsTaskFinished((uint)preTask);
					if (flag3)
					{
						return SceneRefuseReason.PreTask_Notfinish;
					}
				}
				int[] preScene = sceneData.PreScene;
				bool flag4 = preScene != null && preScene.Length != 0;
				if (flag4)
				{
					bool flag5 = this.GetUnFinishedPreSceneID(sceneData) > 0;
					if (flag5)
					{
						return SceneRefuseReason.PreScene_Notfinish;
					}
				}
				bool flag6 = (uint)sceneData.RequiredLevel > XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				if (flag6)
				{
					result = SceneRefuseReason.Level_NotEnough;
				}
				else
				{
					bool flag7 = 1 == XSingleton<XSceneMgr>.singleton.GetSceneDifficult((int)sceneID);
					if (flag7)
					{
						uint num = sceneData.DayLimitGroupID;
						bool flag8 = num == 0U;
						if (flag8)
						{
							num = sceneID;
						}
						uint num2 = 0U;
						bool flag9 = this.SceneDayEnter.TryGetValue(num, out num2);
						if (flag9)
						{
							bool flag10 = num2 == 0U;
							if (flag10)
							{
								return SceneRefuseReason.ReachLimitTimes;
							}
						}
					}
					result = SceneRefuseReason.Admit;
				}
			}
			return result;
		}

		// Token: 0x06009631 RID: 38449 RVA: 0x0016A5BA File Offset: 0x001687BA
		public void OnTaskRandomTask(int rtask)
		{
			XSingleton<XTimerMgr>.singleton.SetTimer(1f, this._showRandomTaskCb, rtask);
		}

		// Token: 0x06009632 RID: 38450 RVA: 0x0016A5DC File Offset: 0x001687DC
		public override void PostUpdate(float fDeltaT)
		{
			base.PostUpdate(fDeltaT);
			bool isPlaying = XSingleton<XCutScene>.singleton.IsPlaying;
			if (!isPlaying)
			{
				bool flag = this._rtask > 0;
				if (flag)
				{
					DlgBase<ChallengeDlg, ChallengeDlgBehaviour>.singleton.ShowRandomTask(this._rtask);
					this._rtask = 0;
				}
			}
		}

		// Token: 0x06009633 RID: 38451 RVA: 0x0016A62C File Offset: 0x0016882C
		protected void ShowRandomTask(object o)
		{
			int rtask = (int)o;
			this._rtask = rtask;
		}

		// Token: 0x06009634 RID: 38452 RVA: 0x0016A648 File Offset: 0x00168848
		public RandomTaskTable.RowData GetRandomTaskData(int rtask)
		{
			return XLevelDocument._randomtask.GetByTaskID(rtask);
		}

		// Token: 0x06009635 RID: 38453 RVA: 0x0016A668 File Offset: 0x00168868
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = !this.m_bIsResetSceneMesBack;
			if (flag)
			{
				this.ResetScene(this.m_reqSceneId);
			}
		}

		// Token: 0x06009636 RID: 38454 RVA: 0x0016A690 File Offset: 0x00168890
		public BossRushTable.RowData GetBossRushConfig(uint sceneID, uint index)
		{
			return null;
		}

		// Token: 0x06009637 RID: 38455 RVA: 0x0016A6A4 File Offset: 0x001688A4
		public uint GetBossRushReward(uint sceneID, int killcount)
		{
			return 0U;
		}

		// Token: 0x04003308 RID: 13064
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XLevelDocument");

		// Token: 0x04003309 RID: 13065
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x0400330A RID: 13066
		private static RandomTaskTable _randomtask = new RandomTaskTable();

		// Token: 0x0400330B RID: 13067
		public Dictionary<uint, uint> SceneDayEnter = new Dictionary<uint, uint>();

		// Token: 0x0400330C RID: 13068
		public Dictionary<uint, uint> SceneBuyCount = new Dictionary<uint, uint>();

		// Token: 0x0400330D RID: 13069
		public Dictionary<int, List<XDropData>> DropData = new Dictionary<int, List<XDropData>>();

		// Token: 0x0400330E RID: 13070
		public List<uint> SceneBox = new List<uint>();

		// Token: 0x0400330F RID: 13071
		private int _rtask = 0;

		// Token: 0x04003310 RID: 13072
		private XTimerMgr.ElapsedEventHandler _showRandomTaskCb = null;

		// Token: 0x04003311 RID: 13073
		private bool m_bIsResetSceneMesBack = true;

		// Token: 0x04003312 RID: 13074
		private int m_reqSceneId = 0;
	}
}
