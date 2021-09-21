using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000238 RID: 568
	[ProtoContract(Name = "SkyCityFinalInfo")]
	[Serializable]
	public class SkyCityFinalInfo : IExtensible
	{
		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x06001F8E RID: 8078 RVA: 0x0003DDC0 File Offset: 0x0003BFC0
		[ProtoMember(1, Name = "info", DataFormat = DataFormat.Default)]
		public List<SkyCityFinalBaseInfo> info
		{
			get
			{
				return this._info;
			}
		}

		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x06001F8F RID: 8079 RVA: 0x0003DDD8 File Offset: 0x0003BFD8
		// (set) Token: 0x06001F90 RID: 8080 RVA: 0x0003DE04 File Offset: 0x0003C004
		[ProtoMember(2, IsRequired = false, Name = "floor", DataFormat = DataFormat.TwosComplement)]
		public uint floor
		{
			get
			{
				return this._floor ?? 0U;
			}
			set
			{
				this._floor = new uint?(value);
			}
		}

		// Token: 0x170009D7 RID: 2519
		// (get) Token: 0x06001F91 RID: 8081 RVA: 0x0003DE14 File Offset: 0x0003C014
		// (set) Token: 0x06001F92 RID: 8082 RVA: 0x0003DE34 File Offset: 0x0003C034
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
					this._floor = (value ? new uint?(this.floor) : null);
				}
			}
		}

		// Token: 0x06001F93 RID: 8083 RVA: 0x0003DE78 File Offset: 0x0003C078
		private bool ShouldSerializefloor()
		{
			return this.floorSpecified;
		}

		// Token: 0x06001F94 RID: 8084 RVA: 0x0003DE90 File Offset: 0x0003C090
		private void Resetfloor()
		{
			this.floorSpecified = false;
		}

		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x06001F95 RID: 8085 RVA: 0x0003DE9C File Offset: 0x0003C09C
		[ProtoMember(3, Name = "item", DataFormat = DataFormat.Default)]
		public List<ItemBrief> item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x06001F96 RID: 8086 RVA: 0x0003DEB4 File Offset: 0x0003C0B4
		// (set) Token: 0x06001F97 RID: 8087 RVA: 0x0003DEE0 File Offset: 0x0003C0E0
		[ProtoMember(4, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		// Token: 0x170009DA RID: 2522
		// (get) Token: 0x06001F98 RID: 8088 RVA: 0x0003DEF0 File Offset: 0x0003C0F0
		// (set) Token: 0x06001F99 RID: 8089 RVA: 0x0003DF10 File Offset: 0x0003C110
		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		// Token: 0x06001F9A RID: 8090 RVA: 0x0003DF54 File Offset: 0x0003C154
		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		// Token: 0x06001F9B RID: 8091 RVA: 0x0003DF6C File Offset: 0x0003C16C
		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		// Token: 0x06001F9C RID: 8092 RVA: 0x0003DF78 File Offset: 0x0003C178
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007DF RID: 2015
		private readonly List<SkyCityFinalBaseInfo> _info = new List<SkyCityFinalBaseInfo>();

		// Token: 0x040007E0 RID: 2016
		private uint? _floor;

		// Token: 0x040007E1 RID: 2017
		private readonly List<ItemBrief> _item = new List<ItemBrief>();

		// Token: 0x040007E2 RID: 2018
		private bool? _ismvp;

		// Token: 0x040007E3 RID: 2019
		private IExtension extensionObject;
	}
}
