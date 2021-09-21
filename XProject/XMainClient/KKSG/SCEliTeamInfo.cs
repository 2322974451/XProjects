using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200070E RID: 1806
	[ProtoContract(Name = "SCEliTeamInfo")]
	[Serializable]
	public class SCEliTeamInfo : IExtensible
	{
		// Token: 0x170026E1 RID: 9953
		// (get) Token: 0x06007AAB RID: 31403 RVA: 0x000EA808 File Offset: 0x000E8A08
		// (set) Token: 0x06007AAC RID: 31404 RVA: 0x000EA835 File Offset: 0x000E8A35
		[ProtoMember(1, IsRequired = false, Name = "stid", DataFormat = DataFormat.TwosComplement)]
		public ulong stid
		{
			get
			{
				return this._stid ?? 0UL;
			}
			set
			{
				this._stid = new ulong?(value);
			}
		}

		// Token: 0x170026E2 RID: 9954
		// (get) Token: 0x06007AAD RID: 31405 RVA: 0x000EA844 File Offset: 0x000E8A44
		// (set) Token: 0x06007AAE RID: 31406 RVA: 0x000EA864 File Offset: 0x000E8A64
		[XmlIgnore]
		[Browsable(false)]
		public bool stidSpecified
		{
			get
			{
				return this._stid != null;
			}
			set
			{
				bool flag = value == (this._stid == null);
				if (flag)
				{
					this._stid = (value ? new ulong?(this.stid) : null);
				}
			}
		}

		// Token: 0x06007AAF RID: 31407 RVA: 0x000EA8A8 File Offset: 0x000E8AA8
		private bool ShouldSerializestid()
		{
			return this.stidSpecified;
		}

		// Token: 0x06007AB0 RID: 31408 RVA: 0x000EA8C0 File Offset: 0x000E8AC0
		private void Resetstid()
		{
			this.stidSpecified = false;
		}

		// Token: 0x170026E3 RID: 9955
		// (get) Token: 0x06007AB1 RID: 31409 RVA: 0x000EA8CC File Offset: 0x000E8ACC
		// (set) Token: 0x06007AB2 RID: 31410 RVA: 0x000EA8ED File Offset: 0x000E8AED
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x170026E4 RID: 9956
		// (get) Token: 0x06007AB3 RID: 31411 RVA: 0x000EA8F8 File Offset: 0x000E8AF8
		// (set) Token: 0x06007AB4 RID: 31412 RVA: 0x000EA914 File Offset: 0x000E8B14
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06007AB5 RID: 31413 RVA: 0x000EA944 File Offset: 0x000E8B44
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06007AB6 RID: 31414 RVA: 0x000EA95C File Offset: 0x000E8B5C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06007AB7 RID: 31415 RVA: 0x000EA968 File Offset: 0x000E8B68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001CF7 RID: 7415
		private ulong? _stid;

		// Token: 0x04001CF8 RID: 7416
		private string _name;

		// Token: 0x04001CF9 RID: 7417
		private IExtension extensionObject;
	}
}
