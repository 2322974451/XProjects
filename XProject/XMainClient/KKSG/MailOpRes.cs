using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000101 RID: 257
	[ProtoContract(Name = "MailOpRes")]
	[Serializable]
	public class MailOpRes : IExtensible
	{
		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06001084 RID: 4228 RVA: 0x00021E04 File Offset: 0x00020004
		// (set) Token: 0x06001085 RID: 4229 RVA: 0x00021E30 File Offset: 0x00020030
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

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06001086 RID: 4230 RVA: 0x00021E40 File Offset: 0x00020040
		// (set) Token: 0x06001087 RID: 4231 RVA: 0x00021E60 File Offset: 0x00020060
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

		// Token: 0x06001088 RID: 4232 RVA: 0x00021EA4 File Offset: 0x000200A4
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x00021EBC File Offset: 0x000200BC
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x0600108A RID: 4234 RVA: 0x00021EC8 File Offset: 0x000200C8
		[ProtoMember(2, Name = "expireuid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> expireuid
		{
			get
			{
				return this._expireuid;
			}
		}

		// Token: 0x0600108B RID: 4235 RVA: 0x00021EE0 File Offset: 0x000200E0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000421 RID: 1057
		private ErrorCode? _errorcode;

		// Token: 0x04000422 RID: 1058
		private readonly List<ulong> _expireuid = new List<ulong>();

		// Token: 0x04000423 RID: 1059
		private IExtension extensionObject;
	}
}
