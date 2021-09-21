using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020017F2 RID: 6130
	public class PartnerLivenessRecordItem : MonoBehaviour
	{
		// Token: 0x0600FE2C RID: 65068 RVA: 0x003BB3DC File Offset: 0x003B95DC
		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_bgSpr = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_nameLab = (base.transform.Find("Bg/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_timeLab = (base.transform.Find("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_contentLab = (base.transform.Find("Bg/Description").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600FE2D RID: 65069 RVA: 0x003BB494 File Offset: 0x003B9694
		public void Refresh(PartnerLivenessRecord record)
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

		// Token: 0x0400703B RID: 28731
		public IXUILabel m_nameLab;

		// Token: 0x0400703C RID: 28732
		public IXUILabel m_timeLab;

		// Token: 0x0400703D RID: 28733
		public IXUILabel m_contentLab;

		// Token: 0x0400703E RID: 28734
		private IXUISprite m_sprRoot;

		// Token: 0x0400703F RID: 28735
		private IXUISprite m_bgSpr;
	}
}
