using System;

namespace XUtliPoolLib
{

	public struct SeqRef<T> : ISeqRef<T>, ISeqRef
	{

		public SeqRef(T[] buffer)
		{
			this.bufferRef = buffer;
			this.startOffset = 0;
		}

		public T this[int key]
		{
			get
			{
				return this.bufferRef[(int)this.startOffset + key];
			}
		}

		public void Read(XBinaryReader stream, DataHandler dh)
		{
			ushort num = stream.ReadUInt16();
			this.bufferRef = SeqRef<T>.parser.GetBuffer(dh);
			this.startOffset = num;
		}

		public override string ToString()
		{
			return string.Format("{0}={1}", this[0], this[1]);
		}

		public static CVSReader.ValueParse<T> parser;

		public T[] bufferRef;

		public ushort startOffset;
	}
}
