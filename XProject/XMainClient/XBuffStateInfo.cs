using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DB7 RID: 3511
	internal class XBuffStateInfo
	{
		// Token: 0x0600BE4B RID: 48715 RVA: 0x0027ACA6 File Offset: 0x00278EA6
		public XBuffStateInfo()
		{
			this._BuffState = new short[XFastEnumIntEqualityComparer<XBuffType>.ToInt(XBuffType.XBuffType_Max)];
			this._StateParam = new int[XFastEnumIntEqualityComparer<XBuffType>.ToInt(XBuffType.XBuffType_Max)];
		}

		// Token: 0x0600BE4C RID: 48716 RVA: 0x0027ACD4 File Offset: 0x00278ED4
		public void CheckBuffState()
		{
			for (int i = 0; i < this._BuffState.Length; i++)
			{
				bool flag = this._BuffState[i] != 0;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("Clear buff, state {0} is {1}", i, this._BuffState[i]), null, null, null, null, null);
				}
			}
		}

		// Token: 0x0600BE4D RID: 48717 RVA: 0x0027AD3C File Offset: 0x00278F3C
		public void Reset()
		{
			for (int i = 0; i < this._BuffState.Length; i++)
			{
				this._BuffState[i] = 0;
				this._StateParam[i] = 0;
			}
		}

		// Token: 0x0600BE4E RID: 48718 RVA: 0x0027AD75 File Offset: 0x00278F75
		public void SetBuffState(XBuffType state, short count)
		{
			this._BuffState[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] = count;
		}

		// Token: 0x0600BE4F RID: 48719 RVA: 0x0027AD88 File Offset: 0x00278F88
		public void IncBuffState(XBuffType state, int param = 0)
		{
			short[] buffState = this._BuffState;
			int num = XFastEnumIntEqualityComparer<XBuffType>.ToInt(state);
			buffState[num] += 1;
			if (state != XBuffType.XBuffType_Transform && state != XBuffType.XBuffType_Scale)
			{
				this._StateParam[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] += param;
			}
			else
			{
				this._StateParam[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] = param;
			}
		}

		// Token: 0x0600BE50 RID: 48720 RVA: 0x0027ADE8 File Offset: 0x00278FE8
		public void DecBuffState(XBuffType state, int param = 0)
		{
			int num = XFastEnumIntEqualityComparer<XBuffType>.ToInt(state);
			short[] buffState = this._BuffState;
			int num2 = num;
			buffState[num2] -= 1;
			if (state != XBuffType.XBuffType_Transform && state != XBuffType.XBuffType_Scale)
			{
				this._StateParam[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] -= param;
			}
			else
			{
				bool flag = this._StateParam[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] == param;
				if (flag)
				{
					this._StateParam[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] = 0;
				}
			}
			bool flag2 = this._BuffState[num] < 0;
			if (flag2)
			{
			}
		}

		// Token: 0x0600BE51 RID: 48721 RVA: 0x0027AE6C File Offset: 0x0027906C
		public bool IsBuffStateOn(XBuffType state)
		{
			return this._BuffState[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] != 0;
		}

		// Token: 0x0600BE52 RID: 48722 RVA: 0x0027AE90 File Offset: 0x00279090
		public short GetBuffStateCounter(XBuffType state)
		{
			return this._BuffState[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)];
		}

		// Token: 0x0600BE53 RID: 48723 RVA: 0x0027AEB0 File Offset: 0x002790B0
		public int GetStateParam(XBuffType state)
		{
			return this._StateParam[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)];
		}

		// Token: 0x0600BE54 RID: 48724 RVA: 0x0027AECF File Offset: 0x002790CF
		public void SetStateParam(XBuffType state, int v)
		{
			this._StateParam[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] = v;
		}

		// Token: 0x04004DBA RID: 19898
		protected short[] _BuffState;

		// Token: 0x04004DBB RID: 19899
		protected int[] _StateParam;
	}
}
