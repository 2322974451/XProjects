using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000536 RID: 1334
	[ProtoContract(Name = "TryDanceRes")]
	[Serializable]
	public class TryDanceRes : IExtensible
	{
		// Token: 0x170014EF RID: 5359
		// (get) Token: 0x06004474 RID: 17524 RVA: 0x00082364 File Offset: 0x00080564
		// (set) Token: 0x06004475 RID: 17525 RVA: 0x00082390 File Offset: 0x00080590
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

		// Token: 0x170014F0 RID: 5360
		// (get) Token: 0x06004476 RID: 17526 RVA: 0x000823A0 File Offset: 0x000805A0
		// (set) Token: 0x06004477 RID: 17527 RVA: 0x000823C0 File Offset: 0x000805C0
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

		// Token: 0x06004478 RID: 17528 RVA: 0x00082404 File Offset: 0x00080604
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004479 RID: 17529 RVA: 0x0008241C File Offset: 0x0008061C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x0600447A RID: 17530 RVA: 0x00082428 File Offset: 0x00080628
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001118 RID: 4376
		private ErrorCode? _errorcode;

		// Token: 0x04001119 RID: 4377
		private IExtension extensionObject;
	}
}
