using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200186E RID: 6254
	public class ModalDlg2 : DlgBase<ModalDlg2, ModalDlg2Behaviour>
	{
		// Token: 0x170039AE RID: 14766
		// (get) Token: 0x06010474 RID: 66676 RVA: 0x003F083C File Offset: 0x003EEA3C
		public override string fileName
		{
			get
			{
				return "Common/GreyModalDlg2";
			}
		}

		// Token: 0x170039AF RID: 14767
		// (get) Token: 0x06010475 RID: 66677 RVA: 0x003F0854 File Offset: 0x003EEA54
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x170039B0 RID: 14768
		// (get) Token: 0x06010476 RID: 66678 RVA: 0x003F0868 File Offset: 0x003EEA68
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170039B1 RID: 14769
		// (get) Token: 0x06010477 RID: 66679 RVA: 0x003F087C File Offset: 0x003EEA7C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010478 RID: 66680 RVA: 0x003F0890 File Offset: 0x003EEA90
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_Select1.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSelect1BtnClick));
			base.uiBehaviour.m_Select2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSelect2BtnClick));
		}

		// Token: 0x06010479 RID: 66681 RVA: 0x003F08FC File Offset: 0x003EEAFC
		public bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601047A RID: 66682 RVA: 0x003F0918 File Offset: 0x003EEB18
		public bool OnSelect1BtnClick(IXUIButton btn)
		{
			this._bFrButtonDelegate(base.uiBehaviour.m_Select1);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601047B RID: 66683 RVA: 0x003F094C File Offset: 0x003EEB4C
		public bool OnSelect2BtnClick(IXUIButton btn)
		{
			this._bSecButtonDelegate(base.uiBehaviour.m_Select2);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601047C RID: 66684 RVA: 0x003F0980 File Offset: 0x003EEB80
		public void SetBtnMsg(IXUIButton btn, string price, string label)
		{
			IXUILabelSymbol ixuilabelSymbol = btn.gameObject.transform.FindChild("Price").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel = btn.gameObject.transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
			ixuilabelSymbol.InputText = price;
			ixuilabel.SetText(label);
		}

		// Token: 0x0601047D RID: 66685 RVA: 0x003F09E8 File Offset: 0x003EEBE8
		public void InitShow(string text, ButtonClickEventHandler func1, ButtonClickEventHandler func2, string price1, string price2, string btnLabel1, string btnLabel2)
		{
			this.SetVisible(true, true);
			this.SetBtnMsg(base.uiBehaviour.m_Select1, price1, btnLabel1);
			this.SetBtnMsg(base.uiBehaviour.m_Select2, price2, btnLabel2);
			base.uiBehaviour.m_Text.InputText = text;
			this._bFrButtonDelegate = func1;
			this._bSecButtonDelegate = func2;
		}

		// Token: 0x04007514 RID: 29972
		private ButtonClickEventHandler _bFrButtonDelegate = null;

		// Token: 0x04007515 RID: 29973
		private ButtonClickEventHandler _bSecButtonDelegate = null;
	}
}
