using System;
using System.IO;
using System.Text;
using UnityEngine;

namespace XUtliPoolLib
{

	public class XBinaryReader
	{

		public XBinaryReader()
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			this.m_decoder = utf8Encoding.GetDecoder();
		}

		public bool IsEof
		{
			get
			{
				return this.m_Position >= this.m_Length;
			}
		}

		public static void Init()
		{
			StringBuilder sb = XBinaryReader.StringBuilderCache.Acquire(16);
			XBinaryReader.StringBuilderCache.Release(sb);
		}

		public static XBinaryReader Get()
		{
			return CommonObjectPool<XBinaryReader>.Get();
		}

		public static void Return(XBinaryReader reader, bool readShareResource = false)
		{
			bool flag = reader != null;
			if (flag)
			{
				reader.Close(readShareResource);
				CommonObjectPool<XBinaryReader>.Release(reader);
			}
		}

		public void Init(TextAsset ta)
		{
			this.InitByte((ta != null) ? ta.bytes : null, 0, 0);
		}

		public void InitByte(byte[] buff, int offset = 0, int count = 0)
		{
			this.m_srcBuff = buff;
			this.m_StartOffset = offset;
			this.m_Position = 0;
			bool flag = count > 0;
			if (flag)
			{
				this.m_Length = ((this.m_srcBuff != null) ? ((count > this.m_srcBuff.Length) ? this.m_srcBuff.Length : count) : 0);
			}
			else
			{
				this.m_Length = ((this.m_srcBuff != null) ? this.m_srcBuff.Length : 0);
			}
		}

		public byte[] GetBuffer()
		{
			return this.m_srcBuff;
		}

		public int Seek(int offset, SeekOrigin origin)
		{
			switch (origin)
			{
			case SeekOrigin.Begin:
				this.m_Position = ((offset > this.m_Length) ? this.m_Length : offset);
				break;
			case SeekOrigin.Current:
				this.m_Position = ((this.m_Position + offset > this.m_Length) ? this.m_Length : (this.m_Position + offset));
				break;
			case SeekOrigin.End:
				this.m_Position = ((this.m_Length - offset > this.m_Length) ? this.m_Length : (this.m_Length - offset));
				break;
			}
			return this.m_Position;
		}

		public void Close(bool readShareResource)
		{
			this.Init(null);
		}

		public int GetPosition()
		{
			return this.m_Position;
		}

