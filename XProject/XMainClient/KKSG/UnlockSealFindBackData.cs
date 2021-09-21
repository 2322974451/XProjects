using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000610 RID: 1552
	[ProtoContract(Name = "UnlockSealFindBackData")]
	[Serializable]
	public class UnlockSealFindBackData : IExtensible
	{
		// Token: 0x17001D6C RID: 7532
		// (get) Token: 0x06005DCC RID: 24012 RVA: 0x000B2C78 File Offset: 0x000B0E78
		// (set) Token: 0x06005DCD RID: 24013 RVA: 0x000B2CA4 File Offset: 0x000B0EA4
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.Default)]
		public bool state
		{
			get
			{
				return this._state ?? false;
			}
			set
			{
				this._state = new bool?(value);
			}
		}

		// Token: 0x17001D6D RID: 7533
		// (get) Token: 0x06005DCE RID: 24014 RVA: 0x000B2CB4 File Offset: 0x000B0EB4
		// (set) Token: 0x06005DCF RID: 24015 RVA: 0x000B2CD4 File Offset: 0x000B0ED4
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new bool?(this.state) : null);
				}
			}
		}

		// Token: 0x06005DD0 RID: 24016 RVA: 0x000B2D18 File Offset: 0x000B0F18
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06005DD1 RID: 24017 RVA: 0x000B2D30 File Offset: 0x000B0F30
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17001D6E RID: 7534
		// (get) Token: 0x06005DD2 RID: 24018 RVA: 0x000B2D3C File Offset: 0x000B0F3C
		// (set) Token: 0x06005DD3 RID: 24019 RVA: 0x000B2D68 File Offset: 0x000B0F68
		[ProtoMember(2, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public int type
		{
			get
			{
				return this._type ?? 0;
			}
			set
			{
				this._type = new int?(value);
			}
		}

		// Token: 0x17001D6F RID: 7535
		// (get) Token: 0x06005DD4 RID: 24020 RVA: 0x000B2D78 File Offset: 0x000B0F78
		// (set) Token: 0x06005DD5 RID: 24021 RVA: 0x000B2D98 File Offset: 0x000B0F98
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new int?(this.type) : null);
				}
			}
		}

		// Token: 0x06005DD6 RID: 24022 RVA: 0x000B2DDC File Offset: 0x000B0FDC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06005DD7 RID: 24023 RVA: 0x000B2DF4 File Offset: 0x000B0FF4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001D70 RID: 7536
		// (get) Token: 0x06005DD8 RID: 24024 RVA: 0x000B2E00 File Offset: 0x000B1000
		// (set) Token: 0x06005DD9 RID: 24025 RVA: 0x000B2E2C File Offset: 0x000B102C
		[ProtoMember(3, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public int time
		{
			get
			{
				return this._time ?? 0;
			}
			set
			{
				this._time = new int?(value);
			}
		}

		// Token: 0x17001D71 RID: 7537
		// (get) Token: 0x06005DDA RID: 24026 RVA: 0x000B2E3C File Offset: 0x000B103C
		// (set) Token: 0x06005DDB RID: 24027 RVA: 0x000B2E5C File Offset: 0x000B105C
		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new int?(this.time) : null);
				}
			}
		}

		// Token: 0x06005DDC RID: 24028 RVA: 0x000B2EA0 File Offset: 0x000B10A0
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06005DDD RID: 24029 RVA: 0x000B2EB8 File Offset: 0x000B10B8
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06005DDE RID: 24030 RVA: 0x000B2EC4 File Offset: 0x000B10C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016CB RID: 5835
		private bool? _state;

		// Token: 0x040016CC RID: 5836
		private int? _type;

		// Token: 0x040016CD RID: 5837
		private int? _time;

		// Token: 0x040016CE RID: 5838
		private IExtension extensionObject;
	}
}
