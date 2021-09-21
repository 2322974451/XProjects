using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000374 RID: 884
	[ProtoContract(Name = "GetLeagueTeamInfoArg")]
	[Serializable]
	public class GetLeagueTeamInfoArg : IExtensible
	{
		// Token: 0x17000EF8 RID: 3832
		// (get) Token: 0x06003056 RID: 12374 RVA: 0x0005D474 File Offset: 0x0005B674
		// (set) Token: 0x06003057 RID: 12375 RVA: 0x0005D4A1 File Offset: 0x0005B6A1
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

		// Token: 0x17000EF9 RID: 3833
		// (get) Token: 0x06003058 RID: 12376 RVA: 0x0005D4B0 File Offset: 0x0005B6B0
		// (set) Token: 0x06003059 RID: 12377 RVA: 0x0005D4D0 File Offset: 0x0005B6D0
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

		// Token: 0x0600305A RID: 12378 RVA: 0x0005D514 File Offset: 0x0005B714
		private bool ShouldSerializeleague_teamid()
		{
			return this.league_teamidSpecified;
		}

		// Token: 0x0600305B RID: 12379 RVA: 0x0005D52C File Offset: 0x0005B72C
		private void Resetleague_teamid()
		{
			this.league_teamidSpecified = false;
		}

		// Token: 0x0600305C RID: 12380 RVA: 0x0005D538 File Offset: 0x0005B738
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BFA RID: 3066
		private ulong? _league_teamid;

		// Token: 0x04000BFB RID: 3067
		private IExtension extensionObject;
	}
}
