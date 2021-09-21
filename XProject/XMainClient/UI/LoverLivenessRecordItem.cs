using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020018D9 RID: 6361
	public class LoverLivenessRecordItem : MonoBehaviour
	{
		// Token: 0x06010945 RID: 67909 RVA: 0x00415BE8 File Offset: 0x00413DE8
		private void Awake()
		{
			this.m_sprRoot = (base.GetComponent("XUISprite") as IXUISprite);
			this.m_bgSpr = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_nameLab = (base.transform.Find("Bg/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_timeLab = (base.transform.Find("Bg/Time").GetComponent("XUILabel") as IXUILabel);
			this.m_contentLab = (base.transform.Find("Bg/Description").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x06010946 RID: 67910 RVA: 0x00415CA0 File Offset: 0x00413EA0
		public void Refresh(LoverLivenessRecord record)
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

		// Token: 0x04007850 RID: 30800
		public IXUILabel m_nameLab;

		// Token: 0x04007851 RID: 30801
		public IXUILabel m_timeLab;

		// Token: 0x04007852 RID: 30802
		public IXUILabel m_contentLab;

		// Token: 0x04007853 RID: 30803
		private IXUISprite m_sprRoot;

		// Token: 0x04007854 RID: 30804
		private IXUISprite m_bgSpr;
	}
}
