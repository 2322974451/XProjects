using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200001D RID: 29
	[ProtoContract(Name = "AchivementInfo")]
	[Serializable]
	public class AchivementInfo : IExtensible
	{
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000249 RID: 585 RVA: 0x00007160 File Offset: 0x00005360
		// (set) Token: 0x0600024A RID: 586 RVA: 0x0000718C File Offset: 0x0000538C
		[ProtoMember(1, IsRequired = false, Name = "achivementID", DataFormat = DataFormat.TwosComplement)]
		public uint achivementID
		{
			get
			{
				return this._achivementID ?? 0U;
			}
			set
			{
				this._achivementID = new uint?(value);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600024B RID: 587 RVA: 0x0000719C File Offset: 0x0000539C
		// (set) Token: 0x0600024C RID: 588 RVA: 0x000071BC File Offset: 0x000053BC
		[XmlIgnore]
		[Browsable(false)]
		public bool achivementIDSpecified
		{
			get
			{
				return this._achivementID != null;
			}
			set
			{
				bool flag = value == (this._achivementID == null);
				if (flag)
				{
					this._achivementID = (value ? new uint?(this.achivementID) : null);
				}
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00007200 File Offset: 0x00005400
		private bool ShouldSerializeachivementID()
		{
			return this.achivementIDSpecified;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00007218 File Offset: 0x00005418
		private void ResetachivementID()
		{
			this.achivementIDSpecified = false;
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600024F RID: 591 RVA: 0x00007224 File Offset: 0x00005424
		// (set) Token: 0x06000250 RID: 592 RVA: 0x00007250 File Offset: 0x00005450
		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000251 RID: 593 RVA: 0x00007260 File Offset: 0x00005460
		// (set) Token: 0x06000252 RID: 594 RVA: 0x00007280 File Offset: 0x00005480
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

		// Token: 0x06000253 RID: 595 RVA: 0x000072C4 File Offset: 0x000054C4
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000072DC File Offset: 0x000054DC
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x000072E8 File Offset: 0x000054E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400009D RID: 157
		private uint? _achivementID;

		// Token: 0x0400009E RID: 158
		private uint? _state;

		// Token: 0x0400009F RID: 159
		private IExtension extensionObject;
	}
}
