using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000193 RID: 403
	[ProtoContract(Name = "AdjustGuildArenaRolePosRes")]
	[Serializable]
	public class AdjustGuildArenaRolePosRes : IExtensible
	{
		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x06001845 RID: 6213 RVA: 0x00030610 File Offset: 0x0002E810
		// (set) Token: 0x06001846 RID: 6214 RVA: 0x0003063C File Offset: 0x0002E83C
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

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x06001847 RID: 6215 RVA: 0x0003064C File Offset: 0x0002E84C
		// (set) Token: 0x06001848 RID: 6216 RVA: 0x0003066C File Offset: 0x0002E86C
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

		// Token: 0x06001849 RID: 6217 RVA: 0x000306B0 File Offset: 0x0002E8B0
		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x000306C8 File Offset: 0x0002E8C8
		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x0600184B RID: 6219 RVA: 0x000306D4 File Offset: 0x0002E8D4
		[ProtoMember(2, Name = "fightunits", DataFormat = DataFormat.Default)]
		public List<GuildDarenaUnit> fightunits
		{
			get
			{
				return this._fightunits;
			}
		}

		// Token: 0x0600184C RID: 6220 RVA: 0x000306EC File Offset: 0x0002E8EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005FF RID: 1535
		private ErrorCode? _errorCode;

		// Token: 0x04000600 RID: 1536
		private readonly List<GuildDarenaUnit> _fightunits = new List<GuildDarenaUnit>();

		// Token: 0x04000601 RID: 1537
		private IExtension extensionObject;
	}
}