		public char ReadChar()
		{
			int num = 0;
			int num2 = 1;
			int num3 = num3 = 0;
			num3 = this.m_Position;
			bool flag = this.m_charBytes == null;
			if (flag)
			{
				this.m_charBytes = new byte[128];
			}
			bool flag2 = this.m_singleChar == null;
			if (flag2)
			{
				this.m_singleChar = new char[1];
			}
			while (num == 0)
			{
				int num4 = (int)this.ReadByte();
				this.m_charBytes[0] = (byte)num4;
				bool flag3 = num4 == -1;
				if (flag3)
				{
					num2 = 0;
				}
				bool flag4 = num2 == 0;
				if (flag4)
				{
					return '\0';
				}
				try
				{
					num = this.m_decoder.GetChars(this.m_charBytes, 0, num2, this.m_singleChar, 0);
				}
				catch
				{
					this.Seek(num3 - this.m_Position, SeekOrigin.Current);
					throw;
				}
				bool flag5 = num > 1;
				if (flag5)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("XBinaryReader::ReadChar assumes it's reading one bytes only,UTF8.", null, null, null, null, null);
				}
			}
			bool flag6 = num == 0;
			if (flag6)
			{
				return '\0';
			}
			return this.m_singleChar[0];
		}

		public byte ReadByte()
		{
			bool flag = this.m_srcBuff == null || this.m_Position + 1 > this.m_Length;
			byte result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int position = this.m_Position;
				this.m_Position = position + 1;
				int @byte = (int)this.GetByte(position);
				result = (byte)@byte;
			}
			return result;
		}

		public int ReadInt32()
		{
			return (int)this.ReadUInt32();
		}

		public uint ReadUInt32()
		{
			bool flag = this.m_srcBuff == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				int num = this.m_Position += 4;
				bool flag2 = num > this.m_Length;
				if (flag2)
				{
					this.m_Position = this.m_Length;
					result = 0U;
				}
				else
				{
					result = (uint)((int)this.GetByte(num - 4) | (int)this.GetByte(num - 3) << 8 | (int)this.GetByte(num - 2) << 16 | (int)this.GetByte(num - 1) << 24);
				}
			}
			return result;
		}

		public short ReadInt16()
		{
			return (short)this.ReadUInt16();
		}

		public ushort ReadUInt16()
		{
			bool flag = this.m_srcBuff == null;
			ushort result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				int num = this.m_Position += 2;
				bool flag2 = num > this.m_Length;
				if (flag2)
				{
					this.m_Position = this.m_Length;
					result = 0;
				}
				else
				{
					result = (ushort)((int)this.GetByte(num - 2) | (int)this.GetByte(num - 1) << 8);
				}
			}
			return result;
		}

		public unsafe float ReadSingle()
		{
			bool flag = this.m_srcBuff == null;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				int num = this.m_Position += 4;
				bool flag2 = num > this.m_Length;
				if (flag2)
				{
					this.m_Position = this.m_Length;
					result = 0f;
				}
				else
				{
					uint num2 = (uint)((int)this.GetByte(num - 4) | (int)this.GetByte(num - 3) << 8 | (int)this.GetByte(num - 2) << 16 | (int)this.GetByte(num - 1) << 24);
					result = *(float*)(&num2);
				}
			}
			return result;
		}

		public unsafe double ReadDouble()
		{
			bool flag = this.m_srcBuff == null;
			double result;
			if (flag)
			{
				result = 0.0;
			}
			else
			{
				int num = this.m_Position += 8;
				bool flag2 = num > this.m_Length;
				if (flag2)
				{
					this.m_Position = this.m_Length;
					result = 0.0;
				}
				else
				{
					uint num2 = (uint)((int)this.GetByte(num - 8) | (int)this.GetByte(num - 7) << 8 | (int)this.GetByte(num - 6) << 16 | (int)this.GetByte(num - 5) << 24);
					uint num3 = (uint)((int)this.GetByte(num - 4) | (int)this.GetByte(num - 3) << 8 | (int)this.GetByte(num - 2) << 16 | (int)this.GetByte(num - 1) << 24);
					ulong num4 = (ulong)num3 << 32 | (ulong)num2;
					result = *(double*)(&num4);
				}
			}
			return result;
		}

		public long ReadInt64()
		{
			return (long)this.ReadUInt64();
		}

		public ulong ReadUInt64()
		{
			bool flag = this.m_srcBuff == null;
			ulong result;
			if (flag)
			{
				result = 0UL;
			}
			else
			{
				int num = this.m_Position += 8;
				bool flag2 = num > this.m_Length;
				if (flag2)
				{
					this.m_Position = this.m_Length;
					result = 0UL;
				}
				else
				{
					uint num2 = (uint)((int)this.GetByte(num - 8) | (int)this.GetByte(num - 7) << 8 | (int)this.GetByte(num - 6) << 16 | (int)this.GetByte(num - 5) << 24);
					uint num3 = (uint)((int)this.GetByte(num - 4) | (int)this.GetByte(num - 3) << 8 | (int)this.GetByte(num - 2) << 16 | (int)this.GetByte(num - 1) << 24);
					result = ((ulong)num3 << 32 | (ulong)num2);
				}
			}
			return result;
		}

		public bool ReadBoolean()
		{
			bool flag = this.m_srcBuff == null || this.m_Position + 1 > this.m_Length;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int position = this.m_Position;
				this.m_Position = position + 1;
				result = (this.GetByte(position) > 0);
			}
			return result;
		}

		public string ReadString(int length = -1)
		{
			bool flag = this.m_srcBuff == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				int num = 0;
				int num2 = (length < 0) ? this.Read7BitEncodedInt() : length;
				bool flag2 = num2 < 0;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("IO.IO_InvalidStringLen_Len", null, null, null, null, null);
					result = string.Empty;
				}
				else
				{
					bool flag3 = num2 == 0;
					if (flag3)
					{
						result = string.Empty;
					}
					else
					{
						bool flag4 = this.m_charBytes == null;
						if (flag4)
						{
							this.m_charBytes = new byte[128];
						}
						bool flag5 = this.m_charBuffer == null;
						if (flag5)
						{
							this.m_charBuffer = new char[XBinaryReader.MaxCharsSize];
						}
						StringBuilder stringBuilder = null;
						int chars;
						for (;;)
						{
							int num3 = (num2 - num > 128) ? 128 : (num2 - num);
							int num4 = this.m_Position;
							int num5 = this.m_Position += num3;
							bool flag6 = num5 > this.m_Length;
							if (flag6)
							{
								this.m_Position = this.m_Length;
								num3 = this.m_Position - num4;
							}
							num4 += this.m_StartOffset;
							Array.Copy(this.m_srcBuff, num4, this.m_charBytes, 0, num3);
							bool flag7 = num3 == 0;
							if (flag7)
							{
								break;
							}
							chars = this.m_decoder.GetChars(this.m_charBytes, 0, num3, this.m_charBuffer, 0);
							bool flag8 = num == 0 && num3 == num2;
							if (flag8)
							{
								goto Block_11;
							}
							bool flag9 = stringBuilder == null;
							if (flag9)
							{
								stringBuilder = XBinaryReader.StringBuilderCache.Acquire(num2);
							}
							stringBuilder.Append(this.m_charBuffer, 0, chars);
							num += num3;
							if (num >= num2)
							{
								goto Block_13;
							}
						}
						XSingleton<XDebug>.singleton.AddErrorLog("Read String 0 length", null, null, null, null, null);
						return string.Empty;
						Block_11:
						return new string(this.m_charBuffer, 0, chars);
						Block_13:
						result = XBinaryReader.StringBuilderCache.GetStringAndRelease(stringBuilder);
					}
				}
			}
			return result;
		}

		public void SkipString()
		{
			bool flag = this.m_srcBuff == null;
			if (!flag)
			{
				int num = 0;
				int num2 = this.Read7BitEncodedInt();
				bool flag2 = num2 < 0;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("IO.IO_InvalidStringLen_Len", null, null, null, null, null);
				}
				else
				{
					bool flag3 = num2 == 0;
					if (!flag3)
					{
						for (;;)
						{
							int num3 = (num2 - num > 128) ? 128 : (num2 - num);
							int position = this.m_Position;
							int num4 = this.m_Position += num3;
							bool flag4 = num4 > this.m_Length;
							if (flag4)
							{
								this.m_Position = this.m_Length;
								num3 = this.m_Position - position;
							}
							bool flag5 = num3 == 0;
							if (flag5)
							{
								break;
							}
							bool flag6 = num == 0 && num3 <= num2;
							if (flag6)
							{
								goto Block_8;
							}
							num += num3;
							if (num >= num2)
							{
								return;
							}
						}
						XSingleton<XDebug>.singleton.AddErrorLog("Read String 0 length", null, null, null, null, null);
						Block_8:;
					}
				}
			}
		}

		private int Read7BitEncodedInt()
		{
			int num = 0;
			int num2 = 0;
			for (;;)
			{
				bool flag = num2 == 35;
				if (flag)
				{
					break;
				}
				byte b = this.ReadByte();
				num |= (int)(b & 127) << num2;
				num2 += 7;
				if ((b & 128) <= 0)
				{
					goto Block_2;
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("Format_Bad7BitInt32", null, null, null, null, null);
			return 0;
			Block_2:
			return num;
		}

		private byte GetByte(int pos)
		{
			return this.m_srcBuff[pos + this.m_StartOffset];
		}

		private byte[] m_srcBuff = null;

		private int m_Length = 0;

		private int m_Position = 0;

		private int m_StartOffset = 0;

		private byte[] m_charBytes = null;

		private char[] m_charBuffer = null;

		private char[] m_singleChar = null;

		private const int MaxCharBytesSize = 128;

		private static int MaxCharsSize = 128;

		private Decoder m_decoder;

		private static class StringBuilderCache
		{

			public static StringBuilder Acquire(int capacity = 16)
			{
				bool flag = capacity <= 360;
				if (flag)
				{
					StringBuilder cachedInstance = XBinaryReader.StringBuilderCache.CachedInstance;
					bool flag2 = cachedInstance != null;
					if (flag2)
					{
						bool flag3 = capacity <= cachedInstance.Capacity;
						if (flag3)
						{
							XBinaryReader.StringBuilderCache.CachedInstance = null;
							cachedInstance.Length = 0;
							return cachedInstance;
						}
					}
				}
				return new StringBuilder(capacity);
			}

			public static void Release(StringBuilder sb)
			{
				bool flag = sb.Capacity <= 360;
				if (flag)
				{
					XBinaryReader.StringBuilderCache.CachedInstance = sb;
				}
			}

			public static string GetStringAndRelease(StringBuilder sb)
			{
				string result = sb.ToString();
				XBinaryReader.StringBuilderCache.Release(sb);
				return result;
			}

			private const int MAX_BUILDER_SIZE = 360;

			[ThreadStatic]
			private static StringBuilder CachedInstance;
		}
	}
}
