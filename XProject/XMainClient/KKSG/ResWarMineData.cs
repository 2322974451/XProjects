using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002E4 RID: 740
	[ProtoContract(Name = "ResWarMineData")]
	[Serializable]
	public class ResWarMineData : IExtensible
	{
		// Token: 0x17000CAB RID: 3243
		// (get) Token: 0x060028C8 RID: 10440 RVA: 0x0004F3B0 File Offset: 0x0004D5B0
		// (set) Token: 0x060028C9 RID: 10441 RVA: 0x0004F3DD File Offset: 0x0004D5DD
		[ProtoMember(1, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		// Token: 0x17000CAC RID: 3244
		// (get) Token: 0x060028CA RID: 10442 RVA: 0x0004F3EC File Offset: 0x0004D5EC
		// (set) Token: 0x060028CB RID: 10443 RVA: 0x0004F40C File Offset: 0x0004D60C
		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		// Token: 0x060028CC RID: 10444 RVA: 0x0004F450 File Offset: 0x0004D650
		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		// Token: 0x060028CD RID: 10445 RVA: 0x0004F468 File Offset: 0x0004D668
		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		// Token: 0x17000CAD RID: 3245
		// (get) Token: 0x060028CE RID: 10446 RVA: 0x0004F474 File Offset: 0x0004D674
		// (set) Token: 0x060028CF RID: 10447 RVA: 0x0004F4A0 File Offset: 0x0004D6A0
		[ProtoMember(2, IsRequired = false, Name = "mine", DataFormat = DataFormat.TwosComplement)]
		public uint mine
		{
			get
			{
				return this._mine ?? 0U;
			}
			set
			{
				this._mine = new uint?(value);
			}
		}

		// Token: 0x17000CAE RID: 3246
		// (get) Token: 0x060028D0 RID: 10448 RVA: 0x0004F4B0 File Offset: 0x0004D6B0
		// (set) Token: 0x060028D1 RID: 10449 RVA: 0x0004F4D0 File Offset: 0x0004D6D0
		[XmlIgnore]
		[Browsable(false)]
		public bool mineSpecified
		{
			get
			{
				return this._mine != null;
			}
			set
			{
				bool flag = value == (this._mine == null);
				if (flag)
				{
					this._mine = (value ? new uint?(this.mine) : null);
				}
			}
		}

		// Token: 0x060028D2 RID: 10450 RVA: 0x0004F514 File Offset: 0x0004D714
		private bool ShouldSerializemine()
		{
			return this.mineSpecified;
		}

		// Token: 0x060028D3 RID: 10451 RVA: 0x0004F52C File Offset: 0x0004D72C
		private void Resetmine()
		{
			this.mineSpecified = false;
		}

		// Token: 0x060028D4 RID: 10452 RVA: 0x0004F538 File Offset: 0x0004D738
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A22 RID: 2594
		private ulong? _guildid;

		// Token: 0x04000A23 RID: 2595
		private uint? _mine;

		// Token: 0x04000A24 RID: 2596
		private IExtension extensionObject;
	}
}
