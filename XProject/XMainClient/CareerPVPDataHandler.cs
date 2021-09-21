using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C7F RID: 3199
	internal class CareerPVPDataHandler : DlgHandlerBase
	{
		// Token: 0x0600B4B8 RID: 46264 RVA: 0x002367B4 File Offset: 0x002349B4
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XPersonalCareerDocument>(XPersonalCareerDocument.uuID);
			this.m_CurTitle = (base.transform.Find("Title/T").GetComponent("XUILabel") as IXUILabel);
			this.m_CurTitleBtn = (base.transform.Find("Title/Bg").GetComponent("XUIButton") as IXUIButton);
			this.m_TitleSelected = base.transform.Find("Title/TitleSelected");
			Transform transform = base.transform.Find("Title/TitleSelected/TypeTpl");
			this.m_TitlePool.SetupPool(null, transform.gameObject, 5U, false);
			this.m_TitlePool.FakeReturnAll();
			for (int i = 0; i < this.PVPSysID.Length; i++)
			{
				GameObject gameObject = this.m_TitlePool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_TitlePool.TplHeight * i), 0f) + this.m_TitlePool.TplPos;
				this.m_TitleName[i] = (gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
				this.m_TitleName[i].SetText(XSingleton<XGameSysMgr>.singleton.GetSystemName(int.Parse(this.PVPSysID[i])));
				this.m_TitleBtn[i] = (gameObject.GetComponent("XUIButton") as IXUIButton);
			}
			this.m_TitlePool.ActualReturnAll(false);
			this.m_QualifyPanel = base.transform.Find("Qualify");
			Transform transform2 = this.m_QualifyPanel.Find("Left");
			this.m_HistorySegment = (transform2.Find("History/Segment").GetComponent("XUITexture") as IXUITexture);
			this.m_Beyond = (transform2.Find("Rank/Beyond").GetComponent("XUILabel") as IXUILabel);
			this.m_Score = (transform2.Find("Rank/Score/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_CurSegment = (transform2.Find("Rank/Segment").GetComponent("XUITexture") as IXUITexture);
			this.m_ServerRank = (transform2.Find("Rank/ServerRank").GetComponent("XUILabel") as IXUILabel);
			this.m_ProfessionRank = (transform2.Find("Rank/ProfessionRank").GetComponent("XUILabel") as IXUILabel);
			this.m_PKDetail = (transform2.Find("PKDetail").GetComponent("XUIButton") as IXUIButton);
			Transform transform3 = this.m_QualifyPanel.Find("Right");
			this.m_Win = (transform3.Find("Base/Win/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Lose = (transform3.Find("Base/Lose/T").GetComponent("XUILabel") as IXUILabel);
			this.m_WinStreak = (transform3.Find("Base/WinStreak/T").GetComponent("XUILabel") as IXUILabel);
			this.m_WinRateDetail = transform3.Find("WinRateDetail");
			Transform transform4 = transform3.Find("WinRateDetail/Profession");
			for (int j = 0; j < transform4.childCount; j++)
			{
				IXUILabel item = transform4.Find(string.Format("Profession{0}", j)).GetComponent("XUILabel") as IXUILabel;
				this.m_ProfessionWinRate.Add(item);
			}
			this.m_WinRate = (transform3.Find("WinRate/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_WinRateProgress = (transform3.Find("WinRate/Progress").GetComponent("XUISprite") as IXUISprite);
			this.m_TotalCount = (transform3.Find("Total/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_Push = (this.m_QualifyPanel.Find("Btn/Push").GetComponent("XUIButton") as IXUIButton);
			this.m_Share = (this.m_QualifyPanel.Find("Btn/Share").GetComponent("XUIButton") as IXUIButton);
			this.m_SeasonTab = (this.m_QualifyPanel.transform.Find("Tab/Season").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_AllTab = (this.m_QualifyPanel.transform.Find("Tab/All").GetComponent("XUICheckBox") as IXUICheckBox);
			this.InitQualify();
		}

		// Token: 0x170031FF RID: 12799
		// (get) Token: 0x0600B4B9 RID: 46265 RVA: 0x00236C40 File Offset: 0x00234E40
		protected override string FileName
		{
			get
			{
				return "GameSystem/PersonalCareer/CareerPVPData";
			}
		}

		// Token: 0x0600B4BA RID: 46266 RVA: 0x00236C58 File Offset: 0x00234E58
		public override void RegisterEvent()
		{
			this.m_CurTitleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this._OpenSelectTitle));
			for (int i = 0; i < this.PVPSysID.Length; i++)
			{
				this.m_TitleBtn[i].ID = (ulong)((long)i);
				this.m_TitleBtn[i].RegisterClickEventHandler(new ButtonClickEventHandler(this._TitleChanged));
			}
			this.m_SeasonTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._SeasonBoxChanged));
			this.m_AllTab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._AllBoxChanged));
			this.m_PKDetail.RegisterClickEventHandler(new ButtonClickEventHandler(this._OpenPKDetail));
			this.m_Push.RegisterClickEventHandler(new ButtonClickEventHandler(this._PushBtnClick));
			this.m_Share.RegisterClickEventHandler(new ButtonClickEventHandler(this._ShareBtnClick));
		}

		// Token: 0x0600B4BB RID: 46267 RVA: 0x00236D39 File Offset: 0x00234F39
		protected override void OnShow()
		{
			base.OnShow();
			this.OnTabChanged(this.m_CurPVPIndex);
		}

		// Token: 0x0600B4BC RID: 46268 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600B4BD RID: 46269 RVA: 0x00236D50 File Offset: 0x00234F50
		public override void OnUnload()
		{
			this.m_HistorySegment.SetTexturePath("");
			this.m_CurSegment.SetTexturePath("");
			DlgHandlerBase.EnsureUnload<XQualifyingRecordsHandler>(ref this.QualifyingRecordsHandler);
			base.OnUnload();
		}

		// Token: 0x0600B4BE RID: 46270 RVA: 0x00236D88 File Offset: 0x00234F88
		private void InitInfo()
		{
			this.m_CurTitle.SetText(this.m_TitleName[this.m_CurPVPIndex].GetText());
			this.m_TitleSelected.gameObject.SetActive(false);
		}

		// Token: 0x0600B4BF RID: 46271 RVA: 0x00236DBC File Offset: 0x00234FBC
		private bool _OpenSelectTitle(IXUIButton btn)
		{
			this.m_TitleSelected.gameObject.SetActive(!this.m_TitleSelected.gameObject.activeSelf);
			return true;
		}

		// Token: 0x0600B4C0 RID: 46272 RVA: 0x00236DF4 File Offset: 0x00234FF4
		private bool _TitleChanged(IXUIButton btn)
		{
			bool flag = (int)btn.ID >= this.PVPSysID.Length;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"Index:",
					btn.ID,
					" PVPSysCnt:",
					this.PVPSysID.Length
				}), null, null, null, null, null);
			}
			this.OnTabChanged((int)btn.ID);
			return true;
		}

		// Token: 0x0600B4C1 RID: 46273 RVA: 0x00236E78 File Offset: 0x00235078
		public void OnTabChanged(int index)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Tab:" + index.ToString(), null, null, null, null, null);
			this.m_CurPVPIndex = index;
			this.CloseAllTab();
			XSysDefine xsysDefine = (XSysDefine)int.Parse(this.PVPSysID[index]);
			if (xsysDefine == XSysDefine.XSys_Qualifying)
			{
				this.m_QualifyPanel.gameObject.SetActive(true);
			}
			this.m_CurTitle.SetText(this.m_TitleName[index].GetText());
			this.m_TitleSelected.gameObject.SetActive(false);
		}

		// Token: 0x0600B4C2 RID: 46274 RVA: 0x00236F09 File Offset: 0x00235109
		private void CloseAllTab()
		{
			this.m_QualifyPanel.gameObject.SetActive(false);
		}

		// Token: 0x17003200 RID: 12800
		// (get) Token: 0x0600B4C3 RID: 46275 RVA: 0x00236F20 File Offset: 0x00235120
		public int MatchTotalCount
		{
			get
			{
				return this.win + this.draw + this.lose;
			}
		}

		// Token: 0x17003201 RID: 12801
		// (get) Token: 0x0600B4C4 RID: 46276 RVA: 0x00236F48 File Offset: 0x00235148
		public int MatchTotalPercent
		{
			get
			{
				bool flag = this.win == 0;
				int result;
				if (flag)
				{
					result = 0;
				}
				else
				{
					result = Math.Max(1, 100 * this.win / this.MatchTotalCount);
				}
				return result;
			}
		}

		// Token: 0x17003202 RID: 12802
		// (get) Token: 0x0600B4C5 RID: 46277 RVA: 0x00236F84 File Offset: 0x00235184
		public int HisMatchTotalCount
		{
			get
			{
				return this.winHis + this.drawHis + this.loseHis;
			}
		}

		// Token: 0x17003203 RID: 12803
		// (get) Token: 0x0600B4C6 RID: 46278 RVA: 0x00236FAC File Offset: 0x002351AC
		public int HisMatchTotalPercent
		{
			get
			{
				bool flag = this.winHis == 0;
				int result;
				if (flag)
				{
					result = 0;
				}
				else
				{
					result = Math.Max(1, 100 * this.winHis / this.HisMatchTotalCount);
				}
				return result;
			}
		}

		// Token: 0x0600B4C7 RID: 46279 RVA: 0x00236FE5 File Offset: 0x002351E5
		public void SetData(PVPInformation data)
		{
			this.SetData(data.pk_info);
		}

		// Token: 0x0600B4C8 RID: 46280 RVA: 0x00236FF8 File Offset: 0x002351F8
		public void SetData(PKInformation data)
		{
			this.win = (int)data.pk_record.histweek.win;
			this.draw = (int)data.pk_record.histweek.draw;
			this.lose = (int)data.pk_record.histweek.lose;
			this.ContinueWin = data.pk_record.histweek.continuewin;
			this.ContinueLose = data.pk_record.histweek.continuelose;
			this.ProfessionWin.Clear();
			for (int i = 0; i < data.pk_record.prowin.Count; i++)
			{
				uint num = data.pk_record.prowin[i] + data.pk_record.prolose[i];
				bool flag = num == 0U;
				if (flag)
				{
					this.ProfessionWin.Add(0U);
				}
				else
				{
					bool flag2 = data.pk_record.prowin[i] == 0U;
					if (flag2)
					{
						this.ProfessionWin.Add(0U);
					}
					else
					{
						this.ProfessionWin.Add(Math.Max(1U, 100U * data.pk_record.prowin[i] / num));
					}
				}
			}
			this.GameRecords.Clear();
			for (int j = data.pk_record.records.Count - 1; j >= 0; j--)
			{
				this.GameRecords.Add(data.pk_record.records[j]);
			}
			this.curPoint = data.pk_record.point;
			this.serverRank = data.pk_rank;
			this.professionRank = data.pk_profession_rank;
			this.hisPoint = data.pk_max_score;
			this.winHis = (int)data.pk_record.histall.win;
			this.drawHis = (int)data.pk_record.histall.draw;
			this.loseHis = (int)data.pk_record.histall.lose;
			this.ContinueWinHis = data.pk_record.histall.continuewin;
			this.beyondAll = data.pk_all_roles_rate;
			bool flag3 = base.IsVisible();
			if (flag3)
			{
				this.Refresh();
			}
		}

		// Token: 0x0600B4C9 RID: 46281 RVA: 0x00237238 File Offset: 0x00235438
		public void Refresh()
		{
			XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
			this.m_Beyond.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_PK_BEYONG_ALL"), this.beyondAll));
			this.m_Score.SetText(this.curPoint.ToString());
			this.m_HistorySegment.gameObject.SetActive(true);
			this.texHis = string.Format("atlas/UI/common/Pic/tts_{0}", specificDocument.GetIconIndex(this.hisPoint));
			this.m_CurSegment.gameObject.SetActive(true);
			this.texCur = string.Format("atlas/UI/common/Pic/tts_{0}", specificDocument.GetIconIndex(this.curPoint));
			this.m_CurSegment.SetTexturePath(this.texCur);
			for (int i = 0; i < this.m_ProfessionWinRate.Count; i++)
			{
				bool flag = i >= XGame.RoleCount || i >= this.ProfessionWin.Count;
				if (flag)
				{
					this.m_ProfessionWinRate[i].gameObject.SetActive(false);
				}
				else
				{
					this.m_ProfessionWinRate[i].gameObject.SetActive(true);
					this.m_ProfessionWinRate[i].SetText(this.ProfessionWin[i].ToString() + "%");
				}
			}
			bool flag2 = this.serverRank == 0U || this.serverRank == uint.MaxValue;
			if (flag2)
			{
				this.m_ServerRank.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_PK_RANK_OUT"), new object[0]));
			}
			else
			{
				this.m_ServerRank.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_PK_RANK"), this.serverRank));
			}
			bool flag3 = this.professionRank == 0U || this.professionRank == uint.MaxValue;
			if (flag3)
			{
				this.m_ProfessionRank.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_PK_RANK_OUT"), new object[0]));
			}
			else
			{
				this.m_ProfessionRank.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CAREER_PK_RANK"), this.professionRank));
			}
			this.m_Push.gameObject.SetActive(DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.roleId == 0UL);
			this.m_Share.gameObject.SetActive(DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.roleId == 0UL);
			this.RefreshRankStatus();
		}

		// Token: 0x0600B4CA RID: 46282 RVA: 0x002374D0 File Offset: 0x002356D0
		private void InitQualify()
		{
			this.m_Beyond.SetText("");
			this.m_Score.SetText("");
			this.m_HistorySegment.gameObject.SetActive(false);
			this.m_CurSegment.gameObject.SetActive(false);
			this.m_Win.SetText("");
			this.m_Lose.SetText("");
			this.m_WinStreak.SetText("");
			for (int i = 0; i < this.m_ProfessionWinRate.Count; i++)
			{
				this.m_ProfessionWinRate[i].SetText("");
			}
			this.m_WinRate.SetText("");
			this.m_WinRateProgress.SetFillAmount(0f);
			this.m_TotalCount.SetText("");
			this.m_SeasonTab.bChecked = true;
			this.RefreshRankStatus();
			this.m_ServerRank.SetText("");
			this.m_ProfessionRank.SetText("");
		}

		// Token: 0x0600B4CB RID: 46283 RVA: 0x002375F4 File Offset: 0x002357F4
		private bool _SeasonBoxChanged(IXUICheckBox iXUICheckBox)
		{
			bool flag = !iXUICheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.RefreshRankStatus();
				result = true;
			}
			return result;
		}

		// Token: 0x0600B4CC RID: 46284 RVA: 0x00237620 File Offset: 0x00235820
		private bool _AllBoxChanged(IXUICheckBox iXUICheckBox)
		{
			bool flag = !iXUICheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.RefreshRankStatus();
				result = true;
			}
			return result;
		}

		// Token: 0x0600B4CD RID: 46285 RVA: 0x0023764C File Offset: 0x0023584C
		private bool _OpenPKDetail(IXUIButton btn)
		{
			bool flag = this.QualifyingRecordsHandler == null;
			if (flag)
			{
				DlgHandlerBase.EnsureCreate<XQualifyingRecordsHandler>(ref this.QualifyingRecordsHandler, base.transform, true, this);
			}
			this.QualifyingRecordsHandler.WinCount = (uint)this.win;
			this.QualifyingRecordsHandler.DrawCount = (uint)this.draw;
			this.QualifyingRecordsHandler.LoseCount = (uint)this.lose;
			this.QualifyingRecordsHandler.ContinueWin = this.ContinueWin;
			this.QualifyingRecordsHandler.ContinueLose = this.ContinueLose;
			this.QualifyingRecordsHandler.ProfessionWin = this.ProfessionWin;
			this.QualifyingRecordsHandler.GameRecords = this.GameRecords;
			this.QualifyingRecordsHandler.Refresh();
			return true;
		}

		// Token: 0x0600B4CE RID: 46286 RVA: 0x00237708 File Offset: 0x00235908
		private bool _PushBtnClick(IXUIButton btn)
		{
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.PushClick((ulong)((long)this.m_CurPVPIndex));
			return true;
		}

		// Token: 0x0600B4CF RID: 46287 RVA: 0x00237730 File Offset: 0x00235930
		private bool _ShareBtnClick(IXUIButton btn)
		{
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.ShareClick();
			return true;
		}

		// Token: 0x0600B4D0 RID: 46288 RVA: 0x00237750 File Offset: 0x00235950
		private void RefreshRankStatus()
		{
			this.m_WinRateDetail.gameObject.SetActive(this.m_SeasonTab.bChecked);
			this.m_PKDetail.gameObject.SetActive(this.m_SeasonTab.bChecked);
			bool flag2;
			bool flag = this.doc.HasData.TryGetValue(PersonalCarrerReqType.PCRT_PVP_PKINFO, out flag2) && flag2;
			if (flag)
			{
				bool bChecked = this.m_SeasonTab.bChecked;
				if (bChecked)
				{
					this.m_Win.SetText(this.win.ToString());
					this.m_Lose.SetText(this.lose.ToString());
					this.m_WinStreak.SetText(this.ContinueWin.ToString());
					this.m_WinRate.SetText(string.Format("{0}%", this.MatchTotalPercent.ToString()));
					this.m_WinRateProgress.SetFillAmount((float)this.MatchTotalPercent / 100f);
					this.m_TotalCount.SetText(this.MatchTotalCount.ToString());
					this.m_Beyond.gameObject.SetActive(true);
					this.m_ServerRank.gameObject.SetActive(true);
					this.m_ProfessionRank.gameObject.SetActive(true);
				}
				else
				{
					this.m_Win.SetText(this.winHis.ToString());
					this.m_Lose.SetText(this.loseHis.ToString());
					this.m_WinStreak.SetText(this.ContinueWinHis.ToString());
					this.m_WinRate.SetText(string.Format("{0}%", this.HisMatchTotalPercent.ToString()));
					this.m_WinRateProgress.SetFillAmount((float)this.HisMatchTotalPercent / 100f);
					this.m_TotalCount.SetText(this.HisMatchTotalCount.ToString());
					this.m_Beyond.gameObject.SetActive(false);
					this.m_ServerRank.gameObject.SetActive(false);
					this.m_ProfessionRank.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0400463C RID: 17980
		private XPersonalCareerDocument doc = null;

		// Token: 0x0400463D RID: 17981
		private int m_CurPVPIndex = 0;

		// Token: 0x0400463E RID: 17982
		public string[] PVPSysID = XSingleton<XGlobalConfig>.singleton.GetValue("PersonalCareerPVP").Split(new char[]
		{
			'|'
		});

		// Token: 0x0400463F RID: 17983
		public XQualifyingRecordsHandler QualifyingRecordsHandler = null;

		// Token: 0x04004640 RID: 17984
		private IXUILabel m_CurTitle;

		// Token: 0x04004641 RID: 17985
		private IXUIButton m_CurTitleBtn;

		// Token: 0x04004642 RID: 17986
		private Transform m_TitleSelected;

		// Token: 0x04004643 RID: 17987
		private IXUILabel[] m_TitleName = new IXUILabel[5];

		// Token: 0x04004644 RID: 17988
		private IXUIButton[] m_TitleBtn = new IXUIButton[5];

		// Token: 0x04004645 RID: 17989
		private XUIPool m_TitlePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004646 RID: 17990
		private IXUILabel m_Beyond;

		// Token: 0x04004647 RID: 17991
		private IXUILabel m_Score;

		// Token: 0x04004648 RID: 17992
		private IXUITexture m_HistorySegment;

		// Token: 0x04004649 RID: 17993
		private IXUITexture m_CurSegment;

		// Token: 0x0400464A RID: 17994
		private IXUILabel m_ServerRank;

		// Token: 0x0400464B RID: 17995
		private IXUILabel m_ProfessionRank;

		// Token: 0x0400464C RID: 17996
		private IXUIButton m_PKDetail;

		// Token: 0x0400464D RID: 17997
		private Transform m_QualifyPanel;

		// Token: 0x0400464E RID: 17998
		private IXUILabel m_Win;

		// Token: 0x0400464F RID: 17999
		private IXUILabel m_Lose;

		// Token: 0x04004650 RID: 18000
		private IXUILabel m_WinStreak;

		// Token: 0x04004651 RID: 18001
		private Transform m_WinRateDetail;

		// Token: 0x04004652 RID: 18002
		private List<IXUILabel> m_ProfessionWinRate = new List<IXUILabel>();

		// Token: 0x04004653 RID: 18003
		private IXUILabel m_WinRate;

		// Token: 0x04004654 RID: 18004
		private IXUISprite m_WinRateProgress;

		// Token: 0x04004655 RID: 18005
		private IXUILabel m_TotalCount;

		// Token: 0x04004656 RID: 18006
		private IXUIButton m_Push;

		// Token: 0x04004657 RID: 18007
		private IXUIButton m_Share;

		// Token: 0x04004658 RID: 18008
		private IXUICheckBox m_SeasonTab;

		// Token: 0x04004659 RID: 18009
		private IXUICheckBox m_AllTab;

		// Token: 0x0400465A RID: 18010
		private int win;

		// Token: 0x0400465B RID: 18011
		private int draw;

		// Token: 0x0400465C RID: 18012
		private int lose;

		// Token: 0x0400465D RID: 18013
		private uint ContinueWin;

		// Token: 0x0400465E RID: 18014
		private uint ContinueLose;

		// Token: 0x0400465F RID: 18015
		private List<uint> ProfessionWin = new List<uint>();

		// Token: 0x04004660 RID: 18016
		private List<PkOneRecord> GameRecords = new List<PkOneRecord>();

		// Token: 0x04004661 RID: 18017
		private uint curPoint;

		// Token: 0x04004662 RID: 18018
		private uint serverRank;

		// Token: 0x04004663 RID: 18019
		private uint professionRank;

		// Token: 0x04004664 RID: 18020
		private uint hisPoint;

		// Token: 0x04004665 RID: 18021
		private string beyondAll;

		// Token: 0x04004666 RID: 18022
		private string texCur;

		// Token: 0x04004667 RID: 18023
		private string texHis;

		// Token: 0x04004668 RID: 18024
		private int winHis;

		// Token: 0x04004669 RID: 18025
		private int drawHis;

		// Token: 0x0400466A RID: 18026
		private int loseHis;

		// Token: 0x0400466B RID: 18027
		private uint ContinueWinHis;
	}
}
