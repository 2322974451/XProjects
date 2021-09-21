using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000715 RID: 1813
	[ProtoContract(Name = "GuildCampChatInfo")]
	[Serializable]
	public class GuildCampChatInfo : IExtensible
	{
		// Token: 0x1700270C RID: 9996
		// (get) Token: 0x06007B35 RID: 31541 RVA: 0x000EB7FC File Offset: 0x000E99FC
		// (set) Token: 0x06007B36 RID: 31542 RVA: 0x000EB829 File Offset: 0x000E9A29
		[ProtoMember(1, IsRequired = false, Name = "audio_id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700270D RID: 9997
		// (get) Token: 0x06007B37 RID: 31543 RVA: 0x000EB838 File Offset: 0x000E9A38
		// (set) Token: 0x06007B38 RID: 31544 RVA: 0x000EB858 File Offset: 0x000E9A58
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

		// Token: 0x06007B39 RID: 31545 RVA: 0x000EB89C File Offset: 0x000E9A9C
		private bool ShouldSerializeaudio_id()
		{
			return this.audio_idSpecified;
		}

		// Token: 0x06007B3A RID: 31546 RVA: 0x000EB8B4 File Offset: 0x000E9AB4
		private void Resetaudio_id()
		{
			this.audio_idSpecified = false;
		}

		// Token: 0x1700270E RID: 9998
		// (get) Token: 0x06007B3B RID: 31547 RVA: 0x000EB8C0 File Offset: 0x000E9AC0
		// (set) Token: 0x06007B3C RID: 31548 RVA: 0x000EB8EC File Offset: 0x000E9AEC
		[ProtoMember(2, IsRequired = false, Name = "audio_time", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x1700270F RID: 9999
		// (get) Token: 0x06007B3D RID: 31549 RVA: 0x000EB8FC File Offset: 0x000E9AFC
		// (set) Token: 0x06007B3E RID: 31550 RVA: 0x000EB91C File Offset: 0x000E9B1C
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

		// Token: 0x06007B3F RID: 31551 RVA: 0x000EB960 File Offset: 0x000E9B60
		private bool ShouldSerializeaudio_time()
		{
			return this.audio_timeSpecified;
		}

		// Token: 0x06007B40 RID: 31552 RVA: 0x000EB978 File Offset: 0x000E9B78
		private void Resetaudio_time()
		{
			this.audio_timeSpecified = false;
		}

		// Token: 0x17002710 RID: 10000
		// (get) Token: 0x06007B41 RID: 31553 RVA: 0x000EB984 File Offset: 0x000E9B84
		// (set) Token: 0x06007B42 RID: 31554 RVA: 0x000EB9A5 File Offset: 0x000E9BA5
		[ProtoMember(3, IsRequired = false, Name = "chat_text", DataFormat = DataFormat.Default)]
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

		// Token: 0x17002711 RID: 10001
		// (get) Token: 0x06007B43 RID: 31555 RVA: 0x000EB9B0 File Offset: 0x000E9BB0
		// (set) Token: 0x06007B44 RID: 31556 RVA: 0x000EB9CC File Offset: 0x000E9BCC
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

		// Token: 0x06007B45 RID: 31557 RVA: 0x000EB9FC File Offset: 0x000E9BFC
		private bool ShouldSerializechat_text()
		{
			return this.chat_textSpecified;
		}

		// Token: 0x06007B46 RID: 31558 RVA: 0x000EBA14 File Offset: 0x000E9C14
		private void Resetchat_text()
		{
			this.chat_textSpecified = false;
		}

		// Token: 0x06007B47 RID: 31559 RVA: 0x000EBA20 File Offset: 0x000E9C20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D15 RID: 7445
		private ulong? _audio_id;

		// Token: 0x04001D16 RID: 7446
		private uint? _audio_time;

		// Token: 0x04001D17 RID: 7447
		private string _chat_text;

		// Token: 0x04001D18 RID: 7448
		private IExtension extensionObject;
	}
}
