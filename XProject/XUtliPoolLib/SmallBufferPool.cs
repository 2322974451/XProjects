using System;

namespace XUtliPoolLib
{

	public class SmallBufferPool<T>
	{

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

		public void GetBlock(ref SmallBuffer<T> sb, int size, int initSize = 0)
		{
			bool isInit = sb.IsInit;
			if (!isInit)
			{
				this.InnerGetBlock(ref sb, size, initSize);
			}
		}

		public void ExpandBlock(ref SmallBuffer<T> sb, int size)
		{
			this.InnerGetBlock(ref sb, size, 0);
		}

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

		public T[] buffer;

		public BufferBlock[] blocks;

		private BlockInfo[] blockInitRef;

		public int allocBlockCount = 0;
	}
}
