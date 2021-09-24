using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NotifyAccountData : Protocol
	{

		public override uint GetProtoType()
		{
			return 29137U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoadAccountData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LoadAccountData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NotifyAccountData.Process(this);
		}

		public LoadAccountData Data = new LoadAccountData();
	}
}
