using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000274 RID: 628
	[ProtoContract(Name = "DPSNotify")]
	[Serializable]
	public class DPSNotify : IExtensible
	{
		// Token: 0x17000ADC RID: 2780
		// (get) Token: 0x060022EB RID: 8939 RVA: 0x00044314 File Offset: 0x00042514
		// (set) Token: 0x060022EC RID: 8940 RVA: 0x00044344 File Offset: 0x00042544
		[ProtoMember(1, IsRequired = false, Name = "dps", DataFormat = DataFormat.FixedSize)]
		public float dps
		{
			get
			{
				return this._dps ?? 0f;
			}
			set
			{
				this._dps = new float?(value);
			}
		}

		// Token: 0x17000ADD RID: 2781
		// (get) Token: 0x060022ED RID: 8941 RVA: 0x00044354 File Offset: 0x00042554
		// (set) Token: 0x060022EE RID: 8942 RVA: 0x00044374 File Offset: 0x00042574
		[XmlIgnore]
		[Browsable(false)]
		public bool dpsSpecified
		{
			get
			{
				return this._dps != null;
			}
			set
			{
				bool flag = value == (this._dps == null);
				if (flag)
				{
					this._dps = (value ? new float?(this.dps) : null);
				}
			}
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x000443B8 File Offset: 0x000425B8
		private bool ShouldSerializedps()
		{
			return this.dpsSpecified;
		}

		// Token: 0x060022F0 RID: 8944 RVA: 0x000443D0 File Offset: 0x000425D0
		private void Resetdps()
		{
			this.dpsSpecified = false;
		}

		// Token: 0x060022F1 RID: 8945 RVA: 0x000443DC File Offset: 0x000425DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040008AB RID: 2219
		private float? _dps;

		// Token: 0x040008AC RID: 2220
		private IExtension extensionObject;
	}
}
