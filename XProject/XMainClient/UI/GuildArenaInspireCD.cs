using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016EA RID: 5866
	internal class GuildArenaInspireCD
	{
		// Token: 0x0600F1F9 RID: 61945 RVA: 0x0035986C File Offset: 0x00357A6C
		public GuildArenaInspireCD(Transform t)
		{
			this.transform = t;
			this.m_inspireCdTotal = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GMFInspireCoolDown"));
			this.m_cdText = (t.Find("cd").GetComponent("XUILabel") as IXUILabel);
			this.m_cdSprite = (t.Find("cd/Quan").GetComponent("XUISprite") as IXUISprite);
			this.ClearInspireCD();
		}

		// Token: 0x0600F1FA RID: 61946 RVA: 0x00359900 File Offset: 0x00357B00
		public bool IsActive()
		{
			return !(this.transform == null) && this.transform.gameObject.activeInHierarchy;
		}

		// Token: 0x0600F1FB RID: 61947 RVA: 0x00359933 File Offset: 0x00357B33
		private void ClearInspireCD()
		{
			this.m_canInspire = true;
			this.m_cdSprite.SetAlpha(0f);
			this.m_cdText.Alpha = 0f;
		}

		// Token: 0x0600F1FC RID: 61948 RVA: 0x00359960 File Offset: 0x00357B60
		public void ExcuteInspireCD(double curInspire)
		{
			bool flag = !this.IsActive();
			if (!flag)
			{
				bool flag2 = curInspire > 0.0;
				if (flag2)
				{
					bool flag3 = curInspire > this.m_inspireCdTotal;
					if (flag3)
					{
						curInspire = this.m_inspireCdTotal;
					}
					float fillAmount = (float)(curInspire / this.m_inspireCdTotal);
					this.m_cdText.Alpha = 1f;
					this.m_cdSprite.SetAlpha(1f);
					this.m_cdSprite.SetFillAmount(fillAmount);
					this.m_canInspire = false;
					bool flag4 = curInspire >= 1.0;
					if (flag4)
					{
						int num = (int)(curInspire + 0.5);
						this.m_cdText.SetText(num.ToString());
					}
					else
					{
						this.m_cdText.SetText(curInspire.ToString("F1"));
					}
				}
				else
				{
					bool flag5 = !this.m_canInspire;
					if (flag5)
					{
						this.ClearInspireCD();
					}
				}
			}
		}

		// Token: 0x040067A0 RID: 26528
		private IXUILabel m_cdText;

		// Token: 0x040067A1 RID: 26529
		private IXUISprite m_cdSprite;

		// Token: 0x040067A2 RID: 26530
		private double m_inspireCdTotal = 20.0;

		// Token: 0x040067A3 RID: 26531
		private bool m_canInspire = true;

		// Token: 0x040067A4 RID: 26532
		private Transform transform;
	}
}
