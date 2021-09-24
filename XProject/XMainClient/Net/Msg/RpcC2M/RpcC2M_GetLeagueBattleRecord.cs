using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetLeagueBattleRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 51407U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLeagueBattleRecordArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLeagueBattleRecordRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetLeagueBattleRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetLeagueBattleRecord.OnTimeout(this.oArg);
		}

		public GetLeagueBattleRecordArg oArg = new GetLeagueBattleRecordArg();

		public GetLeagueBattleRecordRes oRes = null;
	}
}
