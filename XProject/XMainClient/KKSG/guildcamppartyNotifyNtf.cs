using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F1 RID: 1009
	[ProtoContract(Name = "guildcamppartyNotifyNtf")]
	[Serializable]
	public class guildcamppartyNotifyNtf : IExtensible
	{
		// Token: 0x17001074 RID: 4212
		// (get) Token: 0x06003583 RID: 13699 RVA: 0x000668C4 File Offset: 0x00064AC4
		// (set) Token: 0x06003584 RID: 13700 RVA: 0x000668F0 File Offset: 0x00064AF0
		[ProtoMember(1, IsRequired = false, Name = "notify_type", DataFormat = DataFormat.TwosComplement)]
		public uint notify_type
		{
			get
			{
				return this._notify_type ?? 0U;
			}
			set
			{
				this._notify_type = new uint?(value);
			}
		}

		// Token: 0x17001075 RID: 4213
		// (get) Token: 0x06003585 RID: 13701 RVA: 0x00066900 File Offset: 0x00064B00
		// (set) Token: 0x06003586 RID: 13702 RVA: 0x00066920 File Offset: 0x00064B20
		[XmlIgnore]
		[Browsable(false)]
		public bool notify_typeSpecified
		{
			get
			{
				return this._notify_type != null;
			}
			set
			{
				bool flag = value == (this._notify_type == null);
				if (flag)
				{
					this._notify_type = (value ? new uint?(this.notify_type) : null);
				}
			}
		}

		// Token: 0x06003587 RID: 13703 RVA: 0x00066964 File Offset: 0x00064B64
		private bool ShouldSerializenotify_type()
		{
			return this.notify_typeSpecified;
		}

		// Token: 0x06003588 RID: 13704 RVA: 0x0006697C File Offset: 0x00064B7C
		private void Resetnotify_type()
		{
			this.notify_typeSpecified = false;
		}

		// Token: 0x17001076 RID: 4214
		// (get) Token: 0x06003589 RID: 13705 RVA: 0x00066988 File Offset: 0x00064B88
		[ProtoMember(2, Name = "sprite_list", DataFormat = DataFormat.Default)]
		public List<GuildCampSpriteInfo> sprite_list
		{
			get
			{
				return this._sprite_list;
			}
		}

		// Token: 0x17001077 RID: 4215
		// (get) Token: 0x0600358A RID: 13706 RVA: 0x000669A0 File Offset: 0x00064BA0
		[ProtoMember(3, Name = "lottery_list", DataFormat = DataFormat.TwosComplement)]
		public List<uint> lottery_list
		{
			get
			{
				return this._lottery_list;
			}
		}

		// Token: 0x17001078 RID: 4216
		// (get) Token: 0x0600358B RID: 13707 RVA: 0x000669B8 File Offset: 0x00064BB8
		// (set) Token: 0x0600358C RID: 13708 RVA: 0x000669E4 File Offset: 0x00064BE4
		[ProtoMember(4, IsRequired = false, Name = "left_time", DataFormat = DataFormat.TwosComplement)]
		public uint left_time
		{
			get
			{
				return this._left_time ?? 0U;
			}
			set
			{
				this._left_time = new uint?(value);
			}
		}

		// Token: 0x17001079 RID: 4217
		// (get) Token: 0x0600358D RID: 13709 RVA: 0x000669F4 File Offset: 0x00064BF4
		// (set) Token: 0x0600358E RID: 13710 RVA: 0x00066A14 File Offset: 0x00064C14
		[XmlIgnore]
		[Browsable(false)]
		public bool left_timeSpecified
		{
			get
			{
				return this._left_time != null;
			}
			set
			{
				bool flag = value == (this._left_time == null);
				if (flag)
				{
					this._left_time = (value ? new uint?(this.left_time) : null);
				}
			}
		}

		// Token: 0x0600358F RID: 13711 RVA: 0x00066A58 File Offset: 0x00064C58
		private bool ShouldSerializeleft_time()
		{
			return this.left_timeSpecified;
		}

		// Token: 0x06003590 RID: 13712 RVA: 0x00066A70 File Offset: 0x00064C70
		private void Resetleft_time()
		{
			this.left_timeSpecified = false;
		}

		// Token: 0x06003591 RID: 13713 RVA: 0x00066A7C File Offset: 0x00064C7C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D4B RID: 3403
		private uint? _notify_type;

		// Token: 0x04000D4C RID: 3404
		private readonly List<GuildCampSpriteInfo> _sprite_list = new List<GuildCampSpriteInfo>();

		// Token: 0x04000D4D RID: 3405
		private readonly List<uint> _lottery_list = new List<uint>();

		// Token: 0x04000D4E RID: 3406
		private uint? _left_time;

		// Token: 0x04000D4F RID: 3407
		private IExtension extensionObject;
	}
}
