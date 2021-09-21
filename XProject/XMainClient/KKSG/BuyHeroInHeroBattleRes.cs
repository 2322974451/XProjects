using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000369 RID: 873
	[ProtoContract(Name = "BuyHeroInHeroBattleRes")]
	[Serializable]
	public class BuyHeroInHeroBattleRes : IExtensible
	{
		// Token: 0x17000EB7 RID: 3767
		// (get) Token: 0x06002F8A RID: 12170 RVA: 0x0005BBD0 File Offset: 0x00059DD0
		// (set) Token: 0x06002F8B RID: 12171 RVA: 0x0005BBFC File Offset: 0x00059DFC
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

		// Token: 0x17000EB8 RID: 3768
		// (get) Token: 0x06002F8C RID: 12172 RVA: 0x0005BC0C File Offset: 0x00059E0C
		// (set) Token: 0x06002F8D RID: 12173 RVA: 0x0005BC2C File Offset: 0x00059E2C
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

		// Token: 0x06002F8E RID: 12174 RVA: 0x0005BC70 File Offset: 0x00059E70
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06002F8F RID: 12175 RVA: 0x0005BC88 File Offset: 0x00059E88
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06002F90 RID: 12176 RVA: 0x0005BC94 File Offset: 0x00059E94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BCB RID: 3019
		private ErrorCode? _errorcode;

		// Token: 0x04000BCC RID: 3020
		private IExtension extensionObject;
	}
}
