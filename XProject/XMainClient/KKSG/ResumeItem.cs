using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000641 RID: 1601
	[ProtoContract(Name = "ResumeItem")]
	[Serializable]
	public class ResumeItem : IExtensible
	{
		// Token: 0x17001F53 RID: 8019
		// (get) Token: 0x06006366 RID: 25446 RVA: 0x000BDB8C File Offset: 0x000BBD8C
		// (set) Token: 0x06006367 RID: 25447 RVA: 0x000BDBB8 File Offset: 0x000BBDB8
		[ProtoMember(1, IsRequired = false, Name = "dtime", DataFormat = DataFormat.TwosComplement)]
		public uint dtime
		{
			get
			{
				return this._dtime ?? 0U;
			}
			set
			{
				this._dtime = new uint?(value);
			}
		}

		// Token: 0x17001F54 RID: 8020
		// (get) Token: 0x06006368 RID: 25448 RVA: 0x000BDBC8 File Offset: 0x000BBDC8
		// (set) Token: 0x06006369 RID: 25449 RVA: 0x000BDBE8 File Offset: 0x000BBDE8
		[XmlIgnore]
		[Browsable(false)]
		public bool dtimeSpecified
		{
			get
			{
				return this._dtime != null;
			}
			set
			{
				bool flag = value == (this._dtime == null);
				if (flag)
				{
					this._dtime = (value ? new uint?(this.dtime) : null);
				}
			}
		}

		// Token: 0x0600636A RID: 25450 RVA: 0x000BDC2C File Offset: 0x000BBE2C
		private bool ShouldSerializedtime()
		{
			return this.dtimeSpecified;
		}

		// Token: 0x0600636B RID: 25451 RVA: 0x000BDC44 File Offset: 0x000BBE44
		private void Resetdtime()
		{
			this.dtimeSpecified = false;
		}

		// Token: 0x17001F55 RID: 8021
		// (get) Token: 0x0600636C RID: 25452 RVA: 0x000BDC50 File Offset: 0x000BBE50
		// (set) Token: 0x0600636D RID: 25453 RVA: 0x000BDC68 File Offset: 0x000BBE68
		[ProtoMember(2, IsRequired = false, Name = "equip", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Item equip
		{
			get
			{
				return this._equip;
			}
			set
			{
				this._equip = value;
			}
		}

		// Token: 0x0600636E RID: 25454 RVA: 0x000BDC74 File Offset: 0x000BBE74
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001813 RID: 6163
		private uint? _dtime;

		// Token: 0x04001814 RID: 6164
		private Item _equip = null;

		// Token: 0x04001815 RID: 6165
		private IExtension extensionObject;
	}
}
