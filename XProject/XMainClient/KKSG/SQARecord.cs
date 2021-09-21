using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000617 RID: 1559
	[ProtoContract(Name = "SQARecord")]
	[Serializable]
	public class SQARecord : IExtensible
	{
		// Token: 0x17001DB6 RID: 7606
		// (get) Token: 0x06005EAC RID: 24236 RVA: 0x000B4858 File Offset: 0x000B2A58
		// (set) Token: 0x06005EAD RID: 24237 RVA: 0x000B4884 File Offset: 0x000B2A84
		[ProtoMember(1, IsRequired = false, Name = "cur_qa_type", DataFormat = DataFormat.TwosComplement)]
		public uint cur_qa_type
		{
			get
			{
				return this._cur_qa_type ?? 0U;
			}
			set
			{
				this._cur_qa_type = new uint?(value);
			}
		}

		// Token: 0x17001DB7 RID: 7607
		// (get) Token: 0x06005EAE RID: 24238 RVA: 0x000B4894 File Offset: 0x000B2A94
		// (set) Token: 0x06005EAF RID: 24239 RVA: 0x000B48B4 File Offset: 0x000B2AB4
		[XmlIgnore]
		[Browsable(false)]
		public bool cur_qa_typeSpecified
		{
			get
			{
				return this._cur_qa_type != null;
			}
			set
			{
				bool flag = value == (this._cur_qa_type == null);
				if (flag)
				{
					this._cur_qa_type = (value ? new uint?(this.cur_qa_type) : null);
				}
			}
		}

		// Token: 0x06005EB0 RID: 24240 RVA: 0x000B48F8 File Offset: 0x000B2AF8
		private bool ShouldSerializecur_qa_type()
		{
			return this.cur_qa_typeSpecified;
		}

		// Token: 0x06005EB1 RID: 24241 RVA: 0x000B4910 File Offset: 0x000B2B10
		private void Resetcur_qa_type()
		{
			this.cur_qa_typeSpecified = false;
		}

		// Token: 0x17001DB8 RID: 7608
		// (get) Token: 0x06005EB2 RID: 24242 RVA: 0x000B491C File Offset: 0x000B2B1C
		[ProtoMember(2, Name = "trigger_time", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> trigger_time
		{
			get
			{
				return this._trigger_time;
			}
		}

		// Token: 0x17001DB9 RID: 7609
		// (get) Token: 0x06005EB3 RID: 24243 RVA: 0x000B4934 File Offset: 0x000B2B34
		[ProtoMember(3, Name = "used_count", DataFormat = DataFormat.Default)]
		public List<MapKeyValue> used_count
		{
			get
			{
				return this._used_count;
			}
		}

		// Token: 0x17001DBA RID: 7610
		// (get) Token: 0x06005EB4 RID: 24244 RVA: 0x000B494C File Offset: 0x000B2B4C
		// (set) Token: 0x06005EB5 RID: 24245 RVA: 0x000B4978 File Offset: 0x000B2B78
		[ProtoMember(4, IsRequired = false, Name = "last_reset_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_reset_time
		{
			get
			{
				return this._last_reset_time ?? 0U;
			}
			set
			{
				this._last_reset_time = new uint?(value);
			}
		}

		// Token: 0x17001DBB RID: 7611
		// (get) Token: 0x06005EB6 RID: 24246 RVA: 0x000B4988 File Offset: 0x000B2B88
		// (set) Token: 0x06005EB7 RID: 24247 RVA: 0x000B49A8 File Offset: 0x000B2BA8
		[XmlIgnore]
		[Browsable(false)]
		public bool last_reset_timeSpecified
		{
			get
			{
				return this._last_reset_time != null;
			}
			set
			{
				bool flag = value == (this._last_reset_time == null);
				if (flag)
				{
					this._last_reset_time = (value ? new uint?(this.last_reset_time) : null);
				}
			}
		}

		// Token: 0x06005EB8 RID: 24248 RVA: 0x000B49EC File Offset: 0x000B2BEC
		private bool ShouldSerializelast_reset_time()
		{
			return this.last_reset_timeSpecified;
		}

		// Token: 0x06005EB9 RID: 24249 RVA: 0x000B4A04 File Offset: 0x000B2C04
		private void Resetlast_reset_time()
		{
			this.last_reset_timeSpecified = false;
		}

		// Token: 0x17001DBC RID: 7612
		// (get) Token: 0x06005EBA RID: 24250 RVA: 0x000B4A10 File Offset: 0x000B2C10
		// (set) Token: 0x06005EBB RID: 24251 RVA: 0x000B4A3C File Offset: 0x000B2C3C
		[ProtoMember(5, IsRequired = false, Name = "last_end_time", DataFormat = DataFormat.TwosComplement)]
		public uint last_end_time
		{
			get
			{
				return this._last_end_time ?? 0U;
			}
			set
			{
				this._last_end_time = new uint?(value);
			}
		}

		// Token: 0x17001DBD RID: 7613
		// (get) Token: 0x06005EBC RID: 24252 RVA: 0x000B4A4C File Offset: 0x000B2C4C
		// (set) Token: 0x06005EBD RID: 24253 RVA: 0x000B4A6C File Offset: 0x000B2C6C
		[XmlIgnore]
		[Browsable(false)]
		public bool last_end_timeSpecified
		{
			get
			{
				return this._last_end_time != null;
			}
			set
			{
				bool flag = value == (this._last_end_time == null);
				if (flag)
				{
					this._last_end_time = (value ? new uint?(this.last_end_time) : null);
				}
			}
		}

		// Token: 0x06005EBE RID: 24254 RVA: 0x000B4AB0 File Offset: 0x000B2CB0
		private bool ShouldSerializelast_end_time()
		{
			return this.last_end_timeSpecified;
		}

		// Token: 0x06005EBF RID: 24255 RVA: 0x000B4AC8 File Offset: 0x000B2CC8
		private void Resetlast_end_time()
		{
			this.last_end_timeSpecified = false;
		}

		// Token: 0x06005EC0 RID: 24256 RVA: 0x000B4AD4 File Offset: 0x000B2CD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016FA RID: 5882
		private uint? _cur_qa_type;

		// Token: 0x040016FB RID: 5883
		private readonly List<MapKeyValue> _trigger_time = new List<MapKeyValue>();

		// Token: 0x040016FC RID: 5884
		private readonly List<MapKeyValue> _used_count = new List<MapKeyValue>();

		// Token: 0x040016FD RID: 5885
		private uint? _last_reset_time;

		// Token: 0x040016FE RID: 5886
		private uint? _last_end_time;

		// Token: 0x040016FF RID: 5887
		private IExtension extensionObject;
	}
}
