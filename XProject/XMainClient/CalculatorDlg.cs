using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class CalculatorDlg : DlgBase<CalculatorDlg, CalculatorBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/Calculator";
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
			base.Init();
		}

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

		protected override void OnHide()
		{
			base.OnHide();
			this.mCallback = null;
		}

		public void Show(CalculatorKeyBack func, Vector3 pos)
		{
			this.mCallback = func;
			this.SetVisible(true, true);
			base.uiBehaviour.transform.localPosition = pos;
		}

		private void OnCounterClick(IXUISprite sp)
		{
			ulong id = sp.ID;
			bool flag = this.mCallback != null;
			if (flag)
			{
				this.mCallback((CalculatorKey)id);
			}
		}

		private void OnMaxClick(IXUISprite sp)
		{
			bool flag = this.mCallback != null;
			if (flag)
			{
				this.mCallback(CalculatorKey.MAX);
			}
		}

		private void OnOKClick(IXUISprite sp)
		{
			bool flag = this.mCallback != null;
			if (flag)
			{
				this.mCallback(CalculatorKey.OK);
			}
			this.SetVisible(false, true);
		}

		private void OnDelClick(IXUISprite sp)
		{
			bool flag = this.mCallback != null;
			if (flag)
			{
				this.mCallback(CalculatorKey.DEL);
			}
		}

		private CalculatorKeyBack mCallback = null;
	}
}
