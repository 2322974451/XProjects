using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LoginReward2CNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 51966U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginRewardRet>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LoginRewardRet>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LoginReward2CNtf.Process(this);
		}

		public LoginRewardRet Data = new LoginRewardRet();
	}
}
