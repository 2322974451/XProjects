using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E72 RID: 3698
	internal class XLeftTimeCounter
	{
		// Token: 0x0600C604 RID: 50692 RVA: 0x002BD4F4 File Offset: 0x002BB6F4
		public XLeftTimeCounter(IXUILabel label, bool autoSetVisible = false)
		{
			this.m_Label = label;
			this.m_autoSetVisible = autoSetVisible;
			bool autoSetVisible2 = this.m_autoSetVisible;
			if (autoSetVisible2)
			{
				this.m_Label.SetVisible(false);
			}
			this.m_tween = (label.gameObject.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.SetLeftTimeFx(false);
		}

		// Token: 0x0600C605 RID: 50693 RVA: 0x002BD5BE File Offset: 0x002BB7BE
		public void SetForward(int forward)
		{
			this.m_forward = forward;
		}

		// Token: 0x0600C606 RID: 50694 RVA: 0x002BD5C8 File Offset: 0x002BB7C8
		public void SetFormatString(string formatString)
		{
			this.m_FormatString = formatString;
			this._SetLeftTimeText();
		}

		// Token: 0x0600C607 RID: 50695 RVA: 0x002BD5DC File Offset: 0x002BB7DC
		public int GetLeftTime()
		{
			return this.m_nLeftTime;
		}

		// Token: 0x0600C608 RID: 50696 RVA: 0x002BD5F4 File Offset: 0x002BB7F4
		public float GetFloatLeftTime()
		{
			return this.m_fLeftTime;
		}

		// Token: 0x0600C609 RID: 50697 RVA: 0x002BD60C File Offset: 0x002BB80C
		public void SetLeftTime(float seconds, int noticeTime = -1)
		{
			this.m_startTime = Time.time;
			this.m_fLeftTime = seconds;
			this.m_Time = seconds;
			bool flag = noticeTime != -1;
			if (flag)
			{
				this.m_nNoticeTime = noticeTime;
			}
			this._SetLeftTimeText();
			this.SetLeftTimeFx(false);
		}

		// Token: 0x0600C60A RID: 50698 RVA: 0x002BD654 File Offset: 0x002BB854
		public int Update()
		{
			bool flag = this.m_fLeftTime > 0f;
			int result;
			if (flag)
			{
				bool flag2 = this.m_autoSetVisible && !this.m_Label.IsVisible();
				if (flag2)
				{
					this.m_Label.SetVisible(true);
				}
				this.m_fLeftTime = Math.Max(this.m_Time + (float)this.m_forward * (Time.time - this.m_startTime), 0f);
				bool flag3 = this.m_nLeftTime != (int)this.m_fLeftTime || this.m_needMillisecond;
				if (flag3)
				{
					this._SetLeftTimeText();
					bool flag4 = this.m_tween != null && this.m_forward == -1 && this.m_nLeftTime < this.m_nNoticeTime;
					if (flag4)
					{
						this.SetLeftTimeFx(true);
					}
				}
				result = this.m_nLeftTime;
			}
			else
			{
				bool flag5 = this.m_FinishEventHandler != null;
				if (flag5)
				{
					this.m_FinishEventHandler(this.m_FinishParam);
					this.m_FinishEventHandler = null;
				}
				bool flag6 = this.m_autoSetVisible && this.m_Label.IsVisible();
				if (flag6)
				{
					this.m_Label.SetVisible(false);
				}
				result = 0;
			}
			return result;
		}

		// Token: 0x0600C60B RID: 50699 RVA: 0x002BD78C File Offset: 0x002BB98C
		private void _SetLeftTimeText()
		{
			this.m_nLeftTime = (int)this.m_fLeftTime;
			bool isFormat = this.m_isFormat;
			string text;
			if (isFormat)
			{
				bool needMillisecond = this.m_needMillisecond;
				if (needMillisecond)
				{
					text = XSingleton<UiUtility>.singleton.TimeFormatString(this.m_fLeftTime, this.m_lowCount, this.m_upCount, this.m_minUnit, this.m_isCarry);
				}
				else
				{
					text = XSingleton<UiUtility>.singleton.TimeFormatString(this.m_nLeftTime, this.m_lowCount, this.m_upCount, this.m_minUnit, this.m_isCarry, this.m_needPadLeft);
				}
			}
			else
			{
				text = this.m_nLeftTime.ToString();
			}
			bool flag = string.IsNullOrEmpty(this.m_FormatString);
			if (flag)
			{
				this.m_Label.SetText(text);
			}
			else
			{
				this.m_Label.SetText(string.Format(this.m_FormatString, text));
			}
		}

		// Token: 0x0600C60C RID: 50700 RVA: 0x002BD868 File Offset: 0x002BBA68
		private void SetLeftTimeFx(bool bVisable)
		{
			bool flag = this.m_tween != null;
			if (flag)
			{
				if (bVisable)
				{
					this.m_tween.PlayTween(true, -1f);
				}
				else
				{
					this.m_tween.ResetTween(true);
					this.m_tween.StopTween();
				}
			}
		}

		// Token: 0x0600C60D RID: 50701 RVA: 0x002BD8BB File Offset: 0x002BBABB
		public void SetFinishEventHandler(TimeOverFinishEventHandler finishEventHandler, object param = null)
		{
			this.m_FinishEventHandler = finishEventHandler;
			this.m_FinishParam = param;
		}

		// Token: 0x0600C60E RID: 50702 RVA: 0x002BD8CC File Offset: 0x002BBACC
		public void SetTimeFormat(int lowCount, int upCount = 3, int minUnit = 4, bool needMillisecond = false)
		{
			this.m_lowCount = lowCount;
			this.m_upCount = upCount;
			this.m_minUnit = minUnit;
			this.m_needMillisecond = needMillisecond;
		}

		// Token: 0x0600C60F RID: 50703 RVA: 0x002BD8EC File Offset: 0x002BBAEC
		public void SetCarry()
		{
			this.m_isCarry = true;
		}

		// Token: 0x0600C610 RID: 50704 RVA: 0x002BD8F6 File Offset: 0x002BBAF6
		public void SetNoNeedPadLeft()
		{
			this.m_needPadLeft = false;
		}

		// Token: 0x0600C611 RID: 50705 RVA: 0x002BD900 File Offset: 0x002BBB00
		public void SetFormat(bool isFormat)
		{
			this.m_isFormat = isFormat;
		}

		// Token: 0x040056DF RID: 22239
		private float m_fLeftTime;

		// Token: 0x040056E0 RID: 22240
		private float m_startTime;

		// Token: 0x040056E1 RID: 22241
		private float m_Time;

		// Token: 0x040056E2 RID: 22242
		private int m_nLeftTime;

		// Token: 0x040056E3 RID: 22243
		private int m_nNoticeTime = 0;

		// Token: 0x040056E4 RID: 22244
		private bool m_autoSetVisible = false;

		// Token: 0x040056E5 RID: 22245
		private int m_forward = -1;

		// Token: 0x040056E6 RID: 22246
		private IXUILabel m_Label = null;

		// Token: 0x040056E7 RID: 22247
		private object m_FinishParam = null;

		// Token: 0x040056E8 RID: 22248
		private string m_FormatString = "";

		// Token: 0x040056E9 RID: 22249
		private TimeOverFinishEventHandler m_FinishEventHandler = null;

		// Token: 0x040056EA RID: 22250
		private int m_lowCount = 2;

		// Token: 0x040056EB RID: 22251
		private int m_upCount = 3;

		// Token: 0x040056EC RID: 22252
		private int m_minUnit = 4;

		// Token: 0x040056ED RID: 22253
		private bool m_isCarry = false;

		// Token: 0x040056EE RID: 22254
		private bool m_needPadLeft = true;

		// Token: 0x040056EF RID: 22255
		private bool m_needMillisecond = false;

		// Token: 0x040056F0 RID: 22256
		private bool m_isFormat = true;

		// Token: 0x040056F1 RID: 22257
		private IXUITweenTool m_tween = null;
	}
}
