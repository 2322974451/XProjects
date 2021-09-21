using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002C8 RID: 712
	[ProtoContract(Name = "JustDanceRes")]
	[Serializable]
	public class JustDanceRes : IExtensible
	{
		// Token: 0x17000C3A RID: 3130
		// (get) Token: 0x06002753 RID: 10067 RVA: 0x0004C750 File Offset: 0x0004A950
		// (set) Token: 0x06002754 RID: 10068 RVA: 0x0004C77C File Offset: 0x0004A97C
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

		// Token: 0x17000C3B RID: 3131
		// (get) Token: 0x06002755 RID: 10069 RVA: 0x0004C78C File Offset: 0x0004A98C
		// (set) Token: 0x06002756 RID: 10070 RVA: 0x0004C7AC File Offset: 0x0004A9AC
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

		// Token: 0x06002757 RID: 10071 RVA: 0x0004C7F0 File Offset: 0x0004A9F0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002758 RID: 10072 RVA: 0x0004C808 File Offset: 0x0004AA08
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06002759 RID: 10073 RVA: 0x0004C814 File Offset: 0x0004AA14
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009C8 RID: 2504
		private ErrorCode? _errorcode;

		// Token: 0x040009C9 RID: 2505
		private IExtension extensionObject;
	}
}
