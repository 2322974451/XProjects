using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200016B RID: 363
	[ProtoContract(Name = "IdentifyEmblemRes")]
	[Serializable]
	public class IdentifyEmblemRes : IExtensible
	{
		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x060015F0 RID: 5616 RVA: 0x0002C030 File Offset: 0x0002A230
		// (set) Token: 0x060015F1 RID: 5617 RVA: 0x0002C05C File Offset: 0x0002A25C
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x060015F2 RID: 5618 RVA: 0x0002C06C File Offset: 0x0002A26C
		// (set) Token: 0x060015F3 RID: 5619 RVA: 0x0002C08C File Offset: 0x0002A28C
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x0002C0D0 File Offset: 0x0002A2D0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x0002C0E8 File Offset: 0x0002A2E8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060015F6 RID: 5622 RVA: 0x0002C0F4 File Offset: 0x0002A2F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000573 RID: 1395
		private ErrorCode? _errorcode;

		// Token: 0x04000574 RID: 1396
		private IExtension extensionObject;
	}
}
