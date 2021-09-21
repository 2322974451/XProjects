using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000377 RID: 887
	[ProtoContract(Name = "NotifyLeagueTeamCreate")]
	[Serializable]
	public class NotifyLeagueTeamCreate : IExtensible
	{
		// Token: 0x17000EFD RID: 3837
		// (get) Token: 0x0600306A RID: 12394 RVA: 0x0005D6A4 File Offset: 0x0005B8A4
		// (set) Token: 0x0600306B RID: 12395 RVA: 0x0005D6D1 File Offset: 0x0005B8D1
		[ProtoMember(1, IsRequired = false, Name = "league_teamid", DataFormat = DataFormat.TwosComplement)]
		public ulong league_teamid
		{
			get
			{
				return this._league_teamid ?? 0UL;
			}
			set
			{
				this._league_teamid = new ulong?(value);
			}
		}

		// Token: 0x17000EFE RID: 3838
		// (get) Token: 0x0600306C RID: 12396 RVA: 0x0005D6E0 File Offset: 0x0005B8E0
		// (set) Token: 0x0600306D RID: 12397 RVA: 0x0005D700 File Offset: 0x0005B900
		[XmlIgnore]
		[Browsable(false)]
		public bool league_teamidSpecified
		{
			get
			{
				return this._league_teamid != null;
			}
			set
			{
				bool flag = value == (this._league_teamid == null);
				if (flag)
				{
					this._league_teamid = (value ? new ulong?(this.league_teamid) : null);
				}
			}
		}

		// Token: 0x0600306E RID: 12398 RVA: 0x0005D744 File Offset: 0x0005B944
		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		// Token: 0x0600306F RID: 12399 RVA: 0x0005D75C File Offset: 0x0005B95C
		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

		// Token: 0x17000EFF RID: 3839
		// (get) Token: 0x06003070 RID: 12400 RVA: 0x0005D768 File Offset: 0x0005B968
		// (set) Token: 0x06003071 RID: 12401 RVA: 0x0005D789 File Offset: 0x0005B989
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

		// Token: 0x17000F00 RID: 3840
		// (get) Token: 0x06003072 RID: 12402 RVA: 0x0005D794 File Offset: 0x0005B994
		// (set) Token: 0x06003073 RID: 12403 RVA: 0x0005D7B0 File Offset: 0x0005B9B0
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

		// Token: 0x06003074 RID: 12404 RVA: 0x0005D7E0 File Offset: 0x0005B9E0
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003075 RID: 12405 RVA: 0x0005D7F8 File Offset: 0x0005B9F8
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17000F01 RID: 3841
		// (get) Token: 0x06003076 RID: 12406 RVA: 0x0005D804 File Offset: 0x0005BA04
		[ProtoMember(3, Name = "members", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x06003077 RID: 12407 RVA: 0x0005D81C File Offset: 0x0005BA1C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C00 RID: 3072
		private ulong? _league_teamid;

		// Token: 0x04000C01 RID: 3073
		private string _name;

		// Token: 0x04000C02 RID: 3074
		private readonly List<ulong> _members = new List<ulong>();

		// Token: 0x04000C03 RID: 3075
		private IExtension extensionObject;
	}
}
