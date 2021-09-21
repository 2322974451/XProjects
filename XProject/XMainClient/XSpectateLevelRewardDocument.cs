using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009DC RID: 2524
	internal class XSpectateLevelRewardDocument : XDocComponent
	{
		// Token: 0x17002DEB RID: 11755
		// (get) Token: 0x060099DD RID: 39389 RVA: 0x00182CB8 File Offset: 0x00180EB8
		public override uint ID
		{
			get
			{
				return XSpectateLevelRewardDocument.uuID;
			}
		}

		// Token: 0x060099DE RID: 39390 RVA: 0x00182CCF File Offset: 0x00180ECF
		public static void Execute(OnLoadedCallback callback = null)
		{
			XSpectateLevelRewardDocument.AsyncLoader.AddTask("Table/SpectateLevelRewardConfig", XSpectateLevelRewardDocument._levelRewardConfig, false);
			XSpectateLevelRewardDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060099DF RID: 39391 RVA: 0x00182CF4 File Offset: 0x00180EF4
		public bool InitData()
		{
			this.DamageSum = 0.0;
			for (int i = 0; i < this.DataList.Count; i++)
			{
				this.DamageSum += this.DataList[i].damageall;
			}
			int key = XFastEnumIntEqualityComparer<SceneType>.ToInt(XSingleton<XScene>.singleton.SceneType);
			SpectateLevelRewardConfig.RowData bySceneType = XSpectateLevelRewardDocument._levelRewardConfig.GetBySceneType(key);
			bool flag = bySceneType == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("SpectateLevelRewardConfig can't find by sceneType = ", key.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				result = false;
			}
			else
			{
				this.DataType = bySceneType.DataConfig;
				this.SetWidth();
				result = true;
			}
			return result;
		}

		// Token: 0x060099E0 RID: 39392 RVA: 0x00182DAC File Offset: 0x00180FAC
		public void SetWidth()
		{
			this.WidthList.Clear();
			this.WidthTotal = 0;
			bool flag = this.DataType != null;
			if (flag)
			{
				int i = 0;
				while (i < this.DataType.Length)
				{
					int num = 0;
					switch (this.DataType[i])
					{
					case 3:
						num = 332;
						break;
					case 4:
						goto IL_B6;
					case 5:
						num = 116;
						break;
					case 6:
						num = 140;
						break;
					case 7:
						num = 120;
						break;
					case 8:
						num = 112;
						break;
					case 9:
						num = 108;
						break;
					case 10:
						num = 124;
						break;
					case 11:
						num = 160;
						break;
					case 12:
						num = 140;
						this.CalWinOrLoseMess();
						break;
					case 13:
						num = 135;
						break;
					default:
						goto IL_B6;
					}
					IL_DD:
					this.WidthTotal += num;
					this.WidthList.Add(num);
					i++;
					continue;
					IL_B6:
					XSingleton<XDebug>.singleton.AddErrorLog("SpectateLevelRewardConfig DataConfig Error! Can't find width of type = ", this.DataType[i].ToString(), null, null, null, null);
					goto IL_DD;
				}
			}
		}

		// Token: 0x060099E1 RID: 39393 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x060099E2 RID: 39394 RVA: 0x00182ECC File Offset: 0x001810CC
		public void SetData(BattleWatcherNtf ntf)
		{
			this.DataList = ntf.data;
			this.StarDict.Clear();
			bool flag = ntf.star != null;
			if (flag)
			{
				for (int i = 0; i < ntf.star.Count; i++)
				{
					this.StarDict[ntf.star[i].roleid] = ntf.star[i].star;
				}
			}
			this.WinUid = ntf.winuid;
			this.MvpUid = ntf.mvp;
			this.WatchNum = ntf.watchinfo.wathccount;
			this.CommendNum = ntf.watchinfo.likecount;
			bool flag2 = DlgBase<XChatView, XChatBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XChatView, XChatBehaviour>.singleton.SetVisible(false, true);
			}
			bool flag3 = !this.InitData();
			if (!flag3)
			{
				DlgBase<SpectateLevelRewardView, SpectateLevelRewardBehaviour>.singleton.ShowData();
			}
		}

		// Token: 0x060099E3 RID: 39395 RVA: 0x00182FBC File Offset: 0x001811BC
		public void LevelScene()
		{
			bool flag = Time.time - this.LastLevelSceneTime < 5f;
			if (!flag)
			{
				this.LastLevelSceneTime = Time.time;
				XSingleton<XScene>.singleton.ReqLeaveScene();
			}
		}

		// Token: 0x060099E4 RID: 39396 RVA: 0x00182FFC File Offset: 0x001811FC
		private void CalWinOrLoseMess()
		{
			bool flag = this.WinUid == 0UL;
			if (flag)
			{
				this.WinTag = 0;
			}
			else
			{
				XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
				bool flag2 = true;
				bool flag3 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HEROBATTLE;
				if (flag3)
				{
					XHeroBattleDocument specificDocument2 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					flag2 = (specificDocument2.MyTeam == (uint)this.WinUid);
				}
				else
				{
					bool flag4 = !specificDocument.IsBlueTeamDict.TryGetValue(this.WinUid, out flag2);
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("spectate level reward can't find this winer's team, winer uid = ", this.WinUid.ToString(), null, null, null, null);
					}
				}
				this.WinTag = (flag2 ? 1 : -1);
			}
		}

		// Token: 0x040034D8 RID: 13528
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SpectateLevelRewardDocument");

		// Token: 0x040034D9 RID: 13529
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040034DA RID: 13530
		private static SpectateLevelRewardConfig _levelRewardConfig = new SpectateLevelRewardConfig();

		// Token: 0x040034DB RID: 13531
		public List<BattleStatisticsData> DataList;

		// Token: 0x040034DC RID: 13532
		public Dictionary<ulong, uint> StarDict = new Dictionary<ulong, uint>();

		// Token: 0x040034DD RID: 13533
		public uint WatchNum;

		// Token: 0x040034DE RID: 13534
		public uint CommendNum;

		// Token: 0x040034DF RID: 13535
		public ulong WinUid;

		// Token: 0x040034E0 RID: 13536
		public ulong MvpUid;

		// Token: 0x040034E1 RID: 13537
		public int[] DataType;

		// Token: 0x040034E2 RID: 13538
		public List<int> WidthList = new List<int>();

		// Token: 0x040034E3 RID: 13539
		public int WidthTotal;

		// Token: 0x040034E4 RID: 13540
		public int WinTag;

		// Token: 0x040034E5 RID: 13541
		public double DamageSum;

		// Token: 0x040034E6 RID: 13542
		private float LastLevelSceneTime = 0f;
	}
}
