using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000733 RID: 1843
	[ProtoContract(Name = "GoalAwardsValue")]
	[Serializable]
	public class GoalAwardsValue : IExtensible
	{
		// Token: 0x17002874 RID: 10356
		// (get) Token: 0x06007F95 RID: 32661 RVA: 0x000F3FC0 File Offset: 0x000F21C0
		// (set) Token: 0x06007F96 RID: 32662 RVA: 0x000F3FEC File Offset: 0x000F21EC
		[ProtoMember(1, IsRequired = false, Name = "gkid", DataFormat = DataFormat.TwosComplement)]
		public uint gkid
		{
			get
			{
				return this._gkid ?? 0U;
			}
			set
			{
				this._gkid = new uint?(value);
			}
		}

		// Token: 0x17002875 RID: 10357
		// (get) Token: 0x06007F97 RID: 32663 RVA: 0x000F3FFC File Offset: 0x000F21FC
		// (set) Token: 0x06007F98 RID: 32664 RVA: 0x000F401C File Offset: 0x000F221C
		[XmlIgnore]
		[Browsable(false)]
		public bool gkidSpecified
		{
			get
			{
				return this._gkid != null;
			}
			set
			{
				bool flag = value == (this._gkid == null);
				if (flag)
				{
					this._gkid = (value ? new uint?(this.gkid) : null);
				}
			}
		}

		// Token: 0x06007F99 RID: 32665 RVA: 0x000F4060 File Offset: 0x000F2260
		private bool ShouldSerializegkid()
		{
			return this.gkidSpecified;
		}

		// Token: 0x06007F9A RID: 32666 RVA: 0x000F4078 File Offset: 0x000F2278
		private void Resetgkid()
		{
			this.gkidSpecified = false;
		}

		// Token: 0x17002876 RID: 10358
		// (get) Token: 0x06007F9B RID: 32667 RVA: 0x000F4084 File Offset: 0x000F2284
		// (set) Token: 0x06007F9C RID: 32668 RVA: 0x000F40B8 File Offset: 0x000F22B8
		[ProtoMember(2, IsRequired = false, Name = "gkvalue", DataFormat = DataFormat.TwosComplement)]
		public double gkvalue
		{
			get
			{
				return this._gkvalue ?? 0.0;
			}
			set
			{
				this._gkvalue = new double?(value);
			}
		}

		// Token: 0x17002877 RID: 10359
		// (get) Token: 0x06007F9D RID: 32669 RVA: 0x000F40C8 File Offset: 0x000F22C8
		// (set) Token: 0x06007F9E RID: 32670 RVA: 0x000F40E8 File Offset: 0x000F22E8
		[XmlIgnore]
		[Browsable(false)]
		public bool gkvalueSpecified
		{
			get
			{
				return this._gkvalue != null;
			}
			set
			{
				bool flag = value == (this._gkvalue == null);
				if (flag)
				{
					this._gkvalue = (value ? new double?(this.gkvalue) : null);
				}
			}
		}

		// Token: 0x06007F9F RID: 32671 RVA: 0x000F412C File Offset: 0x000F232C
		private bool ShouldSerializegkvalue()
		{
			return this.gkvalueSpecified;
		}

		// Token: 0x06007FA0 RID: 32672 RVA: 0x000F4144 File Offset: 0x000F2344
		private void Resetgkvalue()
		{
			this.gkvalueSpecified = false;
		}

		// Token: 0x06007FA1 RID: 32673 RVA: 0x000F4150 File Offset: 0x000F2350
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001DED RID: 7661
		private uint? _gkid;

		// Token: 0x04001DEE RID: 7662
		private double? _gkvalue;

		// Token: 0x04001DEF RID: 7663
		private IExtension extensionObject;
	}
}
