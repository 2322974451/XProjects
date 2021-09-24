using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CareerPVPDataHandler : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "GameSystem/PersonalCareer/CareerPVPData";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this.OnTabChanged(this.m_CurPVPIndex);
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			this.m_HistorySegment.SetTexturePath("");
			this.m_CurSegment.SetTexturePath("");
			DlgHandlerBase.EnsureUnload<XQualifyingRecordsHandler>(ref this.QualifyingRecordsHandler);
			base.OnUnload();
		}

		private void InitInfo()
		{
			this.m_CurTitle.SetText(this.m_TitleName[this.m_CurPVPIndex].GetText());
			this.m_TitleSelected.gameObject.SetActive(false);
		}

		private bool _OpenSelectTitle(IXUIButton btn)
		{
			this.m_TitleSelected.gameObject.SetActive(!this.m_TitleSelected.gameObject.activeSelf);
			return true;
		}

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

		private void CloseAllTab()
		{
			this.m_QualifyPanel.gameObject.SetActive(false);
		}

		public int MatchTotalCount
		{
			get
			{
				return this.win + this.draw + this.lose;
			}
		}

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

		public int HisMatchTotalCount
		{
			get
			{
				return this.winHis + this.drawHis + this.loseHis;
			}
		}

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

		public void SetData(PVPInformation data)
		{
			this.SetData(data.pk_info);
		}

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

		private bool _PushBtnClick(IXUIButton btn)
		{
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.PushClick((ulong)((long)this.m_CurPVPIndex));
			return true;
		}

		private bool _ShareBtnClick(IXUIButton btn)
		{
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.ShareClick();
			return true;
		}

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

		private XPersonalCareerDocument doc = null;

		private int m_CurPVPIndex = 0;

		public string[] PVPSysID = XSingleton<XGlobalConfig>.singleton.GetValue("PersonalCareerPVP").Split(new char[]
		{
			'|'
		});

		public XQualifyingRecordsHandler QualifyingRecordsHandler = null;

		private IXUILabel m_CurTitle;

		private IXUIButton m_CurTitleBtn;

		private Transform m_TitleSelected;

		private IXUILabel[] m_TitleName = new IXUILabel[5];

		private IXUIButton[] m_TitleBtn = new IXUIButton[5];

		private XUIPool m_TitlePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUILabel m_Beyond;

		private IXUILabel m_Score;

		private IXUITexture m_HistorySegment;

		private IXUITexture m_CurSegment;

		private IXUILabel m_ServerRank;

		private IXUILabel m_ProfessionRank;

		private IXUIButton m_PKDetail;

		private Transform m_QualifyPanel;

		private IXUILabel m_Win;

		private IXUILabel m_Lose;

		private IXUILabel m_WinStreak;

		private Transform m_WinRateDetail;

		private List<IXUILabel> m_ProfessionWinRate = new List<IXUILabel>();

		private IXUILabel m_WinRate;

		private IXUISprite m_WinRateProgress;

		private IXUILabel m_TotalCount;

		private IXUIButton m_Push;

		private IXUIButton m_Share;

		private IXUICheckBox m_SeasonTab;

		private IXUICheckBox m_AllTab;

		private int win;

		private int draw;

		private int lose;

		private uint ContinueWin;

		private uint ContinueLose;

		private List<uint> ProfessionWin = new List<uint>();

		private List<PkOneRecord> GameRecords = new List<PkOneRecord>();

		private uint curPoint;

		private uint serverRank;

		private uint professionRank;

		private uint hisPoint;

		private string beyondAll;

		private string texCur;

		private string texHis;

		private int winHis;

		private int drawHis;

		private int loseHis;

		private uint ContinueWinHis;
	}
}
