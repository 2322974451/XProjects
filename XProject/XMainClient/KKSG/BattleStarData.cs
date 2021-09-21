using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000699 RID: 1689
	[ProtoContract(Name = "BattleStarData")]
	[Serializable]
	public class BattleStarData : IExtensible
	{
		// Token: 0x170022C3 RID: 8899
		// (get) Token: 0x06006DD3 RID: 28115 RVA: 0x000D2264 File Offset: 0x000D0464
		// (set) Token: 0x06006DD4 RID: 28116 RVA: 0x000D2291 File Offset: 0x000D0491
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x170022C4 RID: 8900
		// (get) Token: 0x06006DD5 RID: 28117 RVA: 0x000D22A0 File Offset: 0x000D04A0
		// (set) Token: 0x06006DD6 RID: 28118 RVA: 0x000D22C0 File Offset: 0x000D04C0
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06006DD7 RID: 28119 RVA: 0x000D2304 File Offset: 0x000D0504
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06006DD8 RID: 28120 RVA: 0x000D231C File Offset: 0x000D051C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170022C5 RID: 8901
		// (get) Token: 0x06006DD9 RID: 28121 RVA: 0x000D2328 File Offset: 0x000D0528
		// (set) Token: 0x06006DDA RID: 28122 RVA: 0x000D2354 File Offset: 0x000D0554
		[ProtoMember(2, IsRequired = false, Name = "star", DataFormat = DataFormat.TwosComplement)]
		public uint star
		{
			get
			{
				return this._star ?? 0U;
			}
			set
			{
				this._star = new uint?(value);
			}
		}

		// Token: 0x170022C6 RID: 8902
		// (get) Token: 0x06006DDB RID: 28123 RVA: 0x000D2364 File Offset: 0x000D0564
		// (set) Token: 0x06006DDC RID: 28124 RVA: 0x000D2384 File Offset: 0x000D0584
		[XmlIgnore]
		[Browsable(false)]
		public bool starSpecified
		{
			get
			{
				return this._star != null;
			}
			set
			{
				bool flag = value == (this._star == null);
				if (flag)
				{
					this._star = (value ? new uint?(this.star) : null);
				}
			}
		}

		// Token: 0x06006DDD RID: 28125 RVA: 0x000D23C8 File Offset: 0x000D05C8
		private bool ShouldSerializestar()
		{
			return this.starSpecified;
		}

		// Token: 0x06006DDE RID: 28126 RVA: 0x000D23E0 File Offset: 0x000D05E0
		private void Resetstar()
		{
			this.starSpecified = false;
		}

		// Token: 0x06006DDF RID: 28127 RVA: 0x000D23EC File Offset: 0x000D05EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A4E RID: 6734
		private ulong? _roleid;

		// Token: 0x04001A4F RID: 6735
		private uint? _star;

		// Token: 0x04001A50 RID: 6736
		private IExtension extensionObject;
	}
}
