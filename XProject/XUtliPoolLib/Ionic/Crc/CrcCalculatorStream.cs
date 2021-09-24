using System;
using System.IO;

namespace Ionic.Crc
{

	public class CrcCalculatorStream : Stream, IDisposable
	{

		public CrcCalculatorStream(Stream stream) : this(true, CrcCalculatorStream.UnsetLengthLimit, stream, null)
		{
		}

		public CrcCalculatorStream(Stream stream, bool leaveOpen) : this(leaveOpen, CrcCalculatorStream.UnsetLengthLimit, stream, null)
		{
		}

		public CrcCalculatorStream(Stream stream, long length) : this(true, length, stream, null)
		{
			bool flag = length < 0L;
			if (flag)
			{
				throw new ArgumentException("length");
			}
		}

		public CrcCalculatorStream(Stream stream, long length, bool leaveOpen) : this(leaveOpen, length, stream, null)
		{
			bool flag = length < 0L;
			if (flag)
			{
				throw new ArgumentException("length");
			}
		}

		public CrcCalculatorStream(Stream stream, long length, bool leaveOpen, CRC32 crc32) : this(leaveOpen, length, stream, crc32)
		{
			bool flag = length < 0L;
			if (flag)
			{
				throw new ArgumentException("length");
			}
		}

		private CrcCalculatorStream(bool leaveOpen, long length, Stream stream, CRC32 crc32)
		{
			this._innerStream = stream;
			this._Crc32 = (crc32 ?? new CRC32());
			this._lengthLimit = length;
			this._leaveOpen = leaveOpen;
		}

		public long TotalBytesSlurped
		{
			get
			{
				return this._Crc32.TotalBytesRead;
			}
		}

		public int Crc
		{
			get
			{
				return this._Crc32.Crc32Result;
			}
		}

		public bool LeaveOpen
		{
			get
			{
				return this._leaveOpen;
			}
			set
			{
				this._leaveOpen = value;
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int count2 = count;
			bool flag = this._lengthLimit != CrcCalculatorStream.UnsetLengthLimit;
			if (flag)
			{
				bool flag2 = this._Crc32.TotalBytesRead >= this._lengthLimit;
				if (flag2)
				{
					return 0;
				}
				long num = this._lengthLimit - this._Crc32.TotalBytesRead;
				bool flag3 = num < (long)count;
				if (flag3)
				{
					count2 = (int)num;
				}
			}
			int num2 = this._innerStream.Read(buffer, offset, count2);
			bool flag4 = num2 > 0;
			if (flag4)
			{
				this._Crc32.SlurpBlock(buffer, offset, num2);
			}
			return num2;
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			bool flag = count > 0;
			if (flag)
			{
				this._Crc32.SlurpBlock(buffer, offset, count);
			}
			this._innerStream.Write(buffer, offset, count);
		}

		public override bool CanRead
		{
			get
			{
				return this._innerStream.CanRead;
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
				return this._innerStream.CanWrite;
			}
		}

		public override void Flush()
		{
			this._innerStream.Flush();
		}

		public override long Length
		{
			get
			{
				bool flag = this._lengthLimit == CrcCalculatorStream.UnsetLengthLimit;
				long result;
				if (flag)
				{
					result = this._innerStream.Length;
				}
				else
				{
					result = this._lengthLimit;
				}
				return result;
			}
		}

		public override long Position
		{
			get
			{
				return this._Crc32.TotalBytesRead;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		void IDisposable.Dispose()
		{
			this.Close();
		}

		public override void Close()
		{
			base.Close();
			bool flag = !this._leaveOpen;
			if (flag)
			{
				this._innerStream.Close();
			}
		}

		private static readonly long UnsetLengthLimit = -99L;

		internal Stream _innerStream;

		private CRC32 _Crc32;

		private long _lengthLimit = -99L;

		private bool _leaveOpen;
	}
}
