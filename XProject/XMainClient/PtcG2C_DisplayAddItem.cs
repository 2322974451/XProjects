using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_DisplayAddItem : Protocol
	{

		public override uint GetProtoType()
		{
			return 55159U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DisplayAddItemArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DisplayAddItemArg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_DisplayAddItem.Process(this);
		}

		public DisplayAddItemArg Data = new DisplayAddItemArg();
	}
}
