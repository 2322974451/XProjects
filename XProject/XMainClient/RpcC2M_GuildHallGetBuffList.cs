using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildHallGetBuffList : Rpc
	{

		public override uint GetRpcType()
		{
			return 38816U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildHallGetBuffList_C2M>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildHallGetBuffList_M2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildHallGetBuffList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildHallGetBuffList.OnTimeout(this.oArg);
		}

		public GuildHallGetBuffList_C2M oArg = new GuildHallGetBuffList_C2M();

		public GuildHallGetBuffList_M2C oRes = null;
	}
}
