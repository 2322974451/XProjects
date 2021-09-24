using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_HorseReConnect : Rpc
	{

		public override uint GetRpcType()
		{
			return 7786U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HorseReConnectArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<HorseReConnectRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_HorseReConnect.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_HorseReConnect.OnTimeout(this.oArg);
		}

		public HorseReConnectArg oArg = new HorseReConnectArg();

		public HorseReConnectRes oRes = null;
	}
}
