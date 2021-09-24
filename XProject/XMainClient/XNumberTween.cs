using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	public class XNumberTween : MonoBehaviour
	{

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

		public IXUILabel Label
		{
			get
			{
				return this.m_uiLabel;
			}
		}

		public IXUITweenTool IconTween
		{
			get
			{
				return this.m_uiIconTween;
			}
		}

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

		public static XNumberTween Create(IXUILabel label)
		{
			XNumberTween xnumberTween = label.gameObject.AddComponent<XNumberTween>();
			xnumberTween.m_uiLabel = label;
			return xnumberTween;
		}

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

		private IXUILabel m_uiLabel;

		private IXUITweenTool m_uiIconTween;

		private ulong m_currentNumber = 0UL;

		private ulong m_targetNumber = 0UL;

		private long m_deltaNumber = 0L;

		private string m_tweenPostfix;

		private float m_tweenLeftTime = 0.5f;

		private float m_tweenDuaration = 0.5f;

		public float userTweenDuaration = 0.5f;
	}
}
