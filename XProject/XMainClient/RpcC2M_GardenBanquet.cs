using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001321 RID: 4897
	internal class RpcC2M_GardenBanquet : Rpc
	{
		// Token: 0x0600E173 RID: 57715 RVA: 0x00337998 File Offset: 0x00335B98
		public override uint GetRpcType()
		{
			return 22527U;
		}

		// Token: 0x0600E174 RID: 57716 RVA: 0x003379AF File Offset: 0x00335BAF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenBanquetArg>(stream, this.oArg);
		}

		// Token: 0x0600E175 RID: 57717 RVA: 0x003379BF File Offset: 0x00335BBF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenBanquetRes>(stream);
		}

		// Token: 0x0600E176 RID: 57718 RVA: 0x003379CE File Offset: 0x00335BCE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenBanquet.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E177 RID: 57719 RVA: 0x003379EA File Offset: 0x00335BEA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenBanquet.OnTimeout(this.oArg);
		}

		// Token: 0x0400638C RID: 25484
		public GardenBanquetArg oArg = new GardenBanquetArg();

		// Token: 0x0400638D RID: 25485
		public GardenBanquetRes oRes = null;
	}
}
