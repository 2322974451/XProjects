using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class PressTipsDlg : DlgBase<PressTipsDlg, PressTipsBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/PressTipDlg";
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public void Setup(bool show, string key, Vector3 pos, Vector3 offset)
		{
			if (show)
			{
				this._contentKey = key;
				this._offset = offset;
				this._pos = pos;
				bool flag = !base.IsVisible();
				if (flag)
				{
					this._Show();
				}
				else
				{
					this.RefreshData();
				}
			}
			else
			{
				bool flag2 = base.IsVisible();
				if (flag2)
				{
					this._Close();
				}
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		private void RefreshData()
		{
			bool flag = string.IsNullOrEmpty(this._contentKey);
			if (flag)
			{
				this._Close();
			}
			else
			{
				base.uiBehaviour.transform.position = this._pos;
				base.uiBehaviour.transform.localPosition += this._offset;
				base.uiBehaviour._ContentValue.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString(this._contentKey)));
			}
		}

		private void _Close()
		{
			this.SetVisibleWithAnimation(false, null);
		}

		private void _Show()
		{
			this.SetVisibleWithAnimation(true, null);
		}

		private string _contentKey;

		private Vector3 _offset;

		private Vector3 _pos;
	}
}
