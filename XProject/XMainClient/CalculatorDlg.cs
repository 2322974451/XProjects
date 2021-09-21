using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CE1 RID: 3297
	internal class CalculatorDlg : DlgBase<CalculatorDlg, CalculatorBehaviour>
	{
		// Token: 0x17003281 RID: 12929
		// (get) Token: 0x0600B894 RID: 47252 RVA: 0x002531B4 File Offset: 0x002513B4
		public override string fileName
		{
			get
			{
				return "Common/Calculator";
			}
		}

		// Token: 0x17003282 RID: 12930
		// (get) Token: 0x0600B895 RID: 47253 RVA: 0x002531CC File Offset: 0x002513CC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B896 RID: 47254 RVA: 0x002531DF File Offset: 0x002513DF
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600B897 RID: 47255 RVA: 0x002531EC File Offset: 0x002513EC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_sprDel.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnDelClick));
			base.uiBehaviour.m_sprMax.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMaxClick));
			base.uiBehaviour.m_sprOK.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOKClick));
			base.uiBehaviour.m_sprBg.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnOKClick));
			for (int i = 0; i < base.uiBehaviour.m_sprCounter.Length; i++)
			{
				base.uiBehaviour.m_sprCounter[i].ID = (ulong)((long)i);
				base.uiBehaviour.m_sprCounter[i].RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCounterClick));
			}
		}

		// Token: 0x0600B898 RID: 47256 RVA: 0x002532C7 File Offset: 0x002514C7
		protected override void OnHide()
		{
			base.OnHide();
			this.mCallback = null;
		}

		// Token: 0x0600B899 RID: 47257 RVA: 0x002532D8 File Offset: 0x002514D8
		public void Show(CalculatorKeyBack func, Vector3 pos)
		{
			this.mCallback = func;
			this.SetVisible(true, true);
			base.uiBehaviour.transform.localPosition = pos;
		}

		// Token: 0x0600B89A RID: 47258 RVA: 0x00253300 File Offset: 0x00251500
		private void OnCounterClick(IXUISprite sp)
		{
			ulong id = sp.ID;
			bool flag = this.mCallback != null;
			if (flag)
			{
				this.mCallback((CalculatorKey)id);
			}
		}

		// Token: 0x0600B89B RID: 47259 RVA: 0x00253330 File Offset: 0x00251530
		private void OnMaxClick(IXUISprite sp)
		{
			bool flag = this.mCallback != null;
			if (flag)
			{
				this.mCallback(CalculatorKey.MAX);
			}
		}

		// Token: 0x0600B89C RID: 47260 RVA: 0x0025335C File Offset: 0x0025155C
		private void OnOKClick(IXUISprite sp)
		{
			bool flag = this.mCallback != null;
			if (flag)
			{
				this.mCallback(CalculatorKey.OK);
			}
			this.SetVisible(false, true);
		}

		// Token: 0x0600B89D RID: 47261 RVA: 0x00253390 File Offset: 0x00251590
		private void OnDelClick(IXUISprite sp)
		{
			bool flag = this.mCallback != null;
			if (flag)
			{
				this.mCallback(CalculatorKey.DEL);
			}
		}

		// Token: 0x0400493F RID: 18751
		private CalculatorKeyBack mCallback = null;
	}
}
