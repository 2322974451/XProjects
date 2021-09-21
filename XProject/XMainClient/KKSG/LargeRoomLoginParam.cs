using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002F0 RID: 752
	[ProtoContract(Name = "LargeRoomLoginParam")]
	[Serializable]
	public class LargeRoomLoginParam : IExtensible
	{
		// Token: 0x17000CD9 RID: 3289
		// (get) Token: 0x06002961 RID: 10593 RVA: 0x00050518 File Offset: 0x0004E718
		// (set) Token: 0x06002962 RID: 10594 RVA: 0x00050544 File Offset: 0x0004E744
		[ProtoMember(1, IsRequired = false, Name = "speaker", DataFormat = DataFormat.Default)]
		public bool speaker
		{
			get
			{
				return this._speaker ?? false;
			}
			set
			{
				this._speaker = new bool?(value);
			}
		}

		// Token: 0x17000CDA RID: 3290
		// (get) Token: 0x06002963 RID: 10595 RVA: 0x00050554 File Offset: 0x0004E754
		// (set) Token: 0x06002964 RID: 10596 RVA: 0x00050574 File Offset: 0x0004E774
		[XmlIgnore]
		[Browsable(false)]
		public bool speakerSpecified
		{
			get
			{
				return this._speaker != null;
			}
			set
			{
				bool flag = value == (this._speaker == null);
				if (flag)
				{
					this._speaker = (value ? new bool?(this.speaker) : null);
				}
			}
		}

		// Token: 0x06002965 RID: 10597 RVA: 0x000505B8 File Offset: 0x0004E7B8
		private bool ShouldSerializespeaker()
		{
			return this.speakerSpecified;
		}

		// Token: 0x06002966 RID: 10598 RVA: 0x000505D0 File Offset: 0x0004E7D0
		private void Resetspeaker()
		{
			this.speakerSpecified = false;
		}

		// Token: 0x06002967 RID: 10599 RVA: 0x000505DC File Offset: 0x0004E7DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000A48 RID: 2632
		private bool? _speaker;

		// Token: 0x04000A49 RID: 2633
		private IExtension extensionObject;
	}
}
