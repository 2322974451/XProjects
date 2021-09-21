using System;

namespace XUtliPoolLib
{
	// Token: 0x020000D3 RID: 211
	public struct SeqListRef<T> : ISeqListRef<T>, ISeqRef
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0001AE00 File Offset: 0x00019000
		public int Count
		{
			get
			{
				return (int)this.count;
			}
		}

		// Token: 0x170000A6 RID: 166
		public T this[int index, int key]
		{
			get
			{
				return this.dataHandler.ReadValue<T>(SeqListRef<T>.parser, this.allSameMask, this.startOffset, index, key);
			}
		}

		// Token: 0x060005CF RID: 1487 RVA: 0x0001AE48 File Offset: 0x00019048
		public void Read(XBinaryReader stream, DataHandler dh)
		{
			this.count = stream.ReadByte();
			this.allSameMask = 1;
			this.startOffset = 0;
			bool flag = this.count > 0;
			if (flag)
			{
				this.allSameMask = stream.ReadByte();
				this.startOffset = stream.ReadUInt16();
			}
			this.dataHandler = dh;
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x0001AEA0 File Offset: 0x000190A0
		public override string ToString()
		{
			string text = "";
			for (int i = 0; i < (int)this.count; i++)
			{
				bool flag = i == (int)(this.count - 1);
				if (flag)
				{
					text += string.Format("{0}={1}", this[i, 0], this[i, 1]);
				}
				else
				{
					text += string.Format("{0}={1}|", this[i, 0], this[i, 1]);
				}
			}
			return text;
		}

		// Token: 0x04000318 RID: 792
		public static CVSReader.ValueParse<T> parser;

		// Token: 0x04000319 RID: 793
		public DataHandler dataHandler;

		// Token: 0x0400031A RID: 794
		public byte count;

		// Token: 0x0400031B RID: 795
		public byte allSameMask;

		// Token: 0x0400031C RID: 796
		public ushort startOffset;
	}
}
