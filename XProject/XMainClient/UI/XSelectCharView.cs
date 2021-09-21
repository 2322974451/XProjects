using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018BC RID: 6332
	internal class XSelectCharView : DlgBase<XSelectCharView, SelectCharWindowBehaviour>
	{
		// Token: 0x17003A41 RID: 14913
		// (get) Token: 0x06010812 RID: 67602 RVA: 0x0040C078 File Offset: 0x0040A278
		// (set) Token: 0x06010813 RID: 67603 RVA: 0x0040C090 File Offset: 0x0040A290
		public int SelectCharIndex
		{
			get
			{
				return this._currentSelectedIndex;
			}
			set
			{
				this._currentSelectedIndex = value;
			}
		}

		// Token: 0x17003A42 RID: 14914
		// (get) Token: 0x06010814 RID: 67604 RVA: 0x0040C09C File Offset: 0x0040A29C
		public override string fileName
		{
			get
			{
				return "SelectChar/DNSelectCharDlg";
			}
		}

		// Token: 0x17003A43 RID: 14915
		// (get) Token: 0x06010815 RID: 67605 RVA: 0x0040C0B4 File Offset: 0x0040A2B4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06010816 RID: 67606 RVA: 0x0040C0C8 File Offset: 0x0040A2C8
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XSelectCharacterDocument>(XSelectCharacterDocument.uuID);
			this._doc.View = this;
			this._doc.CurrentProf = 0;
			base.uiBehaviour.m_Version.SetText("v" + XSingleton<XUpdater.XUpdater>.singleton.Version);
		}

		// Token: 0x06010817 RID: 67607 RVA: 0x0040C125 File Offset: 0x0040A325
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XLoginDocument>.singleton.ShowLoginReconnect();
		}

		// Token: 0x06010818 RID: 67608 RVA: 0x0040C13C File Offset: 0x0040A33C
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_enterworld.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterworldButtonClick));
			base.uiBehaviour.m_return.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnClick));
			base.uiBehaviour.m_createRandom.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRandomNameClick));
			for (int i = 0; i < XGame.RoleCount; i++)
			{
				base.uiBehaviour.m_create_profp[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnProfSelect));
			}
			base.uiBehaviour.m_profTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnProfTweenFinish));
		}

		// Token: 0x06010819 RID: 67609 RVA: 0x0040C1F4 File Offset: 0x0040A3F4
		protected int FindSlotByUIIndex(int index)
		{
			return -1;
		}

		// Token: 0x0601081A RID: 67610 RVA: 0x0040C208 File Offset: 0x0040A408
		private bool OnEnterworldButtonClick(IXUIButton go)
		{
			base.uiBehaviour.m_SelectTween.PlayTween(true, -1f);
			this._doc.OnEnterWorld();
			return true;
		}

		// Token: 0x0601081B RID: 67611 RVA: 0x0040C240 File Offset: 0x0040A440
		private bool OnReturnClick(IXUIButton go)
		{
			this._doc.OnSelectCharBack();
			return true;
		}

		// Token: 0x0601081C RID: 67612 RVA: 0x0040C260 File Offset: 0x0040A460
		private void OnProfSelect(IXUISprite sp)
		{
			this._currentSelectedIndex = (int)sp.ID;
			XSelectcharStage xselectcharStage = XSingleton<XGame>.singleton.CurrentStage as XSelectcharStage;
			bool flag = xselectcharStage != null;
			if (flag)
			{
				xselectcharStage.ShowCharacter(this._currentSelectedIndex);
			}
		}

		// Token: 0x0601081D RID: 67613 RVA: 0x0040C2A4 File Offset: 0x0040A4A4
		private void OnProfTweenFinish(IXUITweenTool tween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this._playForward = !this._playForward;
				bool flag2 = !this._playForward;
				if (flag2)
				{
					this.SetProfIntro(this._doc.CurrentProf);
					base.uiBehaviour.m_profTween.PlayTween(this._playForward, -1f);
				}
			}
		}

		// Token: 0x0601081E RID: 67614 RVA: 0x0040C310 File Offset: 0x0040A510
		private void SetIntroPoint(int oplevel)
		{
			base.uiBehaviour.m_AttrPoint.FakeReturnAll();
			float x = base.uiBehaviour.m_AttrPoint.TplPos.x;
			float y = base.uiBehaviour.m_AttrPoint.TplPos.y;
			float num = (float)base.uiBehaviour.m_AttrPoint.TplWidth;
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("ProfOperateLevelMax");
			for (int i = 0; i < @int; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_AttrPoint.FetchGameObject(false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Light").GetComponent("XUISprite") as IXUISprite;
				gameObject.transform.localPosition = new Vector3(x + (float)i * num, y);
				ixuisprite.SetAlpha((float)((i < oplevel) ? 1 : 0));
			}
			base.uiBehaviour.m_AttrPoint.ActualReturnAll(false);
		}

		// Token: 0x0601081F RID: 67615 RVA: 0x0040C408 File Offset: 0x0040A608
		private void SetProfIntro(int prof)
		{
			base.uiBehaviour.m_profName.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfNameIcon(prof);
			base.uiBehaviour.m_profDetail.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfIntro(prof));
			base.uiBehaviour.m_profType.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfTypeIntro(prof));
			this.SetIntroPoint((int)XSingleton<XProfessionSkillMgr>.singleton.GetProfOperateLevel(prof));
		}

		// Token: 0x06010820 RID: 67616 RVA: 0x0040C47C File Offset: 0x0040A67C
		public void SwitchProfession(int profID)
		{
			bool activeInHierarchy = base.uiBehaviour.m_selectFrame.gameObject.activeInHierarchy;
			if (activeInHierarchy)
			{
				bool flag = this._doc.CurrentProf > 0;
				if (flag)
				{
					this._playForward = true;
					base.uiBehaviour.m_create_profp[this._doc.CurrentProf - 1].gameObject.transform.FindChild("Select").gameObject.SetActive(false);
				}
				else
				{
					this.SetProfIntro(profID);
					this._playForward = false;
				}
				this._doc.CurrentProf = profID;
				bool flag2 = this._doc.CurrentProf > 0;
				if (flag2)
				{
					base.uiBehaviour.m_create_profp[this._doc.CurrentProf - 1].gameObject.transform.FindChild("Select").gameObject.SetActive(true);
					base.uiBehaviour.m_profTween.PlayTween(this._playForward, -1f);
				}
			}
		}

		// Token: 0x06010821 RID: 67617 RVA: 0x0040C588 File Offset: 0x0040A788
		private bool OnCreateCharButtonClick(IXUIButton go)
		{
			string text = base.uiBehaviour.m_createName.GetText();
			bool flag = text.Length == 0;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.HasNoRoleOnBackFlowServer();
				if (flag2)
				{
					string label = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("FirstRoleOnBackServerTip"));
					string @string = XStringDefineProxy.GetString("CREATE");
					string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
					XSingleton<UiUtility>.singleton.ShowModalDialog(label, @string, string2, new ButtonClickEventHandler(this.CreateBackRole));
				}
				else
				{
					XSingleton<XLoginDocument>.singleton.CreateChar(text, (RoleType)this._doc.CurrentProf);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06010822 RID: 67618 RVA: 0x0040C634 File Offset: 0x0040A834
		private bool CreateBackRole(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			XSingleton<XLoginDocument>.singleton.CreateChar(base.uiBehaviour.m_createName.GetText(), (RoleType)this._doc.CurrentProf);
			return true;
		}

		// Token: 0x06010823 RID: 67619 RVA: 0x0040C678 File Offset: 0x0040A878
		public void SetCreateNameVisable(bool state)
		{
			base.uiBehaviour.m_createNameFrame.gameObject.SetActive(state);
		}

		// Token: 0x06010824 RID: 67620 RVA: 0x0040C692 File Offset: 0x0040A892
		public void SetEnterGameVisable(bool state)
		{
			base.uiBehaviour.m_enterworld.SetVisible(state);
		}

		// Token: 0x06010825 RID: 67621 RVA: 0x0040C6A8 File Offset: 0x0040A8A8
		private void OnRandomNameClick(IXUISprite uiSprite)
		{
			bool flag = this._randomNameReader == null;
			if (flag)
			{
				this._randomNameReader = new RandomName();
				XSingleton<XResourceLoaderMgr>.singleton.ReadFile("Table/RandomName", this._randomNameReader);
			}
			string text = "";
			string text2 = "";
			while (text == "")
			{
				int key = XSingleton<XCommon>.singleton.RandomInt(1, this._randomNameReader.Table.Length);
				text = this._randomNameReader.GetByID(key).FirstName;
			}
			while (text2 == "")
			{
				int key2 = XSingleton<XCommon>.singleton.RandomInt(1, this._randomNameReader.Table.Length);
				text2 = this._randomNameReader.GetByID(key2).LastName;
			}
			string text3 = text + text2;
			base.uiBehaviour.m_createName.SetText(text3);
		}

		// Token: 0x06010826 RID: 67622 RVA: 0x0040C790 File Offset: 0x0040A990
		public void ShowSelectCharGerenal()
		{
			base.uiBehaviour.m_return.SetVisible(true);
			base.uiBehaviour.m_selectFrame.gameObject.SetActive(true);
			base.uiBehaviour.m_createNameFrame.SetActive(false);
			base.uiBehaviour.m_enterworld.gameObject.SetActive(false);
			base.uiBehaviour.m_playerNameFrame.gameObject.SetActive(false);
			this._enterWorld = true;
			base.uiBehaviour.m_enterworld.SetEnable(true, false);
		}

		// Token: 0x06010827 RID: 67623 RVA: 0x0040C824 File Offset: 0x0040AA24
		public void ShowSelectCharSelected(string name, int level)
		{
			base.uiBehaviour.m_return.SetVisible(true);
			base.uiBehaviour.m_selectFrame.gameObject.SetActive(true);
			base.uiBehaviour.m_createNameFrame.SetActive(false);
			base.uiBehaviour.m_enterworld.gameObject.SetActive(true);
			base.uiBehaviour.m_enterworld.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterworldButtonClick));
			base.uiBehaviour.m_enterWorldLabel.SetText(XStringDefineProxy.GetString("START_GAME"));
			base.uiBehaviour.m_playerNameFrame.gameObject.SetActive(true);
			base.uiBehaviour.m_playerNameLabel.SetText(name);
			base.uiBehaviour.m_playerLevelLabel.SetText(string.Format("Lv.{0}", level));
			this._enterWorld = true;
			base.uiBehaviour.m_enterworld.SetEnable(true, false);
		}

		// Token: 0x06010828 RID: 67624 RVA: 0x0040C920 File Offset: 0x0040AB20
		public void ShowSelectCharCreated()
		{
			base.uiBehaviour.m_return.SetVisible(true);
			base.uiBehaviour.m_selectFrame.gameObject.SetActive(true);
			base.uiBehaviour.m_enterworld.gameObject.SetActive(true);
			base.uiBehaviour.m_enterworld.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCreateCharButtonClick));
			base.uiBehaviour.m_enterWorldLabel.SetText(XStringDefineProxy.GetString("CREATE_CHAR"));
			base.uiBehaviour.m_playerNameFrame.gameObject.SetActive(false);
			base.uiBehaviour.m_preLevel.SetText("");
			bool flag = XSingleton<XAttributeMgr>.singleton.HasNoRoleOnBackFlowServer();
			if (flag)
			{
				base.uiBehaviour.m_preLevel.SetText(string.Format("Lv.{0}", XSingleton<XAttributeMgr>.singleton.LoginExData.backflow_level));
			}
			bool flag2 = !base.uiBehaviour.m_createName.IsVisible();
			if (flag2)
			{
				bool flag3 = base.uiBehaviour.m_createName.GetText().Length == 0;
				if (flag3)
				{
					bool flag4 = XSingleton<PDatabase>.singleton.playerInfo != null;
					if (flag4)
					{
						string nickName = XSingleton<PDatabase>.singleton.playerInfo.data.nickName;
						base.uiBehaviour.m_createName.SetText(nickName);
					}
					else
					{
						this.OnRandomNameClick(null);
					}
				}
			}
			base.uiBehaviour.m_createNameFrame.SetActive(true);
		}

		// Token: 0x06010829 RID: 67625 RVA: 0x0040CAA4 File Offset: 0x0040ACA4
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = base.uiBehaviour.m_createNameFrame != null && base.uiBehaviour.m_createNameFrame.activeSelf;
			if (flag)
			{
				bool flag2 = base.uiBehaviour.m_createName.GetText().Length != 0;
				bool flag3 = this._enterWorld != flag2;
				if (flag3)
				{
					this._enterWorld = flag2;
					base.uiBehaviour.m_enterworld.SetEnable(this._enterWorld, false);
				}
			}
		}

		// Token: 0x04007773 RID: 30579
		private XSelectCharacterDocument _doc = null;

		// Token: 0x04007774 RID: 30580
		private int _currentSelectedIndex = 0;

		// Token: 0x04007775 RID: 30581
		public RandomName _randomNameReader = null;

		// Token: 0x04007776 RID: 30582
		private bool _playForward = true;

		// Token: 0x04007777 RID: 30583
		private bool _enterWorld = true;
	}
}
