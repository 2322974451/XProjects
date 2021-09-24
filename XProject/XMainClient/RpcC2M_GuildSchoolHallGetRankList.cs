using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildSchoolHallGetRankList : Rpc
	{

		public override uint GetRpcType()
		{
			return 34511U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildSchoolHallGetRankList_C2M>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildSchoolHallGetRankList_M2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildSchoolHallGetRankList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildSchoolHallGetRankList.OnTimeout(this.oArg);
		}

		public GuildSchoolHallGetRankList_C2M oArg = new GuildSchoolHallGetRankList_C2M();

		public GuildSchoolHallGetRankList_M2C oRes = null;
	}
}
