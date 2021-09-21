using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A5 RID: 1701
	[ProtoContract(Name = "CardAttr")]
	[Serializable]
	public class CardAttr : IExtensible
	{
		// Token: 0x1700231D RID: 8989
		// (get) Token: 0x06006EEB RID: 28395 RVA: 0x000D4418 File Offset: 0x000D2618
		// (set) Token: 0x06006EEC RID: 28396 RVA: 0x000D4444 File Offset: 0x000D2644
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x1700231E RID: 8990
		// (get) Token: 0x06006EED RID: 28397 RVA: 0x000D4454 File Offset: 0x000D2654
		// (set) Token: 0x06006EEE RID: 28398 RVA: 0x000D4474 File Offset: 0x000D2674
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x06006EEF RID: 28399 RVA: 0x000D44B8 File Offset: 0x000D26B8
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06006EF0 RID: 28400 RVA: 0x000D44D0 File Offset: 0x000D26D0
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x1700231F RID: 8991
		// (get) Token: 0x06006EF1 RID: 28401 RVA: 0x000D44DC File Offset: 0x000D26DC
		// (set) Token: 0x06006EF2 RID: 28402 RVA: 0x000D4508 File Offset: 0x000D2708
		[ProtoMember(2, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
		public uint num
		{
			get
			{
				return this._num ?? 0U;
			}
			set
			{
				this._num = new uint?(value);
			}
		}

		// Token: 0x17002320 RID: 8992
		// (get) Token: 0x06006EF3 RID: 28403 RVA: 0x000D4518 File Offset: 0x000D2718
		// (set) Token: 0x06006EF4 RID: 28404 RVA: 0x000D4538 File Offset: 0x000D2738
		[XmlIgnore]
		[Browsable(false)]
		public bool numSpecified
		{
			get
			{
				return this._num != null;
			}
			set
			{
				bool flag = value == (this._num == null);
				if (flag)
				{
					this._num = (value ? new uint?(this.num) : null);
				}
			}
		}

		// Token: 0x06006EF5 RID: 28405 RVA: 0x000D457C File Offset: 0x000D277C
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x06006EF6 RID: 28406 RVA: 0x000D4594 File Offset: 0x000D2794
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x06006EF7 RID: 28407 RVA: 0x000D45A0 File Offset: 0x000D27A0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A8B RID: 6795
		private uint? _id;

		// Token: 0x04001A8C RID: 6796
		private uint? _num;

		// Token: 0x04001A8D RID: 6797
		private IExtension extensionObject;
	}
}
