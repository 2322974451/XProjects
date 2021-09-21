using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018D3 RID: 6355
	internal class FriendsWeddingHandler : DlgHandlerBase
	{
		// Token: 0x17003A65 RID: 14949
		// (get) Token: 0x06010902 RID: 67842 RVA: 0x004138A0 File Offset: 0x00411AA0
		protected override string FileName
		{
			get
			{
				return "GameSystem/Wedding/FriendsWeddingFrame";
			}
		}

		// Token: 0x06010903 RID: 67843 RVA: 0x004138B8 File Offset: 0x00411AB8
		protected override void Init()
		{
			base.Init();
			this.m_doc.View = this;
			this.m_emptyGo = base.PanelObject.transform.FindChild("Bg/Empty").gameObject;
			this.m_obtainedGo = base.PanelObject.transform.FindChild("Bg/Obtained").gameObject;
			Transform transform = this.m_emptyGo.transform.FindChild("PartnerPrior/Grid");
			this.m_emptyItemPool.SetupPool(transform.gameObject, transform.FindChild("Tpl").gameObject, 3U, false);
			this.m_gotoBtn = (this.m_emptyGo.transform.FindChild("ButtonR").GetComponent("XUIButton") as IXUIButton);
			this.m_noPartnerTips = (this.m_emptyGo.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel);
			this.m_ruleLab = (this.m_emptyGo.transform.FindChild("RulePanel/RuleLab").GetComponent("XUILabel") as IXUILabel);
			this.m_weddingTeamBtn = (this.m_emptyGo.transform.FindChild("Buttonf").GetComponent("XUIButton") as IXUIButton);
			this.m_livenessBtn = (this.m_obtainedGo.transform.FindChild("LivenessBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_levelBtn = (this.m_obtainedGo.transform.FindChild("BreakupBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_levelText = (this.m_levelBtn.gameObject.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel);
			this.m_ShopBtn = (this.m_obtainedGo.transform.FindChild("BtnShop").GetComponent("XUIButton") as IXUIButton);
			transform = this.m_obtainedGo.transform.FindChild("ModleParent");
			this.m_itemPool.SetupPool(transform.gameObject, transform.FindChild("Tpl").gameObject, 4U, false);
			this.m_buffName = (base.PanelObject.transform.FindChild("Bg/Obtained/FriendBonusFrame/Active/Buff").GetComponent("XUILabel") as IXUILabel);
			this.m_CloseValueMax = this.m_obtainedGo.transform.FindChild("LoverDetail/Progress/Max").gameObject;
			this.m_CloseValue = (this.m_obtainedGo.transform.FindChild("LoverDetail/Progress/Exp").GetComponent("XUILabel") as IXUILabel);
			this.m_CloseValueHelp = (this.m_obtainedGo.transform.FindChild("LoverDetail/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_CloseValueProgress = (this.m_obtainedGo.transform.FindChild("LoverDetail/Progress").GetComponent("XUIProgress") as IXUIProgress);
			this.m_LoverLevel = (this.m_obtainedGo.transform.FindChild("LoverDetail/Level/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_LoverPrivilegeBtn = (this.m_obtainedGo.transform.FindChild("LoverDetail/Go").GetComponent("XUIButton") as IXUIButton);
			this.m_CloseValueHelpPanel = this.m_obtainedGo.transform.FindChild("Help").gameObject;
			this.m_CloseValueHelpPanel.SetActive(false);
			this.m_HelpClose = (this.m_obtainedGo.transform.FindChild("Help/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_HelpContent = (this.m_obtainedGo.transform.FindChild("Help/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_LoverPrivilegeClose = (this.m_obtainedGo.transform.FindChild("Privilege/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_PrivilegeFrame = this.m_obtainedGo.transform.Find("Privilege").gameObject;
			DlgHandlerBase.EnsureCreate<FriendsWeddingPrivilegeHandler>(ref this.m_PrivilegeHandler, this.m_PrivilegeFrame, null, false);
		}

		// Token: 0x06010904 RID: 67844 RVA: 0x00413CE0 File Offset: 0x00411EE0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_gotoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickGoToBtn));
			this.m_weddingTeamBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWeddingTeamBtn));
			this.m_livenessBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickLivenessBtn));
			this.m_levelBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickLevelBtn));
			this.m_ShopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShopClick));
			this.m_CloseValueHelp.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseValueHelpBtnClicked));
			this.m_LoverPrivilegeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPrivilegeBtnClicked));
			this.m_HelpClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpCloseBtnClicked));
			this.m_LoverPrivilegeClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPrivilegeCloseClicked));
		}

		// Token: 0x06010905 RID: 67845 RVA: 0x00413DD0 File Offset: 0x00411FD0
		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("FriendsWeddingHandler", 1);
			this.m_doc.ReqPartnerDetailInfo();
			this.m_ShopBtn.gameObject.SetActive(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Mall_WeddingLover));
			this.m_HelpContent.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingLoverCloseHelp")));
			this.CheckMarriageLevelUp();
		}

		// Token: 0x06010906 RID: 67846 RVA: 0x00413E4A File Offset: 0x0041204A
		protected override void OnHide()
		{
			base.Return3DAvatarPool();
			base.OnHide();
		}

		// Token: 0x06010907 RID: 67847 RVA: 0x00413E5B File Offset: 0x0041205B
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("FriendsWeddingHandler", 1);
		}

		// Token: 0x06010908 RID: 67848 RVA: 0x00413E72 File Offset: 0x00412072
		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this.m_doc.View = null;
			DlgHandlerBase.EnsureUnload<FriendsWeddingPrivilegeHandler>(ref this.m_PrivilegeHandler);
			this.m_PrivilegeHandler = null;
			base.OnUnload();
		}

		// Token: 0x06010909 RID: 67849 RVA: 0x00413EA4 File Offset: 0x004120A4
		private void FillContent()
		{
			this.m_emptyGo.SetActive(false);
			this.m_obtainedGo.SetActive(false);
			bool flag = this.m_doc.PartnerList.Count == 0;
			if (flag)
			{
				this.FillNoPartner();
			}
			else
			{
				this.m_doc.ReqPartnerDetailInfo();
			}
		}

		// Token: 0x0601090A RID: 67850 RVA: 0x00413EF8 File Offset: 0x004120F8
		public void RefreshUi()
		{
			this.m_emptyGo.SetActive(false);
			this.m_obtainedGo.SetActive(false);
			bool flag = this.m_doc.PartnerList.Count == 0;
			if (flag)
			{
				this.FillNoPartner();
			}
			else
			{
				this.FillHadPartner();
			}
		}

		// Token: 0x0601090B RID: 67851 RVA: 0x00413F48 File Offset: 0x00412148
		private void FillNoPartner()
		{
			this.m_emptyGo.SetActive(true);
			this.m_emptyItemPool.ReturnAll(false);
			string[] array = XSingleton<XStringTable>.singleton.GetString("WeddingWelfare").Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < array.Length; i++)
			{
				GameObject gameObject = this.m_emptyItemPool.FetchGameObject(false);
				gameObject.SetActive(true);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)i * this.m_emptyItemPool.TplHeight), 0f);
				IXUILabel ixuilabel = gameObject.transform.FindChild("Tip").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(array[i]));
			}
			this.m_ruleLab.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingRule")));
			this.m_noPartnerTips.SetText(XSingleton<XStringTable>.singleton.GetString("NoWeddingTips"));
		}

		// Token: 0x0601090C RID: 67852 RVA: 0x0041405C File Offset: 0x0041225C
		private void FillHadPartner()
		{
			this.m_obtainedGo.SetActive(true);
			this.RefreshUIRedPoint();
			this.m_itemPool.ReturnAll(false);
			int num = 0;
			for (int i = 0; i < this.m_doc.PartnerList.Count; i++)
			{
				GameObject gameObject = this.m_itemPool.FetchGameObject(false);
				gameObject.SetActive(true);
				gameObject.transform.localPosition = new Vector3((float)(this.m_itemPool.TplWidth * num), 0f, 0f);
				this.FillAvataItem(gameObject, this.m_doc.PartnerList[i], num);
				num++;
			}
			base.Return3DAvatarPool();
			base.Alloc3DAvatarPool("PartnerMainHandler", 1);
			int j = this.m_doc.PartnerList.Count;
			int num2 = this.m_Snapshots.Length;
			while (j < num2)
			{
				this.m_Snapshots[j] = null;
				j++;
			}
			this.RefreshAvataData();
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			int dayCount = specificDocument.GetDayCount(TeamLevelType.TeamLevelWedding, null);
			int dayMaxCount = specificDocument.GetDayMaxCount(TeamLevelType.TeamLevelWedding, null);
			this.m_levelText.SetText(XStringDefineProxy.GetString("WeddingLevel", new object[]
			{
				dayCount,
				dayMaxCount
			}));
			WeddingType myWeddingType = XWeddingDocument.Doc.GetMyWeddingType();
			string[] array = null;
			WeddingType weddingType = myWeddingType;
			if (weddingType != WeddingType.WeddingType_Normal)
			{
				if (weddingType == WeddingType.WeddingType_Luxury)
				{
					array = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("PartnerSkill2", XGlobalConfig.SequenceSeparator);
				}
			}
			else
			{
				array = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("PartnerSkill", XGlobalConfig.SequenceSeparator);
			}
			bool flag = array != null && array.Length == 2;
			if (flag)
			{
				BuffTable.RowData buffData = XSingleton<XBuffTemplateManager>.singleton.GetBuffData(int.Parse(array[0]), int.Parse(array[1]));
				bool flag2 = buffData != null;
				if (flag2)
				{
					this.m_buffName.SetText(buffData.BuffName);
				}
			}
			this.RefreshMarriageLevelValue();
		}

		// Token: 0x0601090D RID: 67853 RVA: 0x00414264 File Offset: 0x00412464
		private void FillAvataItem(GameObject go, RoleOutLookBrief partner, int count)
		{
			bool flag = partner == null || go == null || partner == null;
			if (!flag)
			{
				IXUISprite ixuisprite = go.transform.FindChild("ProfIcon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)((int)partner.profession % 10)));
				IXUILabel ixuilabel = go.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(partner.name);
				ixuilabel = (go.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(partner.level.ToString());
				ixuilabel = (go.transform.FindChild("Battlepoint").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(partner.ppt.ToString());
				ixuisprite = (go.transform.FindChild("Bg/BgSmall").GetComponent("XUISprite") as IXUISprite);
				ixuisprite.ID = partner.roleid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickavata));
				this.m_Snapshots[count] = (go.transform.FindChild("Snapshot").GetComponent("UIDummy") as IUIDummy);
			}
		}

		// Token: 0x0601090E RID: 67854 RVA: 0x004143C8 File Offset: 0x004125C8
		private void RefreshAvataData()
		{
			int num = 0;
			for (int i = 0; i < this.m_doc.PartnerList.Count; i++)
			{
				bool flag = num >= XWeddingDocument.MaxAvata;
				if (flag)
				{
					break;
				}
				bool flag2 = this.m_Snapshots[num] != null;
				if (flag2)
				{
					XDummy xdummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonRoleDummy(this.m_dummPool, this.m_doc.PartnerList[i].roleid, (uint)XFastEnumIntEqualityComparer<RoleType>.ToInt(this.m_doc.PartnerList[i].profession), this.m_doc.PartnerList[i].outlook, this.m_Snapshots[num], null);
					num++;
				}
			}
		}

		// Token: 0x0601090F RID: 67855 RVA: 0x0041448C File Offset: 0x0041268C
		public void RefreshUIRedPoint()
		{
			this.m_livenessBtn.gameObject.transform.FindChild("RedPoint").gameObject.SetActive(this.m_doc.IsHadLivenessRedPoint);
		}

		// Token: 0x06010910 RID: 67856 RVA: 0x004144C0 File Offset: 0x004126C0
		public void CheckMarriageLevelUp()
		{
			bool flag = this.m_doc.MarriageLevelUp > 0;
			if (flag)
			{
				MarriageLevel.RowData byLevel = XWeddingDocument.MarriageLevelTable.GetByLevel(this.m_doc.MarriageLevelUp);
				bool flag2 = byLevel != null;
				if (flag2)
				{
					bool flag3 = byLevel.PrerogativeID != 0U || byLevel.PrivilegeBuffs[0] > 0U;
					if (flag3)
					{
						DlgBase<FriendsWeddingLevelUpView, FriendsWeddingLevelUpBehaviour>.singleton.SetVisible(true, true);
					}
				}
			}
		}

		// Token: 0x06010911 RID: 67857 RVA: 0x00414530 File Offset: 0x00412730
		public void RefreshMarriageLevelValue()
		{
			bool flag = this.m_doc.MarriageLevel != null;
			if (flag)
			{
				int key = this.m_doc.MarriageLevel.marriageLevel + 1;
				MarriageLevel.RowData byLevel = XWeddingDocument.MarriageLevelTable.GetByLevel(key);
				bool flag2 = byLevel != null;
				if (flag2)
				{
					this.m_CloseValueMax.SetActive(false);
					this.m_CloseValue.gameObject.SetActive(true);
					this.m_CloseValue.SetText(string.Format("{0}/{1}", this.m_doc.MarriageLevel.marriageLevelValue, byLevel.NeedIntimacyValue));
					this.m_CloseValueProgress.value = ((byLevel.NeedIntimacyValue == 0) ? 1f : ((float)this.m_doc.MarriageLevel.marriageLevelValue / (float)byLevel.NeedIntimacyValue));
				}
				else
				{
					this.m_CloseValueMax.SetActive(true);
					this.m_CloseValue.gameObject.SetActive(false);
					this.m_CloseValueProgress.value = 1f;
				}
				this.m_LoverLevel.SetText(string.Format("{0}/{1}", this.m_doc.MarriageLevel.marriageLevel, XWeddingDocument.MaxMarriageLevel));
			}
		}

		// Token: 0x06010912 RID: 67858 RVA: 0x00414674 File Offset: 0x00412874
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
					bool flag2 = npcInfo.Table[i].LinkSystem == 702;
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

		// Token: 0x06010913 RID: 67859 RVA: 0x0041473C File Offset: 0x0041293C
		private bool OnWeddingTeamBtn(IXUIButton btn)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(XSingleton<XGlobalConfig>.singleton.GetInt("WeddingTeamLevel"));
			return true;
		}

		// Token: 0x06010914 RID: 67860 RVA: 0x00414770 File Offset: 0x00412970
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
				DlgBase<LoversLivenessDlg, LoversLivenessBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				result = true;
			}
			return result;
		}

		// Token: 0x06010915 RID: 67861 RVA: 0x004147A4 File Offset: 0x004129A4
		private bool OnClickLevelBtn(IXUIButton btn)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(XSingleton<XGlobalConfig>.singleton.GetInt("WeddingLevel"));
			return true;
		}

		// Token: 0x06010916 RID: 67862 RVA: 0x004147D8 File Offset: 0x004129D8
		private void OnClickavata(IXUISprite sp)
		{
			bool flag = sp == null;
			if (!flag)
			{
				ulong id = sp.ID;
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
			}
		}

		// Token: 0x06010917 RID: 67863 RVA: 0x00414800 File Offset: 0x00412A00
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

		// Token: 0x06010918 RID: 67864 RVA: 0x00414838 File Offset: 0x00412A38
		private bool OnShopClick(IXUIButton btn)
		{
			DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_Mall_WeddingLover, 0UL);
			return true;
		}

		// Token: 0x06010919 RID: 67865 RVA: 0x00414860 File Offset: 0x00412A60
		private bool OnCloseValueHelpBtnClicked(IXUIButton btn)
		{
			this.m_CloseValueHelpPanel.SetActive(true);
			return true;
		}

		// Token: 0x0601091A RID: 67866 RVA: 0x00414880 File Offset: 0x00412A80
		private bool OnHelpCloseBtnClicked(IXUIButton btn)
		{
			this.m_CloseValueHelpPanel.SetActive(false);
			return true;
		}

		// Token: 0x0601091B RID: 67867 RVA: 0x004148A0 File Offset: 0x00412AA0
		private bool OnPrivilegeCloseClicked(IXUIButton btn)
		{
			this.m_PrivilegeHandler.SetVisible(false);
			return false;
		}

		// Token: 0x0601091C RID: 67868 RVA: 0x004148C0 File Offset: 0x00412AC0
		private bool OnPrivilegeBtnClicked(IXUIButton btn)
		{
			this.m_PrivilegeHandler.SetVisible(true);
			return true;
		}

		// Token: 0x04007812 RID: 30738
		private XWeddingDocument m_doc = XWeddingDocument.Doc;

		// Token: 0x04007813 RID: 30739
		private IUIDummy[] m_Snapshots = new IUIDummy[XWeddingDocument.MaxAvata];

		// Token: 0x04007814 RID: 30740
		private float m_fCoolTime = 0.5f;

		// Token: 0x04007815 RID: 30741
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x04007816 RID: 30742
		private GameObject m_emptyGo;

		// Token: 0x04007817 RID: 30743
		private GameObject m_obtainedGo;

		// Token: 0x04007818 RID: 30744
		private IXUIButton m_gotoBtn;

		// Token: 0x04007819 RID: 30745
		private IXUILabel m_noPartnerTips;

		// Token: 0x0400781A RID: 30746
		private IXUILabel m_ruleLab;

		// Token: 0x0400781B RID: 30747
		private XUIPool m_emptyItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400781C RID: 30748
		private IXUIButton m_ShopBtn;

		// Token: 0x0400781D RID: 30749
		private IXUIButton m_livenessBtn;

		// Token: 0x0400781E RID: 30750
		private IXUIButton m_levelBtn;

		// Token: 0x0400781F RID: 30751
		private IXUILabel m_levelText;

		// Token: 0x04007820 RID: 30752
		private IXUIButton m_weddingTeamBtn;

		// Token: 0x04007821 RID: 30753
		private IXUILabel m_buffName;

		// Token: 0x04007822 RID: 30754
		private XUIPool m_itemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007823 RID: 30755
		private IXUILabel m_CloseValue;

		// Token: 0x04007824 RID: 30756
		private GameObject m_CloseValueMax;

		// Token: 0x04007825 RID: 30757
		private IXUIButton m_CloseValueHelp;

		// Token: 0x04007826 RID: 30758
		private IXUIProgress m_CloseValueProgress;

		// Token: 0x04007827 RID: 30759
		private GameObject m_CloseValueHelpPanel;

		// Token: 0x04007828 RID: 30760
		private IXUIButton m_HelpClose;

		// Token: 0x04007829 RID: 30761
		private IXUILabel m_HelpContent;

		// Token: 0x0400782A RID: 30762
		private IXUILabel m_LoverLevel;

		// Token: 0x0400782B RID: 30763
		private IXUIButton m_LoverPrivilegeBtn;

		// Token: 0x0400782C RID: 30764
		private IXUIButton m_LoverPrivilegeClose;

		// Token: 0x0400782D RID: 30765
		private GameObject m_PrivilegeFrame;

		// Token: 0x0400782E RID: 30766
		private FriendsWeddingPrivilegeHandler m_PrivilegeHandler;
	}
}
