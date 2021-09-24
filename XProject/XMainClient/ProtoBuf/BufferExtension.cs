using System;
using System.IO;

namespace ProtoBuf
{

	public sealed class BufferExtension : IExtension
	{

		int IExtension.GetLength()
		{
			return (this.buffer == null) ? 0 : this.buffer.Length;
		}

		Stream IExtension.BeginAppend()
		{
			return new MemoryStream();
		}

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

		Stream IExtension.BeginQuery()
		{
			return (this.buffer == null) ? Stream.Null : new MemoryStream(this.buffer);
		}

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

		private byte[] buffer;
	}
}
