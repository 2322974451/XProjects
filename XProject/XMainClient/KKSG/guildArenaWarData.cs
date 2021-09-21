using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000691 RID: 1681
	[ProtoContract(Name = "guildArenaWarData")]
	[Serializable]
	public class guildArenaWarData : IExtensible
	{
		// Token: 0x17002276 RID: 8822
		// (get) Token: 0x06006CE1 RID: 27873 RVA: 0x000D0538 File Offset: 0x000CE738
		// (set) Token: 0x06006CE2 RID: 27874 RVA: 0x000D0564 File Offset: 0x000CE764
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

		// Token: 0x17002277 RID: 8823
		// (get) Token: 0x06006CE3 RID: 27875 RVA: 0x000D0574 File Offset: 0x000CE774
		// (set) Token: 0x06006CE4 RID: 27876 RVA: 0x000D0594 File Offset: 0x000CE794
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

		// Token: 0x06006CE5 RID: 27877 RVA: 0x000D05D8 File Offset: 0x000CE7D8
		private bool ShouldSerializewarType()
		{
			return this.warTypeSpecified;
		}

		// Token: 0x06006CE6 RID: 27878 RVA: 0x000D05F0 File Offset: 0x000CE7F0
		private void ResetwarType()
		{
			this.warTypeSpecified = false;
		}

		// Token: 0x17002278 RID: 8824
		// (get) Token: 0x06006CE7 RID: 27879 RVA: 0x000D05FC File Offset: 0x000CE7FC
		[ProtoMember(2, Name = "guildArenaGroupData", DataFormat = DataFormat.Default)]
		public List<GuildArenaGroupData> guildArenaGroupData
		{
			get
			{
				return this._guildArenaGroupData;
			}
		}

		// Token: 0x06006CE8 RID: 27880 RVA: 0x000D0614 File Offset: 0x000CE814
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A1E RID: 6686
		private uint? _warType;

		// Token: 0x04001A1F RID: 6687
		private readonly List<GuildArenaGroupData> _guildArenaGroupData = new List<GuildArenaGroupData>();

		// Token: 0x04001A20 RID: 6688
		private IExtension extensionObject;
	}
}
