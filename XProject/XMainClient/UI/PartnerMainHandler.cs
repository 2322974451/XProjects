using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017F3 RID: 6131
	internal class PartnerMainHandler : DlgHandlerBase
	{
		// Token: 0x170038D8 RID: 14552
		// (get) Token: 0x0600FE2F RID: 65071 RVA: 0x003BB514 File Offset: 0x003B9714
		protected override string FileName
		{
			get
			{
				return "Partner/PartnerFrame";
			}
		}

		// Token: 0x0600FE30 RID: 65072 RVA: 0x003BB52C File Offset: 0x003B972C
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

		// Token: 0x0600FE31 RID: 65073 RVA: 0x003BB7CC File Offset: 0x003B99CC
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

		// Token: 0x0600FE32 RID: 65074 RVA: 0x003BB871 File Offset: 0x003B9A71
		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("PartnerMainHandler", 1);
			this.FillContent();
		}

		// Token: 0x0600FE33 RID: 65075 RVA: 0x003BB88F File Offset: 0x003B9A8F
		protected override void OnHide()
		{
			base.Return3DAvatarPool();
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
		}

		// Token: 0x0600FE34 RID: 65076 RVA: 0x003BB8B1 File Offset: 0x003B9AB1
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("PartnerMainHandler", 1);
		}

		// Token: 0x0600FE35 RID: 65077 RVA: 0x003BB8C8 File Offset: 0x003B9AC8
		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this.m_doc.View = null;
			base.OnUnload();
		}

		// Token: 0x0600FE36 RID: 65078 RVA: 0x003BB8E8 File Offset: 0x003B9AE8
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

		// Token: 0x0600FE37 RID: 65079 RVA: 0x003BB94C File Offset: 0x003B9B4C
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

		// Token: 0x0600FE38 RID: 65080 RVA: 0x003BB9AC File Offset: 0x003B9BAC
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

		// Token: 0x0600FE39 RID: 65081 RVA: 0x003BBACC File Offset: 0x003B9CCC
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

		// Token: 0x0600FE3A RID: 65082 RVA: 0x003BBDD4 File Offset: 0x003B9FD4
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

		// Token: 0x0600FE3B RID: 65083 RVA: 0x003BBF9C File Offset: 0x003BA19C
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

		// Token: 0x0600FE3C RID: 65084 RVA: 0x003BC078 File Offset: 0x003BA278
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

		// Token: 0x0600FE3D RID: 65085 RVA: 0x003BC1DC File Offset: 0x003BA3DC
		public void RefreshUIRedPoint()
		{
			this.m_shopBtn.gameObject.transform.FindChild("RedPoint").gameObject.SetActive(this.m_doc.IsHadShopRedPoint);
			this.m_livenessBtn.gameObject.transform.FindChild("RedPoint").gameObject.SetActive(this.m_doc.IsHadLivenessRedPoint);
		}

		// Token: 0x0600FE3E RID: 65086 RVA: 0x003BC24C File Offset: 0x003BA44C
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

		// Token: 0x0600FE3F RID: 65087 RVA: 0x003BC2C8 File Offset: 0x003BA4C8
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

		// Token: 0x0600FE40 RID: 65088 RVA: 0x003BC310 File Offset: 0x003BA510
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

		// Token: 0x0600FE41 RID: 65089 RVA: 0x003BC3D8 File Offset: 0x003BA5D8
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

		// Token: 0x0600FE42 RID: 65090 RVA: 0x003BC44C File Offset: 0x003BA64C
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

		// Token: 0x0600FE43 RID: 65091 RVA: 0x003BC480 File Offset: 0x003BA680
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

		// Token: 0x0600FE44 RID: 65092 RVA: 0x003BC528 File Offset: 0x003BA728
		private bool BreakUp(IXUIButton btn)
		{
			this.m_doc.ReqLeavePartner();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FE45 RID: 65093 RVA: 0x003BC554 File Offset: 0x003BA754
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

		// Token: 0x0600FE46 RID: 65094 RVA: 0x003BC5B8 File Offset: 0x003BA7B8
		private void OnClickavata(IXUISprite sp)
		{
			bool flag = sp == null;
			if (!flag)
			{
				ulong id = sp.ID;
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
			}
		}

		// Token: 0x0600FE47 RID: 65095 RVA: 0x003BC5E0 File Offset: 0x003BA7E0
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

		// Token: 0x04007040 RID: 28736
		private XPartnerDocument m_doc = XPartnerDocument.Doc;

		// Token: 0x04007041 RID: 28737
		private IUIDummy[] m_Snapshots = new IUIDummy[XPartnerDocument.MaxAvata];

		// Token: 0x04007042 RID: 28738
		private float m_fCoolTime = 0.5f;

		// Token: 0x04007043 RID: 28739
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x04007044 RID: 28740
		private uint m_token;

		// Token: 0x04007045 RID: 28741
		private GameObject m_emptyGo;

		// Token: 0x04007046 RID: 28742
		private GameObject m_obtainedGo;

		// Token: 0x04007047 RID: 28743
		private IXUIButton m_shopBtn;

		// Token: 0x04007048 RID: 28744
		private IXUIButton m_gotoTeamBtn;

		// Token: 0x04007049 RID: 28745
		private IXUIButton m_gotoBtn;

		// Token: 0x0400704A RID: 28746
		private IXUILabel m_noPartnerTips;

		// Token: 0x0400704B RID: 28747
		private IXUILabel m_ruleLab;

		// Token: 0x0400704C RID: 28748
		private XUIPool m_emptyItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400704D RID: 28749
		private Transform m_livenessTra;

		// Token: 0x0400704E RID: 28750
		private IXUIButton m_livenessBtn;

		// Token: 0x0400704F RID: 28751
		private IXUIButton m_breakupBtn;

		// Token: 0x04007050 RID: 28752
		private IXUIButton m_cancleBreakUpBtn;

		// Token: 0x04007051 RID: 28753
		private IXUILabel m_breakUpCutDownLab;

		// Token: 0x04007052 RID: 28754
		private XUIPool m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007053 RID: 28755
		private XTeamPartnerBonusHandler m_FriendBonusHandler = null;
	}
}
