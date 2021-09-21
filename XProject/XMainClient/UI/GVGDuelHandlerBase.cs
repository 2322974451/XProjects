using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020016F1 RID: 5873
	internal class GVGDuelHandlerBase : DlgHandlerBase
	{
		// Token: 0x0600F256 RID: 62038 RVA: 0x0035C0C0 File Offset: 0x0035A2C0
		protected override void Init()
		{
			this._WrapScroll = (base.transform.Find("DuelList").GetComponent("XUIScrollView") as IXUIScrollView);
			this._WrapContent = (base.transform.Find("DuelList/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_DuelHelp = (base.transform.FindChild("Intro").GetComponent("XUILabel") as IXUILabel);
			this._emptyTransform = base.transform.Find("UnApply");
			this._WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnItemWrapContentUpdate));
		}

		// Token: 0x0600F257 RID: 62039 RVA: 0x0035C16C File Offset: 0x0035A36C
		public override void OnUnload()
		{
			bool flag = this._display != null;
			if (flag)
			{
				this._display.Recycle();
				this._display = null;
			}
			base.OnUnload();
		}

		// Token: 0x0600F258 RID: 62040 RVA: 0x0035C1A4 File Offset: 0x0035A3A4
		public override void RefreshData()
		{
			int duelInfoSize = this.GetDuelInfoSize();
			this._WrapContent.SetContentCount(duelInfoSize, false);
			this._WrapScroll.ResetPosition();
		}

		// Token: 0x0600F259 RID: 62041 RVA: 0x0035C1D3 File Offset: 0x0035A3D3
		protected void ShowOrHide(bool active)
		{
			this._emptyTransform.gameObject.SetActive(active);
		}

		// Token: 0x0600F25A RID: 62042 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void OnEnterScene(IXUISprite sprite)
		{
		}

		// Token: 0x0600F25B RID: 62043 RVA: 0x0035C1E8 File Offset: 0x0035A3E8
		protected virtual int GetDuelInfoSize()
		{
			return 0;
		}

		// Token: 0x0600F25C RID: 62044 RVA: 0x0035C1FC File Offset: 0x0035A3FC
		protected virtual GVGDuelCombatInfo GetDuelInfo(int index)
		{
			return null;
		}

		// Token: 0x0600F25D RID: 62045 RVA: 0x0035C210 File Offset: 0x0035A410
		private void OnItemWrapContentUpdate(Transform t, int index)
		{
			bool flag = this._display == null;
			if (flag)
			{
				this._display = new GVGDuelWrapDisplay();
			}
			this._display.Setup(t, index, new SpriteClickEventHandler(this.OnEnterScene));
			this._display.Set(this.GetDuelInfo(index));
		}

		// Token: 0x040067DA RID: 26586
		private IXUIWrapContent _WrapContent;

		// Token: 0x040067DB RID: 26587
		private IXUIScrollView _WrapScroll;

		// Token: 0x040067DC RID: 26588
		private Transform _emptyTransform;

		// Token: 0x040067DD RID: 26589
		protected IXUILabel m_DuelHelp;

		// Token: 0x040067DE RID: 26590
		private GVGDuelWrapDisplay _display;
	}
}
