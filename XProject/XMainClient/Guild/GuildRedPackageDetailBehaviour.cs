using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class GuildRedPackageDetailBehaviour : DlgBehaviourBase
	{

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

		public Transform m_root;

		public GameObject m_LogPanel;

		public IXUILabelSymbol m_Reason;

		public IXUILabelSymbol m_Money;

		public IXUILabelSymbol m_Note;

		public IXUILabelSymbol m_SendName;

		public IXUITexture m_sendHeadTexture;

		public IXUISprite m_sendHeadSprite;

		public IXUILabel m_Count;

		public IXUILabel m_ReplyLabel;

		public IXUIButton m_Reply;

		public IXUISprite m_bgSprite;

		public IXUITweenTool m_playTween;
	}
}
