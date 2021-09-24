using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLFU<T>
	{

		public XLFU(int size)
		{
			bool flag = size <= 0;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("size <= 0", null, null, null, null, null);
			}
			this.m_Size = size;
		}

		public void Clear()
		{
			this.m_Items.Clear();
			this.m_dicItems.Clear();
			this.m_HeapSize = 0;
			this.m_CurTotalCount = 0U;
		}

		public T Add(T t)
		{
			this._AdjustFrequent();
			XLFUItem<T> xlfuitem = null;
			bool flag = this.m_dicItems.TryGetValue(t, out xlfuitem);
			if (!flag)
			{
				bool flag2 = this.m_HeapSize >= this.m_Items.Count;
				if (flag2)
				{
					xlfuitem = new XLFUItem<T>();
					this.m_Items.Add(xlfuitem);
				}
				else
				{
					xlfuitem = this.m_Items[this.m_HeapSize];
				}
				xlfuitem.data = t;
				xlfuitem.frequent = 0U;
				this.m_dicItems.Add(t, xlfuitem);
				xlfuitem.index = this.m_HeapSize;
				this.m_HeapSize++;
				this._PercolateUp(xlfuitem);
			}
			xlfuitem.bCanPop = false;
			xlfuitem.frequent += 1U;
			this._PercolateDown(xlfuitem);
			bool flag3 = this.m_HeapSize > this.m_Size;
			if (flag3)
			{
				XLFUItem<T> xlfuitem2 = this.m_Items[0];
				bool bCanPop = xlfuitem2.bCanPop;
				if (bCanPop)
				{
					return this.Pop();
				}
			}
			return default(T);
		}

		public void MarkCanPop(T t, bool bCanPop)
		{
			XLFUItem<T> xlfuitem = null;
			bool flag = this.m_dicItems.TryGetValue(t, out xlfuitem);
			if (flag)
			{
				xlfuitem.bCanPop = bCanPop;
				if (bCanPop)
				{
					this._PercolateUp(xlfuitem);
				}
				else
				{
					this._PercolateDown(xlfuitem);
				}
			}
		}

		public void Remove(T t)
		{
			XLFUItem<T> xlfuitem = null;
			bool flag = this.m_dicItems.TryGetValue(t, out xlfuitem);
			if (flag)
			{
				this.m_HeapSize--;
				int index = xlfuitem.index;
				this.Swap(index, this.m_HeapSize);
				this._PercolateDown(this.m_Items[index]);
				this.m_dicItems.Remove(this.m_Items[this.m_HeapSize].data);
			}
		}

		private void _AdjustFrequent()
		{
			this.m_CurTotalCount += 1U;
			bool flag = this.m_CurTotalCount >= XLFU<T>.DURATION_COUNT;
			if (flag)
			{
				for (int i = 0; i < this.m_HeapSize; i++)
				{
					this.m_Items[i].frequent >>= 1;
				}
				this.m_CurTotalCount = 0U;
			}
		}

		public T Pop()
		{
			bool flag = this.m_HeapSize > 0;
			T result;
			if (flag)
			{
				this.m_HeapSize--;
				this.Swap(0, this.m_HeapSize);
				this._PercolateDown(this.m_Items[0]);
				this.m_dicItems.Remove(this.m_Items[this.m_HeapSize].data);
				result = this.m_Items[this.m_HeapSize].data;
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		public T Peek()
		{
			bool flag = this.m_HeapSize > 0;
			T result;
			if (flag)
			{
				result = this.m_Items[0].data;
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		private void Swap(int x, int y)
		{
			XLFUItem<T> value = this.m_Items[x];
			this.m_Items[x] = this.m_Items[y];
			this.m_Items[x].index = x;
			this.m_Items[y] = value;
			this.m_Items[y].index = y;
		}

		private void _PercolateDown(XLFUItem<T> item)
		{
			int i = item.index;
			int heapSize = this.m_HeapSize;
			while (i < heapSize)
			{
				int num = 2 * i + 1;
				int num2 = 2 * i + 2;
				XLFUItem<T> other = this.m_Items[i];
				int num3 = i;
				bool flag = num < heapSize && this.m_Items[num].CompareTo(other) < 0;
				if (flag)
				{
					other = this.m_Items[num];
					num3 = num;
				}
				bool flag2 = num2 < heapSize && this.m_Items[num2].CompareTo(other) < 0;
				if (flag2)
				{
					other = this.m_Items[num2];
					num3 = num2;
				}
				bool flag3 = num3 != i;
				if (!flag3)
				{
					break;
				}
				this.Swap(i, num3);
				i = num3;
			}
		}

		private void _PercolateUp(XLFUItem<T> item)
		{
			int num;
			for (int i = item.index; i > 0; i = num)
			{
				num = (i - 1) / 2;
				XLFUItem<T> other = this.m_Items[num];
				int num2 = num;
				bool flag = num >= 0 && this.m_Items[i].CompareTo(other) < 0;
				if (flag)
				{
					num2 = i;
				}
				bool flag2 = num2 != num;
				if (!flag2)
				{
					break;
				}
				this.Swap(num, num2);
			}
		}

		private static readonly uint DURATION_COUNT = 16U;

		private List<XLFUItem<T>> m_Items = new List<XLFUItem<T>>();

		private Dictionary<T, XLFUItem<T>> m_dicItems = new Dictionary<T, XLFUItem<T>>();

		private int m_HeapSize = 0;

		private int m_Size = 5;

		private uint m_CurTotalCount = 0U;
	}
}
