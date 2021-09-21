using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200034A RID: 842
	[ProtoContract(Name = "AllianceGuildTerrRes")]
	[Serializable]
	public class AllianceGuildTerrRes : IExtensible
	{
		// Token: 0x17000E44 RID: 3652
		// (get) Token: 0x06002DFC RID: 11772 RVA: 0x00058F28 File Offset: 0x00057128
		// (set) Token: 0x06002DFD RID: 11773 RVA: 0x00058F54 File Offset: 0x00057154
		[ProtoMember(1, IsRequired = false, Name = "errorcod", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcod
		{
			get
			{
				return this._errorcod ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcod = new ErrorCode?(value);
			}
		}

		// Token: 0x17000E45 RID: 3653
		// (get) Token: 0x06002DFE RID: 11774 RVA: 0x00058F64 File Offset: 0x00057164
		// (set) Token: 0x06002DFF RID: 11775 RVA: 0x00058F84 File Offset: 0x00057184
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodSpecified
		{
			get
			{
				return this._errorcod != null;
			}
			set
			{
				bool flag = value == (this._errorcod == null);
				if (flag)
				{
					this._errorcod = (value ? new ErrorCode?(this.errorcod) : null);
				}
			}
		}

		// Token: 0x06002E00 RID: 11776 RVA: 0x00058FC8 File Offset: 0x000571C8
		private bool ShouldSerializeerrorcod()
		{
			return this.errorcodSpecified;
		}

		// Token: 0x06002E01 RID: 11777 RVA: 0x00058FE0 File Offset: 0x000571E0
		private void Reseterrorcod()
		{
			this.errorcodSpecified = false;
		}

		// Token: 0x06002E02 RID: 11778 RVA: 0x00058FEC File Offset: 0x000571EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B70 RID: 2928
		private ErrorCode? _errorcod;

		// Token: 0x04000B71 RID: 2929
		private IExtension extensionObject;
	}
}
