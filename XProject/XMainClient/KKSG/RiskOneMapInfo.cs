using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000634 RID: 1588
	[ProtoContract(Name = "RiskOneMapInfo")]
	[Serializable]
	public class RiskOneMapInfo : IExtensible
	{
		// Token: 0x17001EB7 RID: 7863
		// (get) Token: 0x06006194 RID: 24980 RVA: 0x000BA254 File Offset: 0x000B8454
		[ProtoMember(1, Name = "grids", DataFormat = DataFormat.Default)]
		public List<RiskGridInfo> grids
		{
			get
			{
				return this._grids;
			}
		}

		// Token: 0x17001EB8 RID: 7864
		// (get) Token: 0x06006195 RID: 24981 RVA: 0x000BA26C File Offset: 0x000B846C
		// (set) Token: 0x06006196 RID: 24982 RVA: 0x000BA298 File Offset: 0x000B8498
		[ProtoMember(2, IsRequired = false, Name = "curX", DataFormat = DataFormat.TwosComplement)]
		public int curX
		{
			get
			{
				return this._curX ?? 0;
			}
			set
			{
				this._curX = new int?(value);
			}
		}

		// Token: 0x17001EB9 RID: 7865
		// (get) Token: 0x06006197 RID: 24983 RVA: 0x000BA2A8 File Offset: 0x000B84A8
		// (set) Token: 0x06006198 RID: 24984 RVA: 0x000BA2C8 File Offset: 0x000B84C8
		[XmlIgnore]
		[Browsable(false)]
		public bool curXSpecified
		{
			get
			{
				return this._curX != null;
			}
			set
			{
				bool flag = value == (this._curX == null);
				if (flag)
				{
					this._curX = (value ? new int?(this.curX) : null);
				}
			}
		}

		// Token: 0x06006199 RID: 24985 RVA: 0x000BA30C File Offset: 0x000B850C
		private bool ShouldSerializecurX()
		{
			return this.curXSpecified;
		}

		// Token: 0x0600619A RID: 24986 RVA: 0x000BA324 File Offset: 0x000B8524
		private void ResetcurX()
		{
			this.curXSpecified = false;
		}

		// Token: 0x17001EBA RID: 7866
		// (get) Token: 0x0600619B RID: 24987 RVA: 0x000BA330 File Offset: 0x000B8530
		// (set) Token: 0x0600619C RID: 24988 RVA: 0x000BA35C File Offset: 0x000B855C
		[ProtoMember(3, IsRequired = false, Name = "curY", DataFormat = DataFormat.TwosComplement)]
		public int curY
		{
			get
			{
				return this._curY ?? 0;
			}
			set
			{
				this._curY = new int?(value);
			}
		}

		// Token: 0x17001EBB RID: 7867
		// (get) Token: 0x0600619D RID: 24989 RVA: 0x000BA36C File Offset: 0x000B856C
		// (set) Token: 0x0600619E RID: 24990 RVA: 0x000BA38C File Offset: 0x000B858C
		[XmlIgnore]
		[Browsable(false)]
		public bool curYSpecified
		{
			get
			{
				return this._curY != null;
			}
			set
			{
				bool flag = value == (this._curY == null);
				if (flag)
				{
					this._curY = (value ? new int?(this.curY) : null);
				}
			}
		}

		// Token: 0x0600619F RID: 24991 RVA: 0x000BA3D0 File Offset: 0x000B85D0
		private bool ShouldSerializecurY()
		{
			return this.curYSpecified;
		}

		// Token: 0x060061A0 RID: 24992 RVA: 0x000BA3E8 File Offset: 0x000B85E8
		private void ResetcurY()
		{
			this.curYSpecified = false;
		}

		// Token: 0x17001EBC RID: 7868
		// (get) Token: 0x060061A1 RID: 24993 RVA: 0x000BA3F4 File Offset: 0x000B85F4
		[ProtoMember(4, Name = "boxInfos", DataFormat = DataFormat.Default)]
		public List<RiskBoxInfo> boxInfos
		{
			get
			{
				return this._boxInfos;
			}
		}

		// Token: 0x17001EBD RID: 7869
		// (get) Token: 0x060061A2 RID: 24994 RVA: 0x000BA40C File Offset: 0x000B860C
		// (set) Token: 0x060061A3 RID: 24995 RVA: 0x000BA438 File Offset: 0x000B8638
		[ProtoMember(5, IsRequired = false, Name = "mapid", DataFormat = DataFormat.TwosComplement)]
		public int mapid
		{
			get
			{
				return this._mapid ?? 0;
			}
			set
			{
				this._mapid = new int?(value);
			}
		}

		// Token: 0x17001EBE RID: 7870
		// (get) Token: 0x060061A4 RID: 24996 RVA: 0x000BA448 File Offset: 0x000B8648
		// (set) Token: 0x060061A5 RID: 24997 RVA: 0x000BA468 File Offset: 0x000B8668
		[XmlIgnore]
		[Browsable(false)]
		public bool mapidSpecified
		{
			get
			{
				return this._mapid != null;
			}
			set
			{
				bool flag = value == (this._mapid == null);
				if (flag)
				{
					this._mapid = (value ? new int?(this.mapid) : null);
				}
			}
		}

		// Token: 0x060061A6 RID: 24998 RVA: 0x000BA4AC File Offset: 0x000B86AC
		private bool ShouldSerializemapid()
		{
			return this.mapidSpecified;
		}

		// Token: 0x060061A7 RID: 24999 RVA: 0x000BA4C4 File Offset: 0x000B86C4
		private void Resetmapid()
		{
			this.mapidSpecified = false;
		}

		// Token: 0x17001EBF RID: 7871
		// (get) Token: 0x060061A8 RID: 25000 RVA: 0x000BA4D0 File Offset: 0x000B86D0
		// (set) Token: 0x060061A9 RID: 25001 RVA: 0x000BA4FC File Offset: 0x000B86FC
		[ProtoMember(6, IsRequired = false, Name = "moveDirection", DataFormat = DataFormat.TwosComplement)]
		public int moveDirection
		{
			get
			{
				return this._moveDirection ?? 0;
			}
			set
			{
				this._moveDirection = new int?(value);
			}
		}

		// Token: 0x17001EC0 RID: 7872
		// (get) Token: 0x060061AA RID: 25002 RVA: 0x000BA50C File Offset: 0x000B870C
		// (set) Token: 0x060061AB RID: 25003 RVA: 0x000BA52C File Offset: 0x000B872C
		[XmlIgnore]
		[Browsable(false)]
		public bool moveDirectionSpecified
		{
			get
			{
				return this._moveDirection != null;
			}
			set
			{
				bool flag = value == (this._moveDirection == null);
				if (flag)
				{
					this._moveDirection = (value ? new int?(this.moveDirection) : null);
				}
			}
		}

		// Token: 0x060061AC RID: 25004 RVA: 0x000BA570 File Offset: 0x000B8770
		private bool ShouldSerializemoveDirection()
		{
			return this.moveDirectionSpecified;
		}

		// Token: 0x060061AD RID: 25005 RVA: 0x000BA588 File Offset: 0x000B8788
		private void ResetmoveDirection()
		{
			this.moveDirectionSpecified = false;
		}

		// Token: 0x060061AE RID: 25006 RVA: 0x000BA594 File Offset: 0x000B8794
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017B0 RID: 6064
		private readonly List<RiskGridInfo> _grids = new List<RiskGridInfo>();

		// Token: 0x040017B1 RID: 6065
		private int? _curX;

		// Token: 0x040017B2 RID: 6066
		private int? _curY;

		// Token: 0x040017B3 RID: 6067
		private readonly List<RiskBoxInfo> _boxInfos = new List<RiskBoxInfo>();

		// Token: 0x040017B4 RID: 6068
		private int? _mapid;

		// Token: 0x040017B5 RID: 6069
		private int? _moveDirection;

		// Token: 0x040017B6 RID: 6070
		private IExtension extensionObject;
	}
}
