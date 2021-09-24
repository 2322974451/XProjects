using System;
using UILib;

namespace XMainClient.UI
{

	internal class XFavorParam : XDataBase
	{

		public override void Init()
		{
			this.Npc = null;
			this.Text = string.Empty;
			this.isShowSend = false;
			this.isShowExchange = false;
			this.isShowExchangeRedpoint = false;
			this.sendCallback = null;
			this.exchangeCallback = null;
		}

		public override void Recycle()
		{
			XDataPool<XFavorParam>.Recycle(this);
		}

		public XNpc Npc;

		public string Text;

		public bool isShowSend = false;

		public bool isShowExchange = false;

		public bool isShowExchangeRedpoint = false;

		public ButtonClickEventHandler sendCallback;

		public ButtonClickEventHandler exchangeCallback;
	}
}
