using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildArenaInspireCD
	{

		public GuildArenaInspireCD(Transform t)
		{
			this.transform = t;
			this.m_inspireCdTotal = double.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GMFInspireCoolDown"));
			this.m_cdText = (t.Find("cd").GetComponent("XUILabel") as IXUILabel);
			this.m_cdSprite = (t.Find("cd/Quan").GetComponent("XUISprite") as IXUISprite);
			this.ClearInspireCD();
		}

		public bool IsActive()
		{
			return !(this.transform == null) && this.transform.gameObject.activeInHierarchy;
		}

		private void ClearInspireCD()
		{
			this.m_canInspire = true;
			this.m_cdSprite.SetAlpha(0f);
			this.m_cdText.Alpha = 0f;
		}

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

		private IXUILabel m_cdText;

		private IXUISprite m_cdSprite;

		private double m_inspireCdTotal = 20.0;

		private bool m_canInspire = true;

		private Transform transform;
	}
}
