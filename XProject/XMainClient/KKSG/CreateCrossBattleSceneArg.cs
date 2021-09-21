using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200072B RID: 1835
	[ProtoContract(Name = "CreateCrossBattleSceneArg")]
	[Serializable]
	public class CreateCrossBattleSceneArg : IExtensible
	{
		// Token: 0x17002811 RID: 10257
		// (get) Token: 0x06007E61 RID: 32353 RVA: 0x000F1A58 File Offset: 0x000EFC58
		// (set) Token: 0x06007E62 RID: 32354 RVA: 0x000F1A84 File Offset: 0x000EFC84
		[ProtoMember(1, IsRequired = false, Name = "mapID", DataFormat = DataFormat.TwosComplement)]
		public uint mapID
		{
			get
			{
				return this._mapID ?? 0U;
			}
			set
			{
				this._mapID = new uint?(value);
			}
		}

		// Token: 0x17002812 RID: 10258
		// (get) Token: 0x06007E63 RID: 32355 RVA: 0x000F1A94 File Offset: 0x000EFC94
		// (set) Token: 0x06007E64 RID: 32356 RVA: 0x000F1AB4 File Offset: 0x000EFCB4
		[XmlIgnore]
		[Browsable(false)]
		public bool mapIDSpecified
		{
			get
			{
				return this._mapID != null;
			}
			set
			{
				bool flag = value == (this._mapID == null);
				if (flag)
				{
					this._mapID = (value ? new uint?(this.mapID) : null);
				}
			}
		}

		// Token: 0x06007E65 RID: 32357 RVA: 0x000F1AF8 File Offset: 0x000EFCF8
		private bool ShouldSerializemapID()
		{
			return this.mapIDSpecified;
		}

		// Token: 0x06007E66 RID: 32358 RVA: 0x000F1B10 File Offset: 0x000EFD10
		private void ResetmapID()
		{
			this.mapIDSpecified = false;
		}

		// Token: 0x17002813 RID: 10259
		// (get) Token: 0x06007E67 RID: 32359 RVA: 0x000F1B1C File Offset: 0x000EFD1C
		[ProtoMember(2, Name = "createInfos", DataFormat = DataFormat.Default)]
		public List<CreateCrossBattleSceneData> createInfos
		{
			get
			{
				return this._createInfos;
			}
		}

		// Token: 0x17002814 RID: 10260
		// (get) Token: 0x06007E68 RID: 32360 RVA: 0x000F1B34 File Offset: 0x000EFD34
		// (set) Token: 0x06007E69 RID: 32361 RVA: 0x000F1B4C File Offset: 0x000EFD4C
		[ProtoMember(3, IsRequired = false, Name = "smallInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public InvFightBefESpara smallInfo
		{
			get
			{
				return this._smallInfo;
			}
			set
			{
				this._smallInfo = value;
			}
		}

		// Token: 0x06007E6A RID: 32362 RVA: 0x000F1B58 File Offset: 0x000EFD58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DB2 RID: 7602
		private uint? _mapID;

		// Token: 0x04001DB3 RID: 7603
		private readonly List<CreateCrossBattleSceneData> _createInfos = new List<CreateCrossBattleSceneData>();

		// Token: 0x04001DB4 RID: 7604
		private InvFightBefESpara _smallInfo = null;

		// Token: 0x04001DB5 RID: 7605
		private IExtension extensionObject;
	}
}
