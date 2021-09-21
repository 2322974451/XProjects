using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x020018B8 RID: 6328
	internal class QualityFilterHandler : DlgHandlerBase
	{
		// Token: 0x060107E2 RID: 67554 RVA: 0x00409FC4 File Offset: 0x004081C4
		protected override void Init()
		{
			base.Init();
			this.m_OK = (base.PanelObject.transform.FindChild("Menu/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_Cancel = (base.PanelObject.transform.FindChild("Menu/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_Opt[0] = (base.PanelObject.transform.FindChild("Menu/C").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Opt[1] = (base.PanelObject.transform.FindChild("Menu/C").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Opt[2] = (base.PanelObject.transform.FindChild("Menu/B").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Opt[3] = (base.PanelObject.transform.FindChild("Menu/A").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Opt[4] = (base.PanelObject.transform.FindChild("Menu/S").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Opt[5] = (base.PanelObject.transform.FindChild("Menu/L").GetComponent("XUICheckBox") as IXUICheckBox);
			for (int i = 0; i < 6; i++)
			{
				IXUISprite ixuisprite = this.m_Opt[i].gameObject.GetComponent("XUISprite") as IXUISprite;
				bool flag = ixuisprite != null;
				if (flag)
				{
					ixuisprite.RegisterSpriteClickEventHandler(null);
				}
			}
		}

		// Token: 0x060107E3 RID: 67555 RVA: 0x0040A174 File Offset: 0x00408374
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKClick));
			this.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelClick));
		}

		// Token: 0x060107E4 RID: 67556 RVA: 0x0040A1B0 File Offset: 0x004083B0
		protected override void OnShow()
		{
			base.OnShow();
			int num = 1;
			foreach (IXUICheckBox ixuicheckBox in this.m_Opt)
			{
				ixuicheckBox.bChecked = ((this.m_Mask & num) != 0);
				num <<= 1;
			}
		}

		// Token: 0x060107E5 RID: 67557 RVA: 0x0040A1F9 File Offset: 0x004083F9
		public void Set(int mask, QualityFilterCallback callback)
		{
			this.m_Mask = mask;
			this.m_Callback = callback;
		}

		// Token: 0x060107E6 RID: 67558 RVA: 0x0040A20C File Offset: 0x0040840C
		protected bool _OnOKClick(IXUIButton go)
		{
			int num = 1;
			this.m_Mask = 0;
			foreach (IXUICheckBox ixuicheckBox in this.m_Opt)
			{
				bool bChecked = ixuicheckBox.bChecked;
				if (bChecked)
				{
					this.m_Mask |= num;
				}
				num <<= 1;
			}
			bool flag = this.m_Callback != null;
			if (flag)
			{
				this.m_Callback(this.m_Mask);
			}
			base.SetVisible(false);
			return true;
		}

		// Token: 0x060107E7 RID: 67559 RVA: 0x0040A290 File Offset: 0x00408490
		protected bool _OnCancelClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04007736 RID: 30518
		private static readonly int QualityCount = 6;

		// Token: 0x04007737 RID: 30519
		private IXUICheckBox[] m_Opt = new IXUICheckBox[QualityFilterHandler.QualityCount];

		// Token: 0x04007738 RID: 30520
		private IXUIButton m_OK;

		// Token: 0x04007739 RID: 30521
		private IXUIButton m_Cancel;

		// Token: 0x0400773A RID: 30522
		private QualityFilterCallback m_Callback;

		// Token: 0x0400773B RID: 30523
		private int m_Mask;
	}
}
