using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001337 RID: 4919
	internal class RpcC2M_GardenFishInfo : Rpc
	{
		// Token: 0x0600E1CA RID: 57802 RVA: 0x00338180 File Offset: 0x00336380
		public override uint GetRpcType()
		{
			return 10768U;
		}

		// Token: 0x0600E1CB RID: 57803 RVA: 0x00338197 File Offset: 0x00336397
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenFishInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E1CC RID: 57804 RVA: 0x003381A7 File Offset: 0x003363A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenFishInfoRes>(stream);
		}

		// Token: 0x0600E1CD RID: 57805 RVA: 0x003381B6 File Offset: 0x003363B6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenFishInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E1CE RID: 57806 RVA: 0x003381D2 File Offset: 0x003363D2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenFishInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400639C RID: 25500
		public GardenFishInfoArg oArg = new GardenFishInfoArg();

		// Token: 0x0400639D RID: 25501
		public GardenFishInfoRes oRes = null;
	}
}
