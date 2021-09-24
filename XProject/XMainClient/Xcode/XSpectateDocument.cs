using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSpectateDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSpectateDocument.uuID;
			}
		}

		public List<OneLiveRecordInfo> SpectateRecord
		{
			get
			{
				return this._spectateRecord;
			}
		}

		public override void OnEnterSceneFinally()
		{
			this.IsLoadingSpectateScene = false;
		}

		private void GetPVPInterval()
		{
			this.PkIntervalList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("Spectate_PVP_interval", false);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.GetPVPInterval();
		}

		public void SendQuerySpectateInfo(int ID)
		{
			this.CurrTabs = ID;
			RpcC2G_GetWatchInfoByID rpcC2G_GetWatchInfoByID = new RpcC2G_GetWatchInfoByID();
			rpcC2G_GetWatchInfoByID.oArg.type = ID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetWatchInfoByID);
		}

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

		public void SendEnterSpectateQuery(uint liveID, LiveType type)
		{
			this.IsLoadingSpectateScene = true;
			RpcC2G_EnterWatchBattle rpcC2G_EnterWatchBattle = new RpcC2G_EnterWatchBattle();
			rpcC2G_EnterWatchBattle.oArg.liveID = liveID;
			rpcC2G_EnterWatchBattle.oArg.type = type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnterWatchBattle);
		}

		public void SendQueryMyLiveInfo()
		{
			RpcC2G_GetMyWatchRecord rpc = new RpcC2G_GetMyWatchRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void EnterLiveError(bool isOver)
		{
			bool flag = DlgBase<SpectateView, SpectateBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<SpectateView, SpectateBehaviour>.singleton.SetWatchBtnGrey(isOver);
			}
		}

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

		public void SetMainInterfaceBtnFalse()
		{
			this.MainInterfaceState = false;
			this.MainInterfaceData = null;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_ExcellentLive, true);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("SpectateDocument");

		private List<OneLiveRecordInfo> _spectateRecord = new List<OneLiveRecordInfo>();

		public List<OneLiveRecordInfo> MyRecentRecord = new List<OneLiveRecordInfo>();

		public OneLiveRecordInfo WatchMostRecord;

		public OneLiveRecordInfo CommendMostRecord;

		public SeqList<int> PkIntervalList;

		public int TotalWatch;

		public int TotalCommend;

		public int CurrPage = 0;

		public int MaxPage = 0;

		public int CurrTime = 0;

		public int CurrTabs = 0;

		public bool IsLoadingSpectateScene = false;

		public readonly int ITEMPERPAGE = 4;

		public bool MainInterfaceState = false;

		public LiveIconData MainInterfaceData;

		public LiveIconData ClickData;

		public uint TempliveID;

		public LiveType TempLiveType;

		public uint LiveCount = 0U;

		public bool VisibleSetting = false;

		public bool TempSetting = false;
	}
}
