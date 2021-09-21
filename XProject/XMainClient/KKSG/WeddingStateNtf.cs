using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000481 RID: 1153
	[ProtoContract(Name = "WeddingStateNtf")]
	[Serializable]
	public class WeddingStateNtf : IExtensible
	{
		// Token: 0x17001277 RID: 4727
		// (get) Token: 0x06003C32 RID: 15410 RVA: 0x00072FCC File Offset: 0x000711CC
		// (set) Token: 0x06003C33 RID: 15411 RVA: 0x00072FF8 File Offset: 0x000711F8
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public WeddingState state
		{
			get
			{
				return this._state ?? WeddingState.WeddingState_Prepare;
			}
			set
			{
				this._state = new WeddingState?(value);
			}
		}

		// Token: 0x17001278 RID: 4728
		// (get) Token: 0x06003C34 RID: 15412 RVA: 0x00073008 File Offset: 0x00071208
		// (set) Token: 0x06003C35 RID: 15413 RVA: 0x00073028 File Offset: 0x00071228
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
					this._state = (value ? new WeddingState?(this.state) : null);
				}
			}
		}

		// Token: 0x06003C36 RID: 15414 RVA: 0x0007306C File Offset: 0x0007126C
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06003C37 RID: 15415 RVA: 0x00073084 File Offset: 0x00071284
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17001279 RID: 4729
		// (get) Token: 0x06003C38 RID: 15416 RVA: 0x00073090 File Offset: 0x00071290
		// (set) Token: 0x06003C39 RID: 15417 RVA: 0x000730BC File Offset: 0x000712BC
		[ProtoMember(2, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700127A RID: 4730
		// (get) Token: 0x06003C3A RID: 15418 RVA: 0x000730CC File Offset: 0x000712CC
		// (set) Token: 0x06003C3B RID: 15419 RVA: 0x000730EC File Offset: 0x000712EC
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

		// Token: 0x06003C3C RID: 15420 RVA: 0x00073130 File Offset: 0x00071330
		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		// Token: 0x06003C3D RID: 15421 RVA: 0x00073148 File Offset: 0x00071348
		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		// Token: 0x1700127B RID: 4731
		// (get) Token: 0x06003C3E RID: 15422 RVA: 0x00073154 File Offset: 0x00071354
		// (set) Token: 0x06003C3F RID: 15423 RVA: 0x00073180 File Offset: 0x00071380
		[ProtoMember(3, IsRequired = false, Name = "happyness", DataFormat = DataFormat.TwosComplement)]
		public uint happyness
		{
			get
			{
				return this._happyness ?? 0U;
			}
			set
			{
				this._happyness = new uint?(value);
			}
		}

		// Token: 0x1700127C RID: 4732
		// (get) Token: 0x06003C40 RID: 15424 RVA: 0x00073190 File Offset: 0x00071390
		// (set) Token: 0x06003C41 RID: 15425 RVA: 0x000731B0 File Offset: 0x000713B0
		[XmlIgnore]
		[Browsable(false)]
		public bool happynessSpecified
		{
			get
			{
				return this._happyness != null;
			}
			set
			{
				bool flag = value == (this._happyness == null);
				if (flag)
				{
					this._happyness = (value ? new uint?(this.happyness) : null);
				}
			}
		}

		// Token: 0x06003C42 RID: 15426 RVA: 0x000731F4 File Offset: 0x000713F4
		private bool ShouldSerializehappyness()
		{
			return this.happynessSpecified;
		}

		// Token: 0x06003C43 RID: 15427 RVA: 0x0007320C File Offset: 0x0007140C
		private void Resethappyness()
		{
			this.happynessSpecified = false;
		}

		// Token: 0x1700127D RID: 4733
		// (get) Token: 0x06003C44 RID: 15428 RVA: 0x00073218 File Offset: 0x00071418
		// (set) Token: 0x06003C45 RID: 15429 RVA: 0x00073244 File Offset: 0x00071444
		[ProtoMember(4, IsRequired = false, Name = "vows", DataFormat = DataFormat.Default)]
		public bool vows
		{
			get
			{
				return this._vows ?? false;
			}
			set
			{
				this._vows = new bool?(value);
			}
		}

		// Token: 0x1700127E RID: 4734
		// (get) Token: 0x06003C46 RID: 15430 RVA: 0x00073254 File Offset: 0x00071454
		// (set) Token: 0x06003C47 RID: 15431 RVA: 0x00073274 File Offset: 0x00071474
		[XmlIgnore]
		[Browsable(false)]
		public bool vowsSpecified
		{
			get
			{
				return this._vows != null;
			}
			set
			{
				bool flag = value == (this._vows == null);
				if (flag)
				{
					this._vows = (value ? new bool?(this.vows) : null);
				}
			}
		}

		// Token: 0x06003C48 RID: 15432 RVA: 0x000732B8 File Offset: 0x000714B8
		private bool ShouldSerializevows()
		{
			return this.vowsSpecified;
		}

		// Token: 0x06003C49 RID: 15433 RVA: 0x000732D0 File Offset: 0x000714D0
		private void Resetvows()
		{
			this.vowsSpecified = false;
		}

		// Token: 0x06003C4A RID: 15434 RVA: 0x000732DC File Offset: 0x000714DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000EFF RID: 3839
		private WeddingState? _state;

		// Token: 0x04000F00 RID: 3840
		private uint? _lefttime;

		// Token: 0x04000F01 RID: 3841
		private uint? _happyness;

		// Token: 0x04000F02 RID: 3842
		private bool? _vows;

		// Token: 0x04000F03 RID: 3843
		private IExtension extensionObject;
	}
}
