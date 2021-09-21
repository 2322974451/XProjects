using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000085 RID: 133
	[ProtoContract(Name = "FetchGuildListRes")]
	[Serializable]
	public class FetchGuildListRes : IExtensible
	{
		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060008CD RID: 2253 RVA: 0x00013644 File Offset: 0x00011844
		[ProtoMember(1, Name = "guilds", DataFormat = DataFormat.Default)]
		public List<GuildInfo> guilds
		{
			get
			{
				return this._guilds;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x0001365C File Offset: 0x0001185C
		// (set) Token: 0x060008CF RID: 2255 RVA: 0x00013688 File Offset: 0x00011888
		[ProtoMember(2, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x00013698 File Offset: 0x00011898
		// (set) Token: 0x060008D1 RID: 2257 RVA: 0x000136B8 File Offset: 0x000118B8
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

		// Token: 0x060008D2 RID: 2258 RVA: 0x000136FC File Offset: 0x000118FC
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00013714 File Offset: 0x00011914
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00013720 File Offset: 0x00011920
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000245 RID: 581
		private readonly List<GuildInfo> _guilds = new List<GuildInfo>();

		// Token: 0x04000246 RID: 582
		private ErrorCode? _errorcode;

		// Token: 0x04000247 RID: 583
		private IExtension extensionObject;
	}
}
