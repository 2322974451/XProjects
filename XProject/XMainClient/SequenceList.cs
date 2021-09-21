using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B06 RID: 2822
	public class SequenceList<T> : ISeqListRef<T>
	{
		// Token: 0x0600A645 RID: 42565 RVA: 0x001D341A File Offset: 0x001D161A
		public SequenceList()
		{
			this.buff = new List<T>();
			this.Reset(2, 1);
		}

		// Token: 0x17002FF2 RID: 12274
		// (get) Token: 0x0600A646 RID: 42566 RVA: 0x001D3448 File Offset: 0x001D1648
		public int Count
		{
			get
			{
				return this.m_count;
			}
		}

		// Token: 0x17002FF3 RID: 12275
		// (get) Token: 0x0600A647 RID: 42567 RVA: 0x001D3460 File Offset: 0x001D1660
		public int Dim
		{
			get
			{
				return (int)this.m_dim;
			}
		}

		// Token: 0x17002FF4 RID: 12276
		public T this[int index, int dim]
		{
			get
			{
				return this.buff[index * (int)this.m_dim + dim];
			}
			set
			{
				bool flag = this._CheckAndExpand(index, dim);
				if (flag)
				{
					this.buff[index * (int)this.m_dim + dim] = value;
				}
			}
		}

		// Token: 0x0600A64A RID: 42570 RVA: 0x001D34D4 File Offset: 0x001D16D4
		private bool _CheckAndExpand(int index, int dim)
		{
			bool flag = dim >= (int)this.m_dim;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = index >= this.m_count;
				if (flag2)
				{
					int i = this.buff.Count;
					int num = (int)this.m_dim * (index + 1);
					while (i < num)
					{
						this.buff.Add(default(T));
						i++;
					}
					this.m_count = index + 1;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A64B RID: 42571 RVA: 0x001D3558 File Offset: 0x001D1758
		public void CheckOrReset(short dim)
		{
			bool flag = this.m_dim != dim;
			if (flag)
			{
				this.Reset(dim);
			}
		}

		// Token: 0x0600A64C RID: 42572 RVA: 0x001D357E File Offset: 0x001D177E
		public void Reset(short dim)
		{
			this.m_dim = dim;
			this.m_count = 0;
			this.buff.Clear();
		}

		// Token: 0x0600A64D RID: 42573 RVA: 0x001D359C File Offset: 0x001D179C
		public void Reset(short dim, int count)
		{
			this.m_dim = dim;
			this.m_count = count;
			this.buff.Clear();
			this.buff.Capacity = (int)this.m_dim * Math.Max(this.m_count, 1);
			int i = 0;
			int num = this.m_count * (int)this.m_dim;
			while (i < num)
			{
				this.buff.Add(default(T));
				i++;
			}
		}

		// Token: 0x0600A64E RID: 42574 RVA: 0x001D3618 File Offset: 0x001D1818
		public void Append(params T[] args)
		{
			int count = this.m_count;
			int num = 0;
			while (num < args.Length && num < (int)this.m_dim)
			{
				this[count, num] = args[num];
				num++;
			}
		}

		// Token: 0x0600A64F RID: 42575 RVA: 0x001D3660 File Offset: 0x001D1860
		public void Append(ISeqListRef<T> other, int dim)
		{
			bool flag = dim != (int)this.m_dim;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog2("Dim not the same: {0} != {1} ", new object[]
				{
					this.m_dim,
					" != ",
					dim
				});
			}
			else
			{
				for (int i = 0; i < other.Count; i++)
				{
					int count = this.m_count;
					for (int j = 0; j < dim; j++)
					{
						this[count, j] = other[i, j];
					}
				}
			}
		}

		// Token: 0x0600A650 RID: 42576 RVA: 0x001D36FC File Offset: 0x001D18FC
		public void Get(int index, T[] outData)
		{
			for (int i = 0; i < (int)this.m_dim; i++)
			{
				outData[i] = this[index, i];
			}
		}

		// Token: 0x0600A651 RID: 42577 RVA: 0x001D3730 File Offset: 0x001D1930
		public void Set(int index, T[] inData)
		{
			int num = 0;
			while (num < (int)this.m_dim && num < inData.Length)
			{
				this[index, num] = inData[num];
				num++;
			}
		}

		// Token: 0x0600A652 RID: 42578 RVA: 0x001D3770 File Offset: 0x001D1970
		public void Trim(int newCount)
		{
			bool flag = this.m_count <= newCount;
			if (!flag)
			{
				this.m_count = newCount;
			}
		}

		// Token: 0x04003D2E RID: 15662
		public List<T> buff;

		// Token: 0x04003D2F RID: 15663
		private short m_dim = 2;

		// Token: 0x04003D30 RID: 15664
		private int m_count = 1;
	}
}
