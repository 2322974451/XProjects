using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{

	internal class XHeap<T> where T : IComparable<T>, IHere
	{

		public XHeap()
		{
			this._heap = new List<T>();
			this._heapSize = 0;
		}

		public int HeapSize
		{
			get
			{
				return this._heapSize;
			}
		}

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

		public static void MakeHeap(List<T> list)
		{
			for (int i = list.Count / 2 - 1; i >= 0; i--)
			{
				XHeap<T>.HeapifyDown(list, i, list.Count);
			}
		}

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

		public void Clear()
		{
			this._heap.Clear();
			this._heapSize = 0;
		}

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

		private List<T> _heap = null;

		private int _heapSize = 0;
	}
}
