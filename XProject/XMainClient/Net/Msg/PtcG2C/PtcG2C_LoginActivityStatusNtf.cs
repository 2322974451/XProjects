using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LoginActivityStatusNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 34113U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginActivityStatus>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LoginActivityStatus>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LoginActivityStatusNtf.Process(this);
		}

		public LoginActivityStatus Data = new LoginActivityStatus();
	}
}
