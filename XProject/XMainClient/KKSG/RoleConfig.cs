using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000608 RID: 1544
	[ProtoContract(Name = "RoleConfig")]
	[Serializable]
	public class RoleConfig : IExtensible
	{
		// Token: 0x17001D2D RID: 7469
		// (get) Token: 0x06005D14 RID: 23828 RVA: 0x000B15E4 File Offset: 0x000AF7E4
		[ProtoMember(1, Name = "type", DataFormat = DataFormat.Default)]
		public List<string> type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x17001D2E RID: 7470
		// (get) Token: 0x06005D15 RID: 23829 RVA: 0x000B15FC File Offset: 0x000AF7FC
		[ProtoMember(2, Name = "value", DataFormat = DataFormat.Default)]
		public List<string> value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x06005D16 RID: 23830 RVA: 0x000B1614 File Offset: 0x000AF814
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400169E RID: 5790
		private readonly List<string> _type = new List<string>();

		// Token: 0x0400169F RID: 5791
		private readonly List<string> _value = new List<string>();

		// Token: 0x040016A0 RID: 5792
		private IExtension extensionObject;
	}
}
