using System;
using System.IO;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EC0 RID: 3776
	public class ProtocolHead
	{
		// Token: 0x170034FA RID: 13562
		// (get) Token: 0x0600C888 RID: 51336 RVA: 0x002CEA08 File Offset: 0x002CCC08
		public bool IsPtc
		{
			get
			{
				return !this.TestBit(this.flag, 0);
			}
		}

		// Token: 0x170034FB RID: 13563
		// (get) Token: 0x0600C889 RID: 51337 RVA: 0x002CEA2C File Offset: 0x002CCC2C
		public bool IsRpc
		{
			get
			{
				return this.TestBit(this.flag, 0);
			}
		}

		// Token: 0x170034FC RID: 13564
		// (get) Token: 0x0600C88A RID: 51338 RVA: 0x002CEA4C File Offset: 0x002CCC4C
		public bool IsRpcReply
		{
			get
			{
				return !this.TestBit(this.flag, 1);
			}
		}

		// Token: 0x170034FD RID: 13565
		// (get) Token: 0x0600C88B RID: 51339 RVA: 0x002CEA70 File Offset: 0x002CCC70
		public bool IsRpcRequest
		{
			get
			{
				return this.TestBit(this.flag, 1);
			}
		}

		// Token: 0x170034FE RID: 13566
		// (get) Token: 0x0600C88C RID: 51340 RVA: 0x002CEA90 File Offset: 0x002CCC90
		public bool IsCompressed
		{
			get
			{
				return this.TestBit(this.flag, 2);
			}
		}

		// Token: 0x170034FF RID: 13567
		// (get) Token: 0x0600C88D RID: 51341 RVA: 0x002CEAB0 File Offset: 0x002CCCB0
		public bool IsRpcNull
		{
			get
			{
				return this.TestBit(this.flag, 3);
			}
		}

		// Token: 0x0600C88E RID: 51342 RVA: 0x002CEAD0 File Offset: 0x002CCCD0
		public bool TestBit(uint value, int bit)
		{
			return ((ulong)value & (ulong)(1L << (bit & 31))) > 0UL;
		}

		// Token: 0x0600C88F RID: 51343 RVA: 0x002CEAF0 File Offset: 0x002CCCF0
		public ProtocolHead()
		{
			this.len = 0U;
			this.type = 0U;
			this.flag = 0U;
		}

		// Token: 0x0600C890 RID: 51344 RVA: 0x002CEB0F File Offset: 0x002CCD0F
		public void Reset()
		{
			this.len = 0U;
			this.type = 0U;
			this.flag = 0U;
			this.tagID = 0U;
		}

		// Token: 0x17003500 RID: 13568
		// (get) Token: 0x0600C891 RID: 51345 RVA: 0x002CEB30 File Offset: 0x002CCD30
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

		// Token: 0x0600C892 RID: 51346 RVA: 0x002CEB54 File Offset: 0x002CCD54
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

		// Token: 0x0600C893 RID: 51347 RVA: 0x002CEBA4 File Offset: 0x002CCDA4
		private uint ToUInt32(ref SmallBuffer<byte> sb, int startIndex)
		{
			uint num = (uint)sb[startIndex];
			uint num2 = (uint)sb[startIndex + 1];
			uint num3 = (uint)sb[startIndex + 2];
			uint num4 = (uint)sb[startIndex + 3];
			return num | num2 << 8 | num3 << 16 | num4 << 24;
		}

		// Token: 0x0600C894 RID: 51348 RVA: 0x002CEBF0 File Offset: 0x002CCDF0
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

		// Token: 0x0600C895 RID: 51349 RVA: 0x002CEC44 File Offset: 0x002CCE44
		private byte[] GetBytes(uint value)
		{
			ProtocolHead.sharedUIntBuffer[0] = (byte)(value & 255U);
			ProtocolHead.sharedUIntBuffer[1] = (byte)((value & 65280U) >> 8);
			ProtocolHead.sharedUIntBuffer[2] = (byte)((value & 16711680U) >> 16);
			ProtocolHead.sharedUIntBuffer[3] = (byte)((value & 4278190080U) >> 24);
			return ProtocolHead.sharedUIntBuffer;
		}

		// Token: 0x0600C896 RID: 51350 RVA: 0x002CECA0 File Offset: 0x002CCEA0
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

		// Token: 0x040058B3 RID: 22707
		public static ProtocolHead SharedHead = new ProtocolHead();

		// Token: 0x040058B4 RID: 22708
		public static byte[] sharedUIntBuffer = new byte[4];

		// Token: 0x040058B5 RID: 22709
		public uint len;

		// Token: 0x040058B6 RID: 22710
		public uint type;

		// Token: 0x040058B7 RID: 22711
		public uint flag;

		// Token: 0x040058B8 RID: 22712
		public uint tagID;

		// Token: 0x040058B9 RID: 22713
		public const uint MinSize = 12U;
	}
}
