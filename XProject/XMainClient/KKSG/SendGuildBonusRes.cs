using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200012F RID: 303
	[ProtoContract(Name = "SendGuildBonusRes")]
	[Serializable]
	public class SendGuildBonusRes : IExtensible
	{
		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x060012BA RID: 4794 RVA: 0x00025FC8 File Offset: 0x000241C8
		// (set) Token: 0x060012BB RID: 4795 RVA: 0x00025FF4 File Offset: 0x000241F4
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

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x060012BC RID: 4796 RVA: 0x00026004 File Offset: 0x00024204
		// (set) Token: 0x060012BD RID: 4797 RVA: 0x00026024 File Offset: 0x00024224
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

		// Token: 0x060012BE RID: 4798 RVA: 0x00026068 File Offset: 0x00024268
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060012BF RID: 4799 RVA: 0x00026080 File Offset: 0x00024280
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060012C0 RID: 4800 RVA: 0x0002608C File Offset: 0x0002428C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004AC RID: 1196
		private ErrorCode? _errorcode;

		// Token: 0x040004AD RID: 1197
		private IExtension extensionObject;
	}
}
