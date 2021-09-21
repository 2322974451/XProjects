using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000564 RID: 1380
	[ProtoContract(Name = "ItemJade")]
	[Serializable]
	public class ItemJade : IExtensible
	{
		// Token: 0x170015B7 RID: 5559
		// (get) Token: 0x060046FF RID: 18175 RVA: 0x00086E3C File Offset: 0x0008503C
		// (set) Token: 0x06004700 RID: 18176 RVA: 0x00086E68 File Offset: 0x00085068
		[ProtoMember(1, IsRequired = false, Name = "SlotInfo", DataFormat = DataFormat.TwosComplement)]
		public uint SlotInfo
		{
			get
			{
				return this._SlotInfo ?? 0U;
			}
			set
			{
				this._SlotInfo = new uint?(value);
			}
		}

		// Token: 0x170015B8 RID: 5560
		// (get) Token: 0x06004701 RID: 18177 RVA: 0x00086E78 File Offset: 0x00085078
		// (set) Token: 0x06004702 RID: 18178 RVA: 0x00086E98 File Offset: 0x00085098
		[XmlIgnore]
		[Browsable(false)]
		public bool SlotInfoSpecified
		{
			get
			{
				return this._SlotInfo != null;
			}
			set
			{
				bool flag = value == (this._SlotInfo == null);
				if (flag)
				{
					this._SlotInfo = (value ? new uint?(this.SlotInfo) : null);
				}
			}
		}

		// Token: 0x06004703 RID: 18179 RVA: 0x00086EDC File Offset: 0x000850DC
		private bool ShouldSerializeSlotInfo()
		{
			return this.SlotInfoSpecified;
		}

		// Token: 0x06004704 RID: 18180 RVA: 0x00086EF4 File Offset: 0x000850F4
		private void ResetSlotInfo()
		{
			this.SlotInfoSpecified = false;
		}

		// Token: 0x170015B9 RID: 5561
		// (get) Token: 0x06004705 RID: 18181 RVA: 0x00086F00 File Offset: 0x00085100
		[ProtoMember(2, Name = "ItemJadeSingle", DataFormat = DataFormat.Default)]
		public List<ItemJadeSingle> ItemJadeSingle
		{
			get
			{
				return this._ItemJadeSingle;
			}
		}

		// Token: 0x06004706 RID: 18182 RVA: 0x00086F18 File Offset: 0x00085118
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011B7 RID: 4535
		private uint? _SlotInfo;

		// Token: 0x040011B8 RID: 4536
		private readonly List<ItemJadeSingle> _ItemJadeSingle = new List<ItemJadeSingle>();

		// Token: 0x040011B9 RID: 4537
		private IExtension extensionObject;
	}
}
