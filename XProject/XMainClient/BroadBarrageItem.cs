using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BC9 RID: 3017
	public class BroadBarrageItem : MonoBehaviour
	{
		// Token: 0x0600AC28 RID: 44072 RVA: 0x001FA364 File Offset: 0x001F8564
		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_lblContent = (base.transform.Find("content").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600AC29 RID: 44073 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void Refresh()
		{
		}

		// Token: 0x0600AC2A RID: 44074 RVA: 0x001FA3A4 File Offset: 0x001F85A4
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

		// Token: 0x040040C9 RID: 16585
		public IXUILabel m_lblContent;

		// Token: 0x040040CA RID: 16586
		private IXUISprite m_sprRoot;
	}
}
