using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x020017F8 RID: 6136
	internal class PairsPetSetHandler : DlgHandlerBase
	{
		// Token: 0x170038E0 RID: 14560
		// (get) Token: 0x0600FE78 RID: 65144 RVA: 0x003BD650 File Offset: 0x003BB850
		protected override string FileName
		{
			get
			{
				return "GameSystem/DoublepetSet";
			}
		}

		// Token: 0x0600FE79 RID: 65145 RVA: 0x003BD668 File Offset: 0x003BB868
		protected override void Init()
		{
			this.m_doc = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_yesToggle = (base.PanelObject.transform.FindChild("Bg/Yes/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_noToggle = (base.PanelObject.transform.FindChild("Bg/No/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
			base.Init();
		}

		// Token: 0x0600FE7A RID: 65146 RVA: 0x003BD70C File Offset: 0x003BB90C
		public override void RegisterEvent()
		{
			this.m_yesToggle.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.ClickYesToggle));
			this.m_noToggle.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.ClickNoToggle));
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClosed));
			base.RegisterEvent();
		}

		// Token: 0x0600FE7B RID: 65147 RVA: 0x003BD769 File Offset: 0x003BB969
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600FE7C RID: 65148 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600FE7D RID: 65149 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600FE7E RID: 65150 RVA: 0x00209F22 File Offset: 0x00208122
		public override void RefreshData()
		{
			base.RefreshData();
		}

		// Token: 0x0600FE7F RID: 65151 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FE80 RID: 65152 RVA: 0x003BD77C File Offset: 0x003BB97C
		private void FillContent()
		{
			bool flag = this.m_doc.CurSelectedPet == null;
			if (!flag)
			{
				this.m_isAllow = this.m_doc.CurSelectedPet.Canpairride;
				bool isAllow = this.m_isAllow;
				if (isAllow)
				{
					this.m_yesToggle.ForceSetFlag(true);
					this.m_noToggle.ForceSetFlag(false);
				}
				else
				{
					this.m_yesToggle.ForceSetFlag(false);
					this.m_noToggle.ForceSetFlag(true);
				}
			}
		}

		// Token: 0x0600FE81 RID: 65153 RVA: 0x003BD7F8 File Offset: 0x003BB9F8
		private bool ClickYesToggle(IXUICheckBox checkBox)
		{
			bool flag = !checkBox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_isAllow = true;
				result = true;
			}
			return result;
		}

		// Token: 0x0600FE82 RID: 65154 RVA: 0x003BD824 File Offset: 0x003BBA24
		private bool ClickNoToggle(IXUICheckBox checkBox)
		{
			bool flag = !checkBox.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_isAllow = false;
				result = true;
			}
			return result;
		}

		// Token: 0x0600FE83 RID: 65155 RVA: 0x003BD850 File Offset: 0x003BBA50
		private bool ClickClosed(IXUIButton btn)
		{
			bool flag = this.m_doc.CurSelectedPet != null;
			if (flag)
			{
				bool flag2 = this.m_doc.CurSelectedPet.Canpairride != this.m_isAllow;
				if (flag2)
				{
					this.m_doc.OnReqSetTravelSet(this.m_isAllow);
				}
			}
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04007066 RID: 28774
		private XPetDocument m_doc;

		// Token: 0x04007067 RID: 28775
		private IXUICheckBox m_yesToggle;

		// Token: 0x04007068 RID: 28776
		private IXUICheckBox m_noToggle;

		// Token: 0x04007069 RID: 28777
		private IXUIButton m_closeBtn;

		// Token: 0x0400706A RID: 28778
		private bool m_isAllow = true;
	}
}
