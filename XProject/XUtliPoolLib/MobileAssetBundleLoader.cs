using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200004B RID: 75
	public class MobileAssetBundleLoader : AssetBundleLoader
	{
		// Token: 0x0600025C RID: 604 RVA: 0x0001312C File Offset: 0x0001132C
		public override void Load()
		{
			bool hasError = this._hasError;
			if (hasError)
			{
				this.state = LoadState.State_Error;
			}
			bool flag = this.state == LoadState.State_None;
			if (flag)
			{
				this.state = LoadState.State_LoadingAsync;
				this.LoadDepends();
			}
			else
			{
				bool flag2 = this.state == LoadState.State_Error;
				if (flag2)
				{
					this.Error();
				}
				else
				{
					bool flag3 = this.state == LoadState.State_Complete;
					if (flag3)
					{
						this.Complete();
					}
				}
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x00013198 File Offset: 0x00011398
		public override void LoadImm()
		{
			bool hasError = this._hasError;
			if (hasError)
			{
				this.state = LoadState.State_Error;
			}
			bool flag = this.state == LoadState.State_None || this.state == LoadState.State_LoadingAsync;
			if (flag)
			{
				this.state = LoadState.State_Loading;
				this.LoadDependsImm();
			}
			else
			{
				bool flag2 = this.state == LoadState.State_Error;
				if (flag2)
				{
					this.Error();
				}
				else
				{
					bool flag3 = this.state == LoadState.State_Complete;
					if (flag3)
					{
						this.Complete();
					}
				}
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00013210 File Offset: 0x00011410
		private void LoadDepends()
		{
			bool flag = this.depLoaders == null && this.bundleData.dependencies != null && this.bundleData.dependencies.Length != 0;
			if (flag)
			{
				this.depLoaders = new AssetBundleLoader[this.bundleData.dependencies.Length];
				for (int i = 0; i < this.bundleData.dependencies.Length; i++)
				{
					this.depLoaders[i] = this.bundleManager.CreateLoader(this.bundleData.dependencies[i], null, null, null);
				}
			}
			this._currentLoadingDepCount = 0;
			bool flag2 = this.depLoaders != null;
			if (flag2)
			{
				for (int j = 0; j < this.depLoaders.Length; j++)
				{
					AssetBundleLoader assetBundleLoader = this.depLoaders[j];
					bool flag3 = !assetBundleLoader.isComplete;
					if (flag3)
					{
						this._currentLoadingDepCount++;
						AssetBundleLoader assetBundleLoader2 = assetBundleLoader;
						assetBundleLoader2.onComplete = (AssetBundleManager.LoadAssetCompleteHandler)Delegate.Combine(assetBundleLoader2.onComplete, new AssetBundleManager.LoadAssetCompleteHandler(this.OnDepComplete));
						assetBundleLoader.Load();
					}
				}
			}
			this.CheckDepComplete();
		}

		// Token: 0x0600025F RID: 607 RVA: 0x00013338 File Offset: 0x00011538
		private void LoadDependsImm()
		{
			bool flag = this.depLoaders == null && this.bundleData.dependencies != null && this.bundleData.dependencies.Length != 0;
			if (flag)
			{
				this.depLoaders = new AssetBundleLoader[this.bundleData.dependencies.Length];
				for (int i = 0; i < this.bundleData.dependencies.Length; i++)
				{
					this.depLoaders[i] = this.bundleManager.CreateLoader(this.bundleData.dependencies[i], null, null, null);
				}
			}
			this._currentLoadingDepCount = 1;
			bool flag2 = this.depLoaders != null;
			if (flag2)
			{
				for (int j = 0; j < this.depLoaders.Length; j++)
				{
					AssetBundleLoader assetBundleLoader = this.depLoaders[j];
					bool flag3 = assetBundleLoader.state != LoadState.State_Error && assetBundleLoader.state != LoadState.State_Complete;
					if (flag3)
					{
						this._currentLoadingDepCount++;
						AssetBundleLoader assetBundleLoader2 = assetBundleLoader;
						assetBundleLoader2.onComplete = (AssetBundleManager.LoadAssetCompleteHandler)Delegate.Combine(assetBundleLoader2.onComplete, new AssetBundleManager.LoadAssetCompleteHandler(this.OnDepCompleteImm));
						assetBundleLoader.LoadImm();
					}
				}
			}
			this._currentLoadingDepCount--;
			this.CheckDepCompleteImm();
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00013480 File Offset: 0x00011680
		public override void LoadBundle()
		{
			string text = this.bundleName.ToString() + ".ab";
			this._assetBundleCachedFile = Path.Combine(this.bundleManager.pathResolver.BundleCacheDir, text);
			this._assetBundleSourceFile = this.bundleManager.pathResolver.GetBundleSourceFile(text, false);
			bool flag = File.Exists(this._assetBundleCachedFile);
			if (flag)
			{
				this.bundleManager.StartCoroutine(this.LoadFromCachedFile());
			}
			else
			{
				this.bundleManager.StartCoroutine(this.LoadFromPackage());
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00013510 File Offset: 0x00011710
		public override void LoadBundleImm()
		{
			string text = this.bundleName.ToString() + ".ab";
			this._assetBundleCachedFile = Path.Combine(this.bundleManager.pathResolver.BundleCacheDir, text);
			this._assetBundleSourceFile = this.bundleManager.pathResolver.GetBundleSourceFile(text, false);
			bool flag = File.Exists(this._assetBundleCachedFile);
			if (flag)
			{
				this.LoadFromCachedFileImm();
			}
			else
			{
				this.LoadFromPackageImm();
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00013587 File Offset: 0x00011787
		protected virtual IEnumerator LoadFromCachedFile()
		{
			bool flag = this.state == LoadState.State_Complete;
			if (flag)
			{
				this.Complete();
			}
			else
			{
				bool flag2 = this.state != LoadState.State_Error;
				if (flag2)
				{
					AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync(this._assetBundleCachedFile);
					while (!req.isDone)
					{
						yield return null;
					}
					bool flag3 = this._bundle == null;
					if (flag3)
					{
						this._bundle = req.assetBundle;
					}
					bool flag4 = this.state != LoadState.State_Complete && base.UnloadNotLoadingBundle(this._bundle);
					if (flag4)
					{
						req = AssetBundle.LoadFromFileAsync(this._assetBundleCachedFile);
						while (!req.isDone)
						{
							yield return null;
						}
						bool flag5 = this._bundle == null;
						if (flag5)
						{
							this._bundle = req.assetBundle;
						}
					}
					this.Complete();
					req = null;
				}
			}
			yield break;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x00013598 File Offset: 0x00011798
		protected virtual void LoadFromCachedFileImm()
		{
			bool flag = this.state == LoadState.State_Complete;
			if (flag)
			{
				this.Complete();
			}
			else
			{
				bool flag2 = this.state != LoadState.State_Error;
				if (flag2)
				{
					bool flag3 = this._bundle == null;
					if (flag3)
					{
						this._bundle = AssetBundle.LoadFromFile(this._assetBundleCachedFile);
					}
					bool flag4 = this.state != LoadState.State_Complete && base.UnloadNotLoadingBundle(this._bundle);
					if (flag4)
					{
						bool flag5 = this._bundle == null;
						if (flag5)
						{
							this._bundle = AssetBundle.LoadFromFile(this._assetBundleCachedFile);
						}
					}
					this.Complete();
				}
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00013639 File Offset: 0x00011839
		protected virtual IEnumerator LoadFromPackage()
		{
			bool flag = this.state == LoadState.State_Complete;
			if (flag)
			{
				this.Complete();
			}
			else
			{
				bool flag2 = this.state != LoadState.State_Error;
				if (flag2)
				{
					AssetBundleCreateRequest req = AssetBundle.LoadFromFileAsync(this._assetBundleSourceFile);
					while (!req.isDone)
					{
						yield return null;
					}
					bool flag3 = this._bundle == null;
					if (flag3)
					{
						this._bundle = req.assetBundle;
					}
					bool flag4 = this.state != LoadState.State_Complete && base.UnloadNotLoadingBundle(this._bundle);
					if (flag4)
					{
						req = AssetBundle.LoadFromFileAsync(this._assetBundleSourceFile);
						while (!req.isDone)
						{
							yield return null;
						}
						bool flag5 = this._bundle == null;
						if (flag5)
						{
							this._bundle = req.assetBundle;
						}
					}
					this.Complete();
					req = null;
				}
			}
			yield break;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00013648 File Offset: 0x00011848
		protected virtual void LoadFromPackageImm()
		{
			bool flag = this.state == LoadState.State_Complete;
			if (flag)
			{
				this.Complete();
			}
			else
			{
				bool flag2 = this.state != LoadState.State_Error;
				if (flag2)
				{
					bool flag3 = this._bundle == null;
					if (flag3)
					{
						this._bundle = AssetBundle.LoadFromFile(this._assetBundleSourceFile);
					}
					bool flag4 = this.state != LoadState.State_Complete && base.UnloadNotLoadingBundle(this._bundle);
					if (flag4)
					{
						bool flag5 = this._bundle == null;
						if (flag5)
						{
							this._bundle = AssetBundle.LoadFromFile(this._assetBundleSourceFile);
						}
					}
					this.Complete();
				}
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000136E9 File Offset: 0x000118E9
		private void OnDepComplete(AssetBundleInfo abi, int handlerID)
		{
			this._currentLoadingDepCount--;
			this.CheckDepComplete();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00013701 File Offset: 0x00011901
		private void OnDepCompleteImm(AssetBundleInfo abi, int handlerID)
		{
			this._currentLoadingDepCount--;
			this.CheckDepCompleteImm();
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0001371C File Offset: 0x0001191C
		private void CheckDepComplete()
		{
			bool flag = this._currentLoadingDepCount == 0;
			if (flag)
			{
				this.bundleManager.RequestLoadBundle(this);
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00013748 File Offset: 0x00011948
		private void CheckDepCompleteImm()
		{
			bool flag = this._currentLoadingDepCount == 0;
			if (flag)
			{
				this.bundleManager.RequestLoadBundleImm(this);
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00013774 File Offset: 0x00011974
		protected override void Complete()
		{
			bool flag = this.bundleInfo == null && this.state != LoadState.State_Complete;
			if (flag)
			{
				this.state = LoadState.State_Complete;
				this.bundleInfo = this.bundleManager.CreateBundleInfo(this, null, this._bundle);
				this.bundleInfo.isReady = true;
				this.bundleInfo.onUnloaded = new AssetBundleInfo.OnUnloadedHandler(this.OnBundleUnload);
				bool flag2 = this.depLoaders != null;
				if (flag2)
				{
					for (int i = 0; i < this.depLoaders.Length; i++)
					{
						AssetBundleLoader assetBundleLoader = this.depLoaders[i];
						this.bundleInfo.AddDependency(assetBundleLoader.bundleInfo);
					}
				}
				this._bundle = null;
			}
			base.Complete();
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00013839 File Offset: 0x00011A39
		private void OnBundleUnload(AssetBundleInfo abi)
		{
			this.bundleInfo = null;
			this.state = LoadState.State_None;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0001384A File Offset: 0x00011A4A
		protected override void Error()
		{
			this._hasError = true;
			this.state = LoadState.State_Error;
			this.bundleInfo = null;
			base.Error();
		}

		// Token: 0x0400022E RID: 558
		protected int _currentLoadingDepCount;

		// Token: 0x0400022F RID: 559
		protected AssetBundle _bundle;

		// Token: 0x04000230 RID: 560
		protected bool _hasError;

		// Token: 0x04000231 RID: 561
		protected string _assetBundleCachedFile;

		// Token: 0x04000232 RID: 562
		protected string _assetBundleSourceFile;
	}
}
