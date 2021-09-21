using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001720 RID: 5920
	internal class AuctionNumberOperate
	{
		// Token: 0x0600F489 RID: 62601 RVA: 0x0036F01C File Offset: 0x0036D21C
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

		// Token: 0x0600F48A RID: 62602 RVA: 0x0036F178 File Offset: 0x0036D378
		public void SetEnable(bool enable)
		{
			this.m_curEnabel = enable;
			bool flag = this.m_transform != null;
			if (flag)
			{
				this.m_transform.gameObject.SetActive(this.m_curEnabel);
			}
		}

		// Token: 0x170037A9 RID: 14249
		// (get) Token: 0x0600F48B RID: 62603 RVA: 0x0036F1B4 File Offset: 0x0036D3B4
		public int Min
		{
			get
			{
				return this.m_min;
			}
		}

		// Token: 0x170037AA RID: 14250
		// (get) Token: 0x0600F48C RID: 62604 RVA: 0x0036F1CC File Offset: 0x0036D3CC
		public int Max
		{
			get
			{
				return this.m_max;
			}
		}

		// Token: 0x170037AB RID: 14251
		// (get) Token: 0x0600F48D RID: 62605 RVA: 0x0036F1E4 File Offset: 0x0036D3E4
		public int Cur
		{
			get
			{
				return this.m_cur;
			}
		}

		// Token: 0x170037AC RID: 14252
		// (get) Token: 0x0600F48E RID: 62606 RVA: 0x0036F1FC File Offset: 0x0036D3FC
		public int Step
		{
			get
			{
				return this.m_step;
			}
		}

		// Token: 0x0600F48F RID: 62607 RVA: 0x0036F214 File Offset: 0x0036D414
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

		// Token: 0x0600F490 RID: 62608 RVA: 0x0036F254 File Offset: 0x0036D454
		public void OnClickLabelHandler(IXUILabel label)
		{
			bool flag = !this.m_showNumber || !this.m_curEnabel || this.m_max == this.m_min;
			if (!flag)
			{
				this.m_inputNumberCall = 0;
				DlgBase<CalculatorDlg, CalculatorBehaviour>.singleton.Show(new CalculatorKeyBack(this.OnCalculatorCall), this.m_offset);
			}
		}

		// Token: 0x0600F491 RID: 62609 RVA: 0x0036F2B0 File Offset: 0x0036D4B0
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

		// Token: 0x0600F492 RID: 62610 RVA: 0x0036F3A0 File Offset: 0x0036D5A0
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

		// Token: 0x0600F493 RID: 62611 RVA: 0x0036F3E9 File Offset: 0x0036D5E9
		public void RegisterOperateChange(AuctionNumberOperate.NumberOperateCallBack call)
		{
			this.m_numberOperateCall = call;
		}

		// Token: 0x0600F494 RID: 62612 RVA: 0x0036F3F4 File Offset: 0x0036D5F4
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

		// Token: 0x0600F495 RID: 62613 RVA: 0x0036F46C File Offset: 0x0036D66C
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

		// Token: 0x0600F496 RID: 62614 RVA: 0x0036F4E1 File Offset: 0x0036D6E1
		private void OnMaxClickHandler(IXUISprite sprite)
		{
			this.CalculateOperate(this.m_max, false);
		}

		// Token: 0x0600F497 RID: 62615 RVA: 0x0036F4F4 File Offset: 0x0036D6F4
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

		// Token: 0x0600F498 RID: 62616 RVA: 0x0036F596 File Offset: 0x0036D796
		public virtual void Dispose()
		{
			this.m_numberOperateCall = null;
		}

		// Token: 0x04006966 RID: 26982
		private IXUISprite m_Add;

		// Token: 0x04006967 RID: 26983
		private IXUISprite m_Sub;

		// Token: 0x04006968 RID: 26984
		private IXUISprite m_Max;

		// Token: 0x04006969 RID: 26985
		private IXUILabel m_Number;

		// Token: 0x0400696A RID: 26986
		private Transform m_transform;

		// Token: 0x0400696B RID: 26987
		private GameObject m_gameObject;

		// Token: 0x0400696C RID: 26988
		private int m_min;

		// Token: 0x0400696D RID: 26989
		private int m_max;

		// Token: 0x0400696E RID: 26990
		private int m_cur;

		// Token: 0x0400696F RID: 26991
		private int m_step;

		// Token: 0x04006970 RID: 26992
		private Vector3 m_offset;

		// Token: 0x04006971 RID: 26993
		private int m_inputNumberCall = 0;

		// Token: 0x04006972 RID: 26994
		private bool m_curEnabel = true;

		// Token: 0x04006973 RID: 26995
		private bool m_showNumber = true;

		// Token: 0x04006974 RID: 26996
		private bool m_showUnderLine = false;

		// Token: 0x04006975 RID: 26997
		private AuctionNumberOperate.NumberOperateCallBack m_numberOperateCall;

		// Token: 0x02001A06 RID: 6662
		// (Invoke) Token: 0x0601110C RID: 69900
		public delegate void NumberOperateCallBack();
	}
}
