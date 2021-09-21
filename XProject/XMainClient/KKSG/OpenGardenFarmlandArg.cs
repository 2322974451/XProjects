using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200028E RID: 654
	[ProtoContract(Name = "OpenGardenFarmlandArg")]
	[Serializable]
	public class OpenGardenFarmlandArg : IExtensible
	{
		// Token: 0x17000B6A RID: 2922
		// (get) Token: 0x060024B6 RID: 9398 RVA: 0x000479B4 File Offset: 0x00045BB4
		// (set) Token: 0x060024B7 RID: 9399 RVA: 0x000479E1 File Offset: 0x00045BE1
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

		// Token: 0x17000B6B RID: 2923
		// (get) Token: 0x060024B8 RID: 9400 RVA: 0x000479F0 File Offset: 0x00045BF0
		// (set) Token: 0x060024B9 RID: 9401 RVA: 0x00047A10 File Offset: 0x00045C10
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

		// Token: 0x060024BA RID: 9402 RVA: 0x00047A54 File Offset: 0x00045C54
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x00047A6C File Offset: 0x00045C6C
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000B6C RID: 2924
		// (get) Token: 0x060024BC RID: 9404 RVA: 0x00047A78 File Offset: 0x00045C78
		// (set) Token: 0x060024BD RID: 9405 RVA: 0x00047AA4 File Offset: 0x00045CA4
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

		// Token: 0x17000B6D RID: 2925
		// (get) Token: 0x060024BE RID: 9406 RVA: 0x00047AB4 File Offset: 0x00045CB4
		// (set) Token: 0x060024BF RID: 9407 RVA: 0x00047AD4 File Offset: 0x00045CD4
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

		// Token: 0x060024C0 RID: 9408 RVA: 0x00047B18 File Offset: 0x00045D18
		private bool ShouldSerializefarmland_id()
		{
			return this.farmland_idSpecified;
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x00047B30 File Offset: 0x00045D30
		private void Resetfarmland_id()
		{
			this.farmland_idSpecified = false;
		}

		// Token: 0x17000B6E RID: 2926
		// (get) Token: 0x060024C2 RID: 9410 RVA: 0x00047B3C File Offset: 0x00045D3C
		// (set) Token: 0x060024C3 RID: 9411 RVA: 0x00047B68 File Offset: 0x00045D68
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

		// Token: 0x17000B6F RID: 2927
		// (get) Token: 0x060024C4 RID: 9412 RVA: 0x00047B78 File Offset: 0x00045D78
		// (set) Token: 0x060024C5 RID: 9413 RVA: 0x00047B98 File Offset: 0x00045D98
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

		// Token: 0x060024C6 RID: 9414 RVA: 0x00047BDC File Offset: 0x00045DDC
		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		// Token: 0x060024C7 RID: 9415 RVA: 0x00047BF4 File Offset: 0x00045DF4
		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		// Token: 0x060024C8 RID: 9416 RVA: 0x00047C00 File Offset: 0x00045E00
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000911 RID: 2321
		private ulong? _garden_id;

		// Token: 0x04000912 RID: 2322
		private uint? _farmland_id;

		// Token: 0x04000913 RID: 2323
		private GardenQuestType? _quest_type;

		// Token: 0x04000914 RID: 2324
		private IExtension extensionObject;
	}
}
