using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200018F RID: 399
	[ProtoContract(Name = "NoticeGuildBossEnd")]
	[Serializable]
	public class NoticeGuildBossEnd : IExtensible
	{
		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x0600181D RID: 6173 RVA: 0x00030158 File Offset: 0x0002E358
		// (set) Token: 0x0600181E RID: 6174 RVA: 0x00030184 File Offset: 0x0002E384
		[ProtoMember(1, IsRequired = false, Name = "isWin", DataFormat = DataFormat.Default)]
		public bool isWin
		{
			get
			{
				return this._isWin ?? false;
			}
			set
			{
				this._isWin = new bool?(value);
			}
		}

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x0600181F RID: 6175 RVA: 0x00030194 File Offset: 0x0002E394
		// (set) Token: 0x06001820 RID: 6176 RVA: 0x000301B4 File Offset: 0x0002E3B4
		[XmlIgnore]
		[Browsable(false)]
		public bool isWinSpecified
		{
			get
			{
				return this._isWin != null;
			}
			set
			{
				bool flag = value == (this._isWin == null);
				if (flag)
				{
					this._isWin = (value ? new bool?(this.isWin) : null);
				}
			}
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x000301F8 File Offset: 0x0002E3F8
		private bool ShouldSerializeisWin()
		{
			return this.isWinSpecified;
		}

		// Token: 0x06001822 RID: 6178 RVA: 0x00030210 File Offset: 0x0002E410
		private void ResetisWin()
		{
			this.isWinSpecified = false;
		}

		// Token: 0x06001823 RID: 6179 RVA: 0x0003021C File Offset: 0x0002E41C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005F4 RID: 1524
		private bool? _isWin;

		// Token: 0x040005F5 RID: 1525
		private IExtension extensionObject;
	}
}
