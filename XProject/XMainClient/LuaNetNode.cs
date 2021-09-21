using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B3D RID: 2877
	public class LuaNetNode
	{
		// Token: 0x0600A82F RID: 43055 RVA: 0x001DFA58 File Offset: 0x001DDC58
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

		// Token: 0x0600A830 RID: 43056 RVA: 0x001DFABC File Offset: 0x001DDCBC
		public void Reset()
		{
			this.isRpc = false;
			this.type = 0U;
			this.tagID = 0U;
			this.length = 0;
			this.resp = null;
			this.err = null;
		}

		// Token: 0x04003E50 RID: 15952
		public bool isRpc = false;

		// Token: 0x04003E51 RID: 15953
		public uint type;

		// Token: 0x04003E52 RID: 15954
		public uint tagID;

		// Token: 0x04003E53 RID: 15955
		public bool isOnlyLua = false;

		// Token: 0x04003E54 RID: 15956
		public byte[] buffer;

		// Token: 0x04003E55 RID: 15957
		public int length;

		// Token: 0x04003E56 RID: 15958
		public bool copyBuffer = true;

		// Token: 0x04003E57 RID: 15959
		public DelLuaRespond resp;

		// Token: 0x04003E58 RID: 15960
		public DelLuaError err;
	}
}
