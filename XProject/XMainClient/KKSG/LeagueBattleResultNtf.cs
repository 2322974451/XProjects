using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000386 RID: 902
	[ProtoContract(Name = "LeagueBattleResultNtf")]
	[Serializable]
	public class LeagueBattleResultNtf : IExtensible
	{
		// Token: 0x17000F27 RID: 3879
		// (get) Token: 0x060030F8 RID: 12536 RVA: 0x0005E640 File Offset: 0x0005C840
		// (set) Token: 0x060030F9 RID: 12537 RVA: 0x0005E66C File Offset: 0x0005C86C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleType type
		{
			get
			{
				return this._type ?? LeagueBattleType.LeagueBattleType_RacePoint;
			}
			set
			{
				this._type = new LeagueBattleType?(value);
			}
		}

		// Token: 0x17000F28 RID: 3880
		// (get) Token: 0x060030FA RID: 12538 RVA: 0x0005E67C File Offset: 0x0005C87C
		// (set) Token: 0x060030FB RID: 12539 RVA: 0x0005E69C File Offset: 0x0005C89C
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
					this._type = (value ? new LeagueBattleType?(this.type) : null);
				}
			}
		}

		// Token: 0x060030FC RID: 12540 RVA: 0x0005E6E0 File Offset: 0x0005C8E0
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x060030FD RID: 12541 RVA: 0x0005E6F8 File Offset: 0x0005C8F8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000F29 RID: 3881
		// (get) Token: 0x060030FE RID: 12542 RVA: 0x0005E704 File Offset: 0x0005C904
		// (set) Token: 0x060030FF RID: 12543 RVA: 0x0005E71C File Offset: 0x0005C91C
		[ProtoMember(2, IsRequired = false, Name = "winteam", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleResultTeam winteam
		{
			get
			{
				return this._winteam;
			}
			set
			{
				this._winteam = value;
			}
		}

		// Token: 0x17000F2A RID: 3882
		// (get) Token: 0x06003100 RID: 12544 RVA: 0x0005E728 File Offset: 0x0005C928
		// (set) Token: 0x06003101 RID: 12545 RVA: 0x0005E740 File Offset: 0x0005C940
		[ProtoMember(3, IsRequired = false, Name = "loseteam", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleResultTeam loseteam
		{
			get
			{
				return this._loseteam;
			}
			set
			{
				this._loseteam = value;
			}
		}

		// Token: 0x06003102 RID: 12546 RVA: 0x0005E74C File Offset: 0x0005C94C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C29 RID: 3113
		private LeagueBattleType? _type;

		// Token: 0x04000C2A RID: 3114
		private LeagueBattleResultTeam _winteam = null;

		// Token: 0x04000C2B RID: 3115
		private LeagueBattleResultTeam _loseteam = null;

		// Token: 0x04000C2C RID: 3116
		private IExtension extensionObject;
	}
}
