using System;

namespace XUtliPoolLib
{
	// Token: 0x0200018B RID: 395
	public struct SmallBuffer<T>
	{
		// Token: 0x170000AA RID: 170
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

		// Token: 0x170000AB RID: 171
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

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x0002E080 File Offset: 0x0002C280
		public int Count
		{
			get
			{
				return (this.bufferRef == null) ? 0 : this.bufferBlock.size;
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x0002E0A8 File Offset: 0x0002C2A8
		public bool IsInit
		{
			get
			{
				return this.bufferRef != null;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000889 RID: 2185 RVA: 0x0002E0C4 File Offset: 0x0002C2C4
		public T[] OriginalBuff
		{
			get
			{
				return this.bufferRef;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x0002E0DC File Offset: 0x0002C2DC
		public int StartOffset
		{
			get
			{
				return this.bufferBlock.offset;
			}
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0002E0FC File Offset: 0x0002C2FC
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

		// Token: 0x0600088C RID: 2188 RVA: 0x0002E178 File Offset: 0x0002C378
		private void ReturnBlock()
		{
			bool flag = this.poolRef != null;
			if (flag)
			{
				this.poolRef.ReturnBlock(ref this);
			}
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0002E1A2 File Offset: 0x0002C3A2
		public void Init(BufferBlock bb, SmallBufferPool<T> pool)
		{
			this.ReturnBlock();
			this.bufferBlock = bb;
			this.poolRef = pool;
			this.bufferRef = pool.buffer;
			this.debugBuffer = new T[this.bufferBlock.capacity];
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0002E1DC File Offset: 0x0002C3DC
		public void Init(BufferBlock bb, SmallBufferPool<T> pool, T[] buffer)
		{
			this.ReturnBlock();
			this.bufferBlock = bb;
			this.poolRef = pool;
			this.bufferRef = buffer;
			this.debugBuffer = new T[this.bufferBlock.capacity];
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0002E211 File Offset: 0x0002C411
		public void UnInit()
		{
			this.poolRef = null;
			this.bufferRef = null;
			this.debugBuffer = null;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0002E22C File Offset: 0x0002C42C
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

		// Token: 0x06000891 RID: 2193 RVA: 0x0002E298 File Offset: 0x0002C498
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

		// Token: 0x06000892 RID: 2194 RVA: 0x0002E35C File Offset: 0x0002C55C
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

		// Token: 0x06000893 RID: 2195 RVA: 0x0002E3DC File Offset: 0x0002C5DC
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

		// Token: 0x06000894 RID: 2196 RVA: 0x0002E440 File Offset: 0x0002C640
		public void Clear()
		{
			this.bufferBlock.size = 0;
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x0002E450 File Offset: 0x0002C650
		public void DeepClear()
		{
			bool flag = this.bufferRef != null;
			if (flag)
			{
				Array.Clear(this.bufferRef, this.bufferBlock.offset, this.bufferBlock.capacity);
			}
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x0002E490 File Offset: 0x0002C690
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

		// Token: 0x06000897 RID: 2199 RVA: 0x0002E4F7 File Offset: 0x0002C6F7
		public void SetInvalid()
		{
			this.bufferBlock.blockIndex = -1;
			this.poolRef = null;
			this.bufferRef = null;
		}

		// Token: 0x040003DB RID: 987
		public BufferBlock bufferBlock;

		// Token: 0x040003DC RID: 988
		private SmallBufferPool<T> poolRef;

		// Token: 0x040003DD RID: 989
		private T[] bufferRef;

		// Token: 0x040003DE RID: 990
		public string debugName;

		// Token: 0x040003DF RID: 991
		private T[] debugBuffer;
	}
}
