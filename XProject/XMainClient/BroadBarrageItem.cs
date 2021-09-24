using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	public class BroadBarrageItem : MonoBehaviour
	{

		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_lblContent = (base.transform.Find("content").GetComponent("XUILabel") as IXUILabel);
		}

		public void Refresh()
		{
		}

		public void Refresh(string nick, string content)
		{
			bool flag = this.m_lblContent != null && !string.IsNullOrEmpty(nick) && !string.IsNullOrEmpty(content);
			if (flag)
			{
				this.m_lblContent.SetText(XSingleton<XCommon>.singleton.StringCombine("[00ff00]", nick, "[-]: ", content));
				this.m_sprRoot.spriteHeight = 20 + this.m_lblContent.spriteHeight;
				this.m_lblContent.gameObject.transform.localPosition = new Vector3(-160f, (float)(this.m_sprRoot.spriteHeight / 2 - 4), 0f);
			}
		}

		public IXUILabel m_lblContent;

		private IXUISprite m_sprRoot;
	}
}
