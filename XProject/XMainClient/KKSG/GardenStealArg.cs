using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000284 RID: 644
	[ProtoContract(Name = "GardenStealArg")]
	[Serializable]
	public class GardenStealArg : IExtensible
	{
		// Token: 0x17000B2D RID: 2861
		// (get) Token: 0x060023F4 RID: 9204 RVA: 0x000462F0 File Offset: 0x000444F0
		// (set) Token: 0x060023F5 RID: 9205 RVA: 0x0004631D File Offset: 0x0004451D
		[ProtoMember(1, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
		public ulong garden_id
		{
			get
			{
				return this._garden_id ?? 0UL;
			}
			set
			{
				this._garden_id = new ulong?(value);
			}
		}

		// Token: 0x17000B2E RID: 2862
		// (get) Token: 0x060023F6 RID: 9206 RVA: 0x0004632C File Offset: 0x0004452C
		// (set) Token: 0x060023F7 RID: 9207 RVA: 0x0004634C File Offset: 0x0004454C
		[XmlIgnore]
		[Browsable(false)]
		public bool garden_idSpecified
		{
			get
			{
				return this._garden_id != null;
			}
			set
			{
				bool flag = value == (this._garden_id == null);
				if (flag)
				{
					this._garden_id = (value ? new ulong?(this.garden_id) : null);
				}
			}
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x00046390 File Offset: 0x00044590
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x000463A8 File Offset: 0x000445A8
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000B2F RID: 2863
		// (get) Token: 0x060023FA RID: 9210 RVA: 0x000463B4 File Offset: 0x000445B4
		// (set) Token: 0x060023FB RID: 9211 RVA: 0x000463E0 File Offset: 0x000445E0
		[ProtoMember(2, IsRequired = false, Name = "farmland_id", DataFormat = DataFormat.TwosComplement)]
		public uint farmland_id
		{
			get
			{
				return this._farmland_id ?? 0U;
			}
			set
			{
				this._farmland_id = new uint?(value);
			}
		}

		// Token: 0x17000B30 RID: 2864
		// (get) Token: 0x060023FC RID: 9212 RVA: 0x000463F0 File Offset: 0x000445F0
		// (set) Token: 0x060023FD RID: 9213 RVA: 0x00046410 File Offset: 0x00044610
		[XmlIgnore]
		[Browsable(false)]
		public bool farmland_idSpecified
		{
			get
			{
				return this._farmland_id != null;
			}
			set
			{
				bool flag = value == (this._farmland_id == null);
				if (flag)
				{
					this._farmland_id = (value ? new uint?(this.farmland_id) : null);
				}
			}
		}

		// Token: 0x060023FE RID: 9214 RVA: 0x00046454 File Offset: 0x00044654
		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		// Token: 0x060023FF RID: 9215 RVA: 0x0004646C File Offset: 0x0004466C
		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		// Token: 0x17000B31 RID: 2865
		// (get) Token: 0x06002400 RID: 9216 RVA: 0x00046478 File Offset: 0x00044678
		// (set) Token: 0x06002401 RID: 9217 RVA: 0x000464A4 File Offset: 0x000446A4
		[ProtoMember(3, IsRequired = false, Name = "quest_type", DataFormat = DataFormat.TwosComplement)]
		public GardenQuestType quest_type
		{
			get
			{
				return this._quest_type ?? GardenQuestType.MYSELF;
			}
			set
			{
				this._quest_type = new GardenQuestType?(value);
			}
		}

		// Token: 0x17000B32 RID: 2866
		// (get) Token: 0x06002402 RID: 9218 RVA: 0x000464B4 File Offset: 0x000446B4
		// (set) Token: 0x06002403 RID: 9219 RVA: 0x000464D4 File Offset: 0x000446D4
		[XmlIgnore]
		[Browsable(false)]
		public bool quest_typeSpecified
		{
			get
			{
				return this._quest_type != null;
			}
			set
			{
				bool flag = value == (this._quest_type == null);
				if (flag)
				{
					this._quest_type = (value ? new GardenQuestType?(this.quest_type) : null);
				}
			}
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x00046518 File Offset: 0x00044718
		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		// Token: 0x06002405 RID: 9221 RVA: 0x00046530 File Offset: 0x00044730
		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		// Token: 0x06002406 RID: 9222 RVA: 0x0004653C File Offset: 0x0004473C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008E6 RID: 2278
		private ulong? _garden_id;

		// Token: 0x040008E7 RID: 2279
		private uint? _farmland_id;

		// Token: 0x040008E8 RID: 2280
		private GardenQuestType? _quest_type;

		// Token: 0x040008E9 RID: 2281
		private IExtension extensionObject;
	}
}
