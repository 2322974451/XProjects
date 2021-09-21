using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C3D RID: 3133
	internal class GuildRelaxChildHandler : DlgHandlerBase, IGuildRelexChildInterface
	{
		// Token: 0x1700315E RID: 12638
		// (get) Token: 0x0600B183 RID: 45443 RVA: 0x0022110C File Offset: 0x0021F30C
		public int ModuleID
		{
			get
			{
				return this.m_moduleID;
			}
		}

		// Token: 0x0600B184 RID: 45444 RVA: 0x00221124 File Offset: 0x0021F324
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

		// Token: 0x0600B185 RID: 45445 RVA: 0x002211F8 File Offset: 0x0021F3F8
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this.RefreshRedPoint();
		}

		// Token: 0x0600B186 RID: 45446 RVA: 0x00221210 File Offset: 0x0021F410
		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshData();
			this.RefreshRedPoint();
		}

		// Token: 0x0600B187 RID: 45447 RVA: 0x00221228 File Offset: 0x0021F428
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_bg.RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnGameClick));
		}

		// Token: 0x0600B188 RID: 45448 RVA: 0x0022124B File Offset: 0x0021F44B
		public override void OnUnload()
		{
			this.m_bg.SetTexturePath("");
			base.OnUnload();
		}

		// Token: 0x0600B189 RID: 45449 RVA: 0x00221268 File Offset: 0x0021F468
		public virtual void SetGuildRelex(XSysDefine define)
		{
			this.m_moduleID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(define);
			GuildRelaxGameList.RowData byModuleID = XGuildRelaxGameDocument.GameList.GetByModuleID(this.m_moduleID);
			this.m_bg.SetTexturePath(string.Format("atlas/UI/Social/{0}", byModuleID.GameBg));
			this.m_title.SetText(byModuleID.GameName);
		}

		// Token: 0x0600B18A RID: 45450 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void SetUnLockLevel()
		{
		}

		// Token: 0x0600B18B RID: 45451 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnGameClick(IXUITexture sp)
		{
		}

		// Token: 0x0600B18C RID: 45452 RVA: 0x002212C4 File Offset: 0x0021F4C4
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

		// Token: 0x0600B18D RID: 45453 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void RefreshRedPoint()
		{
		}

		// Token: 0x04004464 RID: 17508
		protected IXUILabel m_title;

		// Token: 0x04004465 RID: 17509
		protected IXUITexture m_bg;

		// Token: 0x04004466 RID: 17510
		protected IXUILabel m_tip;

		// Token: 0x04004467 RID: 17511
		protected GameObject m_qa;

		// Token: 0x04004468 RID: 17512
		protected GameObject m_redPoint;

		// Token: 0x04004469 RID: 17513
		protected int m_moduleID;
	}
}
