using System;

namespace XUtliPoolLib
{
	// Token: 0x0200018D RID: 397
	public class SmallBufferPool<T>
	{
		// Token: 0x06000899 RID: 2201 RVA: 0x0002E528 File Offset: 0x0002C728
		public void Init(BlockInfo[] blockInit, int tSize)
		{
			this.blockInitRef = blockInit;
			int num = 0;
			int num2 = 0;
			int i = 0;
			int num3 = blockInit.Length;
			while (i < num3)
			{
				BlockInfo blockInfo = blockInit[i];
				num += blockInfo.count;
				num2 += blockInfo.size * blockInfo.count;
				i++;
			}
			this.buffer = new T[num2];
			this.blocks = new BufferBlock[num];
			BufferPoolMgr.TotalCount += num2 * tSize + num * 17;
			int num4 = 0;
			int num5 = 0;
			int j = 0;
			int num6 = blockInit.Length;
			while (j < num6)
			{
				BlockInfo blockInfo2 = blockInit[j];
				int k = 0;
				int count = blockInfo2.count;
				while (k < count)
				{
					BufferBlock bufferBlock = this.blocks[num4];
					bufferBlock.offset = num5;
					bufferBlock.size = 0;
					bufferBlock.capacity = blockInfo2.size;
					bufferBlock.blockIndex = num4;
					bufferBlock.inUse = false;
					this.blocks[num4] = bufferBlock;
					num5 += blockInfo2.size;
					num4++;
					k++;
				}
				j++;
			}
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0002E65C File Offset: 0x0002C85C
		private bool InnerGetBlock(ref BufferBlock block, int size, int initSize)
		{
			int num = 0;
			int i = 0;
			int num2 = this.blockInitRef.Length;
			while (i < num2)
			{
				BlockInfo blockInfo = this.blockInitRef[i];
				bool flag = blockInfo.size >= size;
				if (flag)
				{
					int j = num;
					int num3 = num + blockInfo.count;
					while (j < num3)
					{
						BufferBlock bufferBlock = this.blocks[j];
						bool flag2 = !bufferBlock.inUse;
						if (flag2)
						{
							bufferBlock.size = ((initSize < bufferBlock.capacity) ? initSize : bufferBlock.capacity);
							bufferBlock.inUse = true;
							this.blocks[j] = bufferBlock;
							block = bufferBlock;
							this.allocBlockCount++;
							return true;
						}
						j++;
					}
				}
				else
				{
					num += blockInfo.count;
				}
				i++;
			}
			block.blockIndex = -1;
			block.capacity = size;
			block.size = ((initSize < size) ? initSize : size);
			block.inUse = true;
			return false;
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0002E780 File Offset: 0x0002C980
		private void InnerGetBlock(ref SmallBuffer<T> sb, int size, int initSize)
		{
			BufferBlock bufferBlock = default(BufferBlock);
			bool flag = this.InnerGetBlock(ref bufferBlock, size, initSize);
			if (flag)
			{
				sb.Init(bufferBlock, this);
				sb.DeepClear();
			}
			else
			{
				sb.Init(bufferBlock, this, new T[bufferBlock.capacity]);
				XSingleton<XDebug>.singleton.AddWarningLog2("not enough buff size:{0}", new object[]
				{
					bufferBlock.capacity
				});
				BufferPoolMgr.AllocSize += bufferBlock.capacity;
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x0002E800 File Offset: 0x0002CA00
		public void GetBlock(ref SmallBuffer<T> sb, int size, int initSize = 0)
		{
			bool isInit = sb.IsInit;
			if (!isInit)
			{
				this.InnerGetBlock(ref sb, size, initSize);
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0002E824 File Offset: 0x0002CA24
		public void ExpandBlock(ref SmallBuffer<T> sb, int size)
		{
			this.InnerGetBlock(ref sb, size, 0);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0002E834 File Offset: 0x0002CA34
		public void ReturnBlock(ref SmallBuffer<T> sb)
		{
			BufferBlock bufferBlock = sb.bufferBlock;
			bool inUse = bufferBlock.inUse;
			if (inUse)
			{
				bufferBlock.size = 0;
				bufferBlock.inUse = false;
				bool flag = bufferBlock.blockIndex >= 0;
				if (flag)
				{
					this.blocks[bufferBlock.blockIndex] = bufferBlock;
					this.allocBlockCount--;
				}
				sb.debugName = "";
				sb.UnInit();
			}
		}

		// Token: 0x040003E2 RID: 994
		public T[] buffer;

		// Token: 0x040003E3 RID: 995
		public BufferBlock[] blocks;

		// Token: 0x040003E4 RID: 996
		private BlockInfo[] blockInitRef;

		// Token: 0x040003E5 RID: 997
		public int allocBlockCount = 0;
	}
}
