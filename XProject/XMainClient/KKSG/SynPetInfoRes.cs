using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001CC RID: 460
	[ProtoContract(Name = "SynPetInfoRes")]
	[Serializable]
	public class SynPetInfoRes : IExtensible
	{
		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x06001AE6 RID: 6886 RVA: 0x00035390 File Offset: 0x00033590
		// (set) Token: 0x06001AE7 RID: 6887 RVA: 0x000353BC File Offset: 0x000335BC
		[ProtoMember(1, IsRequired = false, Name = "mood", DataFormat = DataFormat.TwosComplement)]
		public uint mood
		{
			get
			{
				return this._mood ?? 0U;
			}
			set
			{
				this._mood = new uint?(value);
			}
		}

		// Token: 0x17000879 RID: 2169
		// (get) Token: 0x06001AE8 RID: 6888 RVA: 0x000353CC File Offset: 0x000335CC
		// (set) Token: 0x06001AE9 RID: 6889 RVA: 0x000353EC File Offset: 0x000335EC
		[XmlIgnore]
		[Browsable(false)]
		public bool moodSpecified
		{
			get
			{
				return this._mood != null;
			}
			set
			{
				bool flag = value == (this._mood == null);
				if (flag)
				{
					this._mood = (value ? new uint?(this.mood) : null);
				}
			}
		}

		// Token: 0x06001AEA RID: 6890 RVA: 0x00035430 File Offset: 0x00033630
		private bool ShouldSerializemood()
		{
			return this.moodSpecified;
		}

		// Token: 0x06001AEB RID: 6891 RVA: 0x00035448 File Offset: 0x00033648
		private void Resetmood()
		{
			this.moodSpecified = false;
		}

		// Token: 0x1700087A RID: 2170
		// (get) Token: 0x06001AEC RID: 6892 RVA: 0x00035454 File Offset: 0x00033654
		// (set) Token: 0x06001AED RID: 6893 RVA: 0x00035480 File Offset: 0x00033680
		[ProtoMember(2, IsRequired = false, Name = "hungry", DataFormat = DataFormat.TwosComplement)]
		public uint hungry
		{
			get
			{
				return this._hungry ?? 0U;
			}
			set
			{
				this._hungry = new uint?(value);
			}
		}

		// Token: 0x1700087B RID: 2171
		// (get) Token: 0x06001AEE RID: 6894 RVA: 0x00035490 File Offset: 0x00033690
		// (set) Token: 0x06001AEF RID: 6895 RVA: 0x000354B0 File Offset: 0x000336B0
		[XmlIgnore]
		[Browsable(false)]
		public bool hungrySpecified
		{
			get
			{
				return this._hungry != null;
			}
			set
			{
				bool flag = value == (this._hungry == null);
				if (flag)
				{
					this._hungry = (value ? new uint?(this.hungry) : null);
				}
			}
		}

		// Token: 0x06001AF0 RID: 6896 RVA: 0x000354F4 File Offset: 0x000336F4
		private bool ShouldSerializehungry()
		{
			return this.hungrySpecified;
		}

		// Token: 0x06001AF1 RID: 6897 RVA: 0x0003550C File Offset: 0x0003370C
		private void Resethungry()
		{
			this.hungrySpecified = false;
		}

		// Token: 0x06001AF2 RID: 6898 RVA: 0x00035518 File Offset: 0x00033718
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006B0 RID: 1712
		private uint? _mood;

		// Token: 0x040006B1 RID: 1713
		private uint? _hungry;

		// Token: 0x040006B2 RID: 1714
		private IExtension extensionObject;
	}
}
