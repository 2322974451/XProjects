using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000707 RID: 1799
	[ProtoContract(Name = "CustomBattleClientInfo")]
	[Serializable]
	public class CustomBattleClientInfo : IExtensible
	{
		// Token: 0x170026A9 RID: 9897
		// (get) Token: 0x06007A08 RID: 31240 RVA: 0x000E94F8 File Offset: 0x000E76F8
		// (set) Token: 0x06007A09 RID: 31241 RVA: 0x000E9510 File Offset: 0x000E7710
		[ProtoMember(1, IsRequired = false, Name = "queryinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleQueryInfo queryinfo
		{
			get
			{
				return this._queryinfo;
			}
			set
			{
				this._queryinfo = value;
			}
		}

		// Token: 0x170026AA RID: 9898
		// (get) Token: 0x06007A0A RID: 31242 RVA: 0x000E951C File Offset: 0x000E771C
		// (set) Token: 0x06007A0B RID: 31243 RVA: 0x000E9534 File Offset: 0x000E7734
		[ProtoMember(2, IsRequired = false, Name = "createinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleDataRole createinfo
		{
			get
			{
				return this._createinfo;
			}
			set
			{
				this._createinfo = value;
			}
		}

		// Token: 0x170026AB RID: 9899
		// (get) Token: 0x06007A0C RID: 31244 RVA: 0x000E9540 File Offset: 0x000E7740
		// (set) Token: 0x06007A0D RID: 31245 RVA: 0x000E9558 File Offset: 0x000E7758
		[ProtoMember(3, IsRequired = false, Name = "joininfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleDataRole joininfo
		{
			get
			{
				return this._joininfo;
			}
			set
			{
				this._joininfo = value;
			}
		}

		// Token: 0x170026AC RID: 9900
		// (get) Token: 0x06007A0E RID: 31246 RVA: 0x000E9564 File Offset: 0x000E7764
		// (set) Token: 0x06007A0F RID: 31247 RVA: 0x000E9590 File Offset: 0x000E7790
		[ProtoMember(4, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x170026AD RID: 9901
		// (get) Token: 0x06007A10 RID: 31248 RVA: 0x000E95A0 File Offset: 0x000E77A0
		// (set) Token: 0x06007A11 RID: 31249 RVA: 0x000E95C0 File Offset: 0x000E77C0
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x06007A12 RID: 31250 RVA: 0x000E9604 File Offset: 0x000E7804
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x06007A13 RID: 31251 RVA: 0x000E961C File Offset: 0x000E781C
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x170026AE RID: 9902
		// (get) Token: 0x06007A14 RID: 31252 RVA: 0x000E9628 File Offset: 0x000E7828
		[ProtoMember(5, Name = "searchinfo", DataFormat = DataFormat.Default)]
		public List<CustomBattleDataRole> searchinfo
		{
			get
			{
				return this._searchinfo;
			}
		}

		// Token: 0x06007A15 RID: 31253 RVA: 0x000E9640 File Offset: 0x000E7840
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CCD RID: 7373
		private CustomBattleQueryInfo _queryinfo = null;

		// Token: 0x04001CCE RID: 7374
		private CustomBattleDataRole _createinfo = null;

		// Token: 0x04001CCF RID: 7375
		private CustomBattleDataRole _joininfo = null;

		// Token: 0x04001CD0 RID: 7376
		private uint? _rank;

		// Token: 0x04001CD1 RID: 7377
		private readonly List<CustomBattleDataRole> _searchinfo = new List<CustomBattleDataRole>();

		// Token: 0x04001CD2 RID: 7378
		private IExtension extensionObject;
	}
}
