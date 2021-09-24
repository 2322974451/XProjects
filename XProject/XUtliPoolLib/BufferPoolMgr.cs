using System;

namespace XUtliPoolLib
{

	public class BufferPoolMgr : XSingleton<BufferPoolMgr>
	{

		public override bool Init()
		{
			this.m_UIntSmallBufferPool.Init(this.uintBlockInit, 4);
			this.m_ObjSmallBufferPool.Init(this.objBlockInit, 4);
			return true;
		}

		public void GetSmallBuffer(ref SmallBuffer<uint> sb, int size, int initSize = 0)
		{
			this.m_UIntSmallBufferPool.GetBlock(ref sb, size, 0);
		}

		public void ReturnSmallBuffer(ref SmallBuffer<uint> sb)
		{
			this.m_UIntSmallBufferPool.ReturnBlock(ref sb);
		}

		public void GetSmallBuffer(ref SmallBuffer<object> sb, int size, int initSize = 0)
		{
			this.m_ObjSmallBufferPool.GetBlock(ref sb, size, 0);
		}

		public void ReturnSmallBuffer(ref SmallBuffer<object> sb)
		{
			this.m_ObjSmallBufferPool.ReturnBlock(ref sb);
		}

		private SmallBufferPool<uint> m_UIntSmallBufferPool = new SmallBufferPool<uint>();

		private SmallBufferPool<object> m_ObjSmallBufferPool = new SmallBufferPool<object>();

		public static int TotalCount = 0;

		public static int AllocSize = 0;

		public BlockInfo[] uintBlockInit = new BlockInfo[]
		{
			new BlockInfo(4, 512),
			new BlockInfo(8, 512),
			new BlockInfo(16, 512),
			new BlockInfo(32, 512),
			new BlockInfo(64, 512),
			new BlockInfo(256, 128),
			new BlockInfo(512, 128)
		};

		public BlockInfo[] objBlockInit = new BlockInfo[]
		{
			new BlockInfo(8, 512),
			new BlockInfo(16, 512),
			new BlockInfo(32, 512),
			new BlockInfo(64, 512),
			new BlockInfo(256, 128),
			new BlockInfo(512, 128)
		};
	}
}
