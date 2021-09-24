using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_MulActivityIconSysReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 64642U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MulActivityIconSys>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MulActivityIconSys>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public MulActivityIconSys Data = new MulActivityIconSys();
	}
}
