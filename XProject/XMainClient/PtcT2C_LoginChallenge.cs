using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcT2C_LoginChallenge : Protocol
	{

		public override uint GetProtoType()
		{
			return 58495U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginChallenge>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LoginChallenge>(stream);
		}

		public override void Process()
		{
			Process_PtcT2C_LoginChallenge.Process(this);
		}

		public LoginChallenge Data = new LoginChallenge();
	}
}
