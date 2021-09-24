using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class AuctionNumberOperate
	{

		public AuctionNumberOperate(GameObject go, Vector3 offset)
		{
			this.m_gameObject = go;
			this.m_transform = go.transform;
			this.m_offset = offset;
			this.m_Number = (this.m_transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel);
			this.m_Add = (this.m_transform.FindChild("Add").GetComponent("XUISprite") as IXUISprite);
			this.m_Sub = (this.m_transform.FindChild("Sub").GetComponent("XUISprite") as IXUISprite);
			Transform transform = this.m_transform.FindChild("Max");
			bool flag = transform != null;
			if (flag)
			{
				this.m_Max = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			this.m_Add.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddClickHandler));
			this.m_Sub.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSubClickHandler));
			this.m_Number.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnClickLabelHandler));
			bool flag2 = this.m_Max != null;
			if (flag2)
			{
				this.m_Max.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnMaxClickHandler));
			}
		}

		public void SetEnable(bool enable)
		{
			this.m_curEnabel = enable;
			bool flag = this.m_transform != null;
			if (flag)
			{
				this.m_transform.gameObject.SetActive(this.m_curEnabel);
			}
		}

		public int Min
		{
			get
			{
				return this.m_min;
			}
		}

		public int Max
		{
			get
			{
				return this.m_max;
			}
		}

		public int Cur
		{
			get
			{
				return this.m_cur;
			}
		}

		public int Step
		{
			get
			{
				return this.m_step;
			}
		}

		public void Set(int max, int min = 1, int cur = 1, int step = 1, bool showNum = true, bool showUnderLine = false)
		{
			this.m_max = max;
			this.m_min = min;
			this.m_cur = cur;
			this.m_step = step;
			this.m_showNumber = showNum;
			this.m_showUnderLine = showUnderLine;
			this.CalculateOperate(this.m_cur, true);
		}

		public void OnClickLabelHandler(IXUILabel label)
		{
			bool flag = !this.m_showNumber || !this.m_curEnabel || this.m_max == this.m_min;
			if (!flag)
			{
				this.m_inputNumberCall = 0;
				DlgBase<CalculatorDlg, CalculatorBehaviour>.singleton.Show(new CalculatorKeyBack(this.OnCalculatorCall), this.m_offset);
			}
		}

		private void OnCalculatorCall(CalculatorKey value)
		{
			switch (value)
			{
			case CalculatorKey.OK:
				this.CalculateOperate(this.m_inputNumberCall, true);
				break;
			case CalculatorKey.DEL:
				this.m_inputNumberCall = 0;
				this.SetTxt(this.m_inputNumberCall);
				break;
			case CalculatorKey.MAX:
				this.m_inputNumberCall = this.m_max;
				this.SetTxt(this.m_inputNumberCall);
				break;
			default:
			{
				int num = XFastEnumIntEqualityComparer<CalculatorKey>.ToInt(value);
				bool flag = num >= 0 && num <= 9;
				if (flag)
				{
					this.m_inputNumberCall = this.m_inputNumberCall * 10 + num;
					bool flag2 = this.m_inputNumberCall > this.m_max;
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_COUNT_UNADD"), "fece00");
					}
					this.m_inputNumberCall = Math.Min(this.m_inputNumberCall, this.m_max);
					this.SetTxt(this.m_inputNumberCall);
				}
				break;
			}
			}
		}

		private void SetTxt(int num)
		{
			bool showUnderLine = this.m_showUnderLine;
			if (showUnderLine)
			{
				this.m_Number.SetText(string.Format("[u]{0}[-]", num));
			}
			else
			{
				this.m_Number.SetText(num.ToString());
			}
		}

		public void RegisterOperateChange(AuctionNumberOperate.NumberOperateCallBack call)
		{
			this.m_numberOperateCall = call;
		}

		private void OnAddClickHandler(IXUISprite sprite)
		{
			bool flag = !this.m_curEnabel || this.m_max == this.m_min;
			if (!flag)
			{
				bool flag2 = this.m_cur + this.m_step > this.m_max;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_COUNT_UNADD"), "fece00");
				}
				this.CalculateOperate(this.m_cur + this.m_step, false);
			}
		}

		private void OnSubClickHandler(IXUISprite sprite)
		{
			bool flag = !this.m_curEnabel || this.m_max == this.m_min;
			if (!flag)
			{
				bool flag2 = this.m_cur - this.m_step < this.m_min;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("AUCTION_COUNT_UNSUB"), "fece00");
				}
				this.CalculateOperate(this.m_cur - this.m_step, false);
			}
		}

		private void OnMaxClickHandler(IXUISprite sprite)
		{
			this.CalculateOperate(this.m_max, false);
		}

		private void CalculateOperate(int cur, bool active = false)
		{
			cur = Mathf.Max(this.m_min, cur);
			cur = Mathf.Min(this.m_max, cur);
			bool flag = !active && this.m_cur == cur;
			if (!flag)
			{
				this.m_cur = cur;
				this.m_Add.SetGrey(this.m_cur < this.m_max);
				this.m_Sub.SetGrey(this.m_cur > this.m_min);
				this.SetTxt(this.m_cur);
				bool flag2 = this.m_numberOperateCall != null;
				if (flag2)
				{
					this.m_numberOperateCall();
				}
			}
		}

		public virtual void Dispose()
		{
			this.m_numberOperateCall = null;
		}

		private IXUISprite m_Add;

		private IXUISprite m_Sub;

		private IXUISprite m_Max;

		private IXUILabel m_Number;

		private Transform m_transform;

		private GameObject m_gameObject;

		private int m_min;

		private int m_max;

		private int m_cur;

		private int m_step;

		private Vector3 m_offset;

		private int m_inputNumberCall = 0;

		private bool m_curEnabel = true;

		private bool m_showNumber = true;

		private bool m_showUnderLine = false;

		private AuctionNumberOperate.NumberOperateCallBack m_numberOperateCall;

		public delegate void NumberOperateCallBack();
	}
}
