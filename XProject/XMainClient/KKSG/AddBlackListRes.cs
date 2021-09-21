using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000079 RID: 121
	[ProtoContract(Name = "AddBlackListRes")]
	[Serializable]
	public class AddBlackListRes : IExtensible
	{
		// Token: 0x17000296 RID: 662
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x00011D58 File Offset: 0x0000FF58
		// (set) Token: 0x060007FE RID: 2046 RVA: 0x00011D84 File Offset: 0x0000FF84
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

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x00011D94 File Offset: 0x0000FF94
		// (set) Token: 0x06000800 RID: 2048 RVA: 0x00011DB4 File Offset: 0x0000FFB4
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

		// Token: 0x06000801 RID: 2049 RVA: 0x00011DF8 File Offset: 0x0000FFF8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00011E10 File Offset: 0x00010010
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x00011E1C File Offset: 0x0001001C
		// (set) Token: 0x06000804 RID: 2052 RVA: 0x00011E34 File Offset: 0x00010034
		[ProtoMember(2, IsRequired = false, Name = "black", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Friend2Client black
		{
			get
			{
				return this._black;
			}
			set
			{
				this._black = value;
			}
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00011E40 File Offset: 0x00010040
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000204 RID: 516
		private ErrorCode? _errorcode;

		// Token: 0x04000205 RID: 517
		private Friend2Client _black = null;

		// Token: 0x04000206 RID: 518
		private IExtension extensionObject;
	}
}
