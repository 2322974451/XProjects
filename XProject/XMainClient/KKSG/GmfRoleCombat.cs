using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006BB RID: 1723
	[ProtoContract(Name = "GmfRoleCombat")]
	[Serializable]
	public class GmfRoleCombat : IExtensible
	{
		// Token: 0x170023DE RID: 9182
		// (get) Token: 0x0600714C RID: 29004 RVA: 0x000D8C88 File Offset: 0x000D6E88
		// (set) Token: 0x0600714D RID: 29005 RVA: 0x000D8CA0 File Offset: 0x000D6EA0
		[ProtoMember(1, IsRequired = false, Name = "gmfrole", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfRoleBrief gmfrole
		{
			get
			{
				return this._gmfrole;
			}
			set
			{
				this._gmfrole = value;
			}
		}

		// Token: 0x170023DF RID: 9183
		// (get) Token: 0x0600714E RID: 29006 RVA: 0x000D8CAC File Offset: 0x000D6EAC
		// (set) Token: 0x0600714F RID: 29007 RVA: 0x000D8CC4 File Offset: 0x000D6EC4
		[ProtoMember(2, IsRequired = false, Name = "combat", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfCombat combat
		{
			get
			{
				return this._combat;
			}
			set
			{
				this._combat = value;
			}
		}

		// Token: 0x06007150 RID: 29008 RVA: 0x000D8CD0 File Offset: 0x000D6ED0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B07 RID: 6919
		private GmfRoleBrief _gmfrole = null;

		// Token: 0x04001B08 RID: 6920
		private GmfCombat _combat = null;

		// Token: 0x04001B09 RID: 6921
		private IExtension extensionObject;
	}
}
