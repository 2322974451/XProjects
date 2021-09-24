using System;
using System.Runtime.InteropServices;

namespace Ionic.Zlib
{

	[Guid("ebc25cf6-9120-4283-b972-0e5520d0000D")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public sealed class ZlibCodec
	{

		public int Adler32
		{
			get
			{
				return (int)this._Adler32;
			}
		}

		public ZlibCodec()
		{
		}

		public ZlibCodec(CompressionMode mode)
		{
			bool flag = mode == CompressionMode.Compress;
			if (flag)
			{
				int num = this.InitializeDeflate();
				bool flag2 = num != 0;
				if (flag2)
				{
					throw new ZlibException("Cannot initialize for deflate.");
				}
			}
			else
			{
				bool flag3 = mode == CompressionMode.Decompress;
				if (!flag3)
				{
					throw new ZlibException("Invalid ZlibStreamFlavor.");
				}
				int num2 = this.InitializeInflate();
				bool flag4 = num2 != 0;
				if (flag4)
				{
					throw new ZlibException("Cannot initialize for inflate.");
				}
			}
		}

		public int InitializeInflate()
		{
			return this.InitializeInflate(this.WindowBits);
		}

		public int InitializeInflate(bool expectRfc1950Header)
		{
			return this.InitializeInflate(this.WindowBits, expectRfc1950Header);
		}

		public int InitializeInflate(int windowBits)
		{
			this.WindowBits = windowBits;
			return this.InitializeInflate(windowBits, true);
		}

		public int InitializeInflate(int windowBits, bool expectRfc1950Header)
		{
			this.WindowBits = windowBits;
			bool flag = this.dstate != null;
			if (flag)
			{
				throw new ZlibException("You may not call InitializeInflate() after calling InitializeDeflate().");
			}
			this.istate = new InflateManager(expectRfc1950Header);
			return this.istate.Initialize(this, windowBits);
		}

		public int Inflate(FlushType flush)
		{
			bool flag = this.istate == null;
			if (flag)
			{
				throw new ZlibException("No Inflate State!");
			}
			return this.istate.Inflate(flush);
		}

		public void Reset()
		{
			bool flag = this.istate == null;
			if (flag)
			{
				throw new ZlibException("No Inflate State!");
			}
			this.istate.Reset();
		}

		public int EndInflate()
		{
			bool flag = this.istate == null;
			if (flag)
			{
				throw new ZlibException("No Inflate State!");
			}
			int result = this.istate.End();
			this.istate = null;
			return result;
		}

		public int SyncInflate()
		{
			bool flag = this.istate == null;
			if (flag)
			{
				throw new ZlibException("No Inflate State!");
			}
			return this.istate.Sync();
		}

		public int InitializeDeflate()
		{
			return this._InternalInitializeDeflate(true);
		}

		public int InitializeDeflate(CompressionLevel level)
		{
			this.CompressLevel = level;
			return this._InternalInitializeDeflate(true);
		}

		public int InitializeDeflate(CompressionLevel level, bool wantRfc1950Header)
		{
			this.CompressLevel = level;
			return this._InternalInitializeDeflate(wantRfc1950Header);
		}

		public int InitializeDeflate(CompressionLevel level, int bits)
		{
			this.CompressLevel = level;
			this.WindowBits = bits;
			return this._InternalInitializeDeflate(true);
		}

		public int InitializeDeflate(CompressionLevel level, int bits, bool wantRfc1950Header)
		{
			this.CompressLevel = level;
			this.WindowBits = bits;
			return this._InternalInitializeDeflate(wantRfc1950Header);
		}

		private int _InternalInitializeDeflate(bool wantRfc1950Header)
		{
			bool flag = this.istate != null;
			if (flag)
			{
				throw new ZlibException("You may not call InitializeDeflate() after calling InitializeInflate().");
			}
			this.dstate = new DeflateManager();
			this.dstate.WantRfc1950HeaderBytes = wantRfc1950Header;
			return this.dstate.Initialize(this, this.CompressLevel, this.WindowBits, this.Strategy);
		}

		public int Deflate(FlushType flush)
		{
			bool flag = this.dstate == null;
			if (flag)
			{
				throw new ZlibException("No Deflate State!");
			}
			return this.dstate.Deflate(flush);
		}

		public int EndDeflate()
		{
			bool flag = this.dstate == null;
			if (flag)
			{
				throw new ZlibException("No Deflate State!");
			}
			this.dstate = null;
			return 0;
		}

		public void ResetDeflate(bool setDeflater)
		{
			bool flag = this.dstate == null;
			if (flag)
			{
				throw new ZlibException("No Deflate State!");
			}
			this.dstate.Reset(setDeflater);
		}

		public int SetDeflateParams(CompressionLevel level, CompressionStrategy strategy)
		{
			bool flag = this.dstate == null;
			if (flag)
			{
				throw new ZlibException("No Deflate State!");
			}
			return this.dstate.SetParams(level, strategy);
		}

		public int SetDictionary(byte[] dictionary)
		{
			bool flag = this.istate != null;
			int result;
			if (flag)
			{
				result = this.istate.SetDictionary(dictionary);
			}
			else
			{
				bool flag2 = this.dstate != null;
				if (!flag2)
				{
					throw new ZlibException("No Inflate or Deflate state!");
				}
				result = this.dstate.SetDictionary(dictionary);
			}
			return result;
		}

		internal void flush_pending()
		{
			int num = this.dstate.pendingCount;
			bool flag = num > this.AvailableBytesOut;
			if (flag)
			{
				num = this.AvailableBytesOut;
			}
			bool flag2 = num == 0;
			if (!flag2)
			{
				bool flag3 = this.dstate.pending.Length <= this.dstate.nextPending || this.OutputBuffer.Length <= this.NextOut || this.dstate.pending.Length < this.dstate.nextPending + num || this.OutputBuffer.Length < this.NextOut + num;
				if (flag3)
				{
					throw new ZlibException(string.Format("Invalid State. (pending.Length={0}, pendingCount={1})", this.dstate.pending.Length, this.dstate.pendingCount));
				}
				Array.Copy(this.dstate.pending, this.dstate.nextPending, this.OutputBuffer, this.NextOut, num);
				this.NextOut += num;
				this.dstate.nextPending += num;
				this.TotalBytesOut += (long)num;
				this.AvailableBytesOut -= num;
				this.dstate.pendingCount -= num;
				bool flag4 = this.dstate.pendingCount == 0;
				if (flag4)
				{
					this.dstate.nextPending = 0;
				}
			}
		}

		internal int read_buf(byte[] buf, int start, int size)
		{
			int num = this.AvailableBytesIn;
			bool flag = num > size;
			if (flag)
			{
				num = size;
			}
			bool flag2 = num == 0;
			int result;
			if (flag2)
			{
				result = 0;
			}
			else
			{
				this.AvailableBytesIn -= num;
				bool wantRfc1950HeaderBytes = this.dstate.WantRfc1950HeaderBytes;
				if (wantRfc1950HeaderBytes)
				{
					this._Adler32 = Adler.Adler32(this._Adler32, this.InputBuffer, this.NextIn, num);
				}
				Array.Copy(this.InputBuffer, this.NextIn, buf, start, num);
				this.NextIn += num;
				this.TotalBytesIn += (long)num;
				result = num;
			}
			return result;
		}

		public byte[] InputBuffer;

		public int NextIn;

		public int AvailableBytesIn;

		public long TotalBytesIn;

		public byte[] OutputBuffer;

		public int NextOut;

		public int AvailableBytesOut;

		public long TotalBytesOut;

		public string Message;

		internal DeflateManager dstate;

		internal InflateManager istate;

		internal uint _Adler32;

		public CompressionLevel CompressLevel = CompressionLevel.Default;

		public int WindowBits = 15;

		public CompressionStrategy Strategy = CompressionStrategy.Default;
	}
}
