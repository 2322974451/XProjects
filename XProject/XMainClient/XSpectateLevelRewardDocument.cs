using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSpectateLevelRewardDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSpectateLevelRewardDocument.uuID;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XSpectateLevelRewardDocument.AsyncLoader.AddTask("Table/SpectateLevelRewardConfig", XSpectateLevelRewardDocument._levelRewardConfig, false);
			XSpectateLevelRewardDocument.AsyncLoader.Execute(callback);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

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

		public void LevelScene()
		{
			bool flag = Time.time - this.LastLevelSceneTime < 5f;
			if (!flag)
			{
				this.LastLevelSceneTime = Time.time;
				XSingleton<XScene>.singleton.ReqLeaveScene();
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SpectateLevelRewardDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static SpectateLevelRewardConfig _levelRewardConfig = new SpectateLevelRewardConfig();

		public List<BattleStatisticsData> DataList;

		public Dictionary<ulong, uint> StarDict = new Dictionary<ulong, uint>();

		public uint WatchNum;

		public uint CommendNum;

		public ulong WinUid;

		public ulong MvpUid;

		public int[] DataType;

		public List<int> WidthList = new List<int>();

		public int WidthTotal;

		public int WinTag;

		public double DamageSum;

		private float LastLevelSceneTime = 0f;
	}
}
