using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006FA RID: 1786
	[ProtoContract(Name = "LBEleTeamInfo")]
	[Serializable]
	public class LBEleTeamInfo : IExtensible
	{
		// Token: 0x17002620 RID: 9760
		// (get) Token: 0x0600785F RID: 30815 RVA: 0x000E640C File Offset: 0x000E460C
		// (set) Token: 0x06007860 RID: 30816 RVA: 0x000E6439 File Offset: 0x000E4639
		[ProtoMember(1, IsRequired = false, Name = "leagueid", DataFormat = DataFormat.TwosComplement)]
		public ulong leagueid
		{
			get
			{
				return this._leagueid ?? 0UL;
			}
			set
			{
				this._leagueid = new ulong?(value);
			}
		}

		// Token: 0x17002621 RID: 9761
		// (get) Token: 0x06007861 RID: 30817 RVA: 0x000E6448 File Offset: 0x000E4648
		// (set) Token: 0x06007862 RID: 30818 RVA: 0x000E6468 File Offset: 0x000E4668
		[XmlIgnore]
		[Browsable(false)]
		public bool leagueidSpecified
		{
			get
			{
				return this._leagueid != null;
			}
			set
			{
				bool flag = value == (this._leagueid == null);
				if (flag)
				{
					this._leagueid = (value ? new ulong?(this.leagueid) : null);
				}
			}
		}

		// Token: 0x06007863 RID: 30819 RVA: 0x000E64AC File Offset: 0x000E46AC
		private bool ShouldSerializeleagueid()
		{
			return this.leagueidSpecified;
		}

		// Token: 0x06007864 RID: 30820 RVA: 0x000E64C4 File Offset: 0x000E46C4
		private void Resetleagueid()
		{
			this.leagueidSpecified = false;
		}

		// Token: 0x17002622 RID: 9762
		// (get) Token: 0x06007865 RID: 30821 RVA: 0x000E64D0 File Offset: 0x000E46D0
		// (set) Token: 0x06007866 RID: 30822 RVA: 0x000E64F1 File Offset: 0x000E46F1
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

		// Token: 0x17002623 RID: 9763
		// (get) Token: 0x06007867 RID: 30823 RVA: 0x000E64FC File Offset: 0x000E46FC
		// (set) Token: 0x06007868 RID: 30824 RVA: 0x000E6518 File Offset: 0x000E4718
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

		// Token: 0x06007869 RID: 30825 RVA: 0x000E6548 File Offset: 0x000E4748
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x0600786A RID: 30826 RVA: 0x000E6560 File Offset: 0x000E4760
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17002624 RID: 9764
		// (get) Token: 0x0600786B RID: 30827 RVA: 0x000E656C File Offset: 0x000E476C
		// (set) Token: 0x0600786C RID: 30828 RVA: 0x000E6598 File Offset: 0x000E4798
		[ProtoMember(3, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x17002625 RID: 9765
		// (get) Token: 0x0600786D RID: 30829 RVA: 0x000E65A8 File Offset: 0x000E47A8
		// (set) Token: 0x0600786E RID: 30830 RVA: 0x000E65C8 File Offset: 0x000E47C8
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x0600786F RID: 30831 RVA: 0x000E660C File Offset: 0x000E480C
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06007870 RID: 30832 RVA: 0x000E6624 File Offset: 0x000E4824
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x17002626 RID: 9766
		// (get) Token: 0x06007871 RID: 30833 RVA: 0x000E6630 File Offset: 0x000E4830
		// (set) Token: 0x06007872 RID: 30834 RVA: 0x000E6651 File Offset: 0x000E4851
		[ProtoMember(4, IsRequired = false, Name = "servername", DataFormat = DataFormat.Default)]
		public string servername
		{
			get
			{
				return this._servername ?? "";
			}
			set
			{
				this._servername = value;
			}
		}

		// Token: 0x17002627 RID: 9767
		// (get) Token: 0x06007873 RID: 30835 RVA: 0x000E665C File Offset: 0x000E485C
		// (set) Token: 0x06007874 RID: 30836 RVA: 0x000E6678 File Offset: 0x000E4878
		[XmlIgnore]
		[Browsable(false)]
		public bool servernameSpecified
		{
			get
			{
				return this._servername != null;
			}
			set
			{
				bool flag = value == (this._servername == null);
				if (flag)
				{
					this._servername = (value ? this.servername : null);
				}
			}
		}

		// Token: 0x06007875 RID: 30837 RVA: 0x000E66A8 File Offset: 0x000E48A8
		private bool ShouldSerializeservername()
		{
			return this.servernameSpecified;
		}

		// Token: 0x06007876 RID: 30838 RVA: 0x000E66C0 File Offset: 0x000E48C0
		private void Resetservername()
		{
			this.servernameSpecified = false;
		}

		// Token: 0x17002628 RID: 9768
		// (get) Token: 0x06007877 RID: 30839 RVA: 0x000E66CC File Offset: 0x000E48CC
		// (set) Token: 0x06007878 RID: 30840 RVA: 0x000E66ED File Offset: 0x000E48ED
		[ProtoMember(5, IsRequired = false, Name = "zonename", DataFormat = DataFormat.Default)]
		public string zonename
		{
			get
			{
				return this._zonename ?? "";
			}
			set
			{
				this._zonename = value;
			}
		}

		// Token: 0x17002629 RID: 9769
		// (get) Token: 0x06007879 RID: 30841 RVA: 0x000E66F8 File Offset: 0x000E48F8
		// (set) Token: 0x0600787A RID: 30842 RVA: 0x000E6714 File Offset: 0x000E4914
		[XmlIgnore]
		[Browsable(false)]
		public bool zonenameSpecified
		{
			get
			{
				return this._zonename != null;
			}
			set
			{
				bool flag = value == (this._zonename == null);
				if (flag)
				{
					this._zonename = (value ? this.zonename : null);
				}
			}
		}

		// Token: 0x0600787B RID: 30843 RVA: 0x000E6744 File Offset: 0x000E4944
		private bool ShouldSerializezonename()
		{
			return this.zonenameSpecified;
		}

		// Token: 0x0600787C RID: 30844 RVA: 0x000E675C File Offset: 0x000E495C
		private void Resetzonename()
		{
			this.zonenameSpecified = false;
		}

		// Token: 0x0600787D RID: 30845 RVA: 0x000E6768 File Offset: 0x000E4968
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C77 RID: 7287
		private ulong? _leagueid;

		// Token: 0x04001C78 RID: 7288
		private string _name;

		// Token: 0x04001C79 RID: 7289
		private uint? _serverid;

		// Token: 0x04001C7A RID: 7290
		private string _servername;

		// Token: 0x04001C7B RID: 7291
		private string _zonename;

		// Token: 0x04001C7C RID: 7292
		private IExtension extensionObject;
	}
}
