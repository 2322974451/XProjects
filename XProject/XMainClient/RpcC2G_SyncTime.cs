using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SyncTime : Rpc
	{

		public override uint GetRpcType()
		{
			return 30514U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SyncTimeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes.serverTime = 0L;
			this.oRes.serverTimeSpecified = false;
			Serializer.Merge<SyncTimeRes>(stream, this.oRes);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SyncTime.Ticks = this.replyTick;
			Process_RpcC2G_SyncTime.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SyncTime.OnTimeout(this.oArg);
		}

		public SyncTimeArg oArg = new SyncTimeArg();

		public SyncTimeRes oRes = new SyncTimeRes();
	}
}
