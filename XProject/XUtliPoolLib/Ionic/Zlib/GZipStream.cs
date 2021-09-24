using System;
using System.IO;
using System.Text;

namespace Ionic.Zlib
{

	public class GZipStream : Stream
	{

		public string Comment
		{
			get
			{
				return this._Comment;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				this._Comment = value;
			}
		}

		public string FileName
		{
			get
			{
				return this._FileName;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				this._FileName = value;
				bool flag = this._FileName == null;
				if (!flag)
				{
					bool flag2 = this._FileName.IndexOf("/") != -1;
					if (flag2)
					{
						this._FileName = this._FileName.Replace("/", "\\");
					}
					bool flag3 = this._FileName.EndsWith("\\");
					if (flag3)
					{
						throw new Exception("Illegal filename");
					}
					bool flag4 = this._FileName.IndexOf("\\") != -1;
					if (flag4)
					{
						this._FileName = Path.GetFileName(this._FileName);
					}
				}
			}
		}

		public int Crc32
		{
			get
			{
				return this._Crc32;
			}
		}

		public GZipStream(Stream stream, CompressionMode mode) : this(stream, mode, CompressionLevel.Default, false)
		{
		}

		public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level) : this(stream, mode, level, false)
		{
		}

		public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen) : this(stream, mode, CompressionLevel.Default, leaveOpen)
		{
		}

		public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
		{
			this._baseStream = new ZlibBaseStream(stream, mode, level, ZlibStreamFlavor.GZIP, leaveOpen);
		}

		public virtual FlushType FlushMode
		{
			get
			{
				return this._baseStream._flushMode;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				this._baseStream._flushMode = value;
			}
		}

		public int BufferSize
		{
			get
			{
				return this._baseStream._bufferSize;
			}
			set
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				bool flag = this._baseStream._workingBuffer != null;
				if (flag)
				{
					throw new ZlibException("The working buffer is already set.");
				}
				bool flag2 = value < 1024;
				if (flag2)
				{
					throw new ZlibException(string.Format("Don't be silly. {0} bytes?? Use a bigger buffer, at least {1}.", value, 1024));
				}
				this._baseStream._bufferSize = value;
			}
		}

		public virtual long TotalIn
		{
			get
			{
				return this._baseStream._z.TotalBytesIn;
			}
		}

		public virtual long TotalOut
		{
			get
			{
				return this._baseStream._z.TotalBytesOut;
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				bool flag = !this._disposed;
				if (flag)
				{
					bool flag2 = disposing && this._baseStream != null;
					if (flag2)
					{
						this._baseStream.Close();
						this._Crc32 = this._baseStream.Crc32;
					}
					this._disposed = true;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		public override bool CanRead
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				return this._baseStream._stream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		public override bool CanWrite
		{
			get
			{
				bool disposed = this._disposed;
				if (disposed)
				{
					throw new ObjectDisposedException("GZipStream");
				}
				return this._baseStream._stream.CanWrite;
			}
		}

		public override void Flush()
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			this._baseStream.Flush();
		}

		public override long Length
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override long Position
		{
			get
			{
				bool flag = this._baseStream._streamMode == ZlibBaseStream.StreamMode.Writer;
				long result;
				if (flag)
				{
					result = this._baseStream._z.TotalBytesOut + (long)this._headerByteCount;
				}
				else
				{
					bool flag2 = this._baseStream._streamMode == ZlibBaseStream.StreamMode.Reader;
					if (flag2)
					{
						result = this._baseStream._z.TotalBytesIn + (long)this._baseStream._gzipHeaderByteCount;
					}
					else
					{
						result = 0L;
					}
				}
				return result;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			int result = this._baseStream.Read(buffer, offset, count);
			bool flag = !this._firstReadDone;
			if (flag)
			{
				this._firstReadDone = true;
				this.FileName = this._baseStream._GzipFileName;
				this.Comment = this._baseStream._GzipComment;
			}
			return result;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			bool disposed = this._disposed;
			if (disposed)
			{
				throw new ObjectDisposedException("GZipStream");
			}
			bool flag = this._baseStream._streamMode == ZlibBaseStream.StreamMode.Undefined;
			if (flag)
			{
				bool wantCompress = this._baseStream._wantCompress;
				if (!wantCompress)
				{
					throw new InvalidOperationException();
				}
				this._headerByteCount = this.EmitHeader();
			}
			this._baseStream.Write(buffer, offset, count);
		}

		private int EmitHeader()
		{
			byte[] array = (this.Comment == null) ? null : GZipStream.iso8859dash1.GetBytes(this.Comment);
			byte[] array2 = (this.FileName == null) ? null : GZipStream.iso8859dash1.GetBytes(this.FileName);
			int num = (this.Comment == null) ? 0 : (array.Length + 1);
			int num2 = (this.FileName == null) ? 0 : (array2.Length + 1);
			int num3 = 10 + num + num2;
			byte[] array3 = new byte[num3];
			int num4 = 0;
			array3[num4++] = 31;
			array3[num4++] = 139;
			array3[num4++] = 8;
			byte b = 0;
			bool flag = this.Comment != null;
			if (flag)
			{
				b ^= 16;
			}
			bool flag2 = this.FileName != null;
			if (flag2)
			{
				b ^= 8;
			}
			array3[num4++] = b;
			bool flag3 = this.LastModified == null;
			if (flag3)
			{
				this.LastModified = new DateTime?(DateTime.Now);
			}
			int value = (int)(this.LastModified.Value - GZipStream._unixEpoch).TotalSeconds;
			Array.Copy(BitConverter.GetBytes(value), 0, array3, num4, 4);
			num4 += 4;
			array3[num4++] = 0;
			array3[num4++] = byte.MaxValue;
			bool flag4 = num2 != 0;
			if (flag4)
			{
				Array.Copy(array2, 0, array3, num4, num2 - 1);
				num4 += num2 - 1;
				array3[num4++] = 0;
			}
			bool flag5 = num != 0;
			if (flag5)
			{
				Array.Copy(array, 0, array3, num4, num - 1);
				num4 += num - 1;
				array3[num4++] = 0;
			}
			this._baseStream._stream.Write(array3, 0, array3.Length);
			return array3.Length;
		}

		public static byte[] CompressString(string s)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZlibBaseStream.CompressString(s, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		public static byte[] CompressBuffer(byte[] b)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Stream compressor = new GZipStream(memoryStream, CompressionMode.Compress, CompressionLevel.BestCompression);
				ZlibBaseStream.CompressBuffer(b, compressor);
				result = memoryStream.ToArray();
			}
			return result;
		}

		public static string UncompressString(byte[] compressed)
		{
			string result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new GZipStream(memoryStream, CompressionMode.Decompress);
				result = ZlibBaseStream.UncompressString(compressed, decompressor);
			}
			return result;
		}

		public static byte[] UncompressBuffer(byte[] compressed)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream(compressed))
			{
				Stream decompressor = new GZipStream(memoryStream, CompressionMode.Decompress);
				result = ZlibBaseStream.UncompressBuffer(compressed, decompressor);
			}
			return result;
		}

		public DateTime? LastModified;

		private int _headerByteCount;

		internal ZlibBaseStream _baseStream;

		private bool _disposed;

		private bool _firstReadDone;

		private string _FileName;

		private string _Comment;

		private int _Crc32;

		internal static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		internal static readonly Encoding iso8859dash1 = Encoding.GetEncoding("iso-8859-1");
	}
}
