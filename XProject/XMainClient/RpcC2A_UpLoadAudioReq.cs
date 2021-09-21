using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001135 RID: 4405
	internal class RpcC2A_UpLoadAudioReq : Rpc
	{
		// Token: 0x0600D999 RID: 55705 RVA: 0x0032B510 File Offset: 0x00329710
		public override uint GetRpcType()
		{
			return 3069U;
		}

		// Token: 0x0600D99A RID: 55706 RVA: 0x0032B527 File Offset: 0x00329727
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpLoadAudioReq>(stream, this.oArg);
		}

		// Token: 0x0600D99B RID: 55707 RVA: 0x0032B537 File Offset: 0x00329737
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UpLoadAudioRes>(stream);
		}

		// Token: 0x0600D99C RID: 55708 RVA: 0x0032B546 File Offset: 0x00329746
		public override void Process()
		{
			base.Process();
			Process_RpcC2A_UpLoadAudioReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D99D RID: 55709 RVA: 0x0032B562 File Offset: 0x00329762
		public override void OnTimeout(object args)
		{
			Process_RpcC2A_UpLoadAudioReq.OnTimeout(this.oArg);
		}

		// Token: 0x0400620C RID: 25100
		public UpLoadAudioReq oArg = new UpLoadAudioReq();

		// Token: 0x0400620D RID: 25101
		public UpLoadAudioRes oRes = new UpLoadAudioRes();
	}
}
