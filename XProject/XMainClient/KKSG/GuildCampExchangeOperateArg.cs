using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003F5 RID: 1013
	[ProtoContract(Name = "GuildCampExchangeOperateArg")]
	[Serializable]
	public class GuildCampExchangeOperateArg : IExtensible
	{
		// Token: 0x1700107F RID: 4223
		// (get) Token: 0x060035A6 RID: 13734 RVA: 0x00066CB0 File Offset: 0x00064EB0
		// (set) Token: 0x060035A7 RID: 13735 RVA: 0x00066CDC File Offset: 0x00064EDC
		[ProtoMember(1, IsRequired = false, Name = "operate_type", DataFormat = DataFormat.TwosComplement)]
		public GuildCampItemOperate operate_type
		{
			get
			{
				return this._operate_type ?? GuildCampItemOperate.SWINGUPITEM;
			}
			set
			{
				this._operate_type = new GuildCampItemOperate?(value);
			}
		}

		// Token: 0x17001080 RID: 4224
		// (get) Token: 0x060035A8 RID: 13736 RVA: 0x00066CEC File Offset: 0x00064EEC
		// (set) Token: 0x060035A9 RID: 13737 RVA: 0x00066D0C File Offset: 0x00064F0C
		[XmlIgnore]
		[Browsable(false)]
		public bool operate_typeSpecified
		{
			get
			{
				return this._operate_type != null;
			}
			set
			{
				bool flag = value == (this._operate_type == null);
				if (flag)
				{
					this._operate_type = (value ? new GuildCampItemOperate?(this.operate_type) : null);
				}
			}
		}

		// Token: 0x060035AA RID: 13738 RVA: 0x00066D50 File Offset: 0x00064F50
		private bool ShouldSerializeoperate_type()
		{
			return this.operate_typeSpecified;
		}

		// Token: 0x060035AB RID: 13739 RVA: 0x00066D68 File Offset: 0x00064F68
		private void Resetoperate_type()
		{
			this.operate_typeSpecified = false;
		}

		// Token: 0x17001081 RID: 4225
		// (get) Token: 0x060035AC RID: 13740 RVA: 0x00066D74 File Offset: 0x00064F74
		// (set) Token: 0x060035AD RID: 13741 RVA: 0x00066DA1 File Offset: 0x00064FA1
		[ProtoMember(2, IsRequired = false, Name = "item_uid", DataFormat = DataFormat.TwosComplement)]
		public ulong item_uid
		{
			get
			{
				return this._item_uid ?? 0UL;
			}
			set
			{
				this._item_uid = new ulong?(value);
			}
		}

		// Token: 0x17001082 RID: 4226
		// (get) Token: 0x060035AE RID: 13742 RVA: 0x00066DB0 File Offset: 0x00064FB0
		// (set) Token: 0x060035AF RID: 13743 RVA: 0x00066DD0 File Offset: 0x00064FD0
		[XmlIgnore]
		[Browsable(false)]
		public bool item_uidSpecified
		{
			get
			{
				return this._item_uid != null;
			}
			set
			{
				bool flag = value == (this._item_uid == null);
				if (flag)
				{
					this._item_uid = (value ? new ulong?(this.item_uid) : null);
				}
			}
		}

		// Token: 0x060035B0 RID: 13744 RVA: 0x00066E14 File Offset: 0x00065014
		private bool ShouldSerializeitem_uid()
		{
			return this.item_uidSpecified;
		}

		// Token: 0x060035B1 RID: 13745 RVA: 0x00066E2C File Offset: 0x0006502C
		private void Resetitem_uid()
		{
			this.item_uidSpecified = false;
		}

		// Token: 0x17001083 RID: 4227
		// (get) Token: 0x060035B2 RID: 13746 RVA: 0x00066E38 File Offset: 0x00065038
		// (set) Token: 0x060035B3 RID: 13747 RVA: 0x00066E64 File Offset: 0x00065064
		[ProtoMember(3, IsRequired = false, Name = "confirm", DataFormat = DataFormat.Default)]
		public bool confirm
		{
			get
			{
				return this._confirm ?? false;
			}
			set
			{
				this._confirm = new bool?(value);
			}
		}

		// Token: 0x17001084 RID: 4228
		// (get) Token: 0x060035B4 RID: 13748 RVA: 0x00066E74 File Offset: 0x00065074
		// (set) Token: 0x060035B5 RID: 13749 RVA: 0x00066E94 File Offset: 0x00065094
		[XmlIgnore]
		[Browsable(false)]
		public bool confirmSpecified
		{
			get
			{
				return this._confirm != null;
			}
			set
			{
				bool flag = value == (this._confirm == null);
				if (flag)
				{
					this._confirm = (value ? new bool?(this.confirm) : null);
				}
			}
		}

		// Token: 0x060035B6 RID: 13750 RVA: 0x00066ED8 File Offset: 0x000650D8
		private bool ShouldSerializeconfirm()
		{
			return this.confirmSpecified;
		}

		// Token: 0x060035B7 RID: 13751 RVA: 0x00066EF0 File Offset: 0x000650F0
		private void Resetconfirm()
		{
			this.confirmSpecified = false;
		}

		// Token: 0x17001085 RID: 4229
		// (get) Token: 0x060035B8 RID: 13752 RVA: 0x00066EFC File Offset: 0x000650FC
		// (set) Token: 0x060035B9 RID: 13753 RVA: 0x00066F29 File Offset: 0x00065129
		[ProtoMember(4, IsRequired = false, Name = "audio_id", DataFormat = DataFormat.TwosComplement)]
		public ulong audio_id
		{
			get
			{
				return this._audio_id ?? 0UL;
			}
			set
			{
				this._audio_id = new ulong?(value);
			}
		}

		// Token: 0x17001086 RID: 4230
		// (get) Token: 0x060035BA RID: 13754 RVA: 0x00066F38 File Offset: 0x00065138
		// (set) Token: 0x060035BB RID: 13755 RVA: 0x00066F58 File Offset: 0x00065158
		[XmlIgnore]
		[Browsable(false)]
		public bool audio_idSpecified
		{
			get
			{
				return this._audio_id != null;
			}
			set
			{
				bool flag = value == (this._audio_id == null);
				if (flag)
				{
					this._audio_id = (value ? new ulong?(this.audio_id) : null);
				}
			}
		}

		// Token: 0x060035BC RID: 13756 RVA: 0x00066F9C File Offset: 0x0006519C
		private bool ShouldSerializeaudio_id()
		{
			return this.audio_idSpecified;
		}

		// Token: 0x060035BD RID: 13757 RVA: 0x00066FB4 File Offset: 0x000651B4
		private void Resetaudio_id()
		{
			this.audio_idSpecified = false;
		}

		// Token: 0x17001087 RID: 4231
		// (get) Token: 0x060035BE RID: 13758 RVA: 0x00066FC0 File Offset: 0x000651C0
		// (set) Token: 0x060035BF RID: 13759 RVA: 0x00066FEC File Offset: 0x000651EC
		[ProtoMember(5, IsRequired = false, Name = "audio_time", DataFormat = DataFormat.TwosComplement)]
		public uint audio_time
		{
			get
			{
				return this._audio_time ?? 0U;
			}
			set
			{
				this._audio_time = new uint?(value);
			}
		}

		// Token: 0x17001088 RID: 4232
		// (get) Token: 0x060035C0 RID: 13760 RVA: 0x00066FFC File Offset: 0x000651FC
		// (set) Token: 0x060035C1 RID: 13761 RVA: 0x0006701C File Offset: 0x0006521C
		[XmlIgnore]
		[Browsable(false)]
		public bool audio_timeSpecified
		{
			get
			{
				return this._audio_time != null;
			}
			set
			{
				bool flag = value == (this._audio_time == null);
				if (flag)
				{
					this._audio_time = (value ? new uint?(this.audio_time) : null);
				}
			}
		}

		// Token: 0x060035C2 RID: 13762 RVA: 0x00067060 File Offset: 0x00065260
		private bool ShouldSerializeaudio_time()
		{
			return this.audio_timeSpecified;
		}

		// Token: 0x060035C3 RID: 13763 RVA: 0x00067078 File Offset: 0x00065278
		private void Resetaudio_time()
		{
			this.audio_timeSpecified = false;
		}

		// Token: 0x17001089 RID: 4233
		// (get) Token: 0x060035C4 RID: 13764 RVA: 0x00067084 File Offset: 0x00065284
		// (set) Token: 0x060035C5 RID: 13765 RVA: 0x000670A5 File Offset: 0x000652A5
		[ProtoMember(6, IsRequired = false, Name = "chat_text", DataFormat = DataFormat.Default)]
		public string chat_text
		{
			get
			{
				return this._chat_text ?? "";
			}
			set
			{
				this._chat_text = value;
			}
		}

		// Token: 0x1700108A RID: 4234
		// (get) Token: 0x060035C6 RID: 13766 RVA: 0x000670B0 File Offset: 0x000652B0
		// (set) Token: 0x060035C7 RID: 13767 RVA: 0x000670CC File Offset: 0x000652CC
		[XmlIgnore]
		[Browsable(false)]
		public bool chat_textSpecified
		{
			get
			{
				return this._chat_text != null;
			}
			set
			{
				bool flag = value == (this._chat_text == null);
				if (flag)
				{
					this._chat_text = (value ? this.chat_text : null);
				}
			}
		}

		// Token: 0x060035C8 RID: 13768 RVA: 0x000670FC File Offset: 0x000652FC
		private bool ShouldSerializechat_text()
		{
			return this.chat_textSpecified;
		}

		// Token: 0x060035C9 RID: 13769 RVA: 0x00067114 File Offset: 0x00065314
		private void Resetchat_text()
		{
			this.chat_textSpecified = false;
		}

		// Token: 0x060035CA RID: 13770 RVA: 0x00067120 File Offset: 0x00065320
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D56 RID: 3414
		private GuildCampItemOperate? _operate_type;

		// Token: 0x04000D57 RID: 3415
		private ulong? _item_uid;

		// Token: 0x04000D58 RID: 3416
		private bool? _confirm;

		// Token: 0x04000D59 RID: 3417
		private ulong? _audio_id;

		// Token: 0x04000D5A RID: 3418
		private uint? _audio_time;

		// Token: 0x04000D5B RID: 3419
		private string _chat_text;

		// Token: 0x04000D5C RID: 3420
		private IExtension extensionObject;
	}
}
