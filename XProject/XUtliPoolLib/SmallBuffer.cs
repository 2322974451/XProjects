using System;

namespace XUtliPoolLib
{

	public struct SmallBuffer<T>
	{

		public T this[int index]
		{
			get
			{
				return (this.bufferRef == null) ? default(T) : this.bufferRef[this.bufferBlock.offset + index];
			}
			set
			{
				bool flag = this.bufferRef != null;
				if (flag)
				{
					this.bufferRef[this.bufferBlock.offset + index] = value;
				}
				bool flag2 = this.debugBuffer != null;
				if (flag2)
				{
					this.debugBuffer[index] = value;
				}
			}
		}

		public T this[uint index]
		{
			get
			{
				return this.bufferRef[(int)(checked((IntPtr)(unchecked((long)this.bufferBlock.offset + (long)((ulong)index)))))];
			}
			set
			{
				this.bufferRef[(int)(checked((IntPtr)(unchecked((long)this.bufferBlock.offset + (long)((ulong)index)))))] = value;
				bool flag = this.debugBuffer != null;
				if (flag)
				{
					this.debugBuffer[(int)index] = value;
				}
			}
		}

		public int Count
		{
			get
			{
				return (this.bufferRef == null) ? 0 : this.bufferBlock.size;
			}
		}

		public bool IsInit
		{
			get
			{
				return this.bufferRef != null;
			}
		}

		public T[] OriginalBuff
		{
			get
			{
				return this.bufferRef;
			}
		}

		public int StartOffset
		{
			get
			{
				return this.bufferBlock.offset;
			}
		}

		private void Expand(int size)
		{
			T[] sourceArray = this.bufferRef;
			int offset = this.bufferBlock.offset;
			int size2 = this.bufferBlock.size;
			int capacity = this.bufferBlock.capacity;
			this.poolRef.ExpandBlock(ref this, size);
			int capacity2 = this.bufferBlock.capacity;
			Array.Copy(sourceArray, offset, this.bufferRef, this.bufferBlock.offset, capacity);
			this.bufferBlock.size = size2;
		}

		private void ReturnBlock()
		{
			bool flag = this.poolRef != null;
			if (flag)
			{
				this.poolRef.ReturnBlock(ref this);
			}
		}

		public void Init(BufferBlock bb, SmallBufferPool<T> pool)
		{
			this.ReturnBlock();
			this.bufferBlock = bb;
			this.poolRef = pool;
			this.bufferRef = pool.buffer;
			this.debugBuffer = new T[this.bufferBlock.capacity];
		}

		public void Init(BufferBlock bb, SmallBufferPool<T> pool, T[] buffer)
		{
			this.ReturnBlock();
			this.bufferBlock = bb;
			this.poolRef = pool;
			this.bufferRef = buffer;
			this.debugBuffer = new T[this.bufferBlock.capacity];
		}

		public void UnInit()
		{
			this.poolRef = null;
			this.bufferRef = null;
			this.debugBuffer = null;
		}

		public void Add(T value)
		{
			bool flag = this.bufferRef != null;
			if (flag)
			{
				bool flag2 = this.bufferBlock.size == this.bufferBlock.capacity;
				if (flag2)
				{
					this.Expand(this.bufferBlock.capacity * 2);
				}
				int size = this.bufferBlock.size;
				this.bufferBlock.size = size + 1;
				this[size] = value;
			}
		}

		public bool Remove(T item)
		{
			bool flag = this.bufferRef != null;
			if (flag)
			{
				T value = default(T);
				for (int i = 0; i < this.bufferBlock.size; i++)
				{
					T t = this[i];
					bool flag2 = t.Equals(item);
					if (flag2)
					{
						this.bufferBlock.size = this.bufferBlock.size - 1;
						this[i] = value;
						for (int j = i; j < this.bufferBlock.size; j++)
						{
							this[j] = this[j + 1];
						}
						return true;
					}
				}
			}
			return false;
		}

		public void RemoveAt(int index)
		{
			bool flag = this.bufferRef != null;
			if (flag)
			{
				bool flag2 = index < this.bufferBlock.size;
				if (flag2)
				{
					this.bufferBlock.size = this.bufferBlock.size - 1;
					this[index] = default(T);
					for (int i = index; i < this.bufferBlock.size; i++)
					{
						this[i] = this[i + 1];
					}
				}
			}
		}

		public bool Contains(T item)
		{
			bool flag = this.bufferRef != null;
			if (flag)
			{
				for (int i = 0; i < this.bufferBlock.size; i++)
				{
					T t = this[i];
					bool flag2 = t.Equals(item);
					if (flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		public void Clear()
		{
			this.bufferBlock.size = 0;
		}

		public void DeepClear()
		{
			bool flag = this.bufferRef != null;
			if (flag)
			{
				Array.Clear(this.bufferRef, this.bufferBlock.offset, this.bufferBlock.capacity);
			}
		}

		public void Copy(T[] src, int startIndex, int desIndex, int count)
		{
			bool flag = this.bufferRef != null;
			if (flag)
			{
				count = ((count < this.bufferBlock.capacity) ? count : this.bufferBlock.capacity);
				Array.Copy(src, startIndex, this.bufferRef, this.bufferBlock.offset + desIndex, count);
				this.bufferBlock.size = count;
			}
		}

		public void SetInvalid()
		{
			this.bufferBlock.blockIndex = -1;
			this.poolRef = null;
			this.bufferRef = null;
		}

		public BufferBlock bufferBlock;

		private SmallBufferPool<T> poolRef;

		private T[] bufferRef;

		public string debugName;

		private T[] debugBuffer;
	}
}
