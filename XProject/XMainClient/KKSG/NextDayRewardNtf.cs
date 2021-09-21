using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000C6 RID: 198
	[ProtoContract(Name = "NextDayRewardNtf")]
	[Serializable]
	public class NextDayRewardNtf : IExtensible
	{
		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06000D15 RID: 3349 RVA: 0x0001B6C0 File Offset: 0x000198C0
		// (set) Token: 0x06000D16 RID: 3350 RVA: 0x0001B6EC File Offset: 0x000198EC
		[ProtoMember(1, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public uint state
		{
			get
			{
				return this._state ?? 0U;
			}
			set
			{
				this._state = new uint?(value);
			}
		}

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000D17 RID: 3351 RVA: 0x0001B6FC File Offset: 0x000198FC
		// (set) Token: 0x06000D18 RID: 3352 RVA: 0x0001B71C File Offset: 0x0001991C
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
					this._state = (value ? new uint?(this.state) : null);
				}
			}
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x0001B760 File Offset: 0x00019960
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x0001B778 File Offset: 0x00019978
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x0001B784 File Offset: 0x00019984
		// (set) Token: 0x06000D1C RID: 3356 RVA: 0x0001B7B0 File Offset: 0x000199B0
		[ProtoMember(2, IsRequired = false, Name = "timeleft", DataFormat = DataFormat.TwosComplement)]
		public uint timeleft
		{
			get
			{
				return this._timeleft ?? 0U;
			}
			set
			{
				this._timeleft = new uint?(value);
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x0001B7C0 File Offset: 0x000199C0
		// (set) Token: 0x06000D1E RID: 3358 RVA: 0x0001B7E0 File Offset: 0x000199E0
		[XmlIgnore]
		[Browsable(false)]
		public bool timeleftSpecified
		{
			get
			{
				return this._timeleft != null;
			}
			set
			{
				bool flag = value == (this._timeleft == null);
				if (flag)
				{
					this._timeleft = (value ? new uint?(this.timeleft) : null);
				}
			}
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x0001B824 File Offset: 0x00019A24
		private bool ShouldSerializetimeleft()
		{
			return this.timeleftSpecified;
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x0001B83C File Offset: 0x00019A3C
		private void Resettimeleft()
		{
			this.timeleftSpecified = false;
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x0001B848 File Offset: 0x00019A48
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000348 RID: 840
		private uint? _state;

		// Token: 0x04000349 RID: 841
		private uint? _timeleft;

		// Token: 0x0400034A RID: 842
		private IExtension extensionObject;
	}
}
