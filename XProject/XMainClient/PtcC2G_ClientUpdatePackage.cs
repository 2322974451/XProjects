using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016A4 RID: 5796
	internal class PtcC2G_ClientUpdatePackage : Protocol
	{
		// Token: 0x0600EFE5 RID: 61413 RVA: 0x0034C090 File Offset: 0x0034A290
		public override uint GetProtoType()
		{
			return 57832U;
		}

		// Token: 0x0600EFE6 RID: 61414 RVA: 0x0034C0A7 File Offset: 0x0034A2A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClientUpdatePackageData>(stream, this.Data);
		}

		// Token: 0x0600EFE7 RID: 61415 RVA: 0x0034C0B7 File Offset: 0x0034A2B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ClientUpdatePackageData>(stream);
		}

		// Token: 0x0600EFE8 RID: 61416 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006664 RID: 26212
		public ClientUpdatePackageData Data = new ClientUpdatePackageData();
	}
}
