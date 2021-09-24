using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PVPActivityDlg : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/DailyActivity/PVPActivityFrame";
			}
		}

		protected override void Init()
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XPVPActivityDocument.uuID) as XPVPActivityDocument);
			this.m_ScrollView = (base.PanelObject.transform.Find("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = base.PanelObject.transform.Find("Panel/Tpl");
			this.m_ActivityPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			this.m_FameHallBtn = (base.transform.Find("Down/Btn_MobaFamous").GetComponent("XUIButton") as IXUIButton);
			this.m_FameHallBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickedFameHallBtn));
			this.m_MilitaryRankBtn = (base.PanelObject.transform.Find("Down/Btn_MobaRank").GetComponent("XUIButton") as IXUIButton);
			this.m_MilitaryRankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMilitaryRankBtnClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_MilitaryRankBtn.SetVisible(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_MilitaryRank));
			this.Refresh();
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<UiUtility>.singleton.DestroyTextureInActivePool(this.m_ActivityPool, "Tex");
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.Refresh();
			this.RefreshHallFameBtn();
		}

		private bool OnMilitaryRankBtnClick(IXUIButton btn)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_MilitaryRank);
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_SYS_NOTOPEN"), "fece00");
				result = false;
			}
			else
			{
				int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(XSysDefine.XSys_MilitaryRank);
				bool flag2 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)sysOpenLevel);
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("LEVEL_REQUIRE_LEVEL"), sysOpenLevel), "fece00");
				}
				else
				{
					XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_MilitaryRank, 0UL);
				}
				result = true;
			}
			return result;
		}

		private string GetMissConditionString(PVPActivityList.RowData data)
		{
			XActivityDocument specificDocument = XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID);
			int sysOpenServerDay = XSingleton<XGameSysMgr>.singleton.GetSysOpenServerDay((int)data.SysID);
			bool flag = specificDocument.ServerOpenDay < sysOpenServerDay;
			string result;
			if (flag)
			{
				result = string.Format(XStringDefineProxy.GetString("MulActivity_ServerOpenDay"), sysOpenServerDay - specificDocument.ServerOpenDay);
			}
			else
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null && (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel((int)data.SysID));
				if (flag2)
				{
					int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel((int)data.SysID);
					result = string.Format(XStringDefineProxy.GetString("MulActivity_ShowTips9"), sysOpenLevel);
				}
				else
				{
					result = XStringDefineProxy.GetString("PVPActivityUnOpen");
				}
			}
			return result;
		}

		public void OnPVPActivityClick(IXUISprite iSp)
		{
			XSysDefine xsysDefine = (XSysDefine)iSp.ID;
			PVPActivityList.RowData bySysID = this._doc.PVPActivityTable.GetBySysID((uint)iSp.ID);
			XActivityDocument specificDocument = XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID);
			XFreeTeamVersusLeagueDocument specificDocument2 = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			int sysOpenServerDay = XSingleton<XGameSysMgr>.singleton.GetSysOpenServerDay((int)iSp.ID);
			bool flag = specificDocument.ServerOpenDay < sysOpenServerDay;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("MulActivity_ServerOpenDay"), sysOpenServerDay - specificDocument.ServerOpenDay), "fece00");
			}
			else
			{
				bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(xsysDefine);
				if (flag2)
				{
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null && (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel((int)bySysID.SysID));
					if (flag3)
					{
						int sysid = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(xsysDefine);
						int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(sysid);
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EXPEDITION_REQUIRED_LEVEL", new object[]
						{
							sysOpenLevel
						}) + XSingleton<XGameSysMgr>.singleton.GetSysName(sysid), "fece00");
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PVPActivityUnOpen"), "fece00");
					}
				}
				else
				{
					bool flag4 = xsysDefine == XSysDefine.XSys_TeamLeague && !specificDocument2.IsOpen;
					if (flag4)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("PVPActivityUnOpen"), "fece00");
					}
					else
					{
						XSingleton<XGameSysMgr>.singleton.OpenSystem(xsysDefine, 0UL);
					}
				}
			}
		}

		public void Refresh()
		{
			this.RefreshHallFameBtn();
			this.m_ScrollView.SetPosition(0f);
			this.m_ActivityPool.ReturnAll(false);
			XFreeTeamVersusLeagueDocument specificDocument = XDocuments.GetSpecificDocument<XFreeTeamVersusLeagueDocument>(XFreeTeamVersusLeagueDocument.uuID);
			XActivityDocument specificDocument2 = XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID);
			for (int i = 0; i < this._doc.PVPActivityTable.Table.Length; i++)
			{
				PVPActivityList.RowData rowData = this._doc.PVPActivityTable.Table[i];
				GameObject gameObject = this.m_ActivityPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(this.m_ActivityPool.TplPos.x + (float)(i * this.m_ActivityPool.TplWidth), this.m_ActivityPool.TplPos.y, 0f);
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)rowData.SysID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPVPActivityClick));
				IXUITexture ixuitexture = gameObject.transform.Find("Tex").GetComponent("XUITexture") as IXUITexture;
				IXUILabel ixuilabel = gameObject.transform.Find("Desc").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Go").GetComponent("XUILabel") as IXUILabel;
				GameObject gameObject2 = gameObject.transform.Find("Lock").gameObject;
				GameObject gameObject3 = gameObject.transform.Find("kf").gameObject;
				GameObject gameObject4 = gameObject.transform.Find("RedPoint").gameObject;
				bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)rowData.SysID) && specificDocument2.ServerOpenDay >= XSingleton<XGameSysMgr>.singleton.GetSysOpenServerDay((int)rowData.SysID);
				bool flag2 = true;
				bool flag3 = rowData.SysID == 960U;
				if (flag3)
				{
					flag2 = specificDocument.IsOpen;
				}
				string texturePath = string.Format("{0}{1}", PVPActivityDlg.ATLAS_PATH, rowData.Icon);
				ixuitexture.SetTexturePath(texturePath);
				ixuitexture.SetEnabled(flag && flag2);
				bool flag4 = flag && flag2;
				if (flag4)
				{
					ixuitexture.SetAlpha(1f);
				}
				else
				{
					ixuitexture.SetAlpha(0.7058824f);
				}
				gameObject2.SetActive(!flag);
				gameObject3.SetActive(rowData.SysID == 960U && specificDocument.IsCross);
				bool sysRedPointState = XSingleton<XGameSysMgr>.singleton.GetSysRedPointState((int)rowData.SysID);
				gameObject4.SetActive(sysRedPointState);
				bool flag5 = sysRedPointState;
				if (flag5)
				{
					IXUILabel ixuilabel3 = gameObject4.gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel3.SetText(this.GetLeftCount((XSysDefine)rowData.SysID).ToString());
				}
				bool flag6 = !flag;
				if (flag6)
				{
					ixuilabel2.SetText(this.GetMissConditionString(rowData));
				}
				else
				{
					bool flag7 = !flag2;
					if (flag7)
					{
						ixuilabel2.SetText(XStringDefineProxy.GetString("PVPActivityUnOpen"));
					}
					else
					{
						ixuilabel2.SetText("");
					}
				}
				ixuilabel.SetText(rowData.Description);
			}
		}

		private void RefreshHallFameBtn()
		{
			bool flag = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_HallFame);
			this.m_FameHallBtn.gameObject.SetActive(flag);
			bool flag2 = flag;
			if (flag2)
			{
				Transform transform = this.m_FameHallBtn.gameObject.transform.Find("RedPoint");
				transform.gameObject.SetActive(XHallFameDocument.Doc.CanSupportType.Count > 0);
			}
		}

		private int GetLeftCount(XSysDefine sys)
		{
			XSysDefine xsysDefine = sys;
			if (xsysDefine <= XSysDefine.XSys_CustomBattle)
			{
				if (xsysDefine == XSysDefine.XSys_Qualifying)
				{
					XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
					int @int = XSingleton<XGlobalConfig>.singleton.GetInt("QualifyingFirstRewardCount");
					return Mathf.Max(@int - (int)specificDocument.LeftFirstRewardCount, 0);
				}
				if (xsysDefine == XSysDefine.XSys_CustomBattle)
				{
					XCustomBattleDocument specificDocument2 = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
					return (specificDocument2.BountyModeRedPoint ? 1 : 0) + (specificDocument2.CustomModeRedPoint ? 1 : 0);
				}
			}
			else
			{
				if (xsysDefine == XSysDefine.XSys_WeekNest)
				{
					XExpeditionDocument specificDocument3 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
					return specificDocument3.GetDayCount(TeamLevelType.TeamLevelWeekNest, null);
				}
				if (xsysDefine == XSysDefine.XSys_HeroBattle)
				{
					XHeroBattleDocument specificDocument4 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("HeroBattleSpecialNum");
					return Math.Max(int2 - (int)specificDocument4.JoinToday, 0);
				}
				if (xsysDefine == XSysDefine.XSys_Moba)
				{
					int int3 = XSingleton<XGlobalConfig>.singleton.GetInt("MobaStageNum");
					XMobaEntranceDocument specificDocument5 = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
					return ((ulong)specificDocument5.GetRewardStage < (ulong)((long)int3)) ? 1 : 0;
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("needless pvpactivity count but try to get it. sys = ", sys.ToString(), null, null, null, null);
			return 0;
		}

		private bool OnClickedFameHallBtn(IXUIButton button)
		{
			DlgBase<HallFameDlg, HallFameBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private XPVPActivityDocument _doc;

		public XUIPool m_ActivityPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_ScrollView;

		private IXUIButton m_FameHallBtn;

		private static readonly string ATLAS_PATH = "atlas/UI/GameSystem/Activity/";

		public IXUIButton m_MilitaryRankBtn;
	}
}
