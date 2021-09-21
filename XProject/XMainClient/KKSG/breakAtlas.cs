using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001FD RID: 509
	[ProtoContract(Name = "breakAtlas")]
	[Serializable]
	public class breakAtlas : IExtensible
	{
		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x06001CE1 RID: 7393 RVA: 0x00038DF0 File Offset: 0x00036FF0
		// (set) Token: 0x06001CE2 RID: 7394 RVA: 0x00038E1C File Offset: 0x0003701C
		[ProtoMember(1, IsRequired = false, Name = "atlaId", DataFormat = DataFormat.TwosComplement)]
		public uint atlaId
		{
			get
			{
				return this._atlaId ?? 0U;
			}
			set
			{
				this._atlaId = new uint?(value);
			}
		}

		// Token: 0x1700090A RID: 2314
		// (get) Token: 0x06001CE3 RID: 7395 RVA: 0x00038E2C File Offset: 0x0003702C
		// (set) Token: 0x06001CE4 RID: 7396 RVA: 0x00038E4C File Offset: 0x0003704C
		[XmlIgnore]
		[Browsable(false)]
		public bool atlaIdSpecified
		{
			get
			{
				return this._atlaId != null;
			}
			set
			{
				bool flag = value == (this._atlaId == null);
				if (flag)
				{
					this._atlaId = (value ? new uint?(this.atlaId) : null);
				}
			}
		}

		// Token: 0x06001CE5 RID: 7397 RVA: 0x00038E90 File Offset: 0x00037090
		private bool ShouldSerializeatlaId()
		{
			return this.atlaIdSpecified;
		}

		// Token: 0x06001CE6 RID: 7398 RVA: 0x00038EA8 File Offset: 0x000370A8
		private void ResetatlaId()
		{
			this.atlaIdSpecified = false;
		}

		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x06001CE7 RID: 7399 RVA: 0x00038EB4 File Offset: 0x000370B4
		// (set) Token: 0x06001CE8 RID: 7400 RVA: 0x00038EE0 File Offset: 0x000370E0
		[ProtoMember(2, IsRequired = false, Name = "atlaNum", DataFormat = DataFormat.TwosComplement)]
		public uint atlaNum
		{
			get
			{
				return this._atlaNum ?? 0U;
			}
			set
			{
				this._atlaNum = new uint?(value);
			}
		}

		// Token: 0x1700090C RID: 2316
		// (get) Token: 0x06001CE9 RID: 7401 RVA: 0x00038EF0 File Offset: 0x000370F0
		// (set) Token: 0x06001CEA RID: 7402 RVA: 0x00038F10 File Offset: 0x00037110
		[XmlIgnore]
		[Browsable(false)]
		public bool atlaNumSpecified
		{
			get
			{
				return this._atlaNum != null;
			}
			set
			{
				bool flag = value == (this._atlaNum == null);
				if (flag)
				{
					this._atlaNum = (value ? new uint?(this.atlaNum) : null);
				}
			}
		}

		// Token: 0x06001CEB RID: 7403 RVA: 0x00038F54 File Offset: 0x00037154
		private bool ShouldSerializeatlaNum()
		{
			return this.atlaNumSpecified;
		}

		// Token: 0x06001CEC RID: 7404 RVA: 0x00038F6C File Offset: 0x0003716C
		private void ResetatlaNum()
		{
			this.atlaNumSpecified = false;
		}

		// Token: 0x06001CED RID: 7405 RVA: 0x00038F78 File Offset: 0x00037178
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000731 RID: 1841
		private uint? _atlaId;

		// Token: 0x04000732 RID: 1842
		private uint? _atlaNum;

		// Token: 0x04000733 RID: 1843
		private IExtension extensionObject;
	}
}
