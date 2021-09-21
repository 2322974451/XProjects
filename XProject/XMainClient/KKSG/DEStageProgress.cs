using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005EF RID: 1519
	[ProtoContract(Name = "DEStageProgress")]
	[Serializable]
	public class DEStageProgress : IExtensible
	{
		// Token: 0x17001C3C RID: 7228
		// (get) Token: 0x06005A53 RID: 23123 RVA: 0x000ABF78 File Offset: 0x000AA178
		// (set) Token: 0x06005A54 RID: 23124 RVA: 0x000ABFA4 File Offset: 0x000AA1A4
		[ProtoMember(1, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		// Token: 0x17001C3D RID: 7229
		// (get) Token: 0x06005A55 RID: 23125 RVA: 0x000ABFB4 File Offset: 0x000AA1B4
		// (set) Token: 0x06005A56 RID: 23126 RVA: 0x000ABFD4 File Offset: 0x000AA1D4
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		// Token: 0x06005A57 RID: 23127 RVA: 0x000AC018 File Offset: 0x000AA218
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x06005A58 RID: 23128 RVA: 0x000AC030 File Offset: 0x000AA230
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x17001C3E RID: 7230
		// (get) Token: 0x06005A59 RID: 23129 RVA: 0x000AC03C File Offset: 0x000AA23C
		[ProtoMember(2, Name = "bossids", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bossids
		{
			get
			{
				return this._bossids;
			}
		}

		// Token: 0x17001C3F RID: 7231
		// (get) Token: 0x06005A5A RID: 23130 RVA: 0x000AC054 File Offset: 0x000AA254
		[ProtoMember(3, Name = "bosshppercenet", DataFormat = DataFormat.TwosComplement)]
		public List<int> bosshppercenet
		{
			get
			{
				return this._bosshppercenet;
			}
		}

		// Token: 0x06005A5B RID: 23131 RVA: 0x000AC06C File Offset: 0x000AA26C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040015FA RID: 5626
		private uint? _sceneid;

		// Token: 0x040015FB RID: 5627
		private readonly List<uint> _bossids = new List<uint>();

		// Token: 0x040015FC RID: 5628
		private readonly List<int> _bosshppercenet = new List<int>();

		// Token: 0x040015FD RID: 5629
		private IExtension extensionObject;
	}
}
