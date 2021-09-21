using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000408 RID: 1032
	[ProtoContract(Name = "ChangeLiveVisibleRes")]
	[Serializable]
	public class ChangeLiveVisibleRes : IExtensible
	{
		// Token: 0x170010E6 RID: 4326
		// (get) Token: 0x060036F5 RID: 14069 RVA: 0x00069464 File Offset: 0x00067664
		// (set) Token: 0x060036F6 RID: 14070 RVA: 0x00069490 File Offset: 0x00067690
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

		// Token: 0x170010E7 RID: 4327
		// (get) Token: 0x060036F7 RID: 14071 RVA: 0x000694A0 File Offset: 0x000676A0
		// (set) Token: 0x060036F8 RID: 14072 RVA: 0x000694C0 File Offset: 0x000676C0
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

		// Token: 0x060036F9 RID: 14073 RVA: 0x00069504 File Offset: 0x00067704
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060036FA RID: 14074 RVA: 0x0006951C File Offset: 0x0006771C
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x060036FB RID: 14075 RVA: 0x00069528 File Offset: 0x00067728
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000DA0 RID: 3488
		private ErrorCode? _error;

		// Token: 0x04000DA1 RID: 3489
		private IExtension extensionObject;
	}
}
