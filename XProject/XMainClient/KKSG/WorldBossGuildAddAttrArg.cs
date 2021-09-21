using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C6 RID: 966
	[ProtoContract(Name = "WorldBossGuildAddAttrArg")]
	[Serializable]
	public class WorldBossGuildAddAttrArg : IExtensible
	{
		// Token: 0x17000FDE RID: 4062
		// (get) Token: 0x06003382 RID: 13186 RVA: 0x00062E34 File Offset: 0x00061034
		// (set) Token: 0x06003383 RID: 13187 RVA: 0x00062E60 File Offset: 0x00061060
		[ProtoMember(1, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17000FDF RID: 4063
		// (get) Token: 0x06003384 RID: 13188 RVA: 0x00062E70 File Offset: 0x00061070
		// (set) Token: 0x06003385 RID: 13189 RVA: 0x00062E90 File Offset: 0x00061090
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06003386 RID: 13190 RVA: 0x00062ED4 File Offset: 0x000610D4
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06003387 RID: 13191 RVA: 0x00062EEC File Offset: 0x000610EC
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06003388 RID: 13192 RVA: 0x00062EF8 File Offset: 0x000610F8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CCE RID: 3278
		private uint? _count;

		// Token: 0x04000CCF RID: 3279
		private IExtension extensionObject;
	}
}
