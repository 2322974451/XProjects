using System;

namespace XUtliPoolLib
{
	// Token: 0x0200018F RID: 399
	public class MemoryPool<T>
	{
		// Token: 0x060008A7 RID: 2215 RVA: 0x0002EA8C File Offset: 0x0002CC8C
		private void Expand()
		{
			MemoryPool<T>.MemoryChunk memoryChunk = new MemoryPool<T>.MemoryChunk();
			memoryChunk.mem = new T[this.m_chunkSize];
			bool flag = this.m_root == null;
			if (flag)
			{
				bool flag2 = this.m_last != null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("root null but last not null!", null, null, null, null, null);
				}
				this.m_root = memoryChunk;
				this.m_last = this.m_root;
			}
			else
			{
				this.m_last.next = memoryChunk;
				this.m_last = memoryChunk;
			}
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0002EB10 File Offset: 0x0002CD10
		private void IndexLastFreeChunk()
		{
			bool flag = this.m_lastFreeChunk == null;
			if (flag)
			{
				this.Expand();
				this.m_lastFreeChunk = this.m_last;
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0002EB40 File Offset: 0x0002CD40
		private MemoryPool<T>.MemoryBlock GetMemoryBlock()
		{
			bool flag = this.m_freeMemBlock == null;
			MemoryPool<T>.MemoryBlock result;
			if (flag)
			{
				result = new MemoryPool<T>.MemoryBlock();
			}
			else
			{
				MemoryPool<T>.MemoryBlock freeMemBlock = this.m_freeMemBlock;
				this.m_freeMemBlock = this.m_freeMemBlock.next;
				result = freeMemBlock;
			}
			return result;
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0002EB84 File Offset: 0x0002CD84
		public void Init(short blockSize, int initChunkCount)
		{
			this.m_blockSize = blockSize;
			this.m_chunkSize = (int)(this.m_blockSize * 32);
			for (int i = 0; i < initChunkCount; i++)
			{
				this.Expand();
			}
			this.m_lastFreeChunk = this.m_root;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0002EBD0 File Offset: 0x0002CDD0
		public MemoryPool<T>.AllocMemoryBlock Alloc(int blockCount)
		{
			bool flag = this.m_freeAllocBlock == null;
			MemoryPool<T>.AllocMemoryBlock allocMemoryBlock;
			if (flag)
			{
				allocMemoryBlock = new MemoryPool<T>.AllocMemoryBlock();
			}
			else
			{
				allocMemoryBlock = this.m_freeAllocBlock;
				this.m_freeAllocBlock = this.m_freeAllocBlock.next;
				allocMemoryBlock.next = null;
			}
			this.IndexLastFreeChunk();
			int num = 0;
			do
			{
				uint num2 = 1U;
				short num3 = 0;
				while ((int)num3 < this.m_chunkSize && num < blockCount)
				{
					bool flag2 = (this.m_lastFreeChunk.blockBit & num2) == 0U;
					if (flag2)
					{
						MemoryPool<T>.MemoryBlock memoryBlock = this.GetMemoryBlock();
						memoryBlock.chunk = this.m_lastFreeChunk;
						memoryBlock.start = num3;
						memoryBlock.next = null;
						allocMemoryBlock.mem[num] = memoryBlock;
						this.m_lastFreeChunk.blockBit |= num2;
						num++;
					}
					num2 <<= 1;
					num3 += this.m_blockSize;
				}
				bool flag3 = num2 == uint.MaxValue;
				if (flag3)
				{
					this.m_lastFreeChunk = this.m_lastFreeChunk.next;
				}
				this.IndexLastFreeChunk();
			}
			while (num < blockCount);
			return allocMemoryBlock;
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0002ECEC File Offset: 0x0002CEEC
		public void Dealloc(MemoryPool<T>.AllocMemoryBlock amb)
		{
			for (int i = 0; i < amb.mem.Length; i++)
			{
				MemoryPool<T>.MemoryBlock memoryBlock = amb.mem[i];
				bool flag = memoryBlock != null;
				if (flag)
				{
					MemoryPool<T>.MemoryChunk chunk = memoryBlock.chunk;
					bool flag2 = chunk != null;
					if (flag2)
					{
						uint num = 1U << (int)(memoryBlock.start / this.m_blockSize);
						chunk.blockBit &= ~num;
					}
					amb.mem[i] = null;
					bool flag3 = this.m_freeMemBlock == null;
					if (flag3)
					{
						this.m_freeMemBlock = memoryBlock;
					}
					else
					{
						memoryBlock.next = this.m_freeMemBlock;
						this.m_freeMemBlock = memoryBlock;
					}
				}
				bool flag4 = this.m_freeAllocBlock == null;
				if (flag4)
				{
					this.m_freeAllocBlock = amb;
				}
				else
				{
					amb.next = this.m_freeAllocBlock;
					this.m_freeAllocBlock = amb;
				}
			}
		}

		// Token: 0x040003EC RID: 1004
		private short m_blockSize = 0;

		// Token: 0x040003ED RID: 1005
		private int m_chunkSize = 0;

		// Token: 0x040003EE RID: 1006
		private MemoryPool<T>.MemoryChunk m_root = null;

		// Token: 0x040003EF RID: 1007
		private MemoryPool<T>.MemoryChunk m_last = null;

		// Token: 0x040003F0 RID: 1008
		private MemoryPool<T>.MemoryChunk m_lastFreeChunk = null;

		// Token: 0x040003F1 RID: 1009
		private MemoryPool<T>.MemoryBlock m_freeMemBlock = null;

		// Token: 0x040003F2 RID: 1010
		private MemoryPool<T>.AllocMemoryBlock m_freeAllocBlock = null;

		// Token: 0x02000389 RID: 905
		public class MemoryChunk
		{
			// Token: 0x04000FC1 RID: 4033
			public T[] mem = null;

			// Token: 0x04000FC2 RID: 4034
			public MemoryPool<T>.MemoryChunk next = null;

			// Token: 0x04000FC3 RID: 4035
			public uint blockBit = 0U;
		}

		// Token: 0x0200038A RID: 906
		public class MemoryBlock
		{
			// Token: 0x04000FC4 RID: 4036
			public MemoryPool<T>.MemoryChunk chunk = null;

			// Token: 0x04000FC5 RID: 4037
			public short start = -1;

			// Token: 0x04000FC6 RID: 4038
			public MemoryPool<T>.MemoryBlock next = null;
		}

		// Token: 0x0200038B RID: 907
		public class AllocMemoryBlock
		{
			// Token: 0x04000FC7 RID: 4039
			public MemoryPool<T>.MemoryBlock[] mem = new MemoryPool<T>.MemoryBlock[32];

			// Token: 0x04000FC8 RID: 4040
			public MemoryPool<T>.AllocMemoryBlock next = null;
		}
	}
}
