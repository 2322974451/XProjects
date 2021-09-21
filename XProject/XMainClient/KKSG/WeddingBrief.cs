using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000724 RID: 1828
	[ProtoContract(Name = "WeddingBrief")]
	[Serializable]
	public class WeddingBrief : IExtensible
	{
		// Token: 0x170027E6 RID: 10214
		// (get) Token: 0x06007DD9 RID: 32217 RVA: 0x000F0AAC File Offset: 0x000EECAC
		// (set) Token: 0x06007DDA RID: 32218 RVA: 0x000F0AD9 File Offset: 0x000EECD9
		[ProtoMember(1, IsRequired = false, Name = "weddingid", DataFormat = DataFormat.TwosComplement)]
		public ulong weddingid
		{
			get
			{
				return this._weddingid ?? 0UL;
			}
			set
			{
				this._weddingid = new ulong?(value);
			}
		}

		// Token: 0x170027E7 RID: 10215
		// (get) Token: 0x06007DDB RID: 32219 RVA: 0x000F0AE8 File Offset: 0x000EECE8
		// (set) Token: 0x06007DDC RID: 32220 RVA: 0x000F0B08 File Offset: 0x000EED08
		[XmlIgnore]
		[Browsable(false)]
		public bool weddingidSpecified
		{
			get
			{
				return this._weddingid != null;
			}
			set
			{
				bool flag = value == (this._weddingid == null);
				if (flag)
				{
					this._weddingid = (value ? new ulong?(this.weddingid) : null);
				}
			}
		}

		// Token: 0x06007DDD RID: 32221 RVA: 0x000F0B4C File Offset: 0x000EED4C
		private bool ShouldSerializeweddingid()
		{
			return this.weddingidSpecified;
		}

		// Token: 0x06007DDE RID: 32222 RVA: 0x000F0B64 File Offset: 0x000EED64
		private void Resetweddingid()
		{
			this.weddingidSpecified = false;
		}

		// Token: 0x170027E8 RID: 10216
		// (get) Token: 0x06007DDF RID: 32223 RVA: 0x000F0B70 File Offset: 0x000EED70
		// (set) Token: 0x06007DE0 RID: 32224 RVA: 0x000F0B9C File Offset: 0x000EED9C
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingType type
		{
			get
			{
				return this._type ?? WeddingType.WeddingType_Normal;
			}
			set
			{
				this._type = new WeddingType?(value);
			}
		}

		// Token: 0x170027E9 RID: 10217
		// (get) Token: 0x06007DE1 RID: 32225 RVA: 0x000F0BAC File Offset: 0x000EEDAC
		// (set) Token: 0x06007DE2 RID: 32226 RVA: 0x000F0BCC File Offset: 0x000EEDCC
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
					this._type = (value ? new WeddingType?(this.type) : null);
				}
			}
		}

		// Token: 0x06007DE3 RID: 32227 RVA: 0x000F0C10 File Offset: 0x000EEE10
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06007DE4 RID: 32228 RVA: 0x000F0C28 File Offset: 0x000EEE28
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170027EA RID: 10218
		// (get) Token: 0x06007DE5 RID: 32229 RVA: 0x000F0C34 File Offset: 0x000EEE34
		// (set) Token: 0x06007DE6 RID: 32230 RVA: 0x000F0C4C File Offset: 0x000EEE4C
		[ProtoMember(3, IsRequired = false, Name = "role1", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingRoleBrief role1
		{
			get
			{
				return this._role1;
			}
			set
			{
				this._role1 = value;
			}
		}

		// Token: 0x170027EB RID: 10219
		// (get) Token: 0x06007DE7 RID: 32231 RVA: 0x000F0C58 File Offset: 0x000EEE58
		// (set) Token: 0x06007DE8 RID: 32232 RVA: 0x000F0C70 File Offset: 0x000EEE70
		[ProtoMember(4, IsRequired = false, Name = "role2", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public WeddingRoleBrief role2
		{
			get
			{
				return this._role2;
			}
			set
			{
				this._role2 = value;
			}
		}

		// Token: 0x170027EC RID: 10220
		// (get) Token: 0x06007DE9 RID: 32233 RVA: 0x000F0C7C File Offset: 0x000EEE7C
		// (set) Token: 0x06007DEA RID: 32234 RVA: 0x000F0CA8 File Offset: 0x000EEEA8
		[ProtoMember(5, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public WeddingState state
		{
			get
			{
				return this._state ?? WeddingState.WeddingState_Prepare;
			}
			set
			{
				this._state = new WeddingState?(value);
			}
		}

		// Token: 0x170027ED RID: 10221
		// (get) Token: 0x06007DEB RID: 32235 RVA: 0x000F0CB8 File Offset: 0x000EEEB8
		// (set) Token: 0x06007DEC RID: 32236 RVA: 0x000F0CD8 File Offset: 0x000EEED8
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new WeddingState?(this.state) : null);
				}
			}
		}

		// Token: 0x06007DED RID: 32237 RVA: 0x000F0D1C File Offset: 0x000EEF1C
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06007DEE RID: 32238 RVA: 0x000F0D34 File Offset: 0x000EEF34
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170027EE RID: 10222
		// (get) Token: 0x06007DEF RID: 32239 RVA: 0x000F0D40 File Offset: 0x000EEF40
		// (set) Token: 0x06007DF0 RID: 32240 RVA: 0x000F0D6C File Offset: 0x000EEF6C
		[ProtoMember(6, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x170027EF RID: 10223
		// (get) Token: 0x06007DF1 RID: 32241 RVA: 0x000F0D7C File Offset: 0x000EEF7C
		// (set) Token: 0x06007DF2 RID: 32242 RVA: 0x000F0D9C File Offset: 0x000EEF9C
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x06007DF3 RID: 32243 RVA: 0x000F0DE0 File Offset: 0x000EEFE0
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06007DF4 RID: 32244 RVA: 0x000F0DF8 File Offset: 0x000EEFF8
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x06007DF5 RID: 32245 RVA: 0x000F0E04 File Offset: 0x000EF004
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D93 RID: 7571
		private ulong? _weddingid;

		// Token: 0x04001D94 RID: 7572
		private WeddingType? _type;

		// Token: 0x04001D95 RID: 7573
		private WeddingRoleBrief _role1 = null;

		// Token: 0x04001D96 RID: 7574
		private WeddingRoleBrief _role2 = null;

		// Token: 0x04001D97 RID: 7575
		private WeddingState? _state;

		// Token: 0x04001D98 RID: 7576
		private uint? _lefttime;

		// Token: 0x04001D99 RID: 7577
		private IExtension extensionObject;
	}
}
