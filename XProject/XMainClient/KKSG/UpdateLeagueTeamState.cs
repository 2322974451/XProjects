using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200037E RID: 894
	[ProtoContract(Name = "UpdateLeagueTeamState")]
	[Serializable]
	public class UpdateLeagueTeamState : IExtensible
	{
		// Token: 0x17000F11 RID: 3857
		// (get) Token: 0x060030AC RID: 12460 RVA: 0x0005DDE0 File Offset: 0x0005BFE0
		// (set) Token: 0x060030AD RID: 12461 RVA: 0x0005DE0C File Offset: 0x0005C00C
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public LeagueTeamState state
		{
			get
			{
				return this._state ?? LeagueTeamState.LeagueTeamState_Idle;
			}
			set
			{
				this._state = new LeagueTeamState?(value);
			}
		}

		// Token: 0x17000F12 RID: 3858
		// (get) Token: 0x060030AE RID: 12462 RVA: 0x0005DE1C File Offset: 0x0005C01C
		// (set) Token: 0x060030AF RID: 12463 RVA: 0x0005DE3C File Offset: 0x0005C03C
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
					this._state = (value ? new LeagueTeamState?(this.state) : null);
				}
			}
		}

		// Token: 0x060030B0 RID: 12464 RVA: 0x0005DE80 File Offset: 0x0005C080
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060030B1 RID: 12465 RVA: 0x0005DE98 File Offset: 0x0005C098
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x060030B2 RID: 12466 RVA: 0x0005DEA4 File Offset: 0x0005C0A4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C13 RID: 3091
		private LeagueTeamState? _state;

		// Token: 0x04000C14 RID: 3092
		private IExtension extensionObject;
	}
}
