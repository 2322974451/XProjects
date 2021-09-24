using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PartnerMainHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Partner/PartnerFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc.View = this;
			this.m_emptyGo = base.PanelObject.transform.FindChild("Bg/Empty").gameObject;
			this.m_obtainedGo = base.PanelObject.transform.FindChild("Bg/Obtained").gameObject;
			this.m_shopBtn = (base.PanelObject.transform.FindChild("Bg/BtnShop").GetComponent("XUIButton") as IXUIButton);
			Transform transform = this.m_emptyGo.transform.FindChild("PartnerPrior/Grid");
			this.m_emptyItemPool.SetupPool(transform.gameObject, transform.FindChild("Tpl").gameObject, 3U, false);
			this.m_gotoBtn = (this.m_emptyGo.transform.FindChild("ButtonR").GetComponent("XUIButton") as IXUIButton);
			this.m_gotoTeamBtn = (this.m_emptyGo.transform.FindChild("GoTeam").GetComponent("XUIButton") as IXUIButton);
			this.m_noPartnerTips = (this.m_emptyGo.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel);
			this.m_ruleLab = (this.m_emptyGo.transform.FindChild("RuleLab").GetComponent("XUILabel") as IXUILabel);
			this.m_livenessTra = this.m_obtainedGo.transform.FindChild("Bar");
			this.m_livenessBtn = (this.m_obtainedGo.transform.FindChild("LivenessBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_breakupBtn = (this.m_obtainedGo.transform.FindChild("BreakupBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_cancleBreakUpBtn = (this.m_obtainedGo.transform.FindChild("CancleBreakupBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_breakUpCutDownLab = (this.m_obtainedGo.transform.FindChild("BreakUpCutDownLab").GetComponent("XUILabel") as IXUILabel);
			transform = this.m_obtainedGo.transform.FindChild("ModleParent");
			this.m_itemPool.SetupPool(transform.gameObject, transform.FindChild("Tpl").gameObject, 4U, false);
			DlgHandlerBase.EnsureCreate<XTeamPartnerBonusHandler>(ref this.m_FriendBonusHandler, this.m_obtainedGo.transform.Find("FriendBonusFrame").gameObject, this, true);
			this.m_FriendBonusHandler.bConsiderTeam = false;
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_shopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickShopBtn));
			this.m_gotoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGoToBtn));
			this.m_gotoTeamBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGoToTeamBtn));
			this.m_livenessBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickLivenessBtn));
			this.m_breakupBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickbreakupBtn));
			this.m_cancleBreakUpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCancleBreakupBtn));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("PartnerMainHandler", 1);
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.Return3DAvatarPool();
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("PartnerMainHandler", 1);
		}

		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this.m_doc.View = null;
			base.OnUnload();
		}

		private void FillContent()
		{
			this.m_emptyGo.SetActive(false);
			this.m_obtainedGo.SetActive(false);
			this.m_shopBtn.gameObject.SetActive(false);
			bool flag = this.m_doc.PartnerID == 0UL;
			if (flag)
			{
				this.FillNoPartner();
			}
			else
			{
				this.m_doc.ReqPartnerDetailInfo();
			}
		}

		public void RefreshUi()
		{
			this.m_emptyGo.SetActive(false);
			this.m_obtainedGo.SetActive(false);
			this.m_shopBtn.gameObject.SetActive(false);
			bool flag = this.m_doc.PartnerID == 0UL;
			if (flag)
			{
				this.FillNoPartner();
			}
			else
			{
				this.FillHadPartner();
			}
		}

		private void FillNoPartner()
		{
			this.m_emptyGo.SetActive(true);
			this.m_emptyItemPool.ReturnAll(false);
			for (int i = 0; i < XPartnerDocument.PartnerWelfareTab.Table.Length; i++)
			{
				PartnerWelfare.RowData rowData = XPartnerDocument.PartnerWelfareTab.Table[i];
				bool flag = rowData == null;
				if (!flag)
				{
					GameObject gameObject = this.m_emptyItemPool.FetchGameObject(false);
					gameObject.SetActive(true);
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)i * this.m_emptyItemPool.TplHeight), 0f);
					IXUILabel ixuilabel = gameObject.transform.FindChild("Tip").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(rowData.ContentTxt));
				}
			}
			this.m_ruleLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("PartnerRule")));
			this.m_noPartnerTips.SetText(XSingleton<XStringTable>.singleton.GetString("NoPartnerTips"));
		}

		private void FillHadPartner()
		{
			this.m_obtainedGo.SetActive(true);
			this.m_shopBtn.gameObject.SetActive(true);
			this.RefreshUIRedPoint();
			Partner myParnerInfo = this.m_doc.GetMyParnerInfo();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			bool flag = myParnerInfo != null;
			if (flag)
			{
				bool is_apply_leave = myParnerInfo.Detail.is_apply_leave;
				if (is_apply_leave)
				{
					this.m_breakUpCutDownLab.gameObject.SetActive(true);
					this.m_breakUpCutDownLab.SetText(this.GetTimeString((ulong)myParnerInfo.Detail.left_leave_time, XSingleton<XStringTable>.singleton.GetString("BreakPartner")));
					this.m_breakupBtn.gameObject.SetActive(false);
					this.m_cancleBreakUpBtn.gameObject.SetActive(true);
					this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.SetTime), myParnerInfo.Detail.left_leave_time);
				}
				else
				{
					this.m_breakUpCutDownLab.gameObject.SetActive(false);
					this.m_breakupBtn.gameObject.SetActive(true);
					this.m_cancleBreakUpBtn.gameObject.SetActive(false);
				}
			}
			IXUISlider ixuislider = this.m_livenessTra.FindChild("slider").GetComponent("XUISlider") as IXUISlider;
			IXUILabel ixuilabel = this.m_livenessTra.FindChild("slider/PLabel").GetComponent("XUILabel") as IXUILabel;
			float num = (this.m_doc.CurLevelMaxExp == 0f) ? 1U : this.m_doc.CurLevelMaxExp;
			ixuislider.Value = this.m_doc.Degree / num;
			ixuilabel.SetText(string.Format("{0}/{1}", this.m_doc.Degree, this.m_doc.CurLevelMaxExp));
			this.m_FriendBonusHandler.RefreshData();
			this.m_itemPool.ReturnAll(false);
			int num2 = 0;
			foreach (KeyValuePair<ulong, Partner> keyValuePair in this.m_doc.PartnerDic)
			{
				GameObject gameObject = this.m_itemPool.FetchGameObject(false);
				gameObject.SetActive(true);
				gameObject.transform.localPosition = new Vector3((float)(this.m_itemPool.TplWidth * num2), 0f, 0f);
				this.FillAvataItem(gameObject, keyValuePair.Value, num2);
				num2++;
			}
			base.Return3DAvatarPool();
			base.Alloc3DAvatarPool("PartnerMainHandler", 1);
			int i = this.m_doc.PartnerDic.Count;
			int num3 = this.m_Snapshots.Length;
			while (i < num3)
			{
				this.m_Snapshots[i] = null;
				i++;
			}
			this.RefreshAvataData();
		}

		private void FillAvataItem(GameObject go, Partner partner, int count)
		{
			bool flag = partner == null || go == null || partner.Detail == null;
			if (!flag)
			{
				IXUISprite ixuisprite = go.transform.FindChild("ProfIcon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)((int)partner.Detail.profession % (int)(RoleType)10)));
				IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(partner.Detail.name);
				ixuilabel = (go.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(partner.Detail.level.ToString());
				ixuilabel = (go.transform.FindChild("Battlepoint").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(partner.Detail.ppt.ToString());
				bool is_apply_leave = partner.Detail.is_apply_leave;
				if (is_apply_leave)
				{
					go.transform.FindChild("Breakup").gameObject.SetActive(true);
				}
				else
				{
					go.transform.FindChild("Breakup").gameObject.SetActive(false);
				}
				ixuisprite = (go.transform.FindChild("Bg/BgSmall").GetComponent("XUISprite") as IXUISprite);
				ixuisprite.ID = partner.MemberId;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickavata));
				this.m_Snapshots[count] = (go.transform.FindChild("Snapshot").GetComponent("UIDummy") as IUIDummy);
			}
		}

		private void RefreshAvataData()
		{
			int num = 0;
			foreach (KeyValuePair<ulong, Partner> keyValuePair in this.m_doc.PartnerDic)
			{
				bool flag = num >= XPartnerDocument.MaxAvata;
				if (flag)
				{
					break;
				}
				bool flag2 = this.m_Snapshots[num] != null;
				if (flag2)
				{
					XDummy xdummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonRoleDummy(this.m_dummPool, keyValuePair.Value.Detail.memberid, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(keyValuePair.Value.Detail.profession), keyValuePair.Value.Detail.outlook, this.m_Snapshots[num], null);
					num++;
				}
			}
		}

		private string GetTimeString(ulong ti, string str)
		{
			bool flag = ti < 60UL;
			string result;
			if (flag)
			{
				string arg = string.Format("{0}{1}", ti, XStringDefineProxy.GetString("SECOND_DUARATION"));
				result = string.Format(str, arg);
			}
			else
			{
				ulong num = ti / 60UL;
				ulong num2 = ti % 60UL;
				bool flag2 = num < 60UL;
				string arg;
				if (flag2)
				{
					bool flag3 = num2 > 0UL;
					if (flag3)
					{
						arg = string.Format("{0}{1}{2}{3}", new object[]
						{
							num,
							XStringDefineProxy.GetString("MINUTE_DUARATION"),
							num2,
							XStringDefineProxy.GetString("SECOND_DUARATION")
						});
					}
					else
					{
						arg = string.Format("{0}{1}", num, XStringDefineProxy.GetString("MINUTE_DUARATION"));
					}
				}
				else
				{
					bool flag4 = num2 > 0UL;
					if (flag4)
					{
						num += 1UL;
					}
					ulong num3 = num / 60UL;
					num %= 60UL;
					bool flag5 = num > 0UL;
					if (flag5)
					{
						arg = string.Format("{0}{1}{2}{3}", new object[]
						{
							num3,
							XStringDefineProxy.GetString("HOUR_DUARATION"),
							num,
							XStringDefineProxy.GetString("MINUTE_DUARATION")
						});
					}
					else
					{
						arg = string.Format("{0}{1}", num3, XStringDefineProxy.GetString("HOUR_DUARATION"));
					}
				}
				result = string.Format(str, arg);
			}
			return result;
		}

		public void RefreshUIRedPoint()
		{
			this.m_shopBtn.gameObject.transform.FindChild("RedPoint").gameObject.SetActive(this.m_doc.IsHadShopRedPoint);
			this.m_livenessBtn.gameObject.transform.FindChild("RedPoint").gameObject.SetActive(this.m_doc.IsHadLivenessRedPoint);
		}

		public void SetTime(object o = null)
		{
			uint num = (uint)o;
			this.m_breakUpCutDownLab.SetText(this.GetTimeString((ulong)num, XSingleton<XStringTable>.singleton.GetString("BreakPartner")));
			bool flag = num == 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			}
			num -= 1U;
			this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.SetTime), num);
		}

		private bool OnClickShopBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_doc.IsHadShopRedPoint = false;
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_Partner, 0UL);
				result = true;
			}
			return result;
		}

		private bool OnClickGoToBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XSingleton<UIManager>.singleton.CloseAllUI();
				uint num = 0U;
				XNpcInfo npcInfo = XSingleton<XEntityMgr>.singleton.NpcInfo;
				for (int i = 0; i < npcInfo.Table.Length; i++)
				{
					bool flag2 = npcInfo.Table[i].LinkSystem == 700;
					if (flag2)
					{
						num = npcInfo.Table[i].ID;
						break;
					}
				}
				bool flag3 = num == 0U;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("had not find partner npc", null, null, null, null, null);
					result = true;
				}
				else
				{
					XSingleton<XInput>.singleton.LastNpc = XSingleton<XEntityMgr>.singleton.GetNpc(num);
					result = true;
				}
			}
			return result;
		}

		private bool OnClickGoToTeamBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(TeamLevelType.TeamLevelPartner);
				bool flag2 = expeditionList != null && expeditionList.Count > 0;
				if (flag2)
				{
					XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
					specificDocument2.SetAndMatch(expeditionList[0].DNExpeditionID);
				}
				result = true;
			}
			return result;
		}

		private bool OnClickLivenessBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgBase<PartnerLivenessDlg, PartnerLivenessBehaviour>.singleton.SetVisible(true, true);
				result = true;
			}
			return result;
		}

		private bool OnClickbreakupBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				Partner myParnerInfo = this.m_doc.GetMyParnerInfo();
				bool flag2 = myParnerInfo == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool is_apply_leave = myParnerInfo.Detail.is_apply_leave;
					if (is_apply_leave)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("IsLeavingPartner"), "fece00");
						result = true;
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("SureBreakUpPartner"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.BreakUp));
						result = true;
					}
				}
			}
			return result;
		}

		private bool BreakUp(IXUIButton btn)
		{
			this.m_doc.ReqLeavePartner();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private bool OnClickCancleBreakupBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				Partner myParnerInfo = this.m_doc.GetMyParnerInfo();
				bool flag2 = myParnerInfo == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = !myParnerInfo.Detail.is_apply_leave;
					if (flag3)
					{
						result = true;
					}
					else
					{
						this.m_doc.ReqCancleLeavePartner();
						result = true;
					}
				}
			}
			return result;
		}

		private void OnClickavata(IXUISprite sp)
		{
			bool flag = sp == null;
			if (!flag)
			{
				ulong id = sp.ID;
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
			}
		}

		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		private XPartnerDocument m_doc = XPartnerDocument.Doc;

		private IUIDummy[] m_Snapshots = new IUIDummy[XPartnerDocument.MaxAvata];

		private float m_fCoolTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;

		private uint m_token;

		private GameObject m_emptyGo;

		private GameObject m_obtainedGo;

		private IXUIButton m_shopBtn;

		private IXUIButton m_gotoTeamBtn;

		private IXUIButton m_gotoBtn;

		private IXUILabel m_noPartnerTips;

		private IXUILabel m_ruleLab;

		private XUIPool m_emptyItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_livenessTra;

		private IXUIButton m_livenessBtn;

		private IXUIButton m_breakupBtn;

		private IXUIButton m_cancleBreakUpBtn;

		private IXUILabel m_breakUpCutDownLab;

		private XUIPool m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XTeamPartnerBonusHandler m_FriendBonusHandler = null;
	}
}
