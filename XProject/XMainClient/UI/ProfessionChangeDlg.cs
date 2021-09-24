using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ProfessionChangeDlg : DlgBase<ProfessionChangeDlg, ProfessionChangeBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/ProfessionChangeDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_ProfessionChange);
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XProfessionChangeDocument>(XProfessionChangeDocument.uuID);
			base.uiBehaviour.m_TipsWindow.SetActive(false);
			this.SetupTabs();
			this._init = true;
		}

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

		protected override void OnHide()
		{
			base.uiBehaviour.m_Texture.SetTexturePath("");
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

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

		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnTipsWindowCloseBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_TipsWindow.SetActive(false);
			return true;
		}

		private bool OnExperienceBtnClick(IXUIButton btn)
		{
			string label = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("ProfessionChangeExperience")), XSingleton<XProfessionSkillMgr>.singleton.GetProfName(this._doc.SelectProfession));
			string @string = XStringDefineProxy.GetString("COMMON_OK");
			string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
			XSingleton<UiUtility>.singleton.ShowModalDialog(label, @string, string2, new ButtonClickEventHandler(this.OnExperienceSure));
			return true;
		}

		private bool OnExperienceSure(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			PtcC2G_EnterSceneReq ptcC2G_EnterSceneReq = new PtcC2G_EnterSceneReq();
			ptcC2G_EnterSceneReq.Data.sceneID = this._doc.SceneID;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_EnterSceneReq);
			return true;
		}

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

		private void OnGetPathBtnClick(IXUISprite btn)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)btn.ID, null);
		}

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

		private bool OnSureCoverBtnClick(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this._doc.QueryChangeProfession();
			return true;
		}

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

		private XProfessionChangeDocument _doc = null;

		private readonly string TEXPATH = "atlas/UI/common/ProfPic";

		private string _texPath = "";

		private bool _init;
	}
}
