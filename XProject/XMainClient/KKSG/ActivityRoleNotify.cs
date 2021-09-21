using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000047 RID: 71
	[ProtoContract(Name = "ActivityRoleNotify")]
	[Serializable]
	public class ActivityRoleNotify : IExtensible
	{
		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0000C19C File Offset: 0x0000A39C
		// (set) Token: 0x060004E8 RID: 1256 RVA: 0x0000C1B4 File Offset: 0x0000A3B4
		[ProtoMember(1, IsRequired = false, Name = "ActivityRecord", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ActivityRecord ActivityRecord
		{
			get
			{
				return this._ActivityRecord;
			}
			set
			{
				this._ActivityRecord = value;
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x0000C1C0 File Offset: 0x0000A3C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000142 RID: 322
		private ActivityRecord _ActivityRecord = null;

		// Token: 0x04000143 RID: 323
		private IExtension extensionObject;
	}
}
