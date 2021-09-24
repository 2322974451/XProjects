using System;
using XUtliPoolLib;

namespace XMainClient
{

	public class LuaNetNode
	{

		public void SetBuff(byte[] buf, int length)
		{
			bool flag = buf != null && length > 0 && this.buffer != null;
			if (flag)
			{
				for (int i = 0; i < this.buffer.Length; i++)
				{
					this.buffer[i] = 0;
				}
				bool flag2 = buf != null;
				if (flag2)
				{
					Array.Copy(buf, this.buffer, length);
				}
				this.length = length;
			}
		}

		public void Reset()
		{
			this.isRpc = false;
			this.type = 0U;
			this.tagID = 0U;
			this.length = 0;
			this.resp = null;
			this.err = null;
		}

		public bool isRpc = false;

		public uint type;

		public uint tagID;

		public bool isOnlyLua = false;

		public byte[] buffer;

		public int length;

		public bool copyBuffer = true;

		public DelLuaRespond resp;

		public DelLuaError err;
	}
}
