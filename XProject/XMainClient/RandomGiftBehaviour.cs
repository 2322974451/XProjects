using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class RandomGiftBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Share = (base.transform.FindChild("Share").GetComponent("XUIButton") as IXUIButton);
			this.m_WX = base.transform.FindChild("WX");
			this.m_WXFriend = (this.m_WX.FindChild("WXFriend").GetComponent("XUIButton") as IXUIButton);
			this.m_WXTimeline = (this.m_WX.FindChild("WXTimeline").GetComponent("XUIButton") as IXUIButton);
			this.m_QQ = base.transform.FindChild("QQ");
			this.m_QQFriend = (this.m_QQ.FindChild("QQFriend").GetComponent("XUIButton") as IXUIButton);
			this.m_QQZone = (this.m_QQ.FindChild("QQZone").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (base.transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_Description = (base.transform.FindChild("Description").GetComponent("XUILabel") as IXUILabel);
			this.m_BoxQQ = base.transform.FindChild("BoxQQ");
			this.m_BoxWX = base.transform.FindChild("BoxWX");
		}

		public IXUIButton m_Close;

		public IXUIButton m_Share;

		public Transform m_WX;

		public IXUIButton m_WXFriend;

		public IXUIButton m_WXTimeline;

		public Transform m_QQ;

		public IXUIButton m_QQFriend;

		public IXUIButton m_QQZone;

		public IXUILabel m_Title;

		public IXUILabel m_Description;

		public Transform m_BoxQQ;

		public Transform m_BoxWX;
	}
}
