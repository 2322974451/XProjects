using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetHolidayStageInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 31093U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetHolidayStageInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetHolidayStageInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetHolidayStageInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetHolidayStageInfo.OnTimeout(this.oArg);
		}

		public GetHolidayStageInfoArg oArg = new GetHolidayStageInfoArg();

		public GetHolidayStageInfoRes oRes = null;
	}
}
