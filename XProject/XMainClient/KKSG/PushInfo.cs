using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000658 RID: 1624
	[ProtoContract(Name = "PushInfo")]
	[Serializable]
	public class PushInfo : IExtensible
	{
		// Token: 0x17001FE4 RID: 8164
		// (get) Token: 0x06006513 RID: 25875 RVA: 0x000C0ED0 File Offset: 0x000BF0D0
		// (set) Token: 0x06006514 RID: 25876 RVA: 0x000C0EFC File Offset: 0x000BF0FC
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

		// Token: 0x17001FE5 RID: 8165
		// (get) Token: 0x06006515 RID: 25877 RVA: 0x000C0F0C File Offset: 0x000BF10C
		// (set) Token: 0x06006516 RID: 25878 RVA: 0x000C0F2C File Offset: 0x000BF12C
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

		// Token: 0x06006517 RID: 25879 RVA: 0x000C0F70 File Offset: 0x000BF170
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06006518 RID: 25880 RVA: 0x000C0F88 File Offset: 0x000BF188
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17001FE6 RID: 8166
		// (get) Token: 0x06006519 RID: 25881 RVA: 0x000C0F94 File Offset: 0x000BF194
		// (set) Token: 0x0600651A RID: 25882 RVA: 0x000C0FC0 File Offset: 0x000BF1C0
		[ProtoMember(2, IsRequired = false, Name = "sub_type", DataFormat = DataFormat.TwosComplement)]
		public uint sub_type
		{
			get
			{
				return this._sub_type ?? 0U;
			}
			set
			{
				this._sub_type = new uint?(value);
			}
		}

		// Token: 0x17001FE7 RID: 8167
		// (get) Token: 0x0600651B RID: 25883 RVA: 0x000C0FD0 File Offset: 0x000BF1D0
		// (set) Token: 0x0600651C RID: 25884 RVA: 0x000C0FF0 File Offset: 0x000BF1F0
		[XmlIgnore]
		[Browsable(false)]
		public bool sub_typeSpecified
		{
			get
			{
				return this._sub_type != null;
			}
			set
			{
				bool flag = value == (this._sub_type == null);
				if (flag)
				{
					this._sub_type = (value ? new uint?(this.sub_type) : null);
				}
			}
		}

		// Token: 0x0600651D RID: 25885 RVA: 0x000C1034 File Offset: 0x000BF234
		private bool ShouldSerializesub_type()
		{
			return this.sub_typeSpecified;
		}

		// Token: 0x0600651E RID: 25886 RVA: 0x000C104C File Offset: 0x000BF24C
		private void Resetsub_type()
		{
			this.sub_typeSpecified = false;
		}

		// Token: 0x17001FE8 RID: 8168
		// (get) Token: 0x0600651F RID: 25887 RVA: 0x000C1058 File Offset: 0x000BF258
		// (set) Token: 0x06006520 RID: 25888 RVA: 0x000C1084 File Offset: 0x000BF284
		[ProtoMember(3, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public uint time
		{
			get
			{
				return this._time ?? 0U;
			}
			set
			{
				this._time = new uint?(value);
			}
		}

		// Token: 0x17001FE9 RID: 8169
		// (get) Token: 0x06006521 RID: 25889 RVA: 0x000C1094 File Offset: 0x000BF294
		// (set) Token: 0x06006522 RID: 25890 RVA: 0x000C10B4 File Offset: 0x000BF2B4
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
					this._time = (value ? new uint?(this.time) : null);
				}
			}
		}

		// Token: 0x06006523 RID: 25891 RVA: 0x000C10F8 File Offset: 0x000BF2F8
		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		// Token: 0x06006524 RID: 25892 RVA: 0x000C1110 File Offset: 0x000BF310
		private void Resettime()
		{
			this.timeSpecified = false;
		}

		// Token: 0x06006525 RID: 25893 RVA: 0x000C111C File Offset: 0x000BF31C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001883 RID: 6275
		private uint? _type;

		// Token: 0x04001884 RID: 6276
		private uint? _sub_type;

		// Token: 0x04001885 RID: 6277
		private uint? _time;

		// Token: 0x04001886 RID: 6278
		private IExtension extensionObject;
	}
}
