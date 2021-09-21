using System;
using System.Threading;

namespace ProtoBuf
{
	// Token: 0x0200083C RID: 2108
	internal sealed class BufferPool
	{
		// Token: 0x0600822B RID: 33323 RVA: 0x000F9A4C File Offset: 0x000F7C4C
		internal static void Flush()
		{
			for (int i = 0; i < BufferPool.pool.Length; i++)
			{
				Interlocked.Exchange(ref BufferPool.pool[i], null);
			}
		}

		// Token: 0x0600822C RID: 33324 RVA: 0x0000311A File Offset: 0x0000131A
		private BufferPool()
		{
		}

		// Token: 0x0600822D RID: 33325 RVA: 0x000F9A84 File Offset: 0x000F7C84
		internal static byte[] GetBuffer()
		{
			for (int i = 0; i < BufferPool.pool.Length; i++)
			{
				object obj;
				bool flag = (obj = Interlocked.Exchange(ref BufferPool.pool[i], null)) != null;
				if (flag)
				{
					return (byte[])obj;
				}
			}
			return new byte[1024];
		}

		// Token: 0x0600822E RID: 33326 RVA: 0x000F9AE0 File Offset: 0x000F7CE0
		internal static void ResizeAndFlushLeft(ref byte[] buffer, int toFitAtLeastBytes, int copyFromIndex, int copyBytes)
		{
			Helpers.DebugAssert(buffer != null);
			Helpers.DebugAssert(toFitAtLeastBytes > buffer.Length);
			Helpers.DebugAssert(copyFromIndex >= 0);
			Helpers.DebugAssert(copyBytes >= 0);
			int num = buffer.Length * 2;
			bool flag = num < toFitAtLeastBytes;
			if (flag)
			{
				num = toFitAtLeastBytes;
			}
			byte[] array = new byte[num];
			bool flag2 = copyBytes > 0;
			if (flag2)
			{
				Helpers.BlockCopy(buffer, copyFromIndex, array, 0, copyBytes);
			}
			bool flag3 = buffer.Length == 1024;
			if (flag3)
			{
				BufferPool.ReleaseBufferToPool(ref buffer);
			}
			buffer = array;
		}

		// Token: 0x0600822F RID: 33327 RVA: 0x000F9B6C File Offset: 0x000F7D6C
		internal static void ReleaseBufferToPool(ref byte[] buffer)
		{
			bool flag = buffer == null;
			if (!flag)
			{
				bool flag2 = buffer.Length == 1024;
				if (flag2)
				{
					for (int i = 0; i < BufferPool.pool.Length; i++)
					{
						bool flag3 = Interlocked.CompareExchange(ref BufferPool.pool[i], buffer, null) == null;
						if (flag3)
						{
							break;
						}
					}
				}
				buffer = null;
			}
		}

		// Token: 0x04002847 RID: 10311
		private const int PoolSize = 20;

		// Token: 0x04002848 RID: 10312
		internal const int BufferLength = 1024;

		// Token: 0x04002849 RID: 10313
		private static readonly object[] pool = new object[20];
	}
}
