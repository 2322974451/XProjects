using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006E1 RID: 1761
	[ProtoContract(Name = "GCFBattleField")]
	[Serializable]
	public class GCFBattleField : IExtensible
	{
		// Token: 0x17002539 RID: 9529
		// (get) Token: 0x0600758F RID: 30095 RVA: 0x000E0EC4 File Offset: 0x000DF0C4
		// (set) Token: 0x06007590 RID: 30096 RVA: 0x000E0EF0 File Offset: 0x000DF0F0
		[ProtoMember(1, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
		public uint mapid
		{
			get
			{
				return this._mapid ?? 0U;
			}
			set
			{
				this._mapid = new uint?(value);
			}
		}

		// Token: 0x1700253A RID: 9530
		// (get) Token: 0x06007591 RID: 30097 RVA: 0x000E0F00 File Offset: 0x000DF100
		// (set) Token: 0x06007592 RID: 30098 RVA: 0x000E0F20 File Offset: 0x000DF120
		[XmlIgnore]
		[Browsable(false)]
		public bool mapidSpecified
		{
			get
			{
				return this._mapid != null;
			}
			set
			{
				bool flag = value == (this._mapid == null);
				if (flag)
				{
					this._mapid = (value ? new uint?(this.mapid) : null);
				}
			}
		}

		// Token: 0x06007593 RID: 30099 RVA: 0x000E0F64 File Offset: 0x000DF164
		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		// Token: 0x06007594 RID: 30100 RVA: 0x000E0F7C File Offset: 0x000DF17C
		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		// Token: 0x1700253B RID: 9531
		// (get) Token: 0x06007595 RID: 30101 RVA: 0x000E0F88 File Offset: 0x000DF188
		[ProtoMember(2, Name = "jvdians", DataFormat = DataFormat.Default)]
		public List<GCFJvDianInfo> jvdians
		{
			get
			{
				return this._jvdians;
			}
		}

		// Token: 0x1700253C RID: 9532
		// (get) Token: 0x06007596 RID: 30102 RVA: 0x000E0FA0 File Offset: 0x000DF1A0
		// (set) Token: 0x06007597 RID: 30103 RVA: 0x000E0FB8 File Offset: 0x000DF1B8
		[ProtoMember(3, IsRequired = false, Name = "zhanchinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFZhanChBriefInfo zhanchinfo
		{
			get
			{
				return this._zhanchinfo;
			}
			set
			{
				this._zhanchinfo = value;
			}
		}

		// Token: 0x06007598 RID: 30104 RVA: 0x000E0FC4 File Offset: 0x000DF1C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001BE3 RID: 7139
		private uint? _mapid;

		// Token: 0x04001BE4 RID: 7140
		private readonly List<GCFJvDianInfo> _jvdians = new List<GCFJvDianInfo>();

		// Token: 0x04001BE5 RID: 7141
		private GCFZhanChBriefInfo _zhanchinfo = null;

		// Token: 0x04001BE6 RID: 7142
		private IExtension extensionObject;
	}
}
