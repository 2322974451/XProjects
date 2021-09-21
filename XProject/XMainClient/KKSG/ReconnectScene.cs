using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000682 RID: 1666
	[ProtoContract(Name = "ReconnectScene")]
	[Serializable]
	public class ReconnectScene : IExtensible
	{
		// Token: 0x170021D7 RID: 8663
		// (get) Token: 0x06006AEA RID: 27370 RVA: 0x000CC7D0 File Offset: 0x000CA9D0
		// (set) Token: 0x06006AEB RID: 27371 RVA: 0x000CC7FC File Offset: 0x000CA9FC
		[ProtoMember(1, IsRequired = false, Name = "sceneid", DataFormat = DataFormat.TwosComplement)]
		public uint sceneid
		{
			get
			{
				return this._sceneid ?? 0U;
			}
			set
			{
				this._sceneid = new uint?(value);
			}
		}

		// Token: 0x170021D8 RID: 8664
		// (get) Token: 0x06006AEC RID: 27372 RVA: 0x000CC80C File Offset: 0x000CAA0C
		// (set) Token: 0x06006AED RID: 27373 RVA: 0x000CC82C File Offset: 0x000CAA2C
		[XmlIgnore]
		[Browsable(false)]
		public bool sceneidSpecified
		{
			get
			{
				return this._sceneid != null;
			}
			set
			{
				bool flag = value == (this._sceneid == null);
				if (flag)
				{
					this._sceneid = (value ? new uint?(this.sceneid) : null);
				}
			}
		}

		// Token: 0x06006AEE RID: 27374 RVA: 0x000CC870 File Offset: 0x000CAA70
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x06006AEF RID: 27375 RVA: 0x000CC888 File Offset: 0x000CAA88
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x170021D9 RID: 8665
		// (get) Token: 0x06006AF0 RID: 27376 RVA: 0x000CC894 File Offset: 0x000CAA94
		// (set) Token: 0x06006AF1 RID: 27377 RVA: 0x000CC8C0 File Offset: 0x000CAAC0
		[ProtoMember(2, IsRequired = false, Name = "isready", DataFormat = DataFormat.Default)]
		public bool isready
		{
			get
			{
				return this._isready ?? false;
			}
			set
			{
				this._isready = new bool?(value);
			}
		}

		// Token: 0x170021DA RID: 8666
		// (get) Token: 0x06006AF2 RID: 27378 RVA: 0x000CC8D0 File Offset: 0x000CAAD0
		// (set) Token: 0x06006AF3 RID: 27379 RVA: 0x000CC8F0 File Offset: 0x000CAAF0
		[XmlIgnore]
		[Browsable(false)]
		public bool isreadySpecified
		{
			get
			{
				return this._isready != null;
			}
			set
			{
				bool flag = value == (this._isready == null);
				if (flag)
				{
					this._isready = (value ? new bool?(this.isready) : null);
				}
			}
		}

		// Token: 0x06006AF4 RID: 27380 RVA: 0x000CC934 File Offset: 0x000CAB34
		private bool ShouldSerializeisready()
		{
			return this.isreadySpecified;
		}

		// Token: 0x06006AF5 RID: 27381 RVA: 0x000CC94C File Offset: 0x000CAB4C
		private void Resetisready()
		{
			this.isreadySpecified = false;
		}

		// Token: 0x06006AF6 RID: 27382 RVA: 0x000CC958 File Offset: 0x000CAB58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019BE RID: 6590
		private uint? _sceneid;

		// Token: 0x040019BF RID: 6591
		private bool? _isready;

		// Token: 0x040019C0 RID: 6592
		private IExtension extensionObject;
	}
}
