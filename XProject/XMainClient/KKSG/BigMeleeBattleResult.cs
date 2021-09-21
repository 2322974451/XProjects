using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005DD RID: 1501
	[ProtoContract(Name = "BigMeleeBattleResult")]
	[Serializable]
	public class BigMeleeBattleResult : IExtensible
	{
		// Token: 0x17001ADD RID: 6877
		// (get) Token: 0x06005687 RID: 22151 RVA: 0x000A4C2C File Offset: 0x000A2E2C
		// (set) Token: 0x06005688 RID: 22152 RVA: 0x000A4C59 File Offset: 0x000A2E59
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

		// Token: 0x17001ADE RID: 6878
		// (get) Token: 0x06005689 RID: 22153 RVA: 0x000A4C68 File Offset: 0x000A2E68
		// (set) Token: 0x0600568A RID: 22154 RVA: 0x000A4C88 File Offset: 0x000A2E88
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

		// Token: 0x0600568B RID: 22155 RVA: 0x000A4CCC File Offset: 0x000A2ECC
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600568C RID: 22156 RVA: 0x000A4CE4 File Offset: 0x000A2EE4
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x17001ADF RID: 6879
		// (get) Token: 0x0600568D RID: 22157 RVA: 0x000A4CF0 File Offset: 0x000A2EF0
		// (set) Token: 0x0600568E RID: 22158 RVA: 0x000A4D1C File Offset: 0x000A2F1C
		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x17001AE0 RID: 6880
		// (get) Token: 0x0600568F RID: 22159 RVA: 0x000A4D2C File Offset: 0x000A2F2C
		// (set) Token: 0x06005690 RID: 22160 RVA: 0x000A4D4C File Offset: 0x000A2F4C
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x06005691 RID: 22161 RVA: 0x000A4D90 File Offset: 0x000A2F90
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06005692 RID: 22162 RVA: 0x000A4DA8 File Offset: 0x000A2FA8
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17001AE1 RID: 6881
		// (get) Token: 0x06005693 RID: 22163 RVA: 0x000A4DB4 File Offset: 0x000A2FB4
		// (set) Token: 0x06005694 RID: 22164 RVA: 0x000A4DE0 File Offset: 0x000A2FE0
		[ProtoMember(3, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
		public uint score
		{
			get
			{
				return this._score ?? 0U;
			}
			set
			{
				this._score = new uint?(value);
			}
		}

		// Token: 0x17001AE2 RID: 6882
		// (get) Token: 0x06005695 RID: 22165 RVA: 0x000A4DF0 File Offset: 0x000A2FF0
		// (set) Token: 0x06005696 RID: 22166 RVA: 0x000A4E10 File Offset: 0x000A3010
		[XmlIgnore]
		[Browsable(false)]
		public bool scoreSpecified
		{
			get
			{
				return this._score != null;
			}
			set
			{
				bool flag = value == (this._score == null);
				if (flag)
				{
					this._score = (value ? new uint?(this.score) : null);
				}
			}
		}

		// Token: 0x06005697 RID: 22167 RVA: 0x000A4E54 File Offset: 0x000A3054
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06005698 RID: 22168 RVA: 0x000A4E6C File Offset: 0x000A306C
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x17001AE3 RID: 6883
		// (get) Token: 0x06005699 RID: 22169 RVA: 0x000A4E78 File Offset: 0x000A3078
		// (set) Token: 0x0600569A RID: 22170 RVA: 0x000A4EA4 File Offset: 0x000A30A4
		[ProtoMember(4, IsRequired = false, Name = "kill", DataFormat = DataFormat.TwosComplement)]
		public uint kill
		{
			get
			{
				return this._kill ?? 0U;
			}
			set
			{
				this._kill = new uint?(value);
			}
		}

		// Token: 0x17001AE4 RID: 6884
		// (get) Token: 0x0600569B RID: 22171 RVA: 0x000A4EB4 File Offset: 0x000A30B4
		// (set) Token: 0x0600569C RID: 22172 RVA: 0x000A4ED4 File Offset: 0x000A30D4
		[XmlIgnore]
		[Browsable(false)]
		public bool killSpecified
		{
			get
			{
				return this._kill != null;
			}
			set
			{
				bool flag = value == (this._kill == null);
				if (flag)
				{
					this._kill = (value ? new uint?(this.kill) : null);
				}
			}
		}

		// Token: 0x0600569D RID: 22173 RVA: 0x000A4F18 File Offset: 0x000A3118
		private bool ShouldSerializekill()
		{
			return this.killSpecified;
		}

		// Token: 0x0600569E RID: 22174 RVA: 0x000A4F30 File Offset: 0x000A3130
		private void Resetkill()
		{
			this.killSpecified = false;
		}

		// Token: 0x17001AE5 RID: 6885
		// (get) Token: 0x0600569F RID: 22175 RVA: 0x000A4F3C File Offset: 0x000A313C
		// (set) Token: 0x060056A0 RID: 22176 RVA: 0x000A4F68 File Offset: 0x000A3168
		[ProtoMember(5, IsRequired = false, Name = "death", DataFormat = DataFormat.TwosComplement)]
		public uint death
		{
			get
			{
				return this._death ?? 0U;
			}
			set
			{
				this._death = new uint?(value);
			}
		}

		// Token: 0x17001AE6 RID: 6886
		// (get) Token: 0x060056A1 RID: 22177 RVA: 0x000A4F78 File Offset: 0x000A3178
		// (set) Token: 0x060056A2 RID: 22178 RVA: 0x000A4F98 File Offset: 0x000A3198
		[XmlIgnore]
		[Browsable(false)]
		public bool deathSpecified
		{
			get
			{
				return this._death != null;
			}
			set
			{
				bool flag = value == (this._death == null);
				if (flag)
				{
					this._death = (value ? new uint?(this.death) : null);
				}
			}
		}

		// Token: 0x060056A3 RID: 22179 RVA: 0x000A4FDC File Offset: 0x000A31DC
		private bool ShouldSerializedeath()
		{
			return this.deathSpecified;
		}

		// Token: 0x060056A4 RID: 22180 RVA: 0x000A4FF4 File Offset: 0x000A31F4
		private void Resetdeath()
		{
			this.deathSpecified = false;
		}

		// Token: 0x17001AE7 RID: 6887
		// (get) Token: 0x060056A5 RID: 22181 RVA: 0x000A5000 File Offset: 0x000A3200
		[ProtoMember(6, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x060056A6 RID: 22182 RVA: 0x000A5018 File Offset: 0x000A3218
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400150B RID: 5387
		private ulong? _roleid;

		// Token: 0x0400150C RID: 5388
		private uint? _rank;

		// Token: 0x0400150D RID: 5389
		private uint? _score;

		// Token: 0x0400150E RID: 5390
		private uint? _kill;

		// Token: 0x0400150F RID: 5391
		private uint? _death;

		// Token: 0x04001510 RID: 5392
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x04001511 RID: 5393
		private IExtension extensionObject;
	}
}
