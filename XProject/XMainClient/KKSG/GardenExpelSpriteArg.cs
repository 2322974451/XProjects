using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000287 RID: 647
	[ProtoContract(Name = "GardenExpelSpriteArg")]
	[Serializable]
	public class GardenExpelSpriteArg : IExtensible
	{
		// Token: 0x17000B45 RID: 2885
		// (get) Token: 0x0600243F RID: 9279 RVA: 0x00046B7C File Offset: 0x00044D7C
		// (set) Token: 0x06002440 RID: 9280 RVA: 0x00046BA9 File Offset: 0x00044DA9
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

		// Token: 0x17000B46 RID: 2886
		// (get) Token: 0x06002441 RID: 9281 RVA: 0x00046BB8 File Offset: 0x00044DB8
		// (set) Token: 0x06002442 RID: 9282 RVA: 0x00046BD8 File Offset: 0x00044DD8
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

		// Token: 0x06002443 RID: 9283 RVA: 0x00046C1C File Offset: 0x00044E1C
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x06002444 RID: 9284 RVA: 0x00046C34 File Offset: 0x00044E34
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000B47 RID: 2887
		// (get) Token: 0x06002445 RID: 9285 RVA: 0x00046C40 File Offset: 0x00044E40
		// (set) Token: 0x06002446 RID: 9286 RVA: 0x00046C6C File Offset: 0x00044E6C
		[ProtoMember(2, IsRequired = false, Name = "sprite_id", DataFormat = DataFormat.TwosComplement)]
		public uint sprite_id
		{
			get
			{
				return this._sprite_id ?? 0U;
			}
			set
			{
				this._sprite_id = new uint?(value);
			}
		}

		// Token: 0x17000B48 RID: 2888
		// (get) Token: 0x06002447 RID: 9287 RVA: 0x00046C7C File Offset: 0x00044E7C
		// (set) Token: 0x06002448 RID: 9288 RVA: 0x00046C9C File Offset: 0x00044E9C
		[XmlIgnore]
		[Browsable(false)]
		public bool sprite_idSpecified
		{
			get
			{
				return this._sprite_id != null;
			}
			set
			{
				bool flag = value == (this._sprite_id == null);
				if (flag)
				{
					this._sprite_id = (value ? new uint?(this.sprite_id) : null);
				}
			}
		}

		// Token: 0x06002449 RID: 9289 RVA: 0x00046CE0 File Offset: 0x00044EE0
		private bool ShouldSerializesprite_id()
		{
			return this.sprite_idSpecified;
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x00046CF8 File Offset: 0x00044EF8
		private void Resetsprite_id()
		{
			this.sprite_idSpecified = false;
		}

		// Token: 0x17000B49 RID: 2889
		// (get) Token: 0x0600244B RID: 9291 RVA: 0x00046D04 File Offset: 0x00044F04
		// (set) Token: 0x0600244C RID: 9292 RVA: 0x00046D30 File Offset: 0x00044F30
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

		// Token: 0x17000B4A RID: 2890
		// (get) Token: 0x0600244D RID: 9293 RVA: 0x00046D40 File Offset: 0x00044F40
		// (set) Token: 0x0600244E RID: 9294 RVA: 0x00046D60 File Offset: 0x00044F60
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

		// Token: 0x0600244F RID: 9295 RVA: 0x00046DA4 File Offset: 0x00044FA4
		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		// Token: 0x06002450 RID: 9296 RVA: 0x00046DBC File Offset: 0x00044FBC
		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		// Token: 0x06002451 RID: 9297 RVA: 0x00046DC8 File Offset: 0x00044FC8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008F6 RID: 2294
		private ulong? _garden_id;

		// Token: 0x040008F7 RID: 2295
		private uint? _sprite_id;

		// Token: 0x040008F8 RID: 2296
		private GardenQuestType? _quest_type;

		// Token: 0x040008F9 RID: 2297
		private IExtension extensionObject;
	}
}
