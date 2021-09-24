using System;
using UILib;

namespace XMainClient.UI
{

	internal class QualityFilterHandler : DlgHandlerBase
	{

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKClick));
			this.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelClick));
		}

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

		public void Set(int mask, QualityFilterCallback callback)
		{
			this.m_Mask = mask;
			this.m_Callback = callback;
		}

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

		protected bool _OnCancelClick(IXUIButton go)
		{
			base.SetVisible(false);
			return true;
		}

		private static readonly int QualityCount = 6;

		private IXUICheckBox[] m_Opt = new IXUICheckBox[QualityFilterHandler.QualityCount];

		private IXUIButton m_OK;

		private IXUIButton m_Cancel;

		private QualityFilterCallback m_Callback;

		private int m_Mask;
	}
}
