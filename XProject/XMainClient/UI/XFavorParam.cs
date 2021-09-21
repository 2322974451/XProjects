using System;
using UILib;

namespace XMainClient.UI
{
	// Token: 0x02001700 RID: 5888
	internal class XFavorParam : XDataBase
	{
		// Token: 0x0600F2C3 RID: 62147 RVA: 0x0035E013 File Offset: 0x0035C213
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

		// Token: 0x0600F2C4 RID: 62148 RVA: 0x0035E04B File Offset: 0x0035C24B
		public override void Recycle()
		{
			XDataPool<XFavorParam>.Recycle(this);
		}

		// Token: 0x04006814 RID: 26644
		public XNpc Npc;

		// Token: 0x04006815 RID: 26645
		public string Text;

		// Token: 0x04006816 RID: 26646
		public bool isShowSend = false;

		// Token: 0x04006817 RID: 26647
		public bool isShowExchange = false;

		// Token: 0x04006818 RID: 26648
		public bool isShowExchangeRedpoint = false;

		// Token: 0x04006819 RID: 26649
		public ButtonClickEventHandler sendCallback;

		// Token: 0x0400681A RID: 26650
		public ButtonClickEventHandler exchangeCallback;
	}
}
