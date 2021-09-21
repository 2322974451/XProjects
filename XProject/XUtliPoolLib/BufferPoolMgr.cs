using System;

namespace XUtliPoolLib
{
	// Token: 0x0200018E RID: 398
	public class BufferPoolMgr : XSingleton<BufferPoolMgr>
	{
		// Token: 0x060008A0 RID: 2208 RVA: 0x0002E8BC File Offset: 0x0002CABC
		public override bool Init()
		{
			this.m_UIntSmallBufferPool.Init(this.uintBlockInit, 4);
			this.m_ObjSmallBufferPool.Init(this.objBlockInit, 4);
			return true;
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0002E8F5 File Offset: 0x0002CAF5
		public void GetSmallBuffer(ref SmallBuffer<uint> sb, int size, int initSize = 0)
		{
			this.m_UIntSmallBufferPool.GetBlock(ref sb, size, 0);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x0002E907 File Offset: 0x0002CB07
		public void ReturnSmallBuffer(ref SmallBuffer<uint> sb)
		{
			this.m_UIntSmallBufferPool.ReturnBlock(ref sb);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0002E917 File Offset: 0x0002CB17
		public void GetSmallBuffer(ref SmallBuffer<object> sb, int size, int initSize = 0)
		{
			this.m_ObjSmallBufferPool.GetBlock(ref sb, size, 0);
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x0002E929 File Offset: 0x0002CB29
		public void ReturnSmallBuffer(ref SmallBuffer<object> sb)
		{
			this.m_ObjSmallBufferPool.ReturnBlock(ref sb);
		}

		// Token: 0x040003E6 RID: 998
		private SmallBufferPool<uint> m_UIntSmallBufferPool = new SmallBufferPool<uint>();

		// Token: 0x040003E7 RID: 999
		private SmallBufferPool<object> m_ObjSmallBufferPool = new SmallBufferPool<object>();

		// Token: 0x040003E8 RID: 1000
		public static int TotalCount = 0;

		// Token: 0x040003E9 RID: 1001
		public static int AllocSize = 0;

		// Token: 0x040003EA RID: 1002
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

		// Token: 0x040003EB RID: 1003
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
