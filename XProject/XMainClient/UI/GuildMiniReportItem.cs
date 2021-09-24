using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	public class GuildMiniReportItem : MonoBehaviour
	{

		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_lblContent = (base.transform.Find("content").GetComponent("XUILabel") as IXUILabel);
		}

		public void Refresh(string content)
		{
			bool flag = this.m_lblContent != null && !string.IsNullOrEmpty(content);
			if (flag)
			{
				this.m_lblContent.SetText(content);
				this.m_sprRoot.spriteHeight = 10 + this.m_lblContent.spriteHeight;
			}
		}

		public IXUILabel m_lblContent;

		public IXUISprite m_sprRoot;
	}
}
