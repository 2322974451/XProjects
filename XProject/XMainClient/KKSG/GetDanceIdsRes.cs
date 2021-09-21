using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000534 RID: 1332
	[ProtoContract(Name = "GetDanceIdsRes")]
	[Serializable]
	public class GetDanceIdsRes : IExtensible
	{
		// Token: 0x170014EB RID: 5355
		// (get) Token: 0x06004468 RID: 17512 RVA: 0x00082230 File Offset: 0x00080430
		[ProtoMember(1, Name = "danceid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> danceid
		{
			get
			{
				return this._danceid;
			}
		}

		// Token: 0x170014EC RID: 5356
		// (get) Token: 0x06004469 RID: 17513 RVA: 0x00082248 File Offset: 0x00080448
		[ProtoMember(2, Name = "valid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> valid
		{
			get
			{
				return this._valid;
			}
		}

		// Token: 0x0600446A RID: 17514 RVA: 0x00082260 File Offset: 0x00080460
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001113 RID: 4371
		private readonly List<uint> _danceid = new List<uint>();

		// Token: 0x04001114 RID: 4372
		private readonly List<uint> _valid = new List<uint>();

		// Token: 0x04001115 RID: 4373
		private IExtension extensionObject;
	}
}
