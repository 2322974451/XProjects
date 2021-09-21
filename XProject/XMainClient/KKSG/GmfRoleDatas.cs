using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200019C RID: 412
	[ProtoContract(Name = "GmfRoleDatas")]
	[Serializable]
	public class GmfRoleDatas : IExtensible
	{
		// Token: 0x170007C9 RID: 1993
		// (get) Token: 0x060018AA RID: 6314 RVA: 0x00031178 File Offset: 0x0002F378
		// (set) Token: 0x060018AB RID: 6315 RVA: 0x00031190 File Offset: 0x0002F390
		[ProtoMember(1, IsRequired = false, Name = "halfrole11", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfHalfRoles halfrole11
		{
			get
			{
				return this._halfrole11;
			}
			set
			{
				this._halfrole11 = value;
			}
		}

		// Token: 0x170007CA RID: 1994
		// (get) Token: 0x060018AC RID: 6316 RVA: 0x0003119C File Offset: 0x0002F39C
		// (set) Token: 0x060018AD RID: 6317 RVA: 0x000311B4 File Offset: 0x0002F3B4
		[ProtoMember(2, IsRequired = false, Name = "halfrole22", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GmfHalfRoles halfrole22
		{
			get
			{
				return this._halfrole22;
			}
			set
			{
				this._halfrole22 = value;
			}
		}

		// Token: 0x060018AE RID: 6318 RVA: 0x000311C0 File Offset: 0x0002F3C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400061A RID: 1562
		private GmfHalfRoles _halfrole11 = null;

		// Token: 0x0400061B RID: 1563
		private GmfHalfRoles _halfrole22 = null;

		// Token: 0x0400061C RID: 1564
		private IExtension extensionObject;
	}
}
