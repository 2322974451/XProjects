using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000391 RID: 913
	[ProtoContract(Name = "LeagueBattleStateNtf")]
	[Serializable]
	public class LeagueBattleStateNtf : IExtensible
	{
		// Token: 0x17000F4B RID: 3915
		// (get) Token: 0x06003174 RID: 12660 RVA: 0x0005F430 File Offset: 0x0005D630
		// (set) Token: 0x06003175 RID: 12661 RVA: 0x0005F45C File Offset: 0x0005D65C
		[ProtoMember(1, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		// Token: 0x17000F4C RID: 3916
		// (get) Token: 0x06003176 RID: 12662 RVA: 0x0005F46C File Offset: 0x0005D66C
		// (set) Token: 0x06003177 RID: 12663 RVA: 0x0005F48C File Offset: 0x0005D68C
		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		// Token: 0x06003178 RID: 12664 RVA: 0x0005F4D0 File Offset: 0x0005D6D0
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06003179 RID: 12665 RVA: 0x0005F4E8 File Offset: 0x0005D6E8
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x17000F4D RID: 3917
		// (get) Token: 0x0600317A RID: 12666 RVA: 0x0005F4F4 File Offset: 0x0005D6F4
		// (set) Token: 0x0600317B RID: 12667 RVA: 0x0005F520 File Offset: 0x0005D720
		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleFightState state
		{
			get
			{
				return this._state ?? LeagueBattleFightState.LBFight_None;
			}
			set
			{
				this._state = new LeagueBattleFightState?(value);
			}
		}

		// Token: 0x17000F4E RID: 3918
		// (get) Token: 0x0600317C RID: 12668 RVA: 0x0005F530 File Offset: 0x0005D730
		// (set) Token: 0x0600317D RID: 12669 RVA: 0x0005F550 File Offset: 0x0005D750
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
					this._state = (value ? new LeagueBattleFightState?(this.state) : null);
				}
			}
		}

		// Token: 0x0600317E RID: 12670 RVA: 0x0005F594 File Offset: 0x0005D794
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x0600317F RID: 12671 RVA: 0x0005F5AC File Offset: 0x0005D7AC
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06003180 RID: 12672 RVA: 0x0005F5B8 File Offset: 0x0005D7B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C48 RID: 3144
		private uint? _lefttime;

		// Token: 0x04000C49 RID: 3145
		private LeagueBattleFightState? _state;

		// Token: 0x04000C4A RID: 3146
		private IExtension extensionObject;
	}
}
