using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EF7 RID: 3831
	internal class XCharacterInfoView : DlgHandlerBase
	{
		// Token: 0x17003578 RID: 13688
		// (get) Token: 0x0600CB4C RID: 52044 RVA: 0x002E4C98 File Offset: 0x002E2E98
		public string EffectPath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_effectPath);
				if (flag)
				{
					this.m_effectPath = XSingleton<XGlobalConfig>.singleton.GetValue("CharacterEffectPath");
				}
				return this.m_effectPath;
			}
		}

		// Token: 0x17003579 RID: 13689
		// (get) Token: 0x0600CB4D RID: 52045 RVA: 0x002E4CD4 File Offset: 0x002E2ED4
		protected override string FileName
		{
			get
			{
				return "ItemNew/CharacterInfoFrame";
			}
		}

		// Token: 0x0600CB4E RID: 52046 RVA: 0x002E4CEC File Offset: 0x002E2EEC
		protected override void Init()
		{
			base.Init();
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCharacterDocument>(XCharacterDocument.uuID);
			this.m_CharacterBG = (base.PanelObject.transform.FindChild("CharacterFrame/Bg").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.PanelObject.transform.FindChild("CharacterFrame/PowerPoint");
			bool flag = transform != null;
			if (flag)
			{
				this.m_PPT = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			transform = base.PanelObject.transform.FindChild("TitleFrame/ProfIcon");
			bool flag2 = transform != null;
			if (flag2)
			{
				this.m_ProfIcon = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			transform = base.PanelObject.transform.FindChild("UID");
			bool flag3 = transform != null;
			if (flag3)
			{
				this.m_UID = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			transform = base.PanelObject.transform.FindChild("name");
			bool flag4 = transform != null;
			if (flag4)
			{
				this.m_Name = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			this.m_SnapShot = (base.PanelObject.transform.FindChild("CharacterFrame/Snapshot").GetComponent("UIDummy") as IUIDummy);
			bool flag5 = this.m_fx == null;
			if (flag5)
			{
				this.m_fx = XSingleton<XFxMgr>.singleton.CreateFx(this.EffectPath, null, true);
			}
			else
			{
				this.m_fx.SetActive(true);
			}
			this.m_fx.Play(base.PanelObject.transform.FindChild("CharacterFrame/T1/FX"), Vector3.zero, Vector3.one, 1f, true, false);
		}

		// Token: 0x0600CB4F RID: 52047 RVA: 0x002E4EB2 File Offset: 0x002E30B2
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_CharacterBG.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnCharacterWindowDrag));
		}

		// Token: 0x0600CB50 RID: 52048 RVA: 0x002E4ED4 File Offset: 0x002E30D4
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.InfoView = this;
			this.SetPowerpoint(this.m_ShowPPT, XCharacterDocument.GetCharacterPPT());
			bool flag = this.m_UID != null;
			if (flag)
			{
				this.m_UID.SetText(string.Format("UID:{0}", XSingleton<XAttributeMgr>.singleton.XPlayerData.ShortId));
			}
			bool flag2 = this.m_Name != null;
			if (flag2)
			{
				this.m_Name.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.Name);
			}
			bool flag3 = this.m_ProfIcon != null;
			if (flag3)
			{
				uint typeID = XSingleton<XEntityMgr>.singleton.Player.TypeID;
				this.m_ProfIcon.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)typeID));
			}
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_SnapShot);
		}

		// Token: 0x0600CB51 RID: 52049 RVA: 0x002E4FAF File Offset: 0x002E31AF
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.SetPowerpoint(this.m_ShowPPT, XCharacterDocument.GetCharacterPPT());
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_SnapShot);
		}

		// Token: 0x0600CB52 RID: 52050 RVA: 0x002E4FE0 File Offset: 0x002E31E0
		protected override void OnHide()
		{
			base.OnHide();
			this._doc.InfoView = null;
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			bool flag = this.m_SnapShot != null;
			if (flag)
			{
				this.m_SnapShot.RefreshRenderQueue = null;
			}
		}

		// Token: 0x0600CB53 RID: 52051 RVA: 0x002E502C File Offset: 0x002E322C
		public override void OnUnload()
		{
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(this.m_SnapShot);
			bool flag = this.m_SnapShot != null;
			if (flag)
			{
				this.m_SnapShot.RefreshRenderQueue = null;
			}
			this._doc.InfoView = null;
			bool flag2 = this.m_fx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
			base.OnUnload();
		}

		// Token: 0x0600CB54 RID: 52052 RVA: 0x002E50A4 File Offset: 0x002E32A4
		protected bool OnCharacterWindowDrag(Vector2 delta)
		{
			XSingleton<X3DAvatarMgr>.singleton.RotateMain(-delta.x / 2f);
			return true;
		}

		// Token: 0x0600CB55 RID: 52053 RVA: 0x002E50D0 File Offset: 0x002E32D0
		public void SetPowerpoint(bool visible, uint value)
		{
			this.m_ShowPPT = visible;
			bool flag = this.m_PPT != null;
			if (flag)
			{
				this.m_PPT.gameObject.SetActive(visible);
				bool flag2 = value > 0U;
				if (flag2)
				{
					this.m_PPT.SetText(value.ToString());
				}
			}
		}

		// Token: 0x040059E4 RID: 23012
		public IXUISprite m_CharacterBG;

		// Token: 0x040059E5 RID: 23013
		public IXUILabel m_PPT;

		// Token: 0x040059E6 RID: 23014
		public IXUILabel m_UID;

		// Token: 0x040059E7 RID: 23015
		public IXUILabel m_Name;

		// Token: 0x040059E8 RID: 23016
		public IXUISprite m_ProfIcon;

		// Token: 0x040059E9 RID: 23017
		private IUIDummy m_SnapShot = null;

		// Token: 0x040059EA RID: 23018
		private XCharacterDocument _doc = null;

		// Token: 0x040059EB RID: 23019
		private bool m_ShowPPT = true;

		// Token: 0x040059EC RID: 23020
		private XFx m_fx;

		// Token: 0x040059ED RID: 23021
		private string m_effectPath = string.Empty;
	}
}
