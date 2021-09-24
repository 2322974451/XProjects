using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMobaBattleBriefRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 35507U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMobaBattleBriefRecordArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMobaBattleBriefRecordRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMobaBattleBriefRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMobaBattleBriefRecord.OnTimeout(this.oArg);
		}

		public GetMobaBattleBriefRecordArg oArg = new GetMobaBattleBriefRecordArg();

		public GetMobaBattleBriefRecordRes oRes = null;
	}
}
