using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_SendGuildBonusInSendList : Rpc
	{

		public override uint GetRpcType()
		{
			return 64498U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendGuildBonusInSendListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SendGuildBonusInSendListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SendGuildBonusInSendList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SendGuildBonusInSendList.OnTimeout(this.oArg);
		}

		public SendGuildBonusInSendListArg oArg = new SendGuildBonusInSendListArg();

		public SendGuildBonusInSendListRes oRes = null;
	}
}
