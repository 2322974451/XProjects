using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017F9 RID: 6137
	internal class ProfessionChangeDlg : DlgBase<ProfessionChangeDlg, ProfessionChangeBehaviour>
	{
		// Token: 0x170038E1 RID: 14561
		// (get) Token: 0x0600FE85 RID: 65157 RVA: 0x003BD8C0 File Offset: 0x003BBAC0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038E2 RID: 14562
		// (get) Token: 0x0600FE86 RID: 65158 RVA: 0x003BD8D4 File Offset: 0x003BBAD4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038E3 RID: 14563
		// (get) Token: 0x0600FE87 RID: 65159 RVA: 0x003BD8E8 File Offset: 0x003BBAE8
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038E4 RID: 14564
		// (get) Token: 0x0600FE88 RID: 65160 RVA: 0x003BD8FC File Offset: 0x003BBAFC
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170038E5 RID: 14565
		// (get) Token: 0x0600FE89 RID: 65161 RVA: 0x003BD910 File Offset: 0x003BBB10
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170038E6 RID: 14566
		// (get) Token: 0x0600FE8A RID: 65162 RVA: 0x003BD924 File Offset: 0x003BBB24
		public override string fileName
		{
			get
			{
				return "GameSystem/ProfessionChangeDlg";
			}
		}

		// Token: 0x170038E7 RID: 14567
		// (get) Token: 0x0600FE8B RID: 65163 RVA: 0x003BD93C File Offset: 0x003BBB3C
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_ProfessionChange);
			}
		}

		// Token: 0x0600FE8C RID: 65164 RVA: 0x003BD958 File Offset: 0x003BBB58
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XProfessionChangeDocument>(XProfessionChangeDocument.uuID);
			base.uiBehaviour.m_TipsWindow.SetActive(false);
			this.SetupTabs();
			this._init = true;
		}

		// Token: 0x0600FE8D RID: 65165 RVA: 0x003BD994 File Offset: 0x003BBB94
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_TipsClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTipsWindowCloseBtnClick));
			base.uiBehaviour.m_ChangeProfBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnChangeProfBtnClick));
			base.uiBehaviour.m_TryProfBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnExperienceBtnClick));
			base.uiBehaviour.m_GetPathBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGetPathBtnClick));
			base.uiBehaviour.m_OKBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSureChangeProfBtnClick));
		}

		// Token: 0x0600FE8E RID: 65166 RVA: 0x003BDA58 File Offset: 0x003BBC58
		protected override void OnShow()
		{
			base.OnShow();
			bool init = this._init;
			if (init)
			{
				this._init = false;
			}
			else
			{
				base.uiBehaviour.m_Texture.SetTexturePath(this._texPath);
			}
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				int num = this._doc.LastExperienceProfID;
				int num2 = (int)(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % 10U);
				bool flag2 = num2 < this._doc.LastExperienceProfID;
				if (flag2)
				{
					num--;
				}
				for (int i = XGame.RoleCount - 2; i >= 0; i--)
				{
					Transform transform = base.uiBehaviour.transform.Find(string.Format("Bg/Tabs/item{0}", i));
					bool flag3 = transform != null;
					if (flag3)
					{
						IXUICheckBox ixuicheckBox = transform.GetComponent("XUICheckBox") as IXUICheckBox;
						bool flag4 = ixuicheckBox != null;
						if (flag4)
						{
							ixuicheckBox.bChecked = (i == num - 1);
						}
					}
				}
				this._doc.LastExperienceProfID = 1;
			}
		}

		// Token: 0x0600FE8F RID: 65167 RVA: 0x003BDB75 File Offset: 0x003BBD75
		protected override void OnHide()
		{
			base.uiBehaviour.m_Texture.SetTexturePath("");
			base.OnHide();
		}

		// Token: 0x0600FE90 RID: 65168 RVA: 0x003BDB95 File Offset: 0x003BBD95
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FE91 RID: 65169 RVA: 0x003BDB9F File Offset: 0x003BBD9F
		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
		}

		// Token: 0x0600FE92 RID: 65170 RVA: 0x003BDBA9 File Offset: 0x003BBDA9
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600FE93 RID: 65171 RVA: 0x003BDBB4 File Offset: 0x003BBDB4
		private void SetupTabs()
		{
			base.uiBehaviour.m_TabPool.ReturnAll(false);
			int num = (int)(XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % 10U);
			Vector3 tplPos = base.uiBehaviour.m_TabPool.TplPos;
			IXUICheckBox ixuicheckBox = null;
			int num2 = 0;
			for (int i = 0; i < XGame.RoleCount; i++)
			{
				bool flag = i + 1 == num;
				if (!flag)
				{
					GameObject gameObject = base.uiBehaviour.m_TabPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(num2 * base.uiBehaviour.m_TabPool.TplHeight));
					num2++;
					IXUICheckBox ixuicheckBox2 = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox2.ID = (ulong)((long)i + 1L);
					ixuicheckBox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabClick));
					bool flag2 = ixuicheckBox == null;
					if (flag2)
					{
						ixuicheckBox = ixuicheckBox2;
					}
					IXUILabel ixuilabel = gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.Find("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(i + 1));
					ixuilabel2.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(i + 1));
				}
			}
			ixuicheckBox.bChecked = true;
		}

		// Token: 0x0600FE94 RID: 65172 RVA: 0x003BDD34 File Offset: 0x003BBF34
		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600FE95 RID: 65173 RVA: 0x003BDD50 File Offset: 0x003BBF50
		private bool OnTipsWindowCloseBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_TipsWindow.SetActive(false);
			return true;
		}

		// Token: 0x0600FE96 RID: 65174 RVA: 0x003BDD78 File Offset: 0x003BBF78
		private bool OnExperienceBtnClick(IXUIButton btn)
		{
			string label = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("ProfessionChangeExperience")), XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._doc.SelectProfession));
			string @string = XStringDefineProxy.GetString("COMMON_OK");
			string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, @string, string2, new ButtonClickEventHandler(this.OnExperienceSure));
			return true;
		}

		// Token: 0x0600FE97 RID: 65175 RVA: 0x003BDDEC File Offset: 0x003BBFEC
		private bool OnExperienceSure(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
			ptcC2G_EnterSceneReq.Data.sceneID = this._doc.SceneID;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
			return true;
		}

		// Token: 0x0600FE98 RID: 65176 RVA: 0x003BDE38 File Offset: 0x003BC038
		private bool OnChangeProfBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_TipsWindow.SetActive(true);
			string @string = XStringDefineProxy.GetString(string.Format("ProfessionChangeType{0}", this._doc.SelectProfession));
			base.uiBehaviour.m_TipsType.SetText(string.Format(XStringDefineProxy.GetString("ProfessionChangeTips"), @string));
			base.uiBehaviour.m_TipsDesc.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("ProfessionChangeDesc")));
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("ProfessionChangeUseItem", true);
			int num = (int)XBagDocument.BagDoc.GetItemCount(sequenceList[0, 0]);
			base.uiBehaviour.m_TipsUse.SetText(string.Format("{0}{1}[-]/{2}", num, (num < sequenceList[0, 1]) ? "[ff3e3e]" : "[ffffff]", sequenceList[0, 1]));
			base.uiBehaviour.m_GetPathBtn.ID = (ulong)((long)sequenceList[0, 0]);
			return true;
		}

		// Token: 0x0600FE99 RID: 65177 RVA: 0x001AE886 File Offset: 0x001ACA86
		private void OnGetPathBtnClick(IXUISprite btn)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)btn.ID, null);
		}

		// Token: 0x0600FE9A RID: 65178 RVA: 0x003BDF48 File Offset: 0x003BC148
		private bool OnSureChangeProfBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_TipsWindow.SetActive(false);
			for (int i = 0; i < XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo.Count; i++)
			{
				RoleBriefInfo roleBriefInfo = XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo[i];
				bool flag = roleBriefInfo == null;
				if (!flag)
				{
					bool flag2 = XFastEnumIntEqualityComparer<RoleType>.ToInt(roleBriefInfo.type) % 10 == this._doc.SelectProfession;
					if (flag2)
					{
						string format = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("ProfessionChangeCoverTips"));
						string label = string.Format(format, roleBriefInfo.level, XSingleton<XProfessionSkillMgr>.singleton.GetProfName(XFastEnumIntEqualityComparer<RoleType>.ToInt(roleBriefInfo.type)), roleBriefInfo.name);
						string @string = XStringDefineProxy.GetString("COMMON_OK");
						string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
						XSingleton<UiUtility>.singleton.ShowModalDialog(label, @string, string2, new ButtonClickEventHandler(this.OnSureCoverBtnClick));
						return true;
					}
				}
			}
			this._doc.QueryChangeProfession();
			return true;
		}

		// Token: 0x0600FE9B RID: 65179 RVA: 0x003BE070 File Offset: 0x003BC270
		private bool OnSureCoverBtnClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.QueryChangeProfession();
			return true;
		}

		// Token: 0x0600FE9C RID: 65180 RVA: 0x003BE09C File Offset: 0x003BC29C
		private bool OnTabClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int profID = (int)icb.ID;
				this._doc.SelectProfession = (int)icb.ID;
				XSingleton<XDebug>.singleton.AddGreenLog("current select profession = ", this._doc.SelectProfession.ToString(), null, null, null, null);
				base.uiBehaviour.m_ProfName.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName(profID));
				base.uiBehaviour.m_ProfIcon.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profID);
				base.uiBehaviour.m_Desc.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XProfessionSkillMgr>.singleton.GetProfDesc(profID)));
				base.uiBehaviour.m_TextScrollView.SetPosition(0f);
				base.uiBehaviour.m_StarPool.ReturnAll(false);
				uint profOperateLevel = XSingleton<XProfessionSkillMgr>.singleton.GetProfOperateLevel(profID);
				Vector3 tplPos = base.uiBehaviour.m_StarPool.TplPos;
				int num = 0;
				while ((long)num < (long)((ulong)profOperateLevel))
				{
					GameObject gameObject = base.uiBehaviour.m_StarPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(num * base.uiBehaviour.m_StarPool.TplWidth), tplPos.y);
					num++;
				}
				string profPic = XSingleton<XProfessionSkillMgr>.singleton.GetProfPic(profID);
				this._texPath = string.Format("{0}/{1}", this.TEXPATH, profPic);
				base.uiBehaviour.m_Texture.SetTexturePath(this._texPath);
				result = true;
			}
			return result;
		}

		// Token: 0x0400706B RID: 28779
		private XProfessionChangeDocument _doc = null;

		// Token: 0x0400706C RID: 28780
		private readonly string TEXPATH = "atlas/UI/common/ProfPic";

		// Token: 0x0400706D RID: 28781
		private string _texPath = "";

		// Token: 0x0400706E RID: 28782
		private bool _init;
	}
}
