using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200023B RID: 571
	[ProtoContract(Name = "SkyCityAllTeamBaseInfo")]
	[Serializable]
	public class SkyCityAllTeamBaseInfo : IExtensible
	{
		// Token: 0x170009E5 RID: 2533
		// (get) Token: 0x06001FBC RID: 8124 RVA: 0x0003E34C File Offset: 0x0003C54C
		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<SkyCityTeamBaseInfo> info
		{
			get
			{
				return this._info;
			}
		}

		// Token: 0x170009E6 RID: 2534
		// (get) Token: 0x06001FBD RID: 8125 RVA: 0x0003E364 File Offset: 0x0003C564
		// (set) Token: 0x06001FBE RID: 8126 RVA: 0x0003E390 File Offset: 0x0003C590
		[ProtoMember(2, IsRequired = false, Name = "games", DataFormat = DataFormat.TwosComplement)]
		public uint games
		{
			get
			{
				return this._games ?? 0U;
			}
			set
			{
				this._games = new uint?(value);
			}
		}

		// Token: 0x170009E7 RID: 2535
		// (get) Token: 0x06001FBF RID: 8127 RVA: 0x0003E3A0 File Offset: 0x0003C5A0
		// (set) Token: 0x06001FC0 RID: 8128 RVA: 0x0003E3C0 File Offset: 0x0003C5C0
		[XmlIgnore]
		[Browsable(false)]
		public bool gamesSpecified
		{
			get
			{
				return this._games != null;
			}
			set
			{
				bool flag = value == (this._games == null);
				if (flag)
				{
					this._games = (value ? new uint?(this.games) : null);
				}
			}
		}

		// Token: 0x06001FC1 RID: 8129 RVA: 0x0003E404 File Offset: 0x0003C604
		private bool ShouldSerializegames()
		{
			return this.gamesSpecified;
		}

		// Token: 0x06001FC2 RID: 8130 RVA: 0x0003E41C File Offset: 0x0003C61C
		private void Resetgames()
		{
			this.gamesSpecified = false;
		}

		// Token: 0x170009E8 RID: 2536
		// (get) Token: 0x06001FC3 RID: 8131 RVA: 0x0003E428 File Offset: 0x0003C628
		// (set) Token: 0x06001FC4 RID: 8132 RVA: 0x0003E454 File Offset: 0x0003C654
		[ProtoMember(3, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public uint floor
		{
			get
			{
				return this._floor ?? 0U;
			}
			set
			{
				this._floor = new uint?(value);
			}
		}

		// Token: 0x170009E9 RID: 2537
		// (get) Token: 0x06001FC5 RID: 8133 RVA: 0x0003E464 File Offset: 0x0003C664
		// (set) Token: 0x06001FC6 RID: 8134 RVA: 0x0003E484 File Offset: 0x0003C684
		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new uint?(this.floor) : null);
				}
			}
		}

		// Token: 0x06001FC7 RID: 8135 RVA: 0x0003E4C8 File Offset: 0x0003C6C8
		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		// Token: 0x06001FC8 RID: 8136 RVA: 0x0003E4E0 File Offset: 0x0003C6E0
		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		// Token: 0x06001FC9 RID: 8137 RVA: 0x0003E4EC File Offset: 0x0003C6EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007EC RID: 2028
		private readonly List<SkyCityTeamBaseInfo> _info = new List<SkyCityTeamBaseInfo>();

		// Token: 0x040007ED RID: 2029
		private uint? _games;

		// Token: 0x040007EE RID: 2030
		private uint? _floor;

		// Token: 0x040007EF RID: 2031
		private IExtension extensionObject;
	}
}
