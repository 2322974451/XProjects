using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000B9 RID: 185
	[ProtoContract(Name = "GetGuildBonusListResult")]
	[Serializable]
	public class GetGuildBonusListResult : IExtensible
	{
		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000C6C RID: 3180 RVA: 0x0001A350 File Offset: 0x00018550
		[ProtoMember(1, Name = "bonusList", DataFormat = DataFormat.Default)]
		public List<GuildBonusAppear> bonusList
		{
			get
			{
				return this._bonusList;
			}
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000C6D RID: 3181 RVA: 0x0001A368 File Offset: 0x00018568
		// (set) Token: 0x06000C6E RID: 3182 RVA: 0x0001A394 File Offset: 0x00018594
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

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06000C6F RID: 3183 RVA: 0x0001A3A4 File Offset: 0x000185A4
		// (set) Token: 0x06000C70 RID: 3184 RVA: 0x0001A3C4 File Offset: 0x000185C4
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

		// Token: 0x06000C71 RID: 3185 RVA: 0x0001A408 File Offset: 0x00018608
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x0001A420 File Offset: 0x00018620
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x0001A42C File Offset: 0x0001862C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000318 RID: 792
		private readonly List<GuildBonusAppear> _bonusList = new List<GuildBonusAppear>();

		// Token: 0x04000319 RID: 793
		private ErrorCode? _errorcode;

		// Token: 0x0400031A RID: 794
		private IExtension extensionObject;
	}
}
