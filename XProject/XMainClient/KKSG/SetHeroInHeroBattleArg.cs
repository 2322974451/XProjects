using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200035D RID: 861
	[ProtoContract(Name = "SetHeroInHeroBattleArg")]
	[Serializable]
	public class SetHeroInHeroBattleArg : IExtensible
	{
		// Token: 0x17000E9B RID: 3739
		// (get) Token: 0x06002F22 RID: 12066 RVA: 0x0005B004 File Offset: 0x00059204
		// (set) Token: 0x06002F23 RID: 12067 RVA: 0x0005B030 File Offset: 0x00059230
		[ProtoMember(1, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		// Token: 0x17000E9C RID: 3740
		// (get) Token: 0x06002F24 RID: 12068 RVA: 0x0005B040 File Offset: 0x00059240
		// (set) Token: 0x06002F25 RID: 12069 RVA: 0x0005B060 File Offset: 0x00059260
		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		// Token: 0x06002F26 RID: 12070 RVA: 0x0005B0A4 File Offset: 0x000592A4
		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		// Token: 0x06002F27 RID: 12071 RVA: 0x0005B0BC File Offset: 0x000592BC
		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		// Token: 0x06002F28 RID: 12072 RVA: 0x0005B0C8 File Offset: 0x000592C8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BB0 RID: 2992
		private uint? _heroid;

		// Token: 0x04000BB1 RID: 2993
		private IExtension extensionObject;
	}
}
