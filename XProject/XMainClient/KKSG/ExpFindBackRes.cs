using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000106 RID: 262
	[ProtoContract(Name = "ExpFindBackRes")]
	[Serializable]
	public class ExpFindBackRes : IExtensible
	{
		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x060010BA RID: 4282 RVA: 0x00022444 File Offset: 0x00020644
		// (set) Token: 0x060010BB RID: 4283 RVA: 0x00022470 File Offset: 0x00020670
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x060010BC RID: 4284 RVA: 0x00022480 File Offset: 0x00020680
		// (set) Token: 0x060010BD RID: 4285 RVA: 0x000224A0 File Offset: 0x000206A0
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x000224E4 File Offset: 0x000206E4
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x000224FC File Offset: 0x000206FC
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x00022508 File Offset: 0x00020708
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400042F RID: 1071
		private ErrorCode? _error;

		// Token: 0x04000430 RID: 1072
		private IExtension extensionObject;
	}
}
