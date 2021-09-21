using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200027A RID: 634
	[ProtoContract(Name = "GetLevelSealSelfGiftRes")]
	[Serializable]
	public class GetLevelSealSelfGiftRes : IExtensible
	{
		// Token: 0x17000AFE RID: 2814
		// (get) Token: 0x06002355 RID: 9045 RVA: 0x00044FE8 File Offset: 0x000431E8
		// (set) Token: 0x06002356 RID: 9046 RVA: 0x00045014 File Offset: 0x00043214
		[ProtoMember(1, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000AFF RID: 2815
		// (get) Token: 0x06002357 RID: 9047 RVA: 0x00045024 File Offset: 0x00043224
		// (set) Token: 0x06002358 RID: 9048 RVA: 0x00045044 File Offset: 0x00043244
		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		// Token: 0x06002359 RID: 9049 RVA: 0x00045088 File Offset: 0x00043288
		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		// Token: 0x0600235A RID: 9050 RVA: 0x000450A0 File Offset: 0x000432A0
		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		// Token: 0x0600235B RID: 9051 RVA: 0x000450AC File Offset: 0x000432AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008C4 RID: 2244
		private ErrorCode? _errcode;

		// Token: 0x040008C5 RID: 2245
		private IExtension extensionObject;
	}
}
