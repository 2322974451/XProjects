using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000244 RID: 580
	[ProtoContract(Name = "GuildCardRankReq")]
	[Serializable]
	public class GuildCardRankReq : IExtensible
	{
		// Token: 0x17000A09 RID: 2569
		// (get) Token: 0x06002032 RID: 8242 RVA: 0x0003F140 File Offset: 0x0003D340
		// (set) Token: 0x06002033 RID: 8243 RVA: 0x0003F16C File Offset: 0x0003D36C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x17000A0A RID: 2570
		// (get) Token: 0x06002034 RID: 8244 RVA: 0x0003F17C File Offset: 0x0003D37C
		// (set) Token: 0x06002035 RID: 8245 RVA: 0x0003F19C File Offset: 0x0003D39C
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06002036 RID: 8246 RVA: 0x0003F1E0 File Offset: 0x0003D3E0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06002037 RID: 8247 RVA: 0x0003F1F8 File Offset: 0x0003D3F8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x06002038 RID: 8248 RVA: 0x0003F204 File Offset: 0x0003D404
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000809 RID: 2057
		private uint? _type;

		// Token: 0x0400080A RID: 2058
		private IExtension extensionObject;
	}
}
