using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200039C RID: 924
	[ProtoContract(Name = "ItemSellRes")]
	[Serializable]
	public class ItemSellRes : IExtensible
	{
		// Token: 0x17000F6E RID: 3950
		// (get) Token: 0x060031F1 RID: 12785 RVA: 0x000602C4 File Offset: 0x0005E4C4
		// (set) Token: 0x060031F2 RID: 12786 RVA: 0x000602F0 File Offset: 0x0005E4F0
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

		// Token: 0x17000F6F RID: 3951
		// (get) Token: 0x060031F3 RID: 12787 RVA: 0x00060300 File Offset: 0x0005E500
		// (set) Token: 0x060031F4 RID: 12788 RVA: 0x00060320 File Offset: 0x0005E520
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

		// Token: 0x060031F5 RID: 12789 RVA: 0x00060364 File Offset: 0x0005E564
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060031F6 RID: 12790 RVA: 0x0006037C File Offset: 0x0005E57C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060031F7 RID: 12791 RVA: 0x00060388 File Offset: 0x0005E588
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C65 RID: 3173
		private ErrorCode? _errorcode;

		// Token: 0x04000C66 RID: 3174
		private IExtension extensionObject;
	}
}
