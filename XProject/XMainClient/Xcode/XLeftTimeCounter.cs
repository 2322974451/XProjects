using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLeftTimeCounter
	{

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

		public void SetForward(int forward)
		{
			this.m_forward = forward;
		}

		public void SetFormatString(string formatString)
		{
			this.m_FormatString = formatString;
			this._SetLeftTimeText();
		}

		public int GetLeftTime()
		{
			return this.m_nLeftTime;
		}

		public float GetFloatLeftTime()
		{
			return this.m_fLeftTime;
		}

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

		public void SetFinishEventHandler(TimeOverFinishEventHandler finishEventHandler, object param = null)
		{
			this.m_FinishEventHandler = finishEventHandler;
			this.m_FinishParam = param;
		}

		public void SetTimeFormat(int lowCount, int upCount = 3, int minUnit = 4, bool needMillisecond = false)
		{
			this.m_lowCount = lowCount;
			this.m_upCount = upCount;
			this.m_minUnit = minUnit;
			this.m_needMillisecond = needMillisecond;
		}

		public void SetCarry()
		{
			this.m_isCarry = true;
		}

		public void SetNoNeedPadLeft()
		{
			this.m_needPadLeft = false;
		}

		public void SetFormat(bool isFormat)
		{
			this.m_isFormat = isFormat;
		}

		private float m_fLeftTime;

		private float m_startTime;

		private float m_Time;

		private int m_nLeftTime;

		private int m_nNoticeTime = 0;

		private bool m_autoSetVisible = false;

		private int m_forward = -1;

		private IXUILabel m_Label = null;

		private object m_FinishParam = null;

		private string m_FormatString = "";

		private TimeOverFinishEventHandler m_FinishEventHandler = null;

		private int m_lowCount = 2;

		private int m_upCount = 3;

		private int m_minUnit = 4;

		private bool m_isCarry = false;

		private bool m_needPadLeft = true;

		private bool m_needMillisecond = false;

		private bool m_isFormat = true;

		private IXUITweenTool m_tween = null;
	}
}
