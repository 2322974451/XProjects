using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200049F RID: 1183
	[ProtoContract(Name = "WeddingCarNotify")]
	[Serializable]
	public class WeddingCarNotify : IExtensible
	{
		// Token: 0x170012DC RID: 4828
		// (get) Token: 0x06003D8D RID: 15757 RVA: 0x000757B0 File Offset: 0x000739B0
		// (set) Token: 0x06003D8E RID: 15758 RVA: 0x000757C8 File Offset: 0x000739C8
		[ProtoMember(1, IsRequired = false, Name = "role1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance role1
		{
			get
			{
				return this._role1;
			}
			set
			{
				this._role1 = value;
			}
		}

		// Token: 0x170012DD RID: 4829
		// (get) Token: 0x06003D8F RID: 15759 RVA: 0x000757D4 File Offset: 0x000739D4
		// (set) Token: 0x06003D90 RID: 15760 RVA: 0x000757EC File Offset: 0x000739EC
		[ProtoMember(2, IsRequired = false, Name = "role2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance role2
		{
			get
			{
				return this._role2;
			}
			set
			{
				this._role2 = value;
			}
		}

		// Token: 0x06003D91 RID: 15761 RVA: 0x000757F8 File Offset: 0x000739F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000F54 RID: 3924
		private UnitAppearance _role1 = null;

		// Token: 0x04000F55 RID: 3925
		private UnitAppearance _role2 = null;

		// Token: 0x04000F56 RID: 3926
		private IExtension extensionObject;
	}
}
