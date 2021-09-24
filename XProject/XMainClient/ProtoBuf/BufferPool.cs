using System;
using System.Threading;

namespace ProtoBuf
{

	internal sealed class BufferPool
	{

		internal static void Flush()
		{
			for (int i = 0; i < BufferPool.pool.Length; i++)
			{
				Interlocked.Exchange(ref BufferPool.pool[i], null);
			}
		}

		private BufferPool()
		{
		}

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

		private const int PoolSize = 20;

		internal const int BufferLength = 1024;

		private static readonly object[] pool = new object[20];
	}
}
