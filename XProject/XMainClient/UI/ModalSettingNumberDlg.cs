using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001870 RID: 6256
	public class ModalSettingNumberDlg : DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>
	{
		// Token: 0x170039B2 RID: 14770
		// (get) Token: 0x06010481 RID: 66689 RVA: 0x003F0B90 File Offset: 0x003EED90
		public override string fileName
		{
			get
			{
				return "Common/ModelSettingNumber";
			}
		}

		// Token: 0x170039B3 RID: 14771
		// (get) Token: 0x06010482 RID: 66690 RVA: 0x003F0BA8 File Offset: 0x003EEDA8
		public override int layer
		{
			get
			{
				return 100;
			}
		}

		// Token: 0x170039B4 RID: 14772
		// (get) Token: 0x06010483 RID: 66691 RVA: 0x003F0BBC File Offset: 0x003EEDBC
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170039B5 RID: 14773
		// (get) Token: 0x06010484 RID: 66692 RVA: 0x003F0BD0 File Offset: 0x003EEDD0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010485 RID: 66693 RVA: 0x003F0BE4 File Offset: 0x003EEDE4
		protected override void Init()
		{
			base.uiBehaviour.CancelBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoCancel));
			base.uiBehaviour.OkBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoClose));
			base.uiBehaviour.backSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.DoCancel));
			base.uiBehaviour.AddBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoAdd));
			base.uiBehaviour.SubBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoSub));
		}

		// Token: 0x06010486 RID: 66694 RVA: 0x003F0C84 File Offset: 0x003EEE84
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.numLabel.SetText(this.MinNumber.ToString());
			base.uiBehaviour.titleLabel.SetText(this.Title);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.itemObject, (int)this.ItemID, 1, false);
		}

		// Token: 0x06010487 RID: 66695 RVA: 0x003F0CEF File Offset: 0x003EEEEF
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x06010488 RID: 66696 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetPanelDepth(int depth)
		{
		}

		// Token: 0x06010489 RID: 66697 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetSingleButtonMode(bool bFlag)
		{
		}

		// Token: 0x0601048A RID: 66698 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetCloseButtonVisible(bool visible)
		{
		}

		// Token: 0x0601048B RID: 66699 RVA: 0x003F0CF9 File Offset: 0x003EEEF9
		public void SetModalInfo(ModalSettingNumberDlg.GetInputNumber handle)
		{
			this.callBack = handle;
		}

		// Token: 0x0601048C RID: 66700 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetTweenTargetAndPlay(GameObject go)
		{
		}

		// Token: 0x0601048D RID: 66701 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void RegisterEvent()
		{
		}

		// Token: 0x0601048E RID: 66702 RVA: 0x003F0D04 File Offset: 0x003EEF04
		private bool DoSub(IXUIButton button)
		{
			int num = 0;
			bool flag = int.TryParse(base.uiBehaviour.numLabel.GetText(), out num);
			if (flag)
			{
				num = Math.Max((int)this.MinNumber, (int)((long)num - (long)((ulong)this.step)));
				base.uiBehaviour.numLabel.SetText(num.ToString());
			}
			return true;
		}

		// Token: 0x0601048F RID: 66703 RVA: 0x003F0D68 File Offset: 0x003EEF68
		private bool DoAdd(IXUIButton button)
		{
			uint num = 0U;
			bool flag = uint.TryParse(base.uiBehaviour.numLabel.GetText(), out num);
			if (flag)
			{
				num = Math.Min(this.MaxNumber, num + this.step);
				base.uiBehaviour.numLabel.SetText(num.ToString());
			}
			return true;
		}

		// Token: 0x06010490 RID: 66704 RVA: 0x003F0DC8 File Offset: 0x003EEFC8
		public bool DoCancel(IXUIButton go)
		{
			this.SetVisible(false, true);
			this.callBack = null;
			return true;
		}

		// Token: 0x06010491 RID: 66705 RVA: 0x003F0DEB File Offset: 0x003EEFEB
		public void DoCancel(IXUISprite sp)
		{
			this.ResetData();
		}

		// Token: 0x06010492 RID: 66706 RVA: 0x003F0DF5 File Offset: 0x003EEFF5
		private void ResetData()
		{
			this.callBack = null;
			this.step = 1U;
			base.uiBehaviour.numLabel.SetText("1");
			this.SetVisible(false, true);
		}

		// Token: 0x06010493 RID: 66707 RVA: 0x003F0E28 File Offset: 0x003EF028
		public bool DoClose(IXUIButton go)
		{
			bool flag = this.callBack != null;
			if (flag)
			{
				uint number = 0U;
				bool flag2 = uint.TryParse(base.uiBehaviour.numLabel.GetText(), out number);
				if (flag2)
				{
					this.callBack(number);
				}
			}
			this.ResetData();
			return true;
		}

		// Token: 0x0400751E RID: 29982
		public uint MinNumber = 0U;

		// Token: 0x0400751F RID: 29983
		public uint MaxNumber = 100U;

		// Token: 0x04007520 RID: 29984
		public uint step = 1U;

		// Token: 0x04007521 RID: 29985
		public uint ItemID = 0U;

		// Token: 0x04007522 RID: 29986
		public string Title;

		// Token: 0x04007523 RID: 29987
		public ModalSettingNumberDlg.GetInputNumber callBack;

		// Token: 0x02001A18 RID: 6680
		// (Invoke) Token: 0x06011130 RID: 69936
		public delegate void GetInputNumber(uint number);
	}
}
