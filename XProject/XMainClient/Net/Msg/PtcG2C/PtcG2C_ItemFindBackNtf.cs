using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ItemFindBackNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 28509U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemFindBackData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ItemFindBackData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ItemFindBackNtf.Process(this);
		}

		public ItemFindBackData Data = new ItemFindBackData();
	}
}
