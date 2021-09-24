using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_WeekEnd4v4GetInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 59573U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeekEnd4v4GetInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WeekEnd4v4GetInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_WeekEnd4v4GetInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_WeekEnd4v4GetInfo.OnTimeout(this.oArg);
		}

		public WeekEnd4v4GetInfoArg oArg = new WeekEnd4v4GetInfoArg();

		public WeekEnd4v4GetInfoRes oRes = null;
	}
}
