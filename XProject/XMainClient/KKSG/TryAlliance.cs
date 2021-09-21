using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000351 RID: 849
	[ProtoContract(Name = "TryAlliance")]
	[Serializable]
	public class TryAlliance : IExtensible
	{
		// Token: 0x17000E62 RID: 3682
		// (get) Token: 0x06002E60 RID: 11872 RVA: 0x00059A20 File Offset: 0x00057C20
		// (set) Token: 0x06002E61 RID: 11873 RVA: 0x00059A4C File Offset: 0x00057C4C
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

		// Token: 0x17000E63 RID: 3683
		// (get) Token: 0x06002E62 RID: 11874 RVA: 0x00059A5C File Offset: 0x00057C5C
		// (set) Token: 0x06002E63 RID: 11875 RVA: 0x00059A7C File Offset: 0x00057C7C
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

		// Token: 0x06002E64 RID: 11876 RVA: 0x00059AC0 File Offset: 0x00057CC0
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002E65 RID: 11877 RVA: 0x00059AD8 File Offset: 0x00057CD8
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06002E66 RID: 11878 RVA: 0x00059AE4 File Offset: 0x00057CE4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B87 RID: 2951
		private ErrorCode? _errorcode;

		// Token: 0x04000B88 RID: 2952
		private IExtension extensionObject;
	}
}
