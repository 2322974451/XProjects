using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_ClientUpdatePackage : Protocol
	{

		public override uint GetProtoType()
		{
			return 57832U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClientUpdatePackageData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ClientUpdatePackageData>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public ClientUpdatePackageData Data = new ClientUpdatePackageData();
	}
}
