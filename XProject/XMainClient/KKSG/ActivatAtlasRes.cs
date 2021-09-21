using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001FA RID: 506
	[ProtoContract(Name = "ActivatAtlasRes")]
	[Serializable]
	public class ActivatAtlasRes : IExtensible
	{
		// Token: 0x17000902 RID: 2306
		// (get) Token: 0x06001CC8 RID: 7368 RVA: 0x00038B18 File Offset: 0x00036D18
		// (set) Token: 0x06001CC9 RID: 7369 RVA: 0x00038B44 File Offset: 0x00036D44
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

		// Token: 0x17000903 RID: 2307
		// (get) Token: 0x06001CCA RID: 7370 RVA: 0x00038B54 File Offset: 0x00036D54
		// (set) Token: 0x06001CCB RID: 7371 RVA: 0x00038B74 File Offset: 0x00036D74
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

		// Token: 0x06001CCC RID: 7372 RVA: 0x00038BB8 File Offset: 0x00036DB8
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001CCD RID: 7373 RVA: 0x00038BD0 File Offset: 0x00036DD0
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06001CCE RID: 7374 RVA: 0x00038BDC File Offset: 0x00036DDC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400072A RID: 1834
		private ErrorCode? _errorcode;

		// Token: 0x0400072B RID: 1835
		private IExtension extensionObject;
	}
}
