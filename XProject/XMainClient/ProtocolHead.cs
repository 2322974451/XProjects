using System;
using System.IO;
using XUtliPoolLib;

namespace XMainClient
{

	public class ProtocolHead
	{

		public bool IsPtc
		{
			get
			{
				return !this.TestBit(this.flag, 0);
			}
		}

		public bool IsRpc
		{
			get
			{
				return this.TestBit(this.flag, 0);
			}
		}

		public bool IsRpcReply
		{
			get
			{
				return !this.TestBit(this.flag, 1);
			}
		}

		public bool IsRpcRequest
		{
			get
			{
				return this.TestBit(this.flag, 1);
			}
		}

		public bool IsCompressed
		{
			get
			{
				return this.TestBit(this.flag, 2);
			}
		}

		public bool IsRpcNull
		{
			get
			{
				return this.TestBit(this.flag, 3);
			}
		}

		public bool TestBit(uint value, int bit)
		{
			return ((ulong)value & (ulong)(1L << (bit & 31))) > 0UL;
		}

		public ProtocolHead()
		{
			this.len = 0U;
			this.type = 0U;
			this.flag = 0U;
		}

		public void Reset()
		{
			this.len = 0U;
			this.type = 0U;
			this.flag = 0U;
			this.tagID = 0U;
		}

		public int Size
		{
			get
			{
				bool isRpc = this.IsRpc;
				int result;
				if (isRpc)
				{
					result = 16;
				}
				else
				{
					result = 12;
				}
				return result;
			}
		}

		public void Deserialize(byte[] bytes)
		{
			this.len = BitConverter.ToUInt32(bytes, 0);
			this.type = BitConverter.ToUInt32(bytes, 4);
			this.flag = BitConverter.ToUInt32(bytes, 8);
			bool isRpc = this.IsRpc;
			if (isRpc)
			{
				this.tagID = BitConverter.ToUInt32(bytes, 12);
			}
		}

		private uint ToUInt32(ref SmallBuffer<byte> sb, int startIndex)
		{
			uint num = (uint)sb[startIndex];
			uint num2 = (uint)sb[startIndex + 1];
			uint num3 = (uint)sb[startIndex + 2];
			uint num4 = (uint)sb[startIndex + 3];
			return num | num2 << 8 | num3 << 16 | num4 << 24;
		}

		public void Deserialize(ref SmallBuffer<byte> sb)
		{
			this.len = this.ToUInt32(ref sb, 0);
			this.type = this.ToUInt32(ref sb, 4);
			this.flag = this.ToUInt32(ref sb, 8);
			bool isRpc = this.IsRpc;
			if (isRpc)
			{
				this.tagID = this.ToUInt32(ref sb, 12);
			}
		}

		private byte[] GetBytes(uint value)
		{
			ProtocolHead.sharedUIntBuffer[0] = (byte)(value & 255U);
			ProtocolHead.sharedUIntBuffer[1] = (byte)((value & 65280U) >> 8);
			ProtocolHead.sharedUIntBuffer[2] = (byte)((value & 16711680U) >> 16);
			ProtocolHead.sharedUIntBuffer[3] = (byte)((value & 4278190080U) >> 24);
			return ProtocolHead.sharedUIntBuffer;
		}

		public void Serialize(MemoryStream stream)
		{
			stream.Write(this.GetBytes(this.len), 0, 4);
			stream.Write(this.GetBytes(this.type), 0, 4);
			stream.Write(this.GetBytes(this.flag), 0, 4);
			bool isRpc = this.IsRpc;
			if (isRpc)
			{
				stream.Write(this.GetBytes(this.tagID), 0, 4);
			}
		}

		public static ProtocolHead SharedHead = new ProtocolHead();

		public static byte[] sharedUIntBuffer = new byte[4];

		public uint len;

		public uint type;

		public uint flag;

		public uint tagID;

		public const uint MinSize = 12U;
	}
}
