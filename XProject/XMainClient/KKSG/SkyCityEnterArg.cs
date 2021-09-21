using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000240 RID: 576
	[ProtoContract(Name = "SkyCityEnterArg")]
	[Serializable]
	public class SkyCityEnterArg : IExtensible
	{
		// Token: 0x170009FD RID: 2557
		// (get) Token: 0x06002006 RID: 8198 RVA: 0x0003EC28 File Offset: 0x0003CE28
		// (set) Token: 0x06002007 RID: 8199 RVA: 0x0003EC54 File Offset: 0x0003CE54
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

		// Token: 0x170009FE RID: 2558
		// (get) Token: 0x06002008 RID: 8200 RVA: 0x0003EC64 File Offset: 0x0003CE64
		// (set) Token: 0x06002009 RID: 8201 RVA: 0x0003EC84 File Offset: 0x0003CE84
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

		// Token: 0x0600200A RID: 8202 RVA: 0x0003ECC8 File Offset: 0x0003CEC8
		private bool ShouldSerializesceneid()
		{
			return this.sceneidSpecified;
		}

		// Token: 0x0600200B RID: 8203 RVA: 0x0003ECE0 File Offset: 0x0003CEE0
		private void Resetsceneid()
		{
			this.sceneidSpecified = false;
		}

		// Token: 0x0600200C RID: 8204 RVA: 0x0003ECEC File Offset: 0x0003CEEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040007FF RID: 2047
		private uint? _sceneid;

		// Token: 0x04000800 RID: 2048
		private IExtension extensionObject;
	}
}
