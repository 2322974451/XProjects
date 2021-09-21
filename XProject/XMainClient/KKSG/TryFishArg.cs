using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200025F RID: 607
	[ProtoContract(Name = "TryFishArg")]
	[Serializable]
	public class TryFishArg : IExtensible
	{
		// Token: 0x17000A99 RID: 2713
		// (get) Token: 0x06002206 RID: 8710 RVA: 0x000428A8 File Offset: 0x00040AA8
		// (set) Token: 0x06002207 RID: 8711 RVA: 0x000428D4 File Offset: 0x00040AD4
		[ProtoMember(1, IsRequired = false, Name = "quest_type", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000A9A RID: 2714
		// (get) Token: 0x06002208 RID: 8712 RVA: 0x000428E4 File Offset: 0x00040AE4
		// (set) Token: 0x06002209 RID: 8713 RVA: 0x00042904 File Offset: 0x00040B04
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

		// Token: 0x0600220A RID: 8714 RVA: 0x00042948 File Offset: 0x00040B48
		private bool ShouldSerializequest_type()
		{
			return this.quest_typeSpecified;
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x00042960 File Offset: 0x00040B60
		private void Resetquest_type()
		{
			this.quest_typeSpecified = false;
		}

		// Token: 0x17000A9B RID: 2715
		// (get) Token: 0x0600220C RID: 8716 RVA: 0x0004296C File Offset: 0x00040B6C
		// (set) Token: 0x0600220D RID: 8717 RVA: 0x00042999 File Offset: 0x00040B99
		[ProtoMember(2, IsRequired = false, Name = "garden_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000A9C RID: 2716
		// (get) Token: 0x0600220E RID: 8718 RVA: 0x000429A8 File Offset: 0x00040BA8
		// (set) Token: 0x0600220F RID: 8719 RVA: 0x000429C8 File Offset: 0x00040BC8
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

		// Token: 0x06002210 RID: 8720 RVA: 0x00042A0C File Offset: 0x00040C0C
		private bool ShouldSerializegarden_id()
		{
			return this.garden_idSpecified;
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x00042A24 File Offset: 0x00040C24
		private void Resetgarden_id()
		{
			this.garden_idSpecified = false;
		}

		// Token: 0x17000A9D RID: 2717
		// (get) Token: 0x06002212 RID: 8722 RVA: 0x00042A30 File Offset: 0x00040C30
		// (set) Token: 0x06002213 RID: 8723 RVA: 0x00042A5C File Offset: 0x00040C5C
		[ProtoMember(3, IsRequired = false, Name = "casting_net", DataFormat = DataFormat.Default)]
		public bool casting_net
		{
			get
			{
				return this._casting_net ?? false;
			}
			set
			{
				this._casting_net = new bool?(value);
			}
		}

		// Token: 0x17000A9E RID: 2718
		// (get) Token: 0x06002214 RID: 8724 RVA: 0x00042A6C File Offset: 0x00040C6C
		// (set) Token: 0x06002215 RID: 8725 RVA: 0x00042A8C File Offset: 0x00040C8C
		[XmlIgnore]
		[Browsable(false)]
		public bool casting_netSpecified
		{
			get
			{
				return this._casting_net != null;
			}
			set
			{
				bool flag = value == (this._casting_net == null);
				if (flag)
				{
					this._casting_net = (value ? new bool?(this.casting_net) : null);
				}
			}
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x00042AD0 File Offset: 0x00040CD0
		private bool ShouldSerializecasting_net()
		{
			return this.casting_netSpecified;
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x00042AE8 File Offset: 0x00040CE8
		private void Resetcasting_net()
		{
			this.casting_netSpecified = false;
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x00042AF4 File Offset: 0x00040CF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000871 RID: 2161
		private GardenQuestType? _quest_type;

		// Token: 0x04000872 RID: 2162
		private ulong? _garden_id;

		// Token: 0x04000873 RID: 2163
		private bool? _casting_net;

		// Token: 0x04000874 RID: 2164
		private IExtension extensionObject;
	}
}
