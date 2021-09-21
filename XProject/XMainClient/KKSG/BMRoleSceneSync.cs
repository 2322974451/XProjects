using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000440 RID: 1088
	[ProtoContract(Name = "BMRoleSceneSync")]
	[Serializable]
	public class BMRoleSceneSync : IExtensible
	{
		// Token: 0x170011A2 RID: 4514
		// (get) Token: 0x06003972 RID: 14706 RVA: 0x0006DE84 File Offset: 0x0006C084
		// (set) Token: 0x06003973 RID: 14707 RVA: 0x0006DEB0 File Offset: 0x0006C0B0
		[ProtoMember(1, IsRequired = false, Name = "games", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170011A3 RID: 4515
		// (get) Token: 0x06003974 RID: 14708 RVA: 0x0006DEC0 File Offset: 0x0006C0C0
		// (set) Token: 0x06003975 RID: 14709 RVA: 0x0006DEE0 File Offset: 0x0006C0E0
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

		// Token: 0x06003976 RID: 14710 RVA: 0x0006DF24 File Offset: 0x0006C124
		private bool ShouldSerializegames()
		{
			return this.gamesSpecified;
		}

		// Token: 0x06003977 RID: 14711 RVA: 0x0006DF3C File Offset: 0x0006C13C
		private void Resetgames()
		{
			this.gamesSpecified = false;
		}

		// Token: 0x170011A4 RID: 4516
		// (get) Token: 0x06003978 RID: 14712 RVA: 0x0006DF48 File Offset: 0x0006C148
		[ProtoMember(2, Name = "roles", DataFormat = DataFormat.Default)]
		public List<BMRoleEnter> roles
		{
			get
			{
				return this._roles;
			}
		}

		// Token: 0x06003979 RID: 14713 RVA: 0x0006DF60 File Offset: 0x0006C160
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E41 RID: 3649
		private uint? _games;

		// Token: 0x04000E42 RID: 3650
		private readonly List<BMRoleEnter> _roles = new List<BMRoleEnter>();

		// Token: 0x04000E43 RID: 3651
		private IExtension extensionObject;
	}
}
