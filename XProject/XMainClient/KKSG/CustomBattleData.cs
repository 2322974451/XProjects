using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200070A RID: 1802
	[ProtoContract(Name = "CustomBattleData")]
	[Serializable]
	public class CustomBattleData : IExtensible
	{
		// Token: 0x170026B4 RID: 9908
		// (get) Token: 0x06007A23 RID: 31267 RVA: 0x000E9798 File Offset: 0x000E7998
		// (set) Token: 0x06007A24 RID: 31268 RVA: 0x000E97C5 File Offset: 0x000E79C5
		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		// Token: 0x170026B5 RID: 9909
		// (get) Token: 0x06007A25 RID: 31269 RVA: 0x000E97D4 File Offset: 0x000E79D4
		// (set) Token: 0x06007A26 RID: 31270 RVA: 0x000E97F4 File Offset: 0x000E79F4
		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		// Token: 0x06007A27 RID: 31271 RVA: 0x000E9838 File Offset: 0x000E7A38
		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		// Token: 0x06007A28 RID: 31272 RVA: 0x000E9850 File Offset: 0x000E7A50
		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		// Token: 0x170026B6 RID: 9910
		// (get) Token: 0x06007A29 RID: 31273 RVA: 0x000E985C File Offset: 0x000E7A5C
		// (set) Token: 0x06007A2A RID: 31274 RVA: 0x000E9874 File Offset: 0x000E7A74
		[ProtoMember(2, IsRequired = false, Name = "config", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleConfig config
		{
			get
			{
				return this._config;
			}
			set
			{
				this._config = value;
			}
		}

		// Token: 0x170026B7 RID: 9911
		// (get) Token: 0x06007A2B RID: 31275 RVA: 0x000E9880 File Offset: 0x000E7A80
		[ProtoMember(3, Name = "rank", DataFormat = DataFormat.Default)]
		public List<CustomBattleRank> rank
		{
			get
			{
				return this._rank;
			}
		}

		// Token: 0x06007A2C RID: 31276 RVA: 0x000E9898 File Offset: 0x000E7A98
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CDA RID: 7386
		private ulong? _uid;

		// Token: 0x04001CDB RID: 7387
		private CustomBattleConfig _config = null;

		// Token: 0x04001CDC RID: 7388
		private readonly List<CustomBattleRank> _rank = new List<CustomBattleRank>();

		// Token: 0x04001CDD RID: 7389
		private IExtension extensionObject;
	}
}
