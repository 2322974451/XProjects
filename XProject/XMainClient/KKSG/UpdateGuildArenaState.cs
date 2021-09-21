using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000194 RID: 404
	[ProtoContract(Name = "UpdateGuildArenaState")]
	[Serializable]
	public class UpdateGuildArenaState : IExtensible
	{
		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x0600184E RID: 6222 RVA: 0x0003070C File Offset: 0x0002E90C
		// (set) Token: 0x0600184F RID: 6223 RVA: 0x00030738 File Offset: 0x0002E938
		[ProtoMember(1, IsRequired = false, Name = "warType", DataFormat = DataFormat.TwosComplement)]
		public uint warType
		{
			get
			{
				return this._warType ?? 0U;
			}
			set
			{
				this._warType = new uint?(value);
			}
		}

		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x06001850 RID: 6224 RVA: 0x00030748 File Offset: 0x0002E948
		// (set) Token: 0x06001851 RID: 6225 RVA: 0x00030768 File Offset: 0x0002E968
		[XmlIgnore]
		[Browsable(false)]
		public bool warTypeSpecified
		{
			get
			{
				return this._warType != null;
			}
			set
			{
				bool flag = value == (this._warType == null);
				if (flag)
				{
					this._warType = (value ? new uint?(this.warType) : null);
				}
			}
		}

		// Token: 0x06001852 RID: 6226 RVA: 0x000307AC File Offset: 0x0002E9AC
		private bool ShouldSerializewarType()
		{
			return this.warTypeSpecified;
		}

		// Token: 0x06001853 RID: 6227 RVA: 0x000307C4 File Offset: 0x0002E9C4
		private void ResetwarType()
		{
			this.warTypeSpecified = false;
		}

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x06001854 RID: 6228 RVA: 0x000307D0 File Offset: 0x0002E9D0
		// (set) Token: 0x06001855 RID: 6229 RVA: 0x000307FC File Offset: 0x0002E9FC
		[ProtoMember(2, IsRequired = false, Name = "battleId", DataFormat = DataFormat.TwosComplement)]
		public uint battleId
		{
			get
			{
				return this._battleId ?? 0U;
			}
			set
			{
				this._battleId = new uint?(value);
			}
		}

		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x06001856 RID: 6230 RVA: 0x0003080C File Offset: 0x0002EA0C
		// (set) Token: 0x06001857 RID: 6231 RVA: 0x0003082C File Offset: 0x0002EA2C
		[XmlIgnore]
		[Browsable(false)]
		public bool battleIdSpecified
		{
			get
			{
				return this._battleId != null;
			}
			set
			{
				bool flag = value == (this._battleId == null);
				if (flag)
				{
					this._battleId = (value ? new uint?(this.battleId) : null);
				}
			}
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x00030870 File Offset: 0x0002EA70
		private bool ShouldSerializebattleId()
		{
			return this.battleIdSpecified;
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x00030888 File Offset: 0x0002EA88
		private void ResetbattleId()
		{
			this.battleIdSpecified = false;
		}

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x0600185A RID: 6234 RVA: 0x00030894 File Offset: 0x0002EA94
		// (set) Token: 0x0600185B RID: 6235 RVA: 0x000308C0 File Offset: 0x0002EAC0
		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x0600185C RID: 6236 RVA: 0x000308D0 File Offset: 0x0002EAD0
		// (set) Token: 0x0600185D RID: 6237 RVA: 0x000308F0 File Offset: 0x0002EAF0
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
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x00030934 File Offset: 0x0002EB34
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x0003094C File Offset: 0x0002EB4C
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06001860 RID: 6240 RVA: 0x00030958 File Offset: 0x0002EB58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000602 RID: 1538
		private uint? _warType;

		// Token: 0x04000603 RID: 1539
		private uint? _battleId;

		// Token: 0x04000604 RID: 1540
		private uint? _state;

		// Token: 0x04000605 RID: 1541
		private IExtension extensionObject;
	}
}
