using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffStateInfo
	{

		public XBuffStateInfo()
		{
			this._BuffState = new short[XFastEnumIntEqualityComparer<XBuffType>.ToInt(XBuffType.XBuffType_Max)];
			this._StateParam = new int[XFastEnumIntEqualityComparer<XBuffType>.ToInt(XBuffType.XBuffType_Max)];
		}

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

		public void Reset()
		{
			for (int i = 0; i < this._BuffState.Length; i++)
			{
				this._BuffState[i] = 0;
				this._StateParam[i] = 0;
			}
		}

		public void SetBuffState(XBuffType state, short count)
		{
			this._BuffState[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] = count;
		}

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

		public bool IsBuffStateOn(XBuffType state)
		{
			return this._BuffState[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] != 0;
		}

		public short GetBuffStateCounter(XBuffType state)
		{
			return this._BuffState[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)];
		}

		public int GetStateParam(XBuffType state)
		{
			return this._StateParam[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)];
		}

		public void SetStateParam(XBuffType state, int v)
		{
			this._StateParam[XFastEnumIntEqualityComparer<XBuffType>.ToInt(state)] = v;
		}

		protected short[] _BuffState;

		protected int[] _StateParam;
	}
}
