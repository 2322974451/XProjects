using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002DB RID: 731
	[ProtoContract(Name = "AceptGuildInheritRes")]
	[Serializable]
	public class AceptGuildInheritRes : IExtensible
	{
		// Token: 0x17000C84 RID: 3204
		// (get) Token: 0x06002843 RID: 10307 RVA: 0x0004E3D8 File Offset: 0x0004C5D8
		// (set) Token: 0x06002844 RID: 10308 RVA: 0x0004E404 File Offset: 0x0004C604
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

		// Token: 0x17000C85 RID: 3205
		// (get) Token: 0x06002845 RID: 10309 RVA: 0x0004E414 File Offset: 0x0004C614
		// (set) Token: 0x06002846 RID: 10310 RVA: 0x0004E434 File Offset: 0x0004C634
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

		// Token: 0x06002847 RID: 10311 RVA: 0x0004E478 File Offset: 0x0004C678
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002848 RID: 10312 RVA: 0x0004E490 File Offset: 0x0004C690
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06002849 RID: 10313 RVA: 0x0004E49C File Offset: 0x0004C69C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A05 RID: 2565
		private ErrorCode? _errorcode;

		// Token: 0x04000A06 RID: 2566
		private IExtension extensionObject;
	}
}
