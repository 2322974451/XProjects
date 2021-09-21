using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C0B RID: 3083
	internal class GuildRedPackageDetailBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AF30 RID: 44848 RVA: 0x00212540 File Offset: 0x00210740
		private void Awake()
		{
			this.m_LogPanel = base.transform.FindChild("DetailMenu/LogPanel").gameObject;
			this.m_root = base.transform.FindChild("DetailMenu");
			this.m_playTween = (this.m_root.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Reason = (base.transform.FindChild("DetailMenu/Reason").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Reason.InputText = "";
			this.m_Money = (base.transform.FindChild("DetailMenu/Money").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Money.InputText = "";
			this.m_Count = (base.transform.FindChild("DetailMenu/Count").GetComponent("XUILabel") as IXUILabel);
			this.m_Count.SetText("");
			this.m_Note = (base.transform.FindChild("DetailMenu/Note").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Note.InputText = "";
			this.m_Reply = (base.transform.FindChild("DetailMenu/Reply").GetComponent("XUIButton") as IXUIButton);
			this.m_SendName = (base.transform.FindChild("DetailMenu/Avatar/Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_SendName.InputText = "";
			this.m_ReplyLabel = (base.transform.FindChild("DetailMenu/Reply/T").GetComponent("XUILabel") as IXUILabel);
			this.m_bgSprite = (base.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_sendHeadTexture = (base.transform.FindChild("DetailMenu/Avatar/Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_sendHeadSprite = (base.transform.FindChild("DetailMenu/Avatar/GuildIcon").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x040042B9 RID: 17081
		public Transform m_root;

		// Token: 0x040042BA RID: 17082
		public GameObject m_LogPanel;

		// Token: 0x040042BB RID: 17083
		public IXUILabelSymbol m_Reason;

		// Token: 0x040042BC RID: 17084
		public IXUILabelSymbol m_Money;

		// Token: 0x040042BD RID: 17085
		public IXUILabelSymbol m_Note;

		// Token: 0x040042BE RID: 17086
		public IXUILabelSymbol m_SendName;

		// Token: 0x040042BF RID: 17087
		public IXUITexture m_sendHeadTexture;

		// Token: 0x040042C0 RID: 17088
		public IXUISprite m_sendHeadSprite;

		// Token: 0x040042C1 RID: 17089
		public IXUILabel m_Count;

		// Token: 0x040042C2 RID: 17090
		public IXUILabel m_ReplyLabel;

		// Token: 0x040042C3 RID: 17091
		public IXUIButton m_Reply;

		// Token: 0x040042C4 RID: 17092
		public IXUISprite m_bgSprite;

		// Token: 0x040042C5 RID: 17093
		public IXUITweenTool m_playTween;
	}
}
