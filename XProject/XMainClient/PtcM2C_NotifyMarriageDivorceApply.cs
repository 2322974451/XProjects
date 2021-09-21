using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015B5 RID: 5557
	internal class PtcM2C_NotifyMarriageDivorceApply : Protocol
	{
		// Token: 0x0600EBFA RID: 60410 RVA: 0x0034675C File Offset: 0x0034495C
		public override uint GetProtoType()
		{
			return 32886U;
		}

		// Token: 0x0600EBFB RID: 60411 RVA: 0x00346773 File Offset: 0x00344973
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyMarriageDivorceApplyData>(stream, this.Data);
		}

		// Token: 0x0600EBFC RID: 60412 RVA: 0x00346783 File Offset: 0x00344983
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyMarriageDivorceApplyData>(stream);
		}

		// Token: 0x0600EBFD RID: 60413 RVA: 0x00346792 File Offset: 0x00344992
		public override void Process()
		{
			Process_PtcM2C_NotifyMarriageDivorceApply.Process(this);
		}

		// Token: 0x04006594 RID: 26004
		public NotifyMarriageDivorceApplyData Data = new NotifyMarriageDivorceApplyData();
	}
}
