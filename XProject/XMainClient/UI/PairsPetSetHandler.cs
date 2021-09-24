using System;
using UILib;

namespace XMainClient.UI
{

	internal class PairsPetSetHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/DoublepetSet";
			}
		}

		protected override void Init()
		{
			this.m_doc = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
			this.m_closeBtn = (base.PanelObject.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_yesToggle = (base.PanelObject.transform.FindChild("Bg/Yes/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_noToggle = (base.PanelObject.transform.FindChild("Bg/No/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
			base.Init();
		}

		public override void RegisterEvent()
		{
			this.m_yesToggle.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.ClickYesToggle));
			this.m_noToggle.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.ClickNoToggle));
			this.m_closeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.ClickClosed));
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public override void RefreshData()
		{
			base.RefreshData();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

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

		private XPetDocument m_doc;

		private IXUICheckBox m_yesToggle;

		private IXUICheckBox m_noToggle;

		private IXUIButton m_closeBtn;

		private bool m_isAllow = true;
	}
}
