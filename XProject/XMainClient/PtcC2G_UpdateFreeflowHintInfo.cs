using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200161F RID: 5663
	internal class PtcC2G_UpdateFreeflowHintInfo : Protocol
	{
		// Token: 0x0600EDB5 RID: 60853 RVA: 0x00348BB4 File Offset: 0x00346DB4
		public override uint GetProtoType()
		{
			return 27628U;
		}

		// Token: 0x0600EDB6 RID: 60854 RVA: 0x00348BCB File Offset: 0x00346DCB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateFreeflowHintInfo>(stream, this.Data);
		}

		// Token: 0x0600EDB7 RID: 60855 RVA: 0x00348BDB File Offset: 0x00346DDB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateFreeflowHintInfo>(stream);
		}

		// Token: 0x0600EDB8 RID: 60856 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040065EC RID: 26092
		public UpdateFreeflowHintInfo Data = new UpdateFreeflowHintInfo();
	}
}
