using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FCE RID: 4046
	internal class EquipLoadTask
	{
		// Token: 0x0600D22E RID: 53806 RVA: 0x003101CB File Offset: 0x0030E3CB
		public EquipLoadTask(EPartType p)
		{
			this.part = p;
			this.fpi.Reset();
		}

		// Token: 0x0600D22F RID: 53807 RVA: 0x00310204 File Offset: 0x0030E404
		public bool IsSamePart(ref FashionPositionInfo newFpi)
		{
			return this.fpi.Equals(newFpi) && this.processStatus >= EProcessStatus.EPreProcess;
		}

		// Token: 0x0600D230 RID: 53808 RVA: 0x00310244 File Offset: 0x0030E444
		public bool MakePath(ref FashionPositionInfo newFpi, HashSet<string> loadedPath)
		{
			this.fpi = newFpi;
			bool flag = this.fpi.presentID > 0U;
			if (flag)
			{
				this.location = "Prefabs/" + XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(this.fpi.presentID).Prefab;
				this.processStatus = EProcessStatus.EProcessing;
			}
			else
			{
				bool flag2 = !string.IsNullOrEmpty(this.fpi.fashionName);
				if (flag2)
				{
					bool flag3 = this.fpi.fashionName.StartsWith("/");
					if (flag3)
					{
						this.location = "Equipments" + this.fpi.fashionName;
					}
					else
					{
						this.location = "Equipments/" + this.fpi.fashionName;
					}
					this.processStatus = EProcessStatus.EProcessing;
				}
			}
			bool flag4 = loadedPath != null;
			bool result;
			if (flag4)
			{
				bool flag5 = !string.IsNullOrEmpty(this.location) && !loadedPath.Contains(this.location);
				if (flag5)
				{
					loadedPath.Add(this.location);
					result = true;
				}
				else
				{
					this.processStatus = EProcessStatus.EProcessed;
					result = false;
				}
			}
			else
			{
				result = !string.IsNullOrEmpty(this.location);
			}
			return result;
		}

		// Token: 0x0600D231 RID: 53809 RVA: 0x00310384 File Offset: 0x0030E584
		public virtual void Load(XEntity e, int prefessionID, ref FashionPositionInfo newFpi, bool async, HashSet<string> loadedPath)
		{
			bool flag = loadedPath != null;
			if (flag)
			{
				bool flag2 = !string.IsNullOrEmpty(this.location) && !loadedPath.Contains(this.location);
				if (flag2)
				{
					loadedPath.Add(this.location);
				}
				else
				{
					this.processStatus = EProcessStatus.EProcessed;
				}
			}
		}

		// Token: 0x0600D232 RID: 53810 RVA: 0x003103DC File Offset: 0x0030E5DC
		public virtual void Reset(XEntity e)
		{
			this.processStatus = EProcessStatus.ENotProcess;
			this.location = "";
		}

		// Token: 0x04005F6D RID: 24429
		public EPartType part = EPartType.ENum;

		// Token: 0x04005F6E RID: 24430
		public FashionPositionInfo fpi;

		// Token: 0x04005F6F RID: 24431
		public EProcessStatus processStatus = EProcessStatus.ENotProcess;

		// Token: 0x04005F70 RID: 24432
		protected string location = "";
	}
}
