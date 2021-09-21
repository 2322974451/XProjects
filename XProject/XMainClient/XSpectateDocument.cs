using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200097C RID: 2428
	internal class XSpectateDocument : XDocComponent
	{
		// Token: 0x17002C97 RID: 11415
		// (get) Token: 0x06009235 RID: 37429 RVA: 0x001510D8 File Offset: 0x0014F2D8
		public override uint ID
		{
			get
			{
				return XSpectateDocument.uuID;
			}
		}

		// Token: 0x17002C98 RID: 11416
		// (get) Token: 0x06009236 RID: 37430 RVA: 0x001510F0 File Offset: 0x0014F2F0
		public List<OneLiveRecordInfo> SpectateRecord
		{
			get
			{
				return this._spectateRecord;
			}
		}

		// Token: 0x06009237 RID: 37431 RVA: 0x00151108 File Offset: 0x0014F308
		public override void OnEnterSceneFinally()
		{
			this.IsLoadingSpectateScene = false;
		}

		// Token: 0x06009238 RID: 37432 RVA: 0x00151112 File Offset: 0x0014F312
		private void GetPVPInterval()
		{
			this.PkIntervalList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("Spectate_PVP_interval", false);
		}

		// Token: 0x06009239 RID: 37433 RVA: 0x0015112B File Offset: 0x0014F32B
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.GetPVPInterval();
		}

		// Token: 0x0600923A RID: 37434 RVA: 0x00151140 File Offset: 0x0014F340
		public void SendQuerySpectateInfo(int ID)
		{
			this.CurrTabs = ID;
			RpcC2G_GetWatchInfoByID rpcC2G_GetWatchInfoByID = new RpcC2G_GetWatchInfoByID();
			rpcC2G_GetWatchInfoByID.oArg.type = ID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetWatchInfoByID);
		}

		// Token: 0x0600923B RID: 37435 RVA: 0x00151174 File Offset: 0x0014F374
		public void SetSpectateInfo(int currTime, List<OneLiveRecordInfo> list)
		{
			this.CurrTime = currTime;
			this._spectateRecord.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				OneLiveRecordInfo item = new OneLiveRecordInfo();
				item = list[i];
				this._spectateRecord.Add(item);
			}
			this.MaxPage = (list.Count + this.ITEMPERPAGE - 1) / this.ITEMPERPAGE;
			bool flag = DlgBase<SpectateView, SpectateBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<SpectateView, SpectateBehaviour>.singleton.RefreshSpectate(0);
			}
		}

		// Token: 0x0600923C RID: 37436 RVA: 0x00151200 File Offset: 0x0014F400
		public bool OnLeaveTeamSure(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool bInTeam = specificDocument.bInTeam;
			if (bInTeam)
			{
				specificDocument.ReqTeamOp(TeamOperate.TEAM_LEAVE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			}
			this.SendEnterSpectateQuery(this.TempliveID, this.TempLiveType);
			return true;
		}

		// Token: 0x0600923D RID: 37437 RVA: 0x00151258 File Offset: 0x0014F458
		public void EnterSpectateBattle(uint liveID, LiveType type)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Spectate);
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("Spectate_UnOpen"), XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(XSysDefine.XSys_Spectate)), "fece00");
			}
			else
			{
				XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
				bool flag2 = !specificDocument.bInTeam;
				if (flag2)
				{
					this.SendEnterSpectateQuery(liveID, type);
				}
				else
				{
					this.TempliveID = liveID;
					this.TempLiveType = type;
					XSingleton<UiUtility>.singleton.ShowLeaveTeamModalDialog(new ButtonClickEventHandler(this.OnLeaveTeamSure), "");
				}
			}
		}

		// Token: 0x0600923E RID: 37438 RVA: 0x001512FC File Offset: 0x0014F4FC
		public void SendEnterSpectateQuery(uint liveID, LiveType type)
		{
			this.IsLoadingSpectateScene = true;
			RpcC2G_EnterWatchBattle rpcC2G_EnterWatchBattle = new RpcC2G_EnterWatchBattle();
			rpcC2G_EnterWatchBattle.oArg.liveID = liveID;
			rpcC2G_EnterWatchBattle.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnterWatchBattle);
		}

		// Token: 0x0600923F RID: 37439 RVA: 0x00151340 File Offset: 0x0014F540
		public void SendQueryMyLiveInfo()
		{
			RpcC2G_GetMyWatchRecord rpc = new RpcC2G_GetMyWatchRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009240 RID: 37440 RVA: 0x00151360 File Offset: 0x0014F560
		public void SetMyLiveInfo(int watchNum, int commendNum, OneLiveRecordInfo watchMostRecord, OneLiveRecordInfo commendMostRecord, List<OneLiveRecordInfo> list, bool visSet)
		{
			this.TotalWatch = watchNum;
			this.TotalCommend = commendNum;
			this.WatchMostRecord = watchMostRecord;
			this.CommendMostRecord = commendMostRecord;
			this.VisibleSetting = visSet;
			this.MyRecentRecord.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				OneLiveRecordInfo item = new OneLiveRecordInfo();
				item = list[i];
				this.MyRecentRecord.Add(item);
			}
			bool flag = DlgBase<SpectateView, SpectateBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<SpectateView, SpectateBehaviour>.singleton.RefreshMyRecord();
			}
		}

		// Token: 0x06009241 RID: 37441 RVA: 0x001513EC File Offset: 0x0014F5EC
		public void EnterLiveError(bool isOver)
		{
			bool flag = DlgBase<SpectateView, SpectateBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<SpectateView, SpectateBehaviour>.singleton.SetWatchBtnGrey(isOver);
			}
		}

		// Token: 0x06009242 RID: 37442 RVA: 0x00151418 File Offset: 0x0014F618
		public void SetLiveCount(uint count)
		{
			XSingleton<XDebug>.singleton.AddLog(string.Format("Get live count = {0} by server", count), null, null, null, null, null, XDebugColor.XDebug_None);
			this.LiveCount = count;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.ShowLiveCount(count);
			}
		}

		// Token: 0x06009243 RID: 37443 RVA: 0x00151468 File Offset: 0x0014F668
		public void SetMainInterfaceBtnState(bool state, LiveIconData data)
		{
			bool flag = data == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Get MainInterfaceBtnState data of spectate is null", null, null, null, null, null);
			}
			else
			{
				bool flag2 = !state && (this.MainInterfaceData == null || data.liveID != this.MainInterfaceData.liveID);
				if (!flag2)
				{
					this.MainInterfaceState = state;
					this.MainInterfaceData = data;
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_ExcellentLive, true);
				}
			}
		}

		// Token: 0x06009244 RID: 37444 RVA: 0x001514DF File Offset: 0x0014F6DF
		public void SetMainInterfaceBtnFalse()
		{
			this.MainInterfaceState = false;
			this.MainInterfaceData = null;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_ExcellentLive, true);
		}

		// Token: 0x06009245 RID: 37445 RVA: 0x00151500 File Offset: 0x0014F700
		public void MainInterfaceEnterQuery()
		{
			bool flag = this.ClickData == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("spectate maininterface click data is null", null, null, null, null, null);
			}
			else
			{
				this.EnterSpectateBattle((uint)this.ClickData.liveID, (LiveType)this.ClickData.liveType);
			}
		}

		// Token: 0x06009246 RID: 37446 RVA: 0x00151550 File Offset: 0x0014F750
		public string GetTitle(OneLiveRecordInfo info)
		{
			string text = XStringDefineProxy.GetString("Spectate_Title_" + XFastEnumIntEqualityComparer<LiveType>.ToInt(info.liveType));
			LiveType liveType = info.liveType;
			switch (liveType)
			{
			case LiveType.LIVE_PVP:
				break;
			case LiveType.LIVE_NEST:
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				return XExpeditionDocument.GetFullName(specificDocument.GetExpeditionDataByID(info.DNExpID));
			}
			case LiveType.LIVE_PROTECTCAPTAIN:
			case LiveType.LIVE_GUILDBATTLE:
				return text;
			case LiveType.LIVE_DRAGON:
			{
				XExpeditionDocument specificDocument2 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				return XExpeditionDocument.GetFullName(specificDocument2.GetExpeditionDataByID(info.DNExpID));
			}
			default:
				if (liveType != LiveType.LIVE_PVP2)
				{
					return text;
				}
				break;
			}
			text = string.Format("{0}{1}{2}", text, this.GetPVPPostfix(info.tianTiLevel), XStringDefineProxy.GetString("PVP_Point"));
			return text;
		}

		// Token: 0x06009247 RID: 37447 RVA: 0x00151614 File Offset: 0x0014F814
		private string GetPVPPostfix(int pkPoint)
		{
			bool flag = this.PkIntervalList == null;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				bool flag2 = pkPoint < this.PkIntervalList[0, 0];
				if (flag2)
				{
					result = "";
				}
				else
				{
					for (int i = 0; i < (int)this.PkIntervalList.Count; i++)
					{
						bool flag3 = pkPoint <= this.PkIntervalList[i, 1];
						if (flag3)
						{
							return this.PkIntervalList[i, 0].ToString();
						}
					}
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06009248 RID: 37448 RVA: 0x001516AC File Offset: 0x0014F8AC
		public static LiveType GetLiveTypeBySceneType(SceneType type)
		{
			if (type <= SceneType.SCENE_WEEK_NEST)
			{
				if (type <= SceneType.SCENE_PK)
				{
					if (type == SceneType.SCENE_NEST)
					{
						return LiveType.LIVE_NEST;
					}
					if (type == SceneType.SCENE_PK)
					{
						return LiveType.LIVE_PVP;
					}
				}
				else
				{
					switch (type)
					{
					case SceneType.SCENE_PVP:
						return LiveType.LIVE_PROTECTCAPTAIN;
					case SceneType.SCENE_DRAGON:
						return LiveType.LIVE_DRAGON;
					case SceneType.SCENE_GMF:
						return LiveType.LIVE_GUILDBATTLE;
					default:
						if (type == SceneType.SCENE_GPR)
						{
							return LiveType.LIVE_GUILDBATTLE;
						}
						if (type == SceneType.SCENE_WEEK_NEST)
						{
							return LiveType.LIVE_DRAGON;
						}
						break;
					}
				}
			}
			else if (type <= SceneType.SCENE_LEAGUE_BATTLE)
			{
				if (type == SceneType.SCENE_HEROBATTLE)
				{
					return LiveType.LIVE_HEROBATTLE;
				}
				if (type == SceneType.SCENE_LEAGUE_BATTLE)
				{
					return LiveType.LIVE_LEAGUEBATTLE;
				}
			}
			else
			{
				if (type == SceneType.SCENE_CUSTOMPK)
				{
					return LiveType.LIVE_CUSTOMPK;
				}
				if (type == SceneType.SCENE_PKTWO)
				{
					return LiveType.LIVE_PVP2;
				}
				if (type == SceneType.SCENE_GCF)
				{
					return LiveType.LIVE_CROSSGVG;
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("Can't find The live Type by SceneType", null, null, null, null, null);
			return LiveType.LIVE_MAX;
		}

		// Token: 0x06009249 RID: 37449 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x040030CA RID: 12490
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SpectateDocument");

		// Token: 0x040030CB RID: 12491
		private List<OneLiveRecordInfo> _spectateRecord = new List<OneLiveRecordInfo>();

		// Token: 0x040030CC RID: 12492
		public List<OneLiveRecordInfo> MyRecentRecord = new List<OneLiveRecordInfo>();

		// Token: 0x040030CD RID: 12493
		public OneLiveRecordInfo WatchMostRecord;

		// Token: 0x040030CE RID: 12494
		public OneLiveRecordInfo CommendMostRecord;

		// Token: 0x040030CF RID: 12495
		public SeqList<int> PkIntervalList;

		// Token: 0x040030D0 RID: 12496
		public int TotalWatch;

		// Token: 0x040030D1 RID: 12497
		public int TotalCommend;

		// Token: 0x040030D2 RID: 12498
		public int CurrPage = 0;

		// Token: 0x040030D3 RID: 12499
		public int MaxPage = 0;

		// Token: 0x040030D4 RID: 12500
		public int CurrTime = 0;

		// Token: 0x040030D5 RID: 12501
		public int CurrTabs = 0;

		// Token: 0x040030D6 RID: 12502
		public bool IsLoadingSpectateScene = false;

		// Token: 0x040030D7 RID: 12503
		public readonly int ITEMPERPAGE = 4;

		// Token: 0x040030D8 RID: 12504
		public bool MainInterfaceState = false;

		// Token: 0x040030D9 RID: 12505
		public LiveIconData MainInterfaceData;

		// Token: 0x040030DA RID: 12506
		public LiveIconData ClickData;

		// Token: 0x040030DB RID: 12507
		public uint TempliveID;

		// Token: 0x040030DC RID: 12508
		public LiveType TempLiveType;

		// Token: 0x040030DD RID: 12509
		public uint LiveCount = 0U;

		// Token: 0x040030DE RID: 12510
		public bool VisibleSetting = false;

		// Token: 0x040030DF RID: 12511
		public bool TempSetting = false;
	}
}
