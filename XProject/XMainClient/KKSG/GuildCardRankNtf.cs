using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000245 RID: 581
	[ProtoContract(Name = "GuildCardRankNtf")]
	[Serializable]
	public class GuildCardRankNtf : IExtensible
	{
		// Token: 0x17000A0B RID: 2571
		// (get) Token: 0x0600203A RID: 8250 RVA: 0x0003F244 File Offset: 0x0003D444
		// (set) Token: 0x0600203B RID: 8251 RVA: 0x0003F270 File Offset: 0x0003D470
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

		// Token: 0x17000A0C RID: 2572
		// (get) Token: 0x0600203C RID: 8252 RVA: 0x0003F280 File Offset: 0x0003D480
		// (set) Token: 0x0600203D RID: 8253 RVA: 0x0003F2A0 File Offset: 0x0003D4A0
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

		// Token: 0x0600203E RID: 8254 RVA: 0x0003F2E4 File Offset: 0x0003D4E4
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600203F RID: 8255 RVA: 0x0003F2FC File Offset: 0x0003D4FC
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000A0D RID: 2573
		// (get) Token: 0x06002040 RID: 8256 RVA: 0x0003F308 File Offset: 0x0003D508
		[ProtoMember(2, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x17000A0E RID: 2574
		// (get) Token: 0x06002041 RID: 8257 RVA: 0x0003F320 File Offset: 0x0003D520
		[ProtoMember(3, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public List<int> point
		{
			get
			{
				return this._point;
			}
		}

		// Token: 0x06002042 RID: 8258 RVA: 0x0003F338 File Offset: 0x0003D538
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400080B RID: 2059
		private uint? _type;

		// Token: 0x0400080C RID: 2060
		private readonly List<string> _name = new List<string>();

		// Token: 0x0400080D RID: 2061
		private readonly List<int> _point = new List<int>();

		// Token: 0x0400080E RID: 2062
		private IExtension extensionObject;
	}
}
