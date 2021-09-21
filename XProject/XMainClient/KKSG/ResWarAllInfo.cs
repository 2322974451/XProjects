using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002A0 RID: 672
	[ProtoContract(Name = "ResWarAllInfo")]
	[Serializable]
	public class ResWarAllInfo : IExtensible
	{
		// Token: 0x17000BAB RID: 2987
		// (get) Token: 0x06002589 RID: 9609 RVA: 0x000491A4 File Offset: 0x000473A4
		[ProtoMember(1, Name = "groupdata", DataFormat = DataFormat.Default)]
		public List<ResWarGroupData> groupdata
		{
			get
			{
				return this._groupdata;
			}
		}

		// Token: 0x17000BAC RID: 2988
		// (get) Token: 0x0600258A RID: 9610 RVA: 0x000491BC File Offset: 0x000473BC
		// (set) Token: 0x0600258B RID: 9611 RVA: 0x000491E8 File Offset: 0x000473E8
		[ProtoMember(2, IsRequired = false, Name = "timetype", DataFormat = DataFormat.TwosComplement)]
		public ResWarTimeType timetype
		{
			get
			{
				return this._timetype ?? ResWarTimeType.RealyTime;
			}
			set
			{
				this._timetype = new ResWarTimeType?(value);
			}
		}

		// Token: 0x17000BAD RID: 2989
		// (get) Token: 0x0600258C RID: 9612 RVA: 0x000491F8 File Offset: 0x000473F8
		// (set) Token: 0x0600258D RID: 9613 RVA: 0x00049218 File Offset: 0x00047418
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
					this._timetype = (value ? new ResWarTimeType?(this.timetype) : null);
				}
			}
		}

		// Token: 0x0600258E RID: 9614 RVA: 0x0004925C File Offset: 0x0004745C
		private bool ShouldSerializetimetype()
		{
			return this.timetypeSpecified;
		}

		// Token: 0x0600258F RID: 9615 RVA: 0x00049274 File Offset: 0x00047474
		private void Resettimetype()
		{
			this.timetypeSpecified = false;
		}

		// Token: 0x17000BAE RID: 2990
		// (get) Token: 0x06002590 RID: 9616 RVA: 0x00049280 File Offset: 0x00047480
		// (set) Token: 0x06002591 RID: 9617 RVA: 0x000492AC File Offset: 0x000474AC
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

		// Token: 0x17000BAF RID: 2991
		// (get) Token: 0x06002592 RID: 9618 RVA: 0x000492BC File Offset: 0x000474BC
		// (set) Token: 0x06002593 RID: 9619 RVA: 0x000492DC File Offset: 0x000474DC
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

		// Token: 0x06002594 RID: 9620 RVA: 0x00049320 File Offset: 0x00047520
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06002595 RID: 9621 RVA: 0x00049338 File Offset: 0x00047538
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x06002596 RID: 9622 RVA: 0x00049344 File Offset: 0x00047544
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400094B RID: 2379
		private readonly List<ResWarGroupData> _groupdata = new List<ResWarGroupData>();

		// Token: 0x0400094C RID: 2380
		private ResWarTimeType? _timetype;

		// Token: 0x0400094D RID: 2381
		private uint? _lefttime;

		// Token: 0x0400094E RID: 2382
		private IExtension extensionObject;
	}
}
