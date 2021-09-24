using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_getguildbosstimeleft : Rpc
	{

		public override uint GetRpcType()
		{
			return 25923U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<getguildbosstimeleftArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<getguildbosstimeleftRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_getguildbosstimeleft.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_getguildbosstimeleft.OnTimeout(this.oArg);
		}

		public getguildbosstimeleftArg oArg = new getguildbosstimeleftArg();

		public getguildbosstimeleftRes oRes = null;
	}
}
