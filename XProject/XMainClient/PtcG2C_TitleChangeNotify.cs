using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TitleChangeNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 1040U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<titleChangeData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<titleChangeData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TitleChangeNotify.Process(this);
		}

		public titleChangeData Data = new titleChangeData();
	}
}
