using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PvpNowAllData : Rpc
	{

		public override uint GetRpcType()
		{
			return 58355U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<roArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PvpNowGameData>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PvpNowAllData.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PvpNowAllData.OnTimeout(this.oArg);
		}

		public roArg oArg = new roArg();

		public PvpNowGameData oRes = new PvpNowGameData();
	}
}
