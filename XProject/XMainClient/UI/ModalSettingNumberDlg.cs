using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	public class ModalSettingNumberDlg : DlgBase<ModalSettingNumberDlg, ModalSettingNumberDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/ModelSettingNumber";
			}
		}

		public override int layer
		{
			get
			{
				return 100;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.uiBehaviour.CancelBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoCancel));
			base.uiBehaviour.OkBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoClose));
			base.uiBehaviour.backSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.DoCancel));
			base.uiBehaviour.AddBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoAdd));
			base.uiBehaviour.SubBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoSub));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.numLabel.SetText(this.MinNumber.ToString());
			base.uiBehaviour.titleLabel.SetText(this.Title);
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.itemObject, (int)this.ItemID, 1, false);
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		public void SetPanelDepth(int depth)
		{
		}

		public void SetSingleButtonMode(bool bFlag)
		{
		}

		public void SetCloseButtonVisible(bool visible)
		{
		}

		public void SetModalInfo(ModalSettingNumberDlg.GetInputNumber handle)
		{
			this.callBack = handle;
		}

		public void SetTweenTargetAndPlay(GameObject go)
		{
		}

		public override void RegisterEvent()
		{
		}

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

		public bool DoCancel(IXUIButton go)
		{
			this.SetVisible(false, true);
			this.callBack = null;
			return true;
		}

		public void DoCancel(IXUISprite sp)
		{
			this.ResetData();
		}

		private void ResetData()
		{
			this.callBack = null;
			this.step = 1U;
			base.uiBehaviour.numLabel.SetText("1");
			this.SetVisible(false, true);
		}

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

		public uint MinNumber = 0U;

		public uint MaxNumber = 100U;

		public uint step = 1U;

		public uint ItemID = 0U;

		public string Title;

		public ModalSettingNumberDlg.GetInputNumber callBack;

		public delegate void GetInputNumber(uint number);
	}
}
