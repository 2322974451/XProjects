using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200063A RID: 1594
	[ProtoContract(Name = "DailyTaskInfo")]
	[Serializable]
	public class DailyTaskInfo : IExtensible
	{
		// Token: 0x17001EFF RID: 7935
		// (get) Token: 0x0600626B RID: 25195 RVA: 0x000BBCC8 File Offset: 0x000B9EC8
		// (set) Token: 0x0600626C RID: 25196 RVA: 0x000BBCF4 File Offset: 0x000B9EF4
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17001F00 RID: 7936
		// (get) Token: 0x0600626D RID: 25197 RVA: 0x000BBD04 File Offset: 0x000B9F04
		// (set) Token: 0x0600626E RID: 25198 RVA: 0x000BBD24 File Offset: 0x000B9F24
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x0600626F RID: 25199 RVA: 0x000BBD68 File Offset: 0x000B9F68
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06006270 RID: 25200 RVA: 0x000BBD80 File Offset: 0x000B9F80
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17001F01 RID: 7937
		// (get) Token: 0x06006271 RID: 25201 RVA: 0x000BBD8C File Offset: 0x000B9F8C
		// (set) Token: 0x06006272 RID: 25202 RVA: 0x000BBDB8 File Offset: 0x000B9FB8
		[ProtoMember(2, IsRequired = false, Name = "step", DataFormat = DataFormat.TwosComplement)]
		public uint step
		{
			get
			{
				return this._step ?? 0U;
			}
			set
			{
				this._step = new uint?(value);
			}
		}

		// Token: 0x17001F02 RID: 7938
		// (get) Token: 0x06006273 RID: 25203 RVA: 0x000BBDC8 File Offset: 0x000B9FC8
		// (set) Token: 0x06006274 RID: 25204 RVA: 0x000BBDE8 File Offset: 0x000B9FE8
		[XmlIgnore]
		[Browsable(false)]
		public bool stepSpecified
		{
			get
			{
				return this._step != null;
			}
			set
			{
				bool flag = value == (this._step == null);
				if (flag)
				{
					this._step = (value ? new uint?(this.step) : null);
				}
			}
		}

		// Token: 0x06006275 RID: 25205 RVA: 0x000BBE2C File Offset: 0x000BA02C
		private bool ShouldSerializestep()
		{
			return this.stepSpecified;
		}

		// Token: 0x06006276 RID: 25206 RVA: 0x000BBE44 File Offset: 0x000BA044
		private void Resetstep()
		{
			this.stepSpecified = false;
		}

		// Token: 0x17001F03 RID: 7939
		// (get) Token: 0x06006277 RID: 25207 RVA: 0x000BBE50 File Offset: 0x000BA050
		// (set) Token: 0x06006278 RID: 25208 RVA: 0x000BBE7C File Offset: 0x000BA07C
		[ProtoMember(3, IsRequired = false, Name = "is_rewarded", DataFormat = DataFormat.Default)]
		public bool is_rewarded
		{
			get
			{
				return this._is_rewarded ?? false;
			}
			set
			{
				this._is_rewarded = new bool?(value);
			}
		}

		// Token: 0x17001F04 RID: 7940
		// (get) Token: 0x06006279 RID: 25209 RVA: 0x000BBE8C File Offset: 0x000BA08C
		// (set) Token: 0x0600627A RID: 25210 RVA: 0x000BBEAC File Offset: 0x000BA0AC
		[XmlIgnore]
		[Browsable(false)]
		public bool is_rewardedSpecified
		{
			get
			{
				return this._is_rewarded != null;
			}
			set
			{
				bool flag = value == (this._is_rewarded == null);
				if (flag)
				{
					this._is_rewarded = (value ? new bool?(this.is_rewarded) : null);
				}
			}
		}

		// Token: 0x0600627B RID: 25211 RVA: 0x000BBEF0 File Offset: 0x000BA0F0
		private bool ShouldSerializeis_rewarded()
		{
			return this.is_rewardedSpecified;
		}

		// Token: 0x0600627C RID: 25212 RVA: 0x000BBF08 File Offset: 0x000BA108
		private void Resetis_rewarded()
		{
			this.is_rewardedSpecified = false;
		}

		// Token: 0x17001F05 RID: 7941
		// (get) Token: 0x0600627D RID: 25213 RVA: 0x000BBF14 File Offset: 0x000BA114
		// (set) Token: 0x0600627E RID: 25214 RVA: 0x000BBF40 File Offset: 0x000BA140
		[ProtoMember(4, IsRequired = false, Name = "ask_help", DataFormat = DataFormat.Default)]
		public bool ask_help
		{
			get
			{
				return this._ask_help ?? false;
			}
			set
			{
				this._ask_help = new bool?(value);
			}
		}

		// Token: 0x17001F06 RID: 7942
		// (get) Token: 0x0600627F RID: 25215 RVA: 0x000BBF50 File Offset: 0x000BA150
		// (set) Token: 0x06006280 RID: 25216 RVA: 0x000BBF70 File Offset: 0x000BA170
		[XmlIgnore]
		[Browsable(false)]
		public bool ask_helpSpecified
		{
			get
			{
				return this._ask_help != null;
			}
			set
			{
				bool flag = value == (this._ask_help == null);
				if (flag)
				{
					this._ask_help = (value ? new bool?(this.ask_help) : null);
				}
			}
		}

		// Token: 0x06006281 RID: 25217 RVA: 0x000BBFB4 File Offset: 0x000BA1B4
		private bool ShouldSerializeask_help()
		{
			return this.ask_helpSpecified;
		}

		// Token: 0x06006282 RID: 25218 RVA: 0x000BBFCC File Offset: 0x000BA1CC
		private void Resetask_help()
		{
			this.ask_helpSpecified = false;
		}

		// Token: 0x06006283 RID: 25219 RVA: 0x000BBFD8 File Offset: 0x000BA1D8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017DE RID: 6110
		private uint? _id;

		// Token: 0x040017DF RID: 6111
		private uint? _step;

		// Token: 0x040017E0 RID: 6112
		private bool? _is_rewarded;

		// Token: 0x040017E1 RID: 6113
		private bool? _ask_help;

		// Token: 0x040017E2 RID: 6114
		private IExtension extensionObject;
	}
}
