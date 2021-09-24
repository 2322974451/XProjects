using System;

namespace XUtliPoolLib
{

	public struct SeqListRef<T> : ISeqListRef<T>, ISeqRef
	{

		public int Count
		{
			get
			{
				return (int)this.count;
			}
		}

		public T this[int index, int key]
		{
			get
			{
				return this.dataHandler.ReadValue<T>(SeqListRef<T>.parser, this.allSameMask, this.startOffset, index, key);
			}
		}

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

		public static CVSReader.ValueParse<T> parser;

		public DataHandler dataHandler;

		public byte count;

		public byte allSameMask;

		public ushort startOffset;
	}
}
