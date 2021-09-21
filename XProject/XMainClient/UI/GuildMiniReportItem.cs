using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x02001767 RID: 5991
	public class GuildMiniReportItem : MonoBehaviour
	{
		// Token: 0x0600F750 RID: 63312 RVA: 0x00384389 File Offset: 0x00382589
		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_lblContent = (base.transform.Find("content").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600F751 RID: 63313 RVA: 0x003843C8 File Offset: 0x003825C8
		public void Refresh(string content)
		{
			bool flag = this.m_lblContent != null && !string.IsNullOrEmpty(content);
			if (flag)
			{
				this.m_lblContent.SetText(content);
				this.m_sprRoot.spriteHeight = 10 + this.m_lblContent.spriteHeight;
			}
		}

		// Token: 0x04006BA4 RID: 27556
		public IXUILabel m_lblContent;

		// Token: 0x04006BA5 RID: 27557
		public IXUISprite m_sprRoot;
	}
}
