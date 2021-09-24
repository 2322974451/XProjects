using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCaptainPVPDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCaptainPVPDocument.uuID;
			}
		}

		public XCaptainPVPView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		public List<BattleRecordGameInfo> RecordList
		{
			get
			{
				return this._recordList;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL;
			if (flag)
			{
				this.ReqGetShowInfo();
			}
		}

		public void ReqGetShowInfo()
		{
			RpcC2G_PvpAllReq rpcC2G_PvpAllReq = new RpcC2G_PvpAllReq();
			rpcC2G_PvpAllReq.oArg.type = PvpReqType.PVP_REQ_BASE_DATA;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PvpAllReq);
		}

		public void SetShowInfo(PvpArg oArg, PvpRes oRes)
		{
			bool flag = !DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool flag2 = oRes.basedata == null;
				if (!flag2)
				{
					int wincountall = oRes.basedata.wincountall;
					int losecountall = oRes.basedata.losecountall;
					this.weekWinCount = oRes.basedata.wincountthisweek;
					this.weekMax = oRes.basedata.wincountweekmax;
					int num = 0;
					bool flag3 = wincountall + losecountall != 0;
					if (flag3)
					{
						num = (int)Math.Round(100.0 * (double)wincountall / (double)(wincountall + losecountall));
					}
					DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_BattleRecord.SetText(string.Format(XStringDefineProxy.GetString("CAPTAINPVP_HISTORY"), new object[]
					{
						this.ShowNum(wincountall + losecountall),
						this.ShowNum(wincountall),
						this.ShowNum(losecountall),
						num.ToString()
					}));
					DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_BoxLabel.SetText(string.Format("{0}/{1}", this.weekWinCount, this.weekMax));
					DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_MatchNum.SetText(string.Format(XStringDefineProxy.GetString("CAPTAINPVP_MATCH"), oRes.basedata.matchingcount));
					bool flag4 = this.weekWinCount >= this.weekMax && !oRes.basedata.weekRewardHaveGet;
					if (flag4)
					{
						this.canGetWeekReward = true;
					}
					else
					{
						this.canGetWeekReward = false;
					}
					this.isEmptyBox = oRes.basedata.weekRewardHaveGet;
					this.View.RefreshWeekReward();
					this.View.RefreshExReward(oRes.basedata.jointodayintime, oRes.basedata.jointodayintimemax);
				}
			}
		}

		private string ShowNum(int num)
		{
			bool flag = num < 10;
			string result;
			if (flag)
			{
				result = num.ToString() + "  ";
			}
			else
			{
				bool flag2 = num < 100;
				if (flag2)
				{
					result = num.ToString() + " ";
				}
				else
				{
					result = num.ToString();
				}
			}
			return result;
		}

		public void ReqGetWeekReward()
		{
			RpcC2G_PvpAllReq rpcC2G_PvpAllReq = new RpcC2G_PvpAllReq();
			rpcC2G_PvpAllReq.oArg.type = PvpReqType.PVP_REQ_GET_WEEKREWARD;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PvpAllReq);
		}

		public void SetWeekReward(PvpArg oArg, PvpRes oRes)
		{
			this.canGetWeekReward = false;
			bool flag = DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.View.RefreshWeekReward();
			}
		}

		public void ReqGetHistory()
		{
			RpcC2G_PvpAllReq rpcC2G_PvpAllReq = new RpcC2G_PvpAllReq();
			rpcC2G_PvpAllReq.oArg.type = PvpReqType.PVP_REQ_HISTORY_REC;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PvpAllReq);
		}

		public void SetBattleRecord(PvpRes oRes)
		{
			bool flag = oRes.history == null;
			if (!flag)
			{
				this._recordList.Clear();
				for (int i = oRes.history.recs.Count - 1; i >= 0; i--)
				{
					BattleRecordGameInfo battleRecordGameInfo = new BattleRecordGameInfo();
					for (int j = 0; j < oRes.history.recs[i].myside.Count; j++)
					{
						bool flag2 = oRes.history.recs[i].myside[j].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag2)
						{
							battleRecordGameInfo.left.Add(this.GetOnePlayerInfo(oRes.history.recs[i].myside[j]));
						}
					}
					for (int k = 0; k < oRes.history.recs[i].myside.Count; k++)
					{
						bool flag3 = oRes.history.recs[i].myside[k].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (!flag3)
						{
							battleRecordGameInfo.left.Add(this.GetOnePlayerInfo(oRes.history.recs[i].myside[k]));
						}
					}
					for (int l = 0; l < oRes.history.recs[i].opside.Count; l++)
					{
						battleRecordGameInfo.right.Add(this.GetOnePlayerInfo(oRes.history.recs[i].opside[l]));
					}
					bool flag4 = oRes.history.recs[i].wincount > oRes.history.recs[i].losecount;
					if (flag4)
					{
						battleRecordGameInfo.result = HeroBattleOver.HeroBattleOver_Win;
					}
					else
					{
						bool flag5 = oRes.history.recs[i].wincount < oRes.history.recs[i].losecount;
						if (flag5)
						{
							battleRecordGameInfo.result = HeroBattleOver.HeroBattleOver_Lose;
						}
						else
						{
							battleRecordGameInfo.result = HeroBattleOver.HeroBattleOver_Draw;
						}
					}
					battleRecordGameInfo.militaryExploit = oRes.history.recs[i].military;
					this._recordList.Add(battleRecordGameInfo);
				}
				bool flag6 = DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.IsVisible() && DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.m_CaptainBattleRecordHandler != null && DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.m_CaptainBattleRecordHandler.IsVisible();
				if (flag6)
				{
					DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.m_CaptainBattleRecordHandler.SetupRecord(this.RecordList);
				}
				bool flag7 = DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.IsVisible() && DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.m_BattleRecordHandler != null && DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.m_BattleRecordHandler.IsVisible();
				if (flag7)
				{
					DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.m_BattleRecordHandler.SetupRecord(this.RecordList);
				}
			}
		}

		public BattleRecordPlayerInfo GetOnePlayerInfo(PvpRoleBrief data)
		{
			return new BattleRecordPlayerInfo
			{
				name = data.rolename,
				profression = data.roleprofession,
				roleID = data.roleid
			};
		}

		public void NtfSetMatch(uint lefttime)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool bInTeam = specificDocument.bInTeam;
			if (bInTeam)
			{
				bool flag = lefttime > 0U;
				if (flag)
				{
					bool flag2 = specificDocument.MyTeamView != null && specificDocument.MyTeamView.IsVisible();
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_MATCH_START"), "fece00");
					}
				}
			}
		}

		public void SetStartSingleLabel()
		{
			DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_BtnStartSingleLabel.SetText(string.Format("{0}...", XStringDefineProxy.GetString("MATCHING")));
		}

		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Activity_CaptainPVP, true);
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CaptainPVPDocument");

		private XCaptainPVPView _view = null;

		private List<BattleRecordGameInfo> _recordList = new List<BattleRecordGameInfo>();

		public bool isEmptyBox;

		public bool canGetWeekReward;

		public int weekMax;

		public int weekWinCount;

		public bool MainInterfaceState = false;
	}
}
