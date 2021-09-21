using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001549 RID: 5449
	internal class RpcC2M_GetMobaBattleBriefRecord : Rpc
	{
		// Token: 0x0600EA3D RID: 59965 RVA: 0x00343EE0 File Offset: 0x003420E0
		public override uint GetRpcType()
		{
			return 35507U;
		}

		// Token: 0x0600EA3E RID: 59966 RVA: 0x00343EF7 File Offset: 0x003420F7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMobaBattleBriefRecordArg>(stream, this.oArg);
		}

		// Token: 0x0600EA3F RID: 59967 RVA: 0x00343F07 File Offset: 0x00342107
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMobaBattleBriefRecordRes>(stream);
		}

		// Token: 0x0600EA40 RID: 59968 RVA: 0x00343F16 File Offset: 0x00342116
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMobaBattleBriefRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EA41 RID: 59969 RVA: 0x00343F32 File Offset: 0x00342132
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMobaBattleBriefRecord.OnTimeout(this.oArg);
		}

		// Token: 0x04006538 RID: 25912
		public GetMobaBattleBriefRecordArg oArg = new GetMobaBattleBriefRecordArg();

		// Token: 0x04006539 RID: 25913
		public GetMobaBattleBriefRecordRes oRes = null;
	}
}
