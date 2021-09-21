using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F9 RID: 505
	[ProtoContract(Name = "ActivatAtlasArg")]
	[Serializable]
	public class ActivatAtlasArg : IExtensible
	{
		// Token: 0x17000900 RID: 2304
		// (get) Token: 0x06001CC0 RID: 7360 RVA: 0x00038A34 File Offset: 0x00036C34
		// (set) Token: 0x06001CC1 RID: 7361 RVA: 0x00038A60 File Offset: 0x00036C60
		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x06001CC2 RID: 7362 RVA: 0x00038A70 File Offset: 0x00036C70
		// (set) Token: 0x06001CC3 RID: 7363 RVA: 0x00038A90 File Offset: 0x00036C90
		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		// Token: 0x06001CC4 RID: 7364 RVA: 0x00038AD4 File Offset: 0x00036CD4
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06001CC5 RID: 7365 RVA: 0x00038AEC File Offset: 0x00036CEC
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x06001CC6 RID: 7366 RVA: 0x00038AF8 File Offset: 0x00036CF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000728 RID: 1832
		private uint? _teamid;

		// Token: 0x04000729 RID: 1833
		private IExtension extensionObject;
	}
}
