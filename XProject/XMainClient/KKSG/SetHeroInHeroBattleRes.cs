using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200035E RID: 862
	[ProtoContract(Name = "SetHeroInHeroBattleRes")]
	[Serializable]
	public class SetHeroInHeroBattleRes : IExtensible
	{
		// Token: 0x17000E9D RID: 3741
		// (get) Token: 0x06002F2A RID: 12074 RVA: 0x0005B0E8 File Offset: 0x000592E8
		// (set) Token: 0x06002F2B RID: 12075 RVA: 0x0005B114 File Offset: 0x00059314
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

		// Token: 0x17000E9E RID: 3742
		// (get) Token: 0x06002F2C RID: 12076 RVA: 0x0005B124 File Offset: 0x00059324
		// (set) Token: 0x06002F2D RID: 12077 RVA: 0x0005B144 File Offset: 0x00059344
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

		// Token: 0x06002F2E RID: 12078 RVA: 0x0005B188 File Offset: 0x00059388
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002F2F RID: 12079 RVA: 0x0005B1A0 File Offset: 0x000593A0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06002F30 RID: 12080 RVA: 0x0005B1AC File Offset: 0x000593AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BB2 RID: 2994
		private ErrorCode? _errorcode;

		// Token: 0x04000BB3 RID: 2995
		private IExtension extensionObject;
	}
}
