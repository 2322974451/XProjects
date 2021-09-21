using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000229 RID: 553
	[ProtoContract(Name = "LearnGuildSkillRes")]
	[Serializable]
	public class LearnGuildSkillRes : IExtensible
	{
		// Token: 0x170009AB RID: 2475
		// (get) Token: 0x06001EF5 RID: 7925 RVA: 0x0003CC38 File Offset: 0x0003AE38
		// (set) Token: 0x06001EF6 RID: 7926 RVA: 0x0003CC64 File Offset: 0x0003AE64
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

		// Token: 0x170009AC RID: 2476
		// (get) Token: 0x06001EF7 RID: 7927 RVA: 0x0003CC74 File Offset: 0x0003AE74
		// (set) Token: 0x06001EF8 RID: 7928 RVA: 0x0003CC94 File Offset: 0x0003AE94
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

		// Token: 0x06001EF9 RID: 7929 RVA: 0x0003CCD8 File Offset: 0x0003AED8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001EFA RID: 7930 RVA: 0x0003CCF0 File Offset: 0x0003AEF0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001EFB RID: 7931 RVA: 0x0003CCFC File Offset: 0x0003AEFC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007BA RID: 1978
		private ErrorCode? _errorcode;

		// Token: 0x040007BB RID: 1979
		private IExtension extensionObject;
	}
}
