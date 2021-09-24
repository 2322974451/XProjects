using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class GVGDuelHandlerBase : DlgHandlerBase
	{

		protected override void Init()
		{
			this._WrapScroll = (base.transform.Find("DuelList").GetComponent("XUIScrollView") as IXUIScrollView);
			this._WrapContent = (base.transform.Find("DuelList/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_DuelHelp = (base.transform.FindChild("Intro").GetComponent("XUILabel") as IXUILabel);
			this._emptyTransform = base.transform.Find("UnApply");
			this._WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnItemWrapContentUpdate));
		}

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

		public override void RefreshData()
		{
			int duelInfoSize = this.GetDuelInfoSize();
			this._WrapContent.SetContentCount(duelInfoSize, false);
			this._WrapScroll.ResetPosition();
		}

		protected void ShowOrHide(bool active)
		{
			this._emptyTransform.gameObject.SetActive(active);
		}

		protected virtual void OnEnterScene(IXUISprite sprite)
		{
		}

		protected virtual int GetDuelInfoSize()
		{
			return 0;
		}

		protected virtual GVGDuelCombatInfo GetDuelInfo(int index)
		{
			return null;
		}

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

		private IXUIWrapContent _WrapContent;

		private IXUIScrollView _WrapScroll;

		private Transform _emptyTransform;

		protected IXUILabel m_DuelHelp;

		private GVGDuelWrapDisplay _display;
	}
}
