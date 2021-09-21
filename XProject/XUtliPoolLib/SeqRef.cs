using System;

namespace XUtliPoolLib
{
	// Token: 0x020000D2 RID: 210
	public struct SeqRef<T> : ISeqRef<T>, ISeqRef
	{
		// Token: 0x060005C9 RID: 1481 RVA: 0x0001AD63 File Offset: 0x00018F63
		public SeqRef(T[] buffer)
		{
			this.bufferRef = buffer;
			this.startOffset = 0;
		}

		// Token: 0x170000A4 RID: 164
		public T this[int key]
		{
			get
			{
				return this.bufferRef[(int)this.startOffset + key];
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0001AD9C File Offset: 0x00018F9C
		public void Read(XBinaryReader stream, DataHandler dh)
		{
			ushort num = stream.ReadUInt16();
			this.bufferRef = SeqRef<T>.parser.GetBuffer(dh);
			this.startOffset = num;
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0001ADCC File Offset: 0x00018FCC
		public override string ToString()
		{
			return string.Format("{0}={1}", this[0], this[1]);
		}

		// Token: 0x04000315 RID: 789
		public static CVSReader.ValueParse<T> parser;

		// Token: 0x04000316 RID: 790
		public T[] bufferRef;

		// Token: 0x04000317 RID: 791
		public ushort startOffset;
	}
}
