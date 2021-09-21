using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000712 RID: 1810
	[ProtoContract(Name = "SkyTeamDetail")]
	[Serializable]
	public class SkyTeamDetail : IExtensible
	{
		// Token: 0x170026F5 RID: 9973
		// (get) Token: 0x06007AEC RID: 31468 RVA: 0x000EAF90 File Offset: 0x000E9190
		// (set) Token: 0x06007AED RID: 31469 RVA: 0x000EAFBD File Offset: 0x000E91BD
		[ProtoMember(1, IsRequired = false, Name = "stid", DataFormat = DataFormat.TwosComplement)]
		public ulong stid
		{
			get
			{
				return this._stid ?? 0UL;
			}
			set
			{
				this._stid = new ulong?(value);
			}
		}

		// Token: 0x170026F6 RID: 9974
		// (get) Token: 0x06007AEE RID: 31470 RVA: 0x000EAFCC File Offset: 0x000E91CC
		// (set) Token: 0x06007AEF RID: 31471 RVA: 0x000EAFEC File Offset: 0x000E91EC
		[XmlIgnore]
		[Browsable(false)]
		public bool stidSpecified
		{
			get
			{
				return this._stid != null;
			}
			set
			{
				bool flag = value == (this._stid == null);
				if (flag)
				{
					this._stid = (value ? new ulong?(this.stid) : null);
				}
			}
		}

		// Token: 0x06007AF0 RID: 31472 RVA: 0x000EB030 File Offset: 0x000E9230
		private bool ShouldSerializestid()
		{
			return this.stidSpecified;
		}

		// Token: 0x06007AF1 RID: 31473 RVA: 0x000EB048 File Offset: 0x000E9248
		private void Resetstid()
		{
			this.stidSpecified = false;
		}

		// Token: 0x170026F7 RID: 9975
		// (get) Token: 0x06007AF2 RID: 31474 RVA: 0x000EB054 File Offset: 0x000E9254
		// (set) Token: 0x06007AF3 RID: 31475 RVA: 0x000EB075 File Offset: 0x000E9275
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170026F8 RID: 9976
		// (get) Token: 0x06007AF4 RID: 31476 RVA: 0x000EB080 File Offset: 0x000E9280
		// (set) Token: 0x06007AF5 RID: 31477 RVA: 0x000EB09C File Offset: 0x000E929C
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06007AF6 RID: 31478 RVA: 0x000EB0CC File Offset: 0x000E92CC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007AF7 RID: 31479 RVA: 0x000EB0E4 File Offset: 0x000E92E4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x170026F9 RID: 9977
		// (get) Token: 0x06007AF8 RID: 31480 RVA: 0x000EB0F0 File Offset: 0x000E92F0
		[ProtoMember(3, Name = "members", DataFormat = DataFormat.Default)]
		public List<SkyTeamMemberInfo> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x170026FA RID: 9978
		// (get) Token: 0x06007AF9 RID: 31481 RVA: 0x000EB108 File Offset: 0x000E9308
		// (set) Token: 0x06007AFA RID: 31482 RVA: 0x000EB134 File Offset: 0x000E9334
		[ProtoMember(4, IsRequired = false, Name = "score", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170026FB RID: 9979
		// (get) Token: 0x06007AFB RID: 31483 RVA: 0x000EB144 File Offset: 0x000E9344
		// (set) Token: 0x06007AFC RID: 31484 RVA: 0x000EB164 File Offset: 0x000E9364
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

		// Token: 0x06007AFD RID: 31485 RVA: 0x000EB1A8 File Offset: 0x000E93A8
		private bool ShouldSerializescore()
		{
			return this.scoreSpecified;
		}

		// Token: 0x06007AFE RID: 31486 RVA: 0x000EB1C0 File Offset: 0x000E93C0
		private void Resetscore()
		{
			this.scoreSpecified = false;
		}

		// Token: 0x06007AFF RID: 31487 RVA: 0x000EB1CC File Offset: 0x000E93CC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D06 RID: 7430
		private ulong? _stid;

		// Token: 0x04001D07 RID: 7431
		private string _name;

		// Token: 0x04001D08 RID: 7432
		private readonly List<SkyTeamMemberInfo> _members = new List<SkyTeamMemberInfo>();

		// Token: 0x04001D09 RID: 7433
		private uint? _score;

		// Token: 0x04001D0A RID: 7434
		private IExtension extensionObject;
	}
}
