using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001133 RID: 4403
	internal class RpcC2A_GetAudioListReq : Rpc
	{
		// Token: 0x0600D990 RID: 55696 RVA: 0x0032B418 File Offset: 0x00329618
		public override uint GetRpcType()
		{
			return 49666U;
		}

		// Token: 0x0600D991 RID: 55697 RVA: 0x0032B42F File Offset: 0x0032962F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetAudioListReq>(stream, this.oArg);
		}

		// Token: 0x0600D992 RID: 55698 RVA: 0x0032B43F File Offset: 0x0032963F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetAudioListRes>(stream);
		}

		// Token: 0x0600D993 RID: 55699 RVA: 0x0032B44E File Offset: 0x0032964E
		public override void Process()
		{
			base.Process();
			Process_RpcC2A_GetAudioListReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D994 RID: 55700 RVA: 0x0032B46A File Offset: 0x0032966A
		public override void OnTimeout(object args)
		{
			Process_RpcC2A_GetAudioListReq.OnTimeout(this.oArg);
		}

		// Token: 0x0400620A RID: 25098
		public GetAudioListReq oArg = new GetAudioListReq();

		// Token: 0x0400620B RID: 25099
		public GetAudioListRes oRes = new GetAudioListRes();
	}
}
