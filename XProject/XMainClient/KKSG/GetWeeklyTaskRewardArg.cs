using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E1 RID: 1249
	[ProtoContract(Name = "GetWeeklyTaskRewardArg")]
	[Serializable]
	public class GetWeeklyTaskRewardArg : IExtensible
	{
		// Token: 0x170013C3 RID: 5059
		// (get) Token: 0x06004090 RID: 16528 RVA: 0x0007AF3C File Offset: 0x0007913C
		// (set) Token: 0x06004091 RID: 16529 RVA: 0x0007AF68 File Offset: 0x00079168
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170013C4 RID: 5060
		// (get) Token: 0x06004092 RID: 16530 RVA: 0x0007AF78 File Offset: 0x00079178
		// (set) Token: 0x06004093 RID: 16531 RVA: 0x0007AF98 File Offset: 0x00079198
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06004094 RID: 16532 RVA: 0x0007AFDC File Offset: 0x000791DC
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06004095 RID: 16533 RVA: 0x0007AFF4 File Offset: 0x000791F4
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170013C5 RID: 5061
		// (get) Token: 0x06004096 RID: 16534 RVA: 0x0007B000 File Offset: 0x00079200
		// (set) Token: 0x06004097 RID: 16535 RVA: 0x0007B02C File Offset: 0x0007922C
		[ProtoMember(2, IsRequired = false, Name = "value", DataFormat = DataFormat.TwosComplement)]
		public uint value
		{
			get
			{
				return this._value ?? 0U;
			}
			set
			{
				this._value = new uint?(value);
			}
		}

		// Token: 0x170013C6 RID: 5062
		// (get) Token: 0x06004098 RID: 16536 RVA: 0x0007B03C File Offset: 0x0007923C
		// (set) Token: 0x06004099 RID: 16537 RVA: 0x0007B05C File Offset: 0x0007925C
		[XmlIgnore]
		[Browsable(false)]
		public bool valueSpecified
		{
			get
			{
				return this._value != null;
			}
			set
			{
				bool flag = value == (this._value == null);
				if (flag)
				{
					this._value = (value ? new uint?(this.value) : null);
				}
			}
		}

		// Token: 0x0600409A RID: 16538 RVA: 0x0007B0A0 File Offset: 0x000792A0
		private bool ShouldSerializevalue()
		{
			return this.valueSpecified;
		}

		// Token: 0x0600409B RID: 16539 RVA: 0x0007B0B8 File Offset: 0x000792B8
		private void Resetvalue()
		{
			this.valueSpecified = false;
		}

		// Token: 0x0600409C RID: 16540 RVA: 0x0007B0C4 File Offset: 0x000792C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001018 RID: 4120
		private uint? _type;

		// Token: 0x04001019 RID: 4121
		private uint? _value;

		// Token: 0x0400101A RID: 4122
		private IExtension extensionObject;
	}
}
