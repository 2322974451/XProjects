using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200059C RID: 1436
	[ProtoContract(Name = "GlobalRiftFloorInfo")]
	[Serializable]
	public class GlobalRiftFloorInfo : IExtensible
	{
		// Token: 0x170017AF RID: 6063
		// (get) Token: 0x06004CE5 RID: 19685 RVA: 0x00092454 File Offset: 0x00090654
		// (set) Token: 0x06004CE6 RID: 19686 RVA: 0x00092480 File Offset: 0x00090680
		[ProtoMember(1, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public int floor
		{
			get
			{
				return this._floor ?? 0;
			}
			set
			{
				this._floor = new int?(value);
			}
		}

		// Token: 0x170017B0 RID: 6064
		// (get) Token: 0x06004CE7 RID: 19687 RVA: 0x00092490 File Offset: 0x00090690
		// (set) Token: 0x06004CE8 RID: 19688 RVA: 0x000924B0 File Offset: 0x000906B0
		[XmlIgnore]
		[Browsable(false)]
		public bool floorSpecified
		{
			get
			{
				return this._floor != null;
			}
			set
			{
				bool flag = value == (this._floor == null);
				if (flag)
				{
					this._floor = (value ? new int?(this.floor) : null);
				}
			}
		}

		// Token: 0x06004CE9 RID: 19689 RVA: 0x000924F4 File Offset: 0x000906F4
		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		// Token: 0x06004CEA RID: 19690 RVA: 0x0009250C File Offset: 0x0009070C
		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		// Token: 0x170017B1 RID: 6065
		// (get) Token: 0x06004CEB RID: 19691 RVA: 0x00092518 File Offset: 0x00090718
		// (set) Token: 0x06004CEC RID: 19692 RVA: 0x00092544 File Offset: 0x00090744
		[ProtoMember(2, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170017B2 RID: 6066
		// (get) Token: 0x06004CED RID: 19693 RVA: 0x00092554 File Offset: 0x00090754
		// (set) Token: 0x06004CEE RID: 19694 RVA: 0x00092574 File Offset: 0x00090774
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

		// Token: 0x06004CEF RID: 19695 RVA: 0x000925B8 File Offset: 0x000907B8
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x06004CF0 RID: 19696 RVA: 0x000925D0 File Offset: 0x000907D0
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x170017B3 RID: 6067
		// (get) Token: 0x06004CF1 RID: 19697 RVA: 0x000925DC File Offset: 0x000907DC
		[ProtoMember(3, Name = "buffs", DataFormat = DataFormat.Default)]
		public List<MapIntItem> buffs
		{
			get
			{
				return this._buffs;
			}
		}

		// Token: 0x06004CF2 RID: 19698 RVA: 0x000925F4 File Offset: 0x000907F4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400130E RID: 4878
		private int? _floor;

		// Token: 0x0400130F RID: 4879
		private uint? _sceneid;

		// Token: 0x04001310 RID: 4880
		private readonly List<MapIntItem> _buffs = new List<MapIntItem>();

		// Token: 0x04001311 RID: 4881
		private IExtension extensionObject;
	}
}
