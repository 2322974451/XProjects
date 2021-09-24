using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ItemChangedNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 20270U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemChanged>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ItemChanged>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ItemChangedNtf.Process(this);
		}

		public ItemChanged Data = new ItemChanged();
	}
}
