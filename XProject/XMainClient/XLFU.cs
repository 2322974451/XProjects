using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F20 RID: 3872
	internal class XLFU<T>
	{
		// Token: 0x0600CD04 RID: 52484 RVA: 0x002F3E3C File Offset: 0x002F203C
		public XLFU(int size)
		{
			bool flag = size <= 0;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("size <= 0", null, null, null, null, null);
			}
			this.m_Size = size;
		}

		// Token: 0x0600CD05 RID: 52485 RVA: 0x002F3EA5 File Offset: 0x002F20A5
		public void Clear()
		{
			this.m_Items.Clear();
			this.m_dicItems.Clear();
			this.m_HeapSize = 0;
			this.m_CurTotalCount = 0U;
		}

		// Token: 0x0600CD06 RID: 52486 RVA: 0x002F3ED0 File Offset: 0x002F20D0
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

		// Token: 0x0600CD07 RID: 52487 RVA: 0x002F3FEC File Offset: 0x002F21EC
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

		// Token: 0x0600CD08 RID: 52488 RVA: 0x002F4030 File Offset: 0x002F2230
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

		// Token: 0x0600CD09 RID: 52489 RVA: 0x002F40AC File Offset: 0x002F22AC
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

		// Token: 0x0600CD0A RID: 52490 RVA: 0x002F4118 File Offset: 0x002F2318
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

		// Token: 0x0600CD0B RID: 52491 RVA: 0x002F41AC File Offset: 0x002F23AC
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

		// Token: 0x0600CD0C RID: 52492 RVA: 0x002F41EC File Offset: 0x002F23EC
		private void Swap(int x, int y)
		{
			XLFUItem<T> value = this.m_Items[x];
			this.m_Items[x] = this.m_Items[y];
			this.m_Items[x].index = x;
			this.m_Items[y] = value;
			this.m_Items[y].index = y;
		}

		// Token: 0x0600CD0D RID: 52493 RVA: 0x002F4254 File Offset: 0x002F2454
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

		// Token: 0x0600CD0E RID: 52494 RVA: 0x002F4330 File Offset: 0x002F2530
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

		// Token: 0x04005B31 RID: 23345
		private static readonly uint DURATION_COUNT = 16U;

		// Token: 0x04005B32 RID: 23346
		private List<XLFUItem<T>> m_Items = new List<XLFUItem<T>>();

		// Token: 0x04005B33 RID: 23347
		private Dictionary<T, XLFUItem<T>> m_dicItems = new Dictionary<T, XLFUItem<T>>();

		// Token: 0x04005B34 RID: 23348
		private int m_HeapSize = 0;

		// Token: 0x04005B35 RID: 23349
		private int m_Size = 5;

		// Token: 0x04005B36 RID: 23350
		private uint m_CurTotalCount = 0U;
	}
}
