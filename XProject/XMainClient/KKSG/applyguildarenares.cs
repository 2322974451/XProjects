using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002B2 RID: 690
	[ProtoContract(Name = "applyguildarenares")]
	[Serializable]
	public class applyguildarenares : IExtensible
	{
		// Token: 0x17000BF7 RID: 3063
		// (get) Token: 0x06002674 RID: 9844 RVA: 0x0004AD60 File Offset: 0x00048F60
		// (set) Token: 0x06002675 RID: 9845 RVA: 0x0004AD8C File Offset: 0x00048F8C
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

		// Token: 0x17000BF8 RID: 3064
		// (get) Token: 0x06002676 RID: 9846 RVA: 0x0004AD9C File Offset: 0x00048F9C
		// (set) Token: 0x06002677 RID: 9847 RVA: 0x0004ADBC File Offset: 0x00048FBC
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

		// Token: 0x06002678 RID: 9848 RVA: 0x0004AE00 File Offset: 0x00049000
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002679 RID: 9849 RVA: 0x0004AE18 File Offset: 0x00049018
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x0600267A RID: 9850 RVA: 0x0004AE24 File Offset: 0x00049024
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400098B RID: 2443
		private ErrorCode? _errorcode;

		// Token: 0x0400098C RID: 2444
		private IExtension extensionObject;
	}
}
