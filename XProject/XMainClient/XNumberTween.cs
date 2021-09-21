using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E77 RID: 3703
	public class XNumberTween : MonoBehaviour
	{
		// Token: 0x1700349D RID: 13469
		// (get) Token: 0x0600C64F RID: 50767 RVA: 0x002BE4A8 File Offset: 0x002BC6A8
		// (set) Token: 0x0600C650 RID: 50768 RVA: 0x002BE4C0 File Offset: 0x002BC6C0
		public float tweenDuaration
		{
			get
			{
				return this.m_tweenDuaration;
			}
			set
			{
				this.m_tweenDuaration = value;
				this.userTweenDuaration = value;
			}
		}

		// Token: 0x1700349E RID: 13470
		// (get) Token: 0x0600C651 RID: 50769 RVA: 0x002BE4D4 File Offset: 0x002BC6D4
		public IXUILabel Label
		{
			get
			{
				return this.m_uiLabel;
			}
		}

		// Token: 0x1700349F RID: 13471
		// (get) Token: 0x0600C652 RID: 50770 RVA: 0x002BE4EC File Offset: 0x002BC6EC
		public IXUITweenTool IconTween
		{
			get
			{
				return this.m_uiIconTween;
			}
		}

		// Token: 0x0600C653 RID: 50771 RVA: 0x002BE504 File Offset: 0x002BC704
		public static XNumberTween Create(Transform t)
		{
			XNumberTween xnumberTween = t.gameObject.GetComponent<XNumberTween>();
			bool flag = xnumberTween == null;
			if (flag)
			{
				xnumberTween = t.gameObject.AddComponent<XNumberTween>();
			}
			Transform transform = t.FindChild("value");
			bool flag2 = transform != null;
			if (flag2)
			{
				xnumberTween.m_uiLabel = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			transform = t.FindChild("icon");
			bool flag3 = transform != null;
			if (flag3)
			{
				xnumberTween.m_uiIconTween = (t.FindChild("icon").GetComponent("XUIPlayTween") as IXUITweenTool);
			}
			return xnumberTween;
		}

		// Token: 0x0600C654 RID: 50772 RVA: 0x002BE5A8 File Offset: 0x002BC7A8
		public static XNumberTween Create(IXUILabel label)
		{
			XNumberTween xnumberTween = label.gameObject.AddComponent<XNumberTween>();
			xnumberTween.m_uiLabel = label;
			return xnumberTween;
		}

		// Token: 0x0600C655 RID: 50773 RVA: 0x002BE5D0 File Offset: 0x002BC7D0
		public void SetNumberWithTween(ulong target, string postfix = "", bool instant = false, bool dynamicAdjustDuaration = true)
		{
			bool flag = target == this.m_currentNumber || instant;
			if (flag)
			{
				this.m_uiLabel.SetText(XSingleton<UiUtility>.singleton.NumberFormat(target) + postfix);
				this.m_targetNumber = target;
				this.m_currentNumber = target;
			}
			else
			{
				this.m_tweenDuaration = this.userTweenDuaration;
				this.m_targetNumber = target;
				this.m_deltaNumber = (long)(this.m_targetNumber - this.m_currentNumber);
				this.m_tweenPostfix = postfix;
				if (dynamicAdjustDuaration)
				{
					long num = Math.Abs(this.m_deltaNumber);
					bool flag2 = num < 20L;
					if (flag2)
					{
						this.m_tweenDuaration = this.userTweenDuaration * (float)num / 20f;
					}
				}
				this.m_tweenLeftTime = this.m_tweenDuaration;
			}
		}

		// Token: 0x0600C656 RID: 50774 RVA: 0x002BE68C File Offset: 0x002BC88C
		private void Update()
		{
			bool flag = this.m_currentNumber != this.m_targetNumber;
			if (flag)
			{
				this.m_tweenLeftTime -= Time.deltaTime;
				bool flag2 = this.m_tweenLeftTime <= 0f;
				if (flag2)
				{
					this.m_currentNumber = this.m_targetNumber;
				}
				else
				{
					this.m_currentNumber = this.m_targetNumber - (ulong)((long)((float)this.m_deltaNumber * this.m_tweenLeftTime / this.m_tweenDuaration));
				}
				this.m_uiLabel.SetText(string.Format("{0}{1}", XSingleton<UiUtility>.singleton.NumberFormat(this.m_currentNumber), this.m_tweenPostfix));
			}
		}

		// Token: 0x040056FD RID: 22269
		private IXUILabel m_uiLabel;

		// Token: 0x040056FE RID: 22270
		private IXUITweenTool m_uiIconTween;

		// Token: 0x040056FF RID: 22271
		private ulong m_currentNumber = 0UL;

		// Token: 0x04005700 RID: 22272
		private ulong m_targetNumber = 0UL;

		// Token: 0x04005701 RID: 22273
		private long m_deltaNumber = 0L;

		// Token: 0x04005702 RID: 22274
		private string m_tweenPostfix;

		// Token: 0x04005703 RID: 22275
		private float m_tweenLeftTime = 0.5f;

		// Token: 0x04005704 RID: 22276
		private float m_tweenDuaration = 0.5f;

		// Token: 0x04005705 RID: 22277
		public float userTweenDuaration = 0.5f;
	}
}
