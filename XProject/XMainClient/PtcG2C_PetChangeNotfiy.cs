using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010DE RID: 4318
	internal class PtcG2C_PetChangeNotfiy : Protocol
	{
		// Token: 0x0600D830 RID: 55344 RVA: 0x0032936C File Offset: 0x0032756C
		public override uint GetProtoType()
		{
			return 22264U;
		}

		// Token: 0x0600D831 RID: 55345 RVA: 0x00329383 File Offset: 0x00327583
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PetChangeNotfiy>(stream, this.Data);
		}

		// Token: 0x0600D832 RID: 55346 RVA: 0x00329393 File Offset: 0x00327593
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PetChangeNotfiy>(stream);
		}

		// Token: 0x0600D833 RID: 55347 RVA: 0x003293A2 File Offset: 0x003275A2
		public override void Process()
		{
			Process_PtcG2C_PetChangeNotfiy.Process(this);
		}

		// Token: 0x040061C7 RID: 25031
		public PetChangeNotfiy Data = new PetChangeNotfiy();
	}
}
