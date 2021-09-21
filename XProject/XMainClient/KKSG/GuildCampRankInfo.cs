using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006C9 RID: 1737
	[ProtoContract(Name = "GuildCampRankInfo")]
	[Serializable]
	public class GuildCampRankInfo : IExtensible
	{
		// Token: 0x17002453 RID: 9299
		// (get) Token: 0x060072BF RID: 29375 RVA: 0x000DB8F0 File Offset: 0x000D9AF0
		// (set) Token: 0x060072C0 RID: 29376 RVA: 0x000DB91C File Offset: 0x000D9B1C
		[ProtoMember(1, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		// Token: 0x17002454 RID: 9300
		// (get) Token: 0x060072C1 RID: 29377 RVA: 0x000DB92C File Offset: 0x000D9B2C
		// (set) Token: 0x060072C2 RID: 29378 RVA: 0x000DB94C File Offset: 0x000D9B4C
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
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		// Token: 0x060072C3 RID: 29379 RVA: 0x000DB990 File Offset: 0x000D9B90
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x060072C4 RID: 29380 RVA: 0x000DB9A8 File Offset: 0x000D9BA8
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17002455 RID: 9301
		// (get) Token: 0x060072C5 RID: 29381 RVA: 0x000DB9B4 File Offset: 0x000D9BB4
		// (set) Token: 0x060072C6 RID: 29382 RVA: 0x000DB9E0 File Offset: 0x000D9BE0
		[ProtoMember(2, IsRequired = false, Name = "rankVar", DataFormat = DataFormat.TwosComplement)]
		public int rankVar
		{
			get
			{
				return this._rankVar ?? 0;
			}
			set
			{
				this._rankVar = new int?(value);
			}
		}

		// Token: 0x17002456 RID: 9302
		// (get) Token: 0x060072C7 RID: 29383 RVA: 0x000DB9F0 File Offset: 0x000D9BF0
		// (set) Token: 0x060072C8 RID: 29384 RVA: 0x000DBA10 File Offset: 0x000D9C10
		[XmlIgnore]
		[Browsable(false)]
		public bool rankVarSpecified
		{
			get
			{
				return this._rankVar != null;
			}
			set
			{
				bool flag = value == (this._rankVar == null);
				if (flag)
				{
					this._rankVar = (value ? new int?(this.rankVar) : null);
				}
			}
		}

		// Token: 0x060072C9 RID: 29385 RVA: 0x000DBA54 File Offset: 0x000D9C54
		private bool ShouldSerializerankVar()
		{
			return this.rankVarSpecified;
		}

		// Token: 0x060072CA RID: 29386 RVA: 0x000DBA6C File Offset: 0x000D9C6C
		private void ResetrankVar()
		{
			this.rankVarSpecified = false;
		}

		// Token: 0x17002457 RID: 9303
		// (get) Token: 0x060072CB RID: 29387 RVA: 0x000DBA78 File Offset: 0x000D9C78
		[ProtoMember(3, Name = "roles", DataFormat = DataFormat.Default)]
		public List<RoleBriefInfo> roles
		{
			get
			{
				return this._roles;
			}
		}

		// Token: 0x060072CC RID: 29388 RVA: 0x000DBA90 File Offset: 0x000D9C90
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001B52 RID: 6994
		private int? _rank;

		// Token: 0x04001B53 RID: 6995
		private int? _rankVar;

		// Token: 0x04001B54 RID: 6996
		private readonly List<RoleBriefInfo> _roles = new List<RoleBriefInfo>();

		// Token: 0x04001B55 RID: 6997
		private IExtension extensionObject;
	}
}
