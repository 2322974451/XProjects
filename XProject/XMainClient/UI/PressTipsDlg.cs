using System;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001872 RID: 6258
	internal class PressTipsDlg : DlgBase<PressTipsDlg, PressTipsBehaviour>
	{
		// Token: 0x170039BB RID: 14779
		// (get) Token: 0x060104AA RID: 66730 RVA: 0x003F116C File Offset: 0x003EF36C
		public override string fileName
		{
			get
			{
				return "Common/PressTipDlg";
			}
		}

		// Token: 0x170039BC RID: 14780
		// (get) Token: 0x060104AB RID: 66731 RVA: 0x003F1184 File Offset: 0x003EF384
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060104AC RID: 66732 RVA: 0x003F1198 File Offset: 0x003EF398
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

		// Token: 0x060104AD RID: 66733 RVA: 0x003F11F9 File Offset: 0x003EF3F9
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x060104AE RID: 66734 RVA: 0x003F120C File Offset: 0x003EF40C
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

		// Token: 0x060104AF RID: 66735 RVA: 0x003F1292 File Offset: 0x003EF492
		private void _Close()
		{
			this.SetVisibleWithAnimation(false, null);
		}

		// Token: 0x060104B0 RID: 66736 RVA: 0x003F129E File Offset: 0x003EF49E
		private void _Show()
		{
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x04007528 RID: 29992
		private string _contentKey;

		// Token: 0x04007529 RID: 29993
		private Vector3 _offset;

		// Token: 0x0400752A RID: 29994
		private Vector3 _pos;
	}
}
