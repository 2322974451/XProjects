using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_UseGuildBuff : Rpc
	{

		public override uint GetRpcType()
		{
			return 15817U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UseGuildBuffArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UseGuildBuffRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_UseGuildBuff.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_UseGuildBuff.OnTimeout(this.oArg);
		}

		public UseGuildBuffArg oArg = new UseGuildBuffArg();

		public UseGuildBuffRes oRes = null;
	}
}
