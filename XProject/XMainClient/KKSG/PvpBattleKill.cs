using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000140 RID: 320
	[ProtoContract(Name = "PvpBattleKill")]
	[Serializable]
	public class PvpBattleKill : IExtensible
	{
		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x060013BF RID: 5055 RVA: 0x00027E60 File Offset: 0x00026060
		// (set) Token: 0x060013C0 RID: 5056 RVA: 0x00027E8D File Offset: 0x0002608D
		[ProtoMember(1, IsRequired = false, Name = "killID", DataFormat = DataFormat.TwosComplement)]
		public ulong killID
		{
			get
			{
				return this._killID ?? 0UL;
			}
			set
			{
				this._killID = new ulong?(value);
			}
		}

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x060013C1 RID: 5057 RVA: 0x00027E9C File Offset: 0x0002609C
		// (set) Token: 0x060013C2 RID: 5058 RVA: 0x00027EBC File Offset: 0x000260BC
		[XmlIgnore]
		[Browsable(false)]
		public bool killIDSpecified
		{
			get
			{
				return this._killID != null;
			}
			set
			{
				bool flag = value == (this._killID == null);
				if (flag)
				{
					this._killID = (value ? new ulong?(this.killID) : null);
				}
			}
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x00027F00 File Offset: 0x00026100
		private bool ShouldSerializekillID()
		{
			return this.killIDSpecified;
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x00027F18 File Offset: 0x00026118
		private void ResetkillID()
		{
			this.killIDSpecified = false;
		}

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x060013C5 RID: 5061 RVA: 0x00027F24 File Offset: 0x00026124
		// (set) Token: 0x060013C6 RID: 5062 RVA: 0x00027F51 File Offset: 0x00026151
		[ProtoMember(2, IsRequired = false, Name = "deadID", DataFormat = DataFormat.TwosComplement)]
		public ulong deadID
		{
			get
			{
				return this._deadID ?? 0UL;
			}
			set
			{
				this._deadID = new ulong?(value);
			}
		}

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x060013C7 RID: 5063 RVA: 0x00027F60 File Offset: 0x00026160
		// (set) Token: 0x060013C8 RID: 5064 RVA: 0x00027F80 File Offset: 0x00026180
		[XmlIgnore]
		[Browsable(false)]
		public bool deadIDSpecified
		{
			get
			{
				return this._deadID != null;
			}
			set
			{
				bool flag = value == (this._deadID == null);
				if (flag)
				{
					this._deadID = (value ? new ulong?(this.deadID) : null);
				}
			}
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x00027FC4 File Offset: 0x000261C4
		private bool ShouldSerializedeadID()
		{
			return this.deadIDSpecified;
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x00027FDC File Offset: 0x000261DC
		private void ResetdeadID()
		{
			this.deadIDSpecified = false;
		}

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x060013CB RID: 5067 RVA: 0x00027FE8 File Offset: 0x000261E8
		// (set) Token: 0x060013CC RID: 5068 RVA: 0x00028014 File Offset: 0x00026214
		[ProtoMember(3, IsRequired = false, Name = "reviveTime", DataFormat = DataFormat.TwosComplement)]
		public uint reviveTime
		{
			get
			{
				return this._reviveTime ?? 0U;
			}
			set
			{
				this._reviveTime = new uint?(value);
			}
		}

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x060013CD RID: 5069 RVA: 0x00028024 File Offset: 0x00026224
		// (set) Token: 0x060013CE RID: 5070 RVA: 0x00028044 File Offset: 0x00026244
		[XmlIgnore]
		[Browsable(false)]
		public bool reviveTimeSpecified
		{
			get
			{
				return this._reviveTime != null;
			}
			set
			{
				bool flag = value == (this._reviveTime == null);
				if (flag)
				{
					this._reviveTime = (value ? new uint?(this.reviveTime) : null);
				}
			}
		}

		// Token: 0x060013CF RID: 5071 RVA: 0x00028088 File Offset: 0x00026288
		private bool ShouldSerializereviveTime()
		{
			return this.reviveTimeSpecified;
		}

		// Token: 0x060013D0 RID: 5072 RVA: 0x000280A0 File Offset: 0x000262A0
		private void ResetreviveTime()
		{
			this.reviveTimeSpecified = false;
		}

		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x060013D1 RID: 5073 RVA: 0x000280AC File Offset: 0x000262AC
		// (set) Token: 0x060013D2 RID: 5074 RVA: 0x000280D8 File Offset: 0x000262D8
		[ProtoMember(4, IsRequired = false, Name = "contiKillCount", DataFormat = DataFormat.TwosComplement)]
		public int contiKillCount
		{
			get
			{
				return this._contiKillCount ?? 0;
			}
			set
			{
				this._contiKillCount = new int?(value);
			}
		}

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x060013D3 RID: 5075 RVA: 0x000280E8 File Offset: 0x000262E8
		// (set) Token: 0x060013D4 RID: 5076 RVA: 0x00028108 File Offset: 0x00026308
		[XmlIgnore]
		[Browsable(false)]
		public bool contiKillCountSpecified
		{
			get
			{
				return this._contiKillCount != null;
			}
			set
			{
				bool flag = value == (this._contiKillCount == null);
				if (flag)
				{
					this._contiKillCount = (value ? new int?(this.contiKillCount) : null);
				}
			}
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x0002814C File Offset: 0x0002634C
		private bool ShouldSerializecontiKillCount()
		{
			return this.contiKillCountSpecified;
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x00028164 File Offset: 0x00026364
		private void ResetcontiKillCount()
		{
			this.contiKillCountSpecified = false;
		}

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x060013D7 RID: 5079 RVA: 0x00028170 File Offset: 0x00026370
		[ProtoMember(5, Name = "assitids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> assitids
		{
			get
			{
				return this._assitids;
			}
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x00028188 File Offset: 0x00026388
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004E5 RID: 1253
		private ulong? _killID;

		// Token: 0x040004E6 RID: 1254
		private ulong? _deadID;

		// Token: 0x040004E7 RID: 1255
		private uint? _reviveTime;

		// Token: 0x040004E8 RID: 1256
		private int? _contiKillCount;

		// Token: 0x040004E9 RID: 1257
		private readonly List<ulong> _assitids = new List<ulong>();

		// Token: 0x040004EA RID: 1258
		private IExtension extensionObject;
	}
}
