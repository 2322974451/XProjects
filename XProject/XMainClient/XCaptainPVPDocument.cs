using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A85 RID: 2693
	internal class XCaptainPVPDocument : XDocComponent
	{
		// Token: 0x17002FAA RID: 12202
		// (get) Token: 0x0600A3D7 RID: 41943 RVA: 0x001C2580 File Offset: 0x001C0780
		public override uint ID
		{
			get
			{
				return XCaptainPVPDocument.uuID;
			}
		}

		// Token: 0x17002FAB RID: 12203
		// (get) Token: 0x0600A3D8 RID: 41944 RVA: 0x001C2598 File Offset: 0x001C0798
		// (set) Token: 0x0600A3D9 RID: 41945 RVA: 0x001C25B0 File Offset: 0x001C07B0
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

		// Token: 0x17002FAC RID: 12204
		// (get) Token: 0x0600A3DA RID: 41946 RVA: 0x001C25BC File Offset: 0x001C07BC
		public List<BattleRecordGameInfo> RecordList
		{
			get
			{
				return this._recordList;
			}
		}

		// Token: 0x0600A3DB RID: 41947 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600A3DC RID: 41948 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnEnterSceneFinally()
		{
		}

		// Token: 0x0600A3DD RID: 41949 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600A3DE RID: 41950 RVA: 0x0013A712 File Offset: 0x00138912
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		// Token: 0x0600A3DF RID: 41951 RVA: 0x001C25D4 File Offset: 0x001C07D4
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_HALL;
			if (flag)
			{
				this.ReqGetShowInfo();
			}
		}

		// Token: 0x0600A3E0 RID: 41952 RVA: 0x001C25FC File Offset: 0x001C07FC
		public void ReqGetShowInfo()
		{
			RpcC2G_PvpAllReq rpcC2G_PvpAllReq = new RpcC2G_PvpAllReq();
			rpcC2G_PvpAllReq.oArg.type = PvpReqType.PVP_REQ_BASE_DATA;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PvpAllReq);
		}

		// Token: 0x0600A3E1 RID: 41953 RVA: 0x001C262C File Offset: 0x001C082C
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

		// Token: 0x0600A3E2 RID: 41954 RVA: 0x001C27FC File Offset: 0x001C09FC
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

		// Token: 0x0600A3E3 RID: 41955 RVA: 0x001C2850 File Offset: 0x001C0A50
		public void ReqGetWeekReward()
		{
			RpcC2G_PvpAllReq rpcC2G_PvpAllReq = new RpcC2G_PvpAllReq();
			rpcC2G_PvpAllReq.oArg.type = PvpReqType.PVP_REQ_GET_WEEKREWARD;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PvpAllReq);
		}

		// Token: 0x0600A3E4 RID: 41956 RVA: 0x001C2880 File Offset: 0x001C0A80
		public void SetWeekReward(PvpArg oArg, PvpRes oRes)
		{
			this.canGetWeekReward = false;
			bool flag = DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.View.RefreshWeekReward();
			}
		}

		// Token: 0x0600A3E5 RID: 41957 RVA: 0x001C28B0 File Offset: 0x001C0AB0
		public void ReqGetHistory()
		{
			RpcC2G_PvpAllReq rpcC2G_PvpAllReq = new RpcC2G_PvpAllReq();
			rpcC2G_PvpAllReq.oArg.type = PvpReqType.PVP_REQ_HISTORY_REC;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PvpAllReq);
		}

		// Token: 0x0600A3E6 RID: 41958 RVA: 0x001C28E0 File Offset: 0x001C0AE0
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

		// Token: 0x0600A3E7 RID: 41959 RVA: 0x001C2C10 File Offset: 0x001C0E10
		public BattleRecordPlayerInfo GetOnePlayerInfo(PvpRoleBrief data)
		{
			return new BattleRecordPlayerInfo
			{
				name = data.rolename,
				profression = data.roleprofession,
				roleID = data.roleid
			};
		}

		// Token: 0x0600A3E8 RID: 41960 RVA: 0x001C2C50 File Offset: 0x001C0E50
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

		// Token: 0x0600A3E9 RID: 41961 RVA: 0x001C2CB5 File Offset: 0x001C0EB5
		public void SetStartSingleLabel()
		{
			DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.uiBehaviour.m_BtnStartSingleLabel.SetText(string.Format("{0}...", XStringDefineProxy.GetString("MATCHING")));
		}

		// Token: 0x0600A3EA RID: 41962 RVA: 0x001C2CE4 File Offset: 0x001C0EE4
		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Activity_CaptainPVP, true);
			}
		}

		// Token: 0x04003B61 RID: 15201
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CaptainPVPDocument");

		// Token: 0x04003B62 RID: 15202
		private XCaptainPVPView _view = null;

		// Token: 0x04003B63 RID: 15203
		private List<BattleRecordGameInfo> _recordList = new List<BattleRecordGameInfo>();

		// Token: 0x04003B64 RID: 15204
		public bool isEmptyBox;

		// Token: 0x04003B65 RID: 15205
		public bool canGetWeekReward;

		// Token: 0x04003B66 RID: 15206
		public int weekMax;

		// Token: 0x04003B67 RID: 15207
		public int weekWinCount;

		// Token: 0x04003B68 RID: 15208
		public bool MainInterfaceState = false;
	}
}
