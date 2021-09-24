using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace XUtliPoolLib
{

	public class MobileAssetBundleLoader : AssetBundleLoader
	{

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

		private void OnDepComplete(AssetBundleInfo abi, int handlerID)
		{
			this._currentLoadingDepCount--;
			this.CheckDepComplete();
		}

		private void OnDepCompleteImm(AssetBundleInfo abi, int handlerID)
		{
			this._currentLoadingDepCount--;
			this.CheckDepCompleteImm();
		}

		private void CheckDepComplete()
		{
			bool flag = this._currentLoadingDepCount == 0;
			if (flag)
			{
				this.bundleManager.RequestLoadBundle(this);
			}
		}

		private void CheckDepCompleteImm()
		{
			bool flag = this._currentLoadingDepCount == 0;
			if (flag)
			{
				this.bundleManager.RequestLoadBundleImm(this);
			}
		}

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

		private void OnBundleUnload(AssetBundleInfo abi)
		{
			this.bundleInfo = null;
			this.state = LoadState.State_None;
		}

		protected override void Error()
		{
			this._hasError = true;
			this.state = LoadState.State_Error;
			this.bundleInfo = null;
			base.Error();
		}

		protected int _currentLoadingDepCount;

		protected AssetBundle _bundle;

		protected bool _hasError;

		protected string _assetBundleCachedFile;

		protected string _assetBundleSourceFile;
	}
}
