using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FetchDragonGuildList : Rpc
	{

		public override uint GetRpcType()
		{
			return 23518U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchDragonGuildListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchDragonGuildRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchDragonGuildList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchDragonGuildList.OnTimeout(this.oArg);
		}

		public FetchDragonGuildListArg oArg = new FetchDragonGuildListArg();

		public FetchDragonGuildRes oRes = null;
	}
}
