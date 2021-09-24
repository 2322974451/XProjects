using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCharacterInfoView : DlgHandlerBase
	{

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

		protected override string FileName
		{
			get
			{
				return "ItemNew/CharacterInfoFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_CharacterBG.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnCharacterWindowDrag));
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.SetPowerpoint(this.m_ShowPPT, XCharacterDocument.GetCharacterPPT());
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, this.m_SnapShot);
		}

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

		protected bool OnCharacterWindowDrag(Vector2 delta)
		{
			XSingleton<X3DAvatarMgr>.singleton.RotateMain(-delta.x / 2f);
			return true;
		}

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

		public IXUISprite m_CharacterBG;

		public IXUILabel m_PPT;

		public IXUILabel m_UID;

		public IXUILabel m_Name;

		public IXUISprite m_ProfIcon;

		private IUIDummy m_SnapShot = null;

		private XCharacterDocument _doc = null;

		private bool m_ShowPPT = true;

		private XFx m_fx;

		private string m_effectPath = string.Empty;
	}
}
