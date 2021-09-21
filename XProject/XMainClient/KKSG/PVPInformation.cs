using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006FD RID: 1789
	[ProtoContract(Name = "PVPInformation")]
	[Serializable]
	public class PVPInformation : IExtensible
	{
		// Token: 0x17002649 RID: 9801
		// (get) Token: 0x060078DE RID: 30942 RVA: 0x000E72E8 File Offset: 0x000E54E8
		// (set) Token: 0x060078DF RID: 30943 RVA: 0x000E7300 File Offset: 0x000E5500
		[ProtoMember(1, IsRequired = false, Name = "pk_info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PKInformation pk_info
		{
			get
			{
				return this._pk_info;
			}
			set
			{
				this._pk_info = value;
			}
		}

		// Token: 0x060078E0 RID: 30944 RVA: 0x000E730C File Offset: 0x000E550C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C8F RID: 7311
		private PKInformation _pk_info = null;

		// Token: 0x04001C90 RID: 7312
		private IExtension extensionObject;
	}
}
