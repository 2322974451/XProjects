using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeRandomIndex
	{

		public void AppendIndex()
		{
			this.m_IndexList.Add(this.m_IndexList.Count);
		}

		public void Rand()
		{
			for (int i = this.m_IndexList.Count - 1; i > 0; i--)
			{
				int num = XSingleton<XCommon>.singleton.RandomInt(i + 1);
				bool flag = num == i;
				if (!flag)
				{
					int value = this.m_IndexList[num];
					this.m_IndexList[num] = this.m_IndexList[i];
					this.m_IndexList[i] = value;
				}
			}
		}

		public int this[int index]
		{
			get
			{
				bool flag = index < 0 || index >= this.m_IndexList.Count;
				int result;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Random index out of range, try get ", index.ToString(), " but length = ", this.m_IndexList.Count.ToString(), null, null);
					result = 0;
				}
				else
				{
					result = this.m_IndexList[index];
				}
				return result;
			}
		}

		private List<int> m_IndexList = new List<int>();
	}
}
