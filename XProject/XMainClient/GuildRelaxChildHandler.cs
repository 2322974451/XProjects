using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildRelaxChildHandler : DlgHandlerBase, IGuildRelexChildInterface
	{

		public int ModuleID
		{
			get
			{
				return this.m_moduleID;
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_title = (base.transform.FindChild("Title/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_bg = (base.transform.FindChild("Bg").GetComponent("XUITexture") as IXUITexture);
			this.m_tip = (base.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_qa = base.transform.Find("QA").gameObject;
			this.m_redPoint = base.transform.FindChild("Title/RedPoint").gameObject;
			this.m_tip.SetVisible(false);
			this.m_qa.SetActive(false);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this.RefreshRedPoint();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
			this.RefreshRedPoint();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_bg.RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnGameClick));
		}

		public override void OnUnload()
		{
			this.m_bg.SetTexturePath("");
			base.OnUnload();
		}

		public virtual void SetGuildRelex(XSysDefine define)
		{
			this.m_moduleID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(define);
			GuildRelaxGameList.RowData byModuleID = XGuildRelaxGameDocument.GameList.GetByModuleID(this.m_moduleID);
			this.m_bg.SetTexturePath(string.Format("atlas/UI/Social/{0}", byModuleID.GameBg));
			this.m_title.SetText(byModuleID.GameName);
		}

		public virtual void SetUnLockLevel()
		{
		}

		protected virtual void OnGameClick(IXUITexture sp)
		{
		}

		public override void RefreshData()
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			uint unlockLevel = XGuildDocument.GuildConfig.GetUnlockLevel((XSysDefine)this.m_moduleID);
			this.m_bg.ID = (ulong)((long)this.m_moduleID);
			bool flag = unlockLevel <= specificDocument.Level;
			if (flag)
			{
				this.m_bg.RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnGameClick));
				this.SetUnLockLevel();
			}
			else
			{
				this.m_qa.SetActive(false);
				this.m_tip.SetVisible(true);
				this.m_bg.RegisterLabelClickEventHandler(null);
				this.m_tip.SetText(XStringDefineProxy.GetString("OPEN_AT_GUILD_LEVEL", new object[]
				{
					unlockLevel
				}));
			}
		}

		public virtual void RefreshRedPoint()
		{
		}

		protected IXUILabel m_title;

		protected IXUITexture m_bg;

		protected IXUILabel m_tip;

		protected GameObject m_qa;

		protected GameObject m_redPoint;

		protected int m_moduleID;
	}
}
