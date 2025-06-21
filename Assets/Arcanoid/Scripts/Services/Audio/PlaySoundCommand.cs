using strange.extensions.command.impl;

namespace Arcanoid.Scripts.Services.Audio
{
    public class PlaySoundCommand : Command
    {
        [Inject] public Sound SoundName { get; set; }
        [Inject] public IAudioService AudioService { get; set; }

        public override void Execute()
        {
            AudioService.PlaySound(SoundName);
        }
    }
}