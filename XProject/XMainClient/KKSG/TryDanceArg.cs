using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000535 RID: 1333
	[ProtoContract(Name = "TryDanceArg")]
	[Serializable]
	public class TryDanceArg : IExtensible
	{
		// Token: 0x170014ED RID: 5357
		// (get) Token: 0x0600446C RID: 17516 RVA: 0x00082280 File Offset: 0x00080480
		// (set) Token: 0x0600446D RID: 17517 RVA: 0x000822AC File Offset: 0x000804AC
		[ProtoMember(1, IsRequired = false, Name = "danceid", DataFormat = DataFormat.TwosComplement)]
		public uint danceid
		{
			get
			{
				return this._danceid ?? 0U;
			}
			set
			{
				this._danceid = new uint?(value);
			}
		}

		// Token: 0x170014EE RID: 5358
		// (get) Token: 0x0600446E RID: 17518 RVA: 0x000822BC File Offset: 0x000804BC
		// (set) Token: 0x0600446F RID: 17519 RVA: 0x000822DC File Offset: 0x000804DC
		[XmlIgnore]
		[Browsable(false)]
		public bool danceidSpecified
		{
			get
			{
				return this._danceid != null;
			}
			set
			{
				bool flag = value == (this._danceid == null);
				if (flag)
				{
					this._danceid = (value ? new uint?(this.danceid) : null);
				}
			}
		}

		// Token: 0x06004470 RID: 17520 RVA: 0x00082320 File Offset: 0x00080520
		private bool ShouldSerializedanceid()
		{
			return this.danceidSpecified;
		}

		// Token: 0x06004471 RID: 17521 RVA: 0x00082338 File Offset: 0x00080538
		private void Resetdanceid()
		{
			this.danceidSpecified = false;
		}

		// Token: 0x06004472 RID: 17522 RVA: 0x00082344 File Offset: 0x00080544
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001116 RID: 4374
		private uint? _danceid;

		// Token: 0x04001117 RID: 4375
		private IExtension extensionObject;
	}
}
