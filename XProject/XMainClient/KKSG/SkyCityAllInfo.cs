using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000252 RID: 594
	[ProtoContract(Name = "SkyCityAllInfo")]
	[Serializable]
	public class SkyCityAllInfo : IExtensible
	{
		// Token: 0x17000A61 RID: 2657
		// (get) Token: 0x0600214A RID: 8522 RVA: 0x00041318 File Offset: 0x0003F518
		[ProtoMember(1, Name = "groupdata", DataFormat = DataFormat.Default)]
		public List<SkyCityGroupData> groupdata
		{
			get
			{
				return this._groupdata;
			}
		}

		// Token: 0x17000A62 RID: 2658
		// (get) Token: 0x0600214B RID: 8523 RVA: 0x00041330 File Offset: 0x0003F530
		// (set) Token: 0x0600214C RID: 8524 RVA: 0x0004135C File Offset: 0x0003F55C
		[ProtoMember(2, IsRequired = false, Name = "timetype", DataFormat = DataFormat.TwosComplement)]
		public SkyCityTimeType timetype
		{
			get
			{
				return this._timetype ?? SkyCityTimeType.Waiting;
			}
			set
			{
				this._timetype = new SkyCityTimeType?(value);
			}
		}

		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x0600214D RID: 8525 RVA: 0x0004136C File Offset: 0x0003F56C
		// (set) Token: 0x0600214E RID: 8526 RVA: 0x0004138C File Offset: 0x0003F58C
		[XmlIgnore]
		[Browsable(false)]
		public bool timetypeSpecified
		{
			get
			{
				return this._timetype != null;
			}
			set
			{
				bool flag = value == (this._timetype == null);
				if (flag)
				{
					this._timetype = (value ? new SkyCityTimeType?(this.timetype) : null);
				}
			}
		}

		// Token: 0x0600214F RID: 8527 RVA: 0x000413D0 File Offset: 0x0003F5D0
		private bool ShouldSerializetimetype()
		{
			return this.timetypeSpecified;
		}

		// Token: 0x06002150 RID: 8528 RVA: 0x000413E8 File Offset: 0x0003F5E8
		private void Resettimetype()
		{
			this.timetypeSpecified = false;
		}

		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x06002151 RID: 8529 RVA: 0x000413F4 File Offset: 0x0003F5F4
		// (set) Token: 0x06002152 RID: 8530 RVA: 0x00041420 File Offset: 0x0003F620
		[ProtoMember(3, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x06002153 RID: 8531 RVA: 0x00041430 File Offset: 0x0003F630
		// (set) Token: 0x06002154 RID: 8532 RVA: 0x00041450 File Offset: 0x0003F650
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

		// Token: 0x06002155 RID: 8533 RVA: 0x00041494 File Offset: 0x0003F694
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06002156 RID: 8534 RVA: 0x000414AC File Offset: 0x0003F6AC
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x06002157 RID: 8535 RVA: 0x000414B8 File Offset: 0x0003F6B8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000846 RID: 2118
		private readonly List<SkyCityGroupData> _groupdata = new List<SkyCityGroupData>();

		// Token: 0x04000847 RID: 2119
		private SkyCityTimeType? _timetype;

		// Token: 0x04000848 RID: 2120
		private uint? _lefttime;

		// Token: 0x04000849 RID: 2121
		private IExtension extensionObject;
	}
}
