using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000533 RID: 1331
	[ProtoContract(Name = "GetDanceIdsArg")]
	[Serializable]
	public class GetDanceIdsArg : IExtensible
	{
		// Token: 0x170014EA RID: 5354
		// (get) Token: 0x06004465 RID: 17509 RVA: 0x000821D8 File Offset: 0x000803D8
		[ProtoMember(1, Name = "danceid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> danceid
		{
			get
			{
				return this._danceid;
			}
		}

		// Token: 0x06004466 RID: 17510 RVA: 0x000821F0 File Offset: 0x000803F0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001111 RID: 4369
		private readonly List<uint> _danceid = new List<uint>();

		// Token: 0x04001112 RID: 4370
		private IExtension extensionObject;
	}
}
