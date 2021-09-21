using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020016D9 RID: 5849
	public class DragonGuildLivenessRecordItem : MonoBehaviour
	{
		// Token: 0x0600F143 RID: 61763 RVA: 0x00353998 File Offset: 0x00351B98
		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_bgSpr = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_nameLab = (base.transform.Find("Bg/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_timeLab = (base.transform.Find("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_contentLab = (base.transform.Find("Bg/Description").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600F144 RID: 61764 RVA: 0x00353A50 File Offset: 0x00351C50
		public void Refresh(DragonGuildLivenessRecord record)
		{
			bool flag = record == null;
			if (!flag)
			{
				this.m_nameLab.SetText(record.Name);
				this.m_timeLab.SetText(record.ShowTimeStr);
				this.m_contentLab.SetText(record.ShowString);
				this.m_sprRoot.spriteHeight = 46 + this.m_contentLab.spriteHeight;
				this.m_bgSpr.spriteHeight = this.m_sprRoot.spriteHeight;
			}
		}

		// Token: 0x0400670C RID: 26380
		public IXUILabel m_nameLab;

		// Token: 0x0400670D RID: 26381
		public IXUILabel m_timeLab;

		// Token: 0x0400670E RID: 26382
		public IXUILabel m_contentLab;

		// Token: 0x0400670F RID: 26383
		private IXUISprite m_sprRoot;

		// Token: 0x04006710 RID: 26384
		private IXUISprite m_bgSpr;
	}
}
