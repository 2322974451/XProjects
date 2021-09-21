using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E0 RID: 736
	[ProtoContract(Name = "DelGuildInheritRes")]
	[Serializable]
	public class DelGuildInheritRes : IExtensible
	{
		// Token: 0x17000C95 RID: 3221
		// (get) Token: 0x0600287E RID: 10366 RVA: 0x0004EAC4 File Offset: 0x0004CCC4
		// (set) Token: 0x0600287F RID: 10367 RVA: 0x0004EAF0 File Offset: 0x0004CCF0
		[ProtoMember(1, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000C96 RID: 3222
		// (get) Token: 0x06002880 RID: 10368 RVA: 0x0004EB00 File Offset: 0x0004CD00
		// (set) Token: 0x06002881 RID: 10369 RVA: 0x0004EB20 File Offset: 0x0004CD20
		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		// Token: 0x06002882 RID: 10370 RVA: 0x0004EB64 File Offset: 0x0004CD64
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x06002883 RID: 10371 RVA: 0x0004EB7C File Offset: 0x0004CD7C
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x06002884 RID: 10372 RVA: 0x0004EB88 File Offset: 0x0004CD88
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A13 RID: 2579
		private ErrorCode? _errorCode;

		// Token: 0x04000A14 RID: 2580
		private IExtension extensionObject;
	}
}
