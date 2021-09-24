using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TajieHelpNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 36521U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TajieHelpData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TajieHelpData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TajieHelpNotify.Process(this);
		}

		public TajieHelpData Data = new TajieHelpData();
	}
}
