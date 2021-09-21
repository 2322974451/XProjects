using System;
using System.IO;

namespace ProtoBuf
{
	// Token: 0x0200083B RID: 2107
	public sealed class BufferExtension : IExtension
	{
		// Token: 0x06008225 RID: 33317 RVA: 0x000F9900 File Offset: 0x000F7B00
		int IExtension.GetLength()
		{
			return (this.buffer == null) ? 0 : this.buffer.Length;
		}

		// Token: 0x06008226 RID: 33318 RVA: 0x000F9928 File Offset: 0x000F7B28
		Stream IExtension.BeginAppend()
		{
			return new MemoryStream();
		}

		// Token: 0x06008227 RID: 33319 RVA: 0x000F9940 File Offset: 0x000F7B40
		void IExtension.EndAppend(Stream stream, bool commit)
		{
			try
			{
				int num = default;
				bool flag = commit && (num = (int)stream.Length) > 0;
				if (flag)
				{
					MemoryStream memoryStream = (MemoryStream)stream;
					bool flag2 = this.buffer == null;
					if (flag2)
					{
						this.buffer = memoryStream.ToArray();
					}
					else
					{
						int num2 = this.buffer.Length;
						byte[] to = new byte[num2 + num];
						Helpers.BlockCopy(this.buffer, 0, to, 0, num2);
						Helpers.BlockCopy(memoryStream.GetBuffer(), 0, to, num2, num);
						this.buffer = to;
					}
				}
			}
			finally
			{
				if (stream != null)
				{
					((IDisposable)stream).Dispose();
				}
			}
		}

		// Token: 0x06008228 RID: 33320 RVA: 0x000F99F0 File Offset: 0x000F7BF0
		Stream IExtension.BeginQuery()
		{
			return (this.buffer == null) ? Stream.Null : new MemoryStream(this.buffer);
		}

		// Token: 0x06008229 RID: 33321 RVA: 0x000F9A1C File Offset: 0x000F7C1C
		void IExtension.EndQuery(Stream stream)
		{
			try
			{
			}
			finally
			{
				if (stream != null)
				{
					((IDisposable)stream).Dispose();
				}
			}
		}

		// Token: 0x04002846 RID: 10310
		private byte[] buffer;
	}
}
