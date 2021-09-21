using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AC0 RID: 2752
	internal class AIRunTimeRandomIndex
	{
		// Token: 0x0600A57C RID: 42364 RVA: 0x001CC785 File Offset: 0x001CA985
		public void AppendIndex()
		{
			this.m_IndexList.Add(this.m_IndexList.Count);
		}

		// Token: 0x0600A57D RID: 42365 RVA: 0x001CC7A0 File Offset: 0x001CA9A0
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

		// Token: 0x17002FEF RID: 12271
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

		// Token: 0x04003C7D RID: 15485
		private List<int> m_IndexList = new List<int>();
	}
}
