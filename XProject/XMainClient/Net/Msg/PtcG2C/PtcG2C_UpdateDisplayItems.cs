using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_UpdateDisplayItems : Protocol
	{

		public override uint GetProtoType()
		{
			return 12217U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateDisplayItems>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateDisplayItems>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_UpdateDisplayItems.Process(this);
		}

		public UpdateDisplayItems Data = new UpdateDisplayItems();
	}
}
