using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_AutoFightNTF : Protocol
	{

		public override uint GetProtoType()
		{
			return 25699U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AutoFight>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AutoFight>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public AutoFight Data = new AutoFight();
	}
}
