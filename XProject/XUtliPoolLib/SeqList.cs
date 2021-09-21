using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x020000D5 RID: 213
	public class SeqList<T>
	{
		// Token: 0x060005D2 RID: 1490 RVA: 0x0001AF4E File Offset: 0x0001914E
		public SeqList()
		{
			this.buff = new List<T>();
			this.Reset(2, 1);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x0001AF7A File Offset: 0x0001917A
		public SeqList(short dim, short count)
		{
			this.buff = new List<T>();
			this.Reset(dim, count);
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x0001AFA8 File Offset: 0x000191A8
		public short Count
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x0001AFC0 File Offset: 0x000191C0
		public short Dim
		{
			get
			{
				return this.m_dim;
			}
		}

		// Token: 0x170000A9 RID: 169
		public T this[int index, int dim]
		{
			get
			{
				return this.buff[index * (int)this.m_dim + dim];
			}
			set
			{
				this.buff[index * (int)this.m_dim + dim] = value;
			}
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x0001B01C File Offset: 0x0001921C
		public void Reset(short dim, short count)
		{
			this.m_dim = dim;
			this.m_count = count;
			this.buff.Clear();
			this.buff.Capacity = (int)(this.m_dim * this.m_count);
			for (int i = 0; i < this.buff.Capacity; i++)
			{
				this.buff.Add(default(T));
			}
		}

		// Token: 0x0400031F RID: 799
		public List<T> buff;

		// Token: 0x04000320 RID: 800
		private short m_dim = 2;

		// Token: 0x04000321 RID: 801
		private short m_count = 1;
	}
}
