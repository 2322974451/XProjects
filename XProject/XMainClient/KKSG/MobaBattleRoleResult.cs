using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005DB RID: 1499
	[ProtoContract(Name = "MobaBattleRoleResult")]
	[Serializable]
	public class MobaBattleRoleResult : IExtensible
	{
		// Token: 0x17001ABE RID: 6846
		// (get) Token: 0x06005628 RID: 22056 RVA: 0x000A4068 File Offset: 0x000A2268
		// (set) Token: 0x06005629 RID: 22057 RVA: 0x000A4094 File Offset: 0x000A2294
		[ProtoMember(1, IsRequired = false, Name = "isWin", DataFormat = DataFormat.Default)]
		public bool isWin
		{
			get
			{
				return this._isWin ?? false;
			}
			set
			{
				this._isWin = new bool?(value);
			}
		}

		// Token: 0x17001ABF RID: 6847
		// (get) Token: 0x0600562A RID: 22058 RVA: 0x000A40A4 File Offset: 0x000A22A4
		// (set) Token: 0x0600562B RID: 22059 RVA: 0x000A40C4 File Offset: 0x000A22C4
		[XmlIgnore]
		[Browsable(false)]
		public bool isWinSpecified
		{
			get
			{
				return this._isWin != null;
			}
			set
			{
				bool flag = value == (this._isWin == null);
				if (flag)
				{
					this._isWin = (value ? new bool?(this.isWin) : null);
				}
			}
		}

		// Token: 0x0600562C RID: 22060 RVA: 0x000A4108 File Offset: 0x000A2308
		private bool ShouldSerializeisWin()
		{
			return this.isWinSpecified;
		}

		// Token: 0x0600562D RID: 22061 RVA: 0x000A4120 File Offset: 0x000A2320
		private void ResetisWin()
		{
			this.isWinSpecified = false;
		}

		// Token: 0x17001AC0 RID: 6848
		// (get) Token: 0x0600562E RID: 22062 RVA: 0x000A412C File Offset: 0x000A232C
		// (set) Token: 0x0600562F RID: 22063 RVA: 0x000A4158 File Offset: 0x000A2358
		[ProtoMember(2, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		// Token: 0x17001AC1 RID: 6849
		// (get) Token: 0x06005630 RID: 22064 RVA: 0x000A4168 File Offset: 0x000A2368
		// (set) Token: 0x06005631 RID: 22065 RVA: 0x000A4188 File Offset: 0x000A2388
		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		// Token: 0x06005632 RID: 22066 RVA: 0x000A41CC File Offset: 0x000A23CC
		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		// Token: 0x06005633 RID: 22067 RVA: 0x000A41E4 File Offset: 0x000A23E4
		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		// Token: 0x17001AC2 RID: 6850
		// (get) Token: 0x06005634 RID: 22068 RVA: 0x000A41F0 File Offset: 0x000A23F0
		// (set) Token: 0x06005635 RID: 22069 RVA: 0x000A4220 File Offset: 0x000A2420
		[ProtoMember(3, IsRequired = false, Name = "kda", DataFormat = DataFormat.FixedSize)]
		public float kda
		{
			get
			{
				return this._kda ?? 0f;
			}
			set
			{
				this._kda = new float?(value);
			}
		}

		// Token: 0x17001AC3 RID: 6851
		// (get) Token: 0x06005636 RID: 22070 RVA: 0x000A4230 File Offset: 0x000A2430
		// (set) Token: 0x06005637 RID: 22071 RVA: 0x000A4250 File Offset: 0x000A2450
		[XmlIgnore]
		[Browsable(false)]
		public bool kdaSpecified
		{
			get
			{
				return this._kda != null;
			}
			set
			{
				bool flag = value == (this._kda == null);
				if (flag)
				{
					this._kda = (value ? new float?(this.kda) : null);
				}
			}
		}

		// Token: 0x06005638 RID: 22072 RVA: 0x000A4294 File Offset: 0x000A2494
		private bool ShouldSerializekda()
		{
			return this.kdaSpecified;
		}

		// Token: 0x06005639 RID: 22073 RVA: 0x000A42AC File Offset: 0x000A24AC
		private void Resetkda()
		{
			this.kdaSpecified = false;
		}

		// Token: 0x17001AC4 RID: 6852
		// (get) Token: 0x0600563A RID: 22074 RVA: 0x000A42B8 File Offset: 0x000A24B8
		// (set) Token: 0x0600563B RID: 22075 RVA: 0x000A42E4 File Offset: 0x000A24E4
		[ProtoMember(4, IsRequired = false, Name = "isescape", DataFormat = DataFormat.Default)]
		public bool isescape
		{
			get
			{
				return this._isescape ?? false;
			}
			set
			{
				this._isescape = new bool?(value);
			}
		}

		// Token: 0x17001AC5 RID: 6853
		// (get) Token: 0x0600563C RID: 22076 RVA: 0x000A42F4 File Offset: 0x000A24F4
		// (set) Token: 0x0600563D RID: 22077 RVA: 0x000A4314 File Offset: 0x000A2514
		[XmlIgnore]
		[Browsable(false)]
		public bool isescapeSpecified
		{
			get
			{
				return this._isescape != null;
			}
			set
			{
				bool flag = value == (this._isescape == null);
				if (flag)
				{
					this._isescape = (value ? new bool?(this.isescape) : null);
				}
			}
		}

		// Token: 0x0600563E RID: 22078 RVA: 0x000A4358 File Offset: 0x000A2558
		private bool ShouldSerializeisescape()
		{
			return this.isescapeSpecified;
		}

		// Token: 0x0600563F RID: 22079 RVA: 0x000A4370 File Offset: 0x000A2570
		private void Resetisescape()
		{
			this.isescapeSpecified = false;
		}

		// Token: 0x17001AC6 RID: 6854
		// (get) Token: 0x06005640 RID: 22080 RVA: 0x000A437C File Offset: 0x000A257C
		[ProtoMember(5, Name = "winreward", DataFormat = DataFormat.Default)]
		public List<ItemBrief> winreward
		{
			get
			{
				return this._winreward;
			}
		}

		// Token: 0x06005641 RID: 22081 RVA: 0x000A4394 File Offset: 0x000A2594
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040014F9 RID: 5369
		private bool? _isWin;

		// Token: 0x040014FA RID: 5370
		private uint? _heroid;

		// Token: 0x040014FB RID: 5371
		private float? _kda;

		// Token: 0x040014FC RID: 5372
		private bool? _isescape;

		// Token: 0x040014FD RID: 5373
		private readonly List<ItemBrief> _winreward = new List<ItemBrief>();

		// Token: 0x040014FE RID: 5374
		private IExtension extensionObject;
	}
}
