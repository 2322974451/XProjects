using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006EC RID: 1772
	[ProtoContract(Name = "DoorState")]
	[Serializable]
	public class DoorState : IExtensible
	{
		// Token: 0x17002592 RID: 9618
		// (get) Token: 0x060076AB RID: 30379 RVA: 0x000E30B0 File Offset: 0x000E12B0
		// (set) Token: 0x060076AC RID: 30380 RVA: 0x000E30D1 File Offset: 0x000E12D1
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17002593 RID: 9619
		// (get) Token: 0x060076AD RID: 30381 RVA: 0x000E30DC File Offset: 0x000E12DC
		// (set) Token: 0x060076AE RID: 30382 RVA: 0x000E30F8 File Offset: 0x000E12F8
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x060076AF RID: 30383 RVA: 0x000E3128 File Offset: 0x000E1328
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060076B0 RID: 30384 RVA: 0x000E3140 File Offset: 0x000E1340
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002594 RID: 9620
		// (get) Token: 0x060076B1 RID: 30385 RVA: 0x000E314C File Offset: 0x000E134C
		// (set) Token: 0x060076B2 RID: 30386 RVA: 0x000E3178 File Offset: 0x000E1378
		[ProtoMember(2, IsRequired = false, Name = "isOn", DataFormat = DataFormat.Default)]
		public bool isOn
		{
			get
			{
				return this._isOn ?? false;
			}
			set
			{
				this._isOn = new bool?(value);
			}
		}

		// Token: 0x17002595 RID: 9621
		// (get) Token: 0x060076B3 RID: 30387 RVA: 0x000E3188 File Offset: 0x000E1388
		// (set) Token: 0x060076B4 RID: 30388 RVA: 0x000E31A8 File Offset: 0x000E13A8
		[XmlIgnore]
		[Browsable(false)]
		public bool isOnSpecified
		{
			get
			{
				return this._isOn != null;
			}
			set
			{
				bool flag = value == (this._isOn == null);
				if (flag)
				{
					this._isOn = (value ? new bool?(this.isOn) : null);
				}
			}
		}

		// Token: 0x060076B5 RID: 30389 RVA: 0x000E31EC File Offset: 0x000E13EC
		private bool ShouldSerializeisOn()
		{
			return this.isOnSpecified;
		}

		// Token: 0x060076B6 RID: 30390 RVA: 0x000E3204 File Offset: 0x000E1404
		private void ResetisOn()
		{
			this.isOnSpecified = false;
		}

		// Token: 0x060076B7 RID: 30391 RVA: 0x000E3210 File Offset: 0x000E1410
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C1C RID: 7196
		private string _name;

		// Token: 0x04001C1D RID: 7197
		private bool? _isOn;

		// Token: 0x04001C1E RID: 7198
		private IExtension extensionObject;
	}
}
