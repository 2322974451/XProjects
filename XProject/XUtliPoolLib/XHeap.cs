using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x020001BB RID: 443
	internal class XHeap<T> where T : IComparable<T>, IHere
	{
		// Token: 0x060009F0 RID: 2544 RVA: 0x0003410E File Offset: 0x0003230E
		public XHeap()
		{
			this._heap = new List<T>();
			this._heapSize = 0;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x00034138 File Offset: 0x00032338
		public int HeapSize
		{
			get
			{
				return this._heapSize;
			}
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x00034150 File Offset: 0x00032350
		public void PushHeap(T item)
		{
			int count = this._heap.Count;
			bool flag = this._heapSize < count;
			if (flag)
			{
				this._heap[this._heapSize] = item;
			}
			else
			{
				this._heap.Add(item);
			}
			item.Here = this._heapSize;
			XHeap<T>.HeapifyUp(this._heap, this._heapSize);
			this._heapSize++;
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x000341D4 File Offset: 0x000323D4
		public T PopHeap()
		{
			T result = default(T);
			bool flag = this._heapSize > 0;
			if (flag)
			{
				this._heapSize--;
				XHeap<T>.Swap(this._heap, 0, this._heapSize);
				XHeap<T>.HeapifyDown(this._heap, 0, this._heapSize);
				result = this._heap[this._heapSize];
				result.Here = -1;
				this._heap[this._heapSize] = default(T);
			}
			return result;
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x00034270 File Offset: 0x00032470
		public void PopHeapAt(int Idx)
		{
			bool flag = this._heapSize > 0 && Idx >= 0 && Idx < this._heapSize;
			if (flag)
			{
				this._heapSize--;
				XHeap<T>.Swap(this._heap, Idx, this._heapSize);
				T t = this._heap[this._heapSize];
				bool flag2 = t.CompareTo(this._heap[Idx]) < 0;
				if (flag2)
				{
					XHeap<T>.HeapifyDown(this._heap, Idx, this._heapSize);
				}
				else
				{
					t = this._heap[this._heapSize];
					bool flag3 = t.CompareTo(this._heap[Idx]) > 0;
					if (flag3)
					{
						XHeap<T>.HeapifyUp(this._heap, Idx);
					}
				}
				t = this._heap[this._heapSize];
				t.Here = -1;
				this._heap[this._heapSize] = default(T);
			}
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x00034384 File Offset: 0x00032584
		public void Adjust(T item, bool downwords)
		{
			bool flag = this._heapSize > 1;
			if (flag)
			{
				if (downwords)
				{
					XHeap<T>.HeapifyDown(this._heap, item.Here, this._heapSize);
				}
				else
				{
					XHeap<T>.HeapifyUp(this._heap, item.Here);
				}
			}
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x000343E4 File Offset: 0x000325E4
		public static void MakeHeap(List<T> list)
		{
			for (int i = list.Count / 2 - 1; i >= 0; i--)
			{
				XHeap<T>.HeapifyDown(list, i, list.Count);
			}
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00034420 File Offset: 0x00032620
		public static void HeapSort(List<T> list)
		{
			bool flag = list.Count < 2;
			if (!flag)
			{
				XHeap<T>.MakeHeap(list);
				for (int i = list.Count - 1; i > 0; i--)
				{
					XHeap<T>.Swap(list, 0, i);
					XHeap<T>.HeapifyDown(list, 0, i);
				}
			}
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00034470 File Offset: 0x00032670
		public T Peek()
		{
			bool flag = this._heapSize > 0;
			T result;
			if (flag)
			{
				result = this._heap[0];
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x000344A8 File Offset: 0x000326A8
		public void Clear()
		{
			this._heap.Clear();
			this._heapSize = 0;
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x000344C0 File Offset: 0x000326C0
		private static void HeapifyDown(List<T> heap, int curIdx, int heapSize)
		{
			while (curIdx < heapSize)
			{
				int num = 2 * curIdx + 1;
				int num2 = 2 * curIdx + 2;
				T other = heap[curIdx];
				int num3 = curIdx;
				bool flag;
				if (num < heapSize)
				{
					T t = heap[num];
					flag = (t.CompareTo(other) < 0);
				}
				else
				{
					flag = false;
				}
				bool flag2 = flag;
				if (flag2)
				{
					other = heap[num];
					num3 = num;
				}
				bool flag3;
				if (num2 < heapSize)
				{
					T t = heap[num2];
					flag3 = (t.CompareTo(other) < 0);
				}
				else
				{
					flag3 = false;
				}
				bool flag4 = flag3;
				if (flag4)
				{
					other = heap[num2];
					num3 = num2;
				}
				bool flag5 = num3 != curIdx;
				if (!flag5)
				{
					break;
				}
				XHeap<T>.Swap(heap, curIdx, num3);
				curIdx = num3;
			}
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00034580 File Offset: 0x00032780
		private static void HeapifyUp(List<T> heap, int curIdx)
		{
			while (curIdx > 0)
			{
				int num = (curIdx - 1) / 2;
				T other = heap[num];
				int num2 = num;
				bool flag;
				if (num >= 0)
				{
					T t = heap[curIdx];
					flag = (t.CompareTo(other) < 0);
				}
				else
				{
					flag = false;
				}
				bool flag2 = flag;
				if (flag2)
				{
					num2 = curIdx;
				}
				bool flag3 = num2 != num;
				if (!flag3)
				{
					break;
				}
				XHeap<T>.Swap(heap, num, num2);
				curIdx = num;
			}
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x000345F4 File Offset: 0x000327F4
		private static void Swap(List<T> heap, int x, int y)
		{
			T value = heap[x];
			heap[x] = heap[y];
			T t = heap[x];
			t.Here = x;
			heap[y] = value;
			t = heap[y];
			t.Here = y;
		}

		// Token: 0x040004B7 RID: 1207
		private List<T> _heap = null;

		// Token: 0x040004B8 RID: 1208
		private int _heapSize = 0;
	}
}
