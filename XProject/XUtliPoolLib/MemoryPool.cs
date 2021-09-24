using System;

namespace XUtliPoolLib
{

	public class MemoryPool<T>
	{

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

		private void IndexLastFreeChunk()
		{
			bool flag = this.m_lastFreeChunk == null;
			if (flag)
			{
				this.Expand();
				this.m_lastFreeChunk = this.m_last;
			}
		}

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

		private short m_blockSize = 0;

		private int m_chunkSize = 0;

		private MemoryPool<T>.MemoryChunk m_root = null;

		private MemoryPool<T>.MemoryChunk m_last = null;

		private MemoryPool<T>.MemoryChunk m_lastFreeChunk = null;

		private MemoryPool<T>.MemoryBlock m_freeMemBlock = null;

		private MemoryPool<T>.AllocMemoryBlock m_freeAllocBlock = null;

		public class MemoryChunk
		{

			public T[] mem = null;

			public MemoryPool<T>.MemoryChunk next = null;

			public uint blockBit = 0U;
		}

		public class MemoryBlock
		{

			public MemoryPool<T>.MemoryChunk chunk = null;

			public short start = -1;

			public MemoryPool<T>.MemoryBlock next = null;
		}

		public class AllocMemoryBlock
		{

			public MemoryPool<T>.MemoryBlock[] mem = new MemoryPool<T>.MemoryBlock[32];

			public MemoryPool<T>.AllocMemoryBlock next = null;
		}
	}
}
