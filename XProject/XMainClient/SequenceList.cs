using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	public class SequenceList<T> : ISeqListRef<T>
	{

		public SequenceList()
		{
			this.buff = new List<T>();
			this.Reset(2, 1);
		}

		public int Count
		{
			get
			{
				return this.m_count;
			}
		}

		public int Dim
		{
			get
			{
				return (int)this.m_dim;
			}
		}

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

		public void CheckOrReset(short dim)
		{
			bool flag = this.m_dim != dim;
			if (flag)
			{
				this.Reset(dim);
			}
		}

		public void Reset(short dim)
		{
			this.m_dim = dim;
			this.m_count = 0;
			this.buff.Clear();
		}

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

		public void Get(int index, T[] outData)
		{
			for (int i = 0; i < (int)this.m_dim; i++)
			{
				outData[i] = this[index, i];
			}
		}

		public void Set(int index, T[] inData)
		{
			int num = 0;
			while (num < (int)this.m_dim && num < inData.Length)
			{
				this[index, num] = inData[num];
				num++;
			}
		}

		public void Trim(int newCount)
		{
			bool flag = this.m_count <= newCount;
			if (!flag)
			{
				this.m_count = newCount;
			}
		}

		public List<T> buff;

		private short m_dim = 2;

		private int m_count = 1;
	}
}
