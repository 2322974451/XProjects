using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000687 RID: 1671
	[ProtoContract(Name = "AudioBrief")]
	[Serializable]
	public class AudioBrief : IExtensible
	{
		// Token: 0x1700220C RID: 8716
		// (get) Token: 0x06006B91 RID: 27537 RVA: 0x000CDC84 File Offset: 0x000CBE84
		// (set) Token: 0x06006B92 RID: 27538 RVA: 0x000CDCB1 File Offset: 0x000CBEB1
		[ProtoMember(1, IsRequired = false, Name = "audioUid", DataFormat = DataFormat.TwosComplement)]
		public ulong audioUid
		{
			get
			{
				return this._audioUid ?? 0UL;
			}
			set
			{
				this._audioUid = new ulong?(value);
			}
		}

		// Token: 0x1700220D RID: 8717
		// (get) Token: 0x06006B93 RID: 27539 RVA: 0x000CDCC0 File Offset: 0x000CBEC0
		// (set) Token: 0x06006B94 RID: 27540 RVA: 0x000CDCE0 File Offset: 0x000CBEE0
		[XmlIgnore]
		[Browsable(false)]
		public bool audioUidSpecified
		{
			get
			{
				return this._audioUid != null;
			}
			set
			{
				bool flag = value == (this._audioUid == null);
				if (flag)
				{
					this._audioUid = (value ? new ulong?(this.audioUid) : null);
				}
			}
		}

		// Token: 0x06006B95 RID: 27541 RVA: 0x000CDD24 File Offset: 0x000CBF24
		private bool ShouldSerializeaudioUid()
		{
			return this.audioUidSpecified;
		}

		// Token: 0x06006B96 RID: 27542 RVA: 0x000CDD3C File Offset: 0x000CBF3C
		private void ResetaudioUid()
		{
			this.audioUidSpecified = false;
		}

		// Token: 0x1700220E RID: 8718
		// (get) Token: 0x06006B97 RID: 27543 RVA: 0x000CDD48 File Offset: 0x000CBF48
		// (set) Token: 0x06006B98 RID: 27544 RVA: 0x000CDD65 File Offset: 0x000CBF65
		[ProtoMember(2, IsRequired = false, Name = "audio", DataFormat = DataFormat.Default)]
		public byte[] audio
		{
			get
			{
				return this._audio ?? null;
			}
			set
			{
				this._audio = value;
			}
		}

		// Token: 0x1700220F RID: 8719
		// (get) Token: 0x06006B99 RID: 27545 RVA: 0x000CDD70 File Offset: 0x000CBF70
		// (set) Token: 0x06006B9A RID: 27546 RVA: 0x000CDD8C File Offset: 0x000CBF8C
		[XmlIgnore]
		[Browsable(false)]
		public bool audioSpecified
		{
			get
			{
				return this._audio != null;
			}
			set
			{
				bool flag = value == (this._audio == null);
				if (flag)
				{
					this._audio = (value ? this.audio : null);
				}
			}
		}

		// Token: 0x06006B9B RID: 27547 RVA: 0x000CDDBC File Offset: 0x000CBFBC
		private bool ShouldSerializeaudio()
		{
			return this.audioSpecified;
		}

		// Token: 0x06006B9C RID: 27548 RVA: 0x000CDDD4 File Offset: 0x000CBFD4
		private void Resetaudio()
		{
			this.audioSpecified = false;
		}

		// Token: 0x17002210 RID: 8720
		// (get) Token: 0x06006B9D RID: 27549 RVA: 0x000CDDE0 File Offset: 0x000CBFE0
		// (set) Token: 0x06006B9E RID: 27550 RVA: 0x000CDDFD File Offset: 0x000CBFFD
		[ProtoMember(3, IsRequired = false, Name = "text", DataFormat = DataFormat.Default)]
		public byte[] text
		{
			get
			{
				return this._text ?? null;
			}
			set
			{
				this._text = value;
			}
		}

		// Token: 0x17002211 RID: 8721
		// (get) Token: 0x06006B9F RID: 27551 RVA: 0x000CDE08 File Offset: 0x000CC008
		// (set) Token: 0x06006BA0 RID: 27552 RVA: 0x000CDE24 File Offset: 0x000CC024
		[XmlIgnore]
		[Browsable(false)]
		public bool textSpecified
		{
			get
			{
				return this._text != null;
			}
			set
			{
				bool flag = value == (this._text == null);
				if (flag)
				{
					this._text = (value ? this.text : null);
				}
			}
		}

		// Token: 0x06006BA1 RID: 27553 RVA: 0x000CDE54 File Offset: 0x000CC054
		private bool ShouldSerializetext()
		{
			return this.textSpecified;
		}

		// Token: 0x06006BA2 RID: 27554 RVA: 0x000CDE6C File Offset: 0x000CC06C
		private void Resettext()
		{
			this.textSpecified = false;
		}

		// Token: 0x06006BA3 RID: 27555 RVA: 0x000CDE78 File Offset: 0x000CC078
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019DE RID: 6622
		private ulong? _audioUid;

		// Token: 0x040019DF RID: 6623
		private byte[] _audio;

		// Token: 0x040019E0 RID: 6624
		private byte[] _text;

		// Token: 0x040019E1 RID: 6625
		private IExtension extensionObject;
	}
}
