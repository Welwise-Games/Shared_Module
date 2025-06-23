using Cysharp.Threading.Tasks;
using WelwiseSharedModule.Runtime.Shared.Scripts;

namespace WelwiseSharedModule.Runtime.Client.Scripts
{
    public class HeroAudioClipsProviderService
    {
        private readonly Container _container = new Container();

        private const string HeroAudioClipsConfigAssetId = "HeroAudioClipsConfig";

        public async UniTask<HeroAudioClipsConfig> GetHeroAudioClipsConfigAsync() =>
            await _container.GetOrLoadAndRegisterObjectAsync<HeroAudioClipsConfig>(HeroAudioClipsConfigAssetId);
    }
}